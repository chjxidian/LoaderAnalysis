using LoaderAnalysis.DataBean;
using LoaderAnalysis.Utils;
using ProgressWnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoaderAnalysis
{
    public partial class Form_Dispose_Load_Line : Form
    {
        public Form_Main mParentForm;
        public static SynchronizationContext mSyncContext = null;
        public static ProgressWindow progress = null;

        public Form_Dispose_Load_Line()
        {
            InitializeComponent();
            mSyncContext = SynchronizationContext.Current;
            initDataGridView();
        }

        public Form_Dispose_Load_Line(Form_Main ParentForm)
        {
            mParentForm = ParentForm;
            InitializeComponent();
            //获取UI线程同步上下文
            mSyncContext = SynchronizationContext.Current;
            initDataGridView();
        }

        private void initDataGridView()
        {
            OleDbDataAdapter da = mParentForm.getMainInfoAdapter();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_all.DataSource = dt;
            dataGridView_all.Columns[0].HeaderText = "编号";
            dataGridView_all.Columns[0].Width = 60;
            dataGridView_all.Columns[1].HeaderText = "名称";
            dataGridView_all.Columns[1].Width = 100;
            dataGridView_all.Columns[2].HeaderText = "工况";
            dataGridView_all.Columns[2].Width = 95;
            dataGridView_all.Columns[3].HeaderText = "型号";
            dataGridView_all.Columns[3].Width = 100;
            dataGridView_all.Columns[4].HeaderText = "创建时间";
            dataGridView_all.Columns[4].Width = 100;
            dataGridView_all.Columns[5].HeaderText = "创建者";
            dataGridView_all.Columns[5].Width = 70;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int ID;
            try
            {
                if (dataGridView_all.RowCount <= 1) return;
                ID = Convert.ToInt32(this.dataGridView_all.SelectedCells[0].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
                MessageBox.Show("请先选择数据集！");
                return;
            }
            if (MessageBox.Show("是否确认删除该条记录？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                mParentForm.deleteFromDataBase(ID);
                initDataGridView();
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            int ID;
            try
            {
                if (dataGridView_all.RowCount <= 1) return;
                ID = Convert.ToInt32(this.dataGridView_all.SelectedCells[0].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
                MessageBox.Show("请先选择数据集！");
                return;
            }
            MainInfo mainInfo = mParentForm.getFromDataBase(ID);
            List<SubInfo> SubInfos = mainInfo.SubInfos;
            if (SubInfos == null || SubInfos.Count == 0)
            {
                MessageBox.Show("当前没有数据可导出！");
                return;
            }
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            if (excel == null)
            {
                MessageBox.Show("请检查本机是否安装了Excel！");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            string sFile = string.Empty;
            dialog.Title = "导出Excel文件";
            dialog.Filter = "Excel 文件(*.xlsx) |.xlsx";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = dialog.FileName;
                if (File.Exists(FileName)) File.Delete(FileName);

                List<Object> objects = new List<Object>();
                objects.Add(SubInfos);  // new List<SubInfo>() 这里需要查找出来的数据
                objects.Add(new OnExcelExportProgress());
                objects.Add(FileName);
                Task task = new Task(ExcelUtil.ExportDataToExcel, objects);
                task.Start();
            }
        }

        private class OnExcelExportProgress : ExcelUtil.IProgressCallback
        {
            private List<Object> listPara = new List<object>();
            private int mMin = 0;
            private int mMax = 0;

            public void OnStart(int minimum, int maximum)
            {
                mMin = minimum;
                mMax = maximum;
                listPara.Clear();
                listPara.Add(true);
                listPara.Add(mMin);
                listPara.Add(mMax);
                mSyncContext.Post(showExportProgressDialog, listPara);
            }

            public void OnProgress(int minimum, int current, int maximum)
            {
                listPara.Clear();
                listPara.Add(current);
                listPara.Add(mMin);
                listPara.Add(mMax);
                mSyncContext.Post(updateExportProgressDialog, listPara);
            }

            public void OnFinish(object o)
            {
                listPara.Clear();
                listPara.Add(false);
                listPara.Add(mMin);
                listPara.Add(mMax);
                mSyncContext.Post(showExportProgressDialog, listPara);
            }
        }

        private static void showExportProgressDialog(object o)
        {
            List<Object> list = o as List<Object>;
            if (list.Count != 3) return;
            if ("Int32".Equals(list[0].GetType().Name)) return;
            bool isShow = (bool)list[0];
            if (isShow)
            {
                progress = new ProgressWindow();
                progress.SetTitle("正在导出数据");
                progress.ShowDialog();
            }
            else
            {
                progress.End();
                progress.Dispose();
            }
        }

        private static void updateExportProgressDialog(object o)
        {
            List<Object> list = o as List<Object>;
            if (list.Count != 3) return;
            if ("Boolean".Equals(list[0].GetType().Name)) return;
            int cur = (int)list[0];
            int min = (int)list[1];
            int max = (int)list[2];
            if (cur > min && cur < max)
            {
                int i = (100 * cur) / (max - min);
                progress.SetText(String.Format("请耐心等待...\n\n已经完成： {0} ， 总数： {1}", cur, max));
                progress.StepTo(i);
            }
        }
    }
}
