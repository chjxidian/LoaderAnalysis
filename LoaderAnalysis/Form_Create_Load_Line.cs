using LoaderAnalysis.DataBean;
using LoaderAnalysis.Utils;
using ProgressWnd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoaderAnalysis
{
    public partial class Form_Create_Load_Line : Form
    {
        public Form_Main mParentForm;
        public static SynchronizationContext mSyncContext = null;
        public String mLoadName;
        public String mStituation;
        public String mLoad;
        public String mModel;
        public DateTime mTestTime;
        public String mCreaterName;
        private static List<SubInfo> mSubInfoList = null;
        private MainInfo mMainInfo = new MainInfo();

        public Form_Create_Load_Line()
        {
            InitializeComponent();
            //获取UI线程同步上下文
            mSyncContext = SynchronizationContext.Current;
        }

        public Form_Create_Load_Line(Form_Main ParentForm)
        {
            mParentForm = ParentForm;
            InitializeComponent();
            //获取UI线程同步上下文
            mSyncContext = SynchronizationContext.Current;
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            disableButtons();
            mLoadName = textBox_load_name.Text.ToString();
            mStituation = textBox_stituation.Text.ToString();
            mLoad = textBox_load.Text.ToString();
            mModel = textBox_model.Text.ToString();
            mCreaterName = textBox_creater.Text.ToString();
            if (String.IsNullOrEmpty(mLoadName) ||
                String.IsNullOrEmpty(mStituation) ||
                String.IsNullOrEmpty(mLoad) ||
                String.IsNullOrEmpty(mModel) ||
                String.IsNullOrEmpty(mTestTime.ToString()) ||
                String.IsNullOrEmpty(mCreaterName))
            {
                MessageBox.Show("参数不全！");
                enableButtons();
                return;
            }
            else
            {
                //
                mMainInfo.Model = mModel;
                mMainInfo.Name = mLoadName;
                mMainInfo.TestTime = mTestTime;
                mMainInfo.WorkingCondition = mStituation;
                mMainInfo.Creater = mCreaterName;
                //
                if (mSubInfoList != null)
                {
                    for (int i = 0; i < mSubInfoList.Count; i++)
                    {
                        mSubInfoList[i].MainID = 1;
                        mSubInfoList[i].ChannelNo = String.Format("{0}", i + 1);
                        mSubInfoList[i].TimeCounts = 0;
                    }
                }
                mMainInfo.SubInfos = mSubInfoList;
                //Insert into database...
                mParentForm.insertIntoDataBase(mMainInfo);
            }
            enableButtons();
        }

        private void button_read_excel_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog()
            {
                Title = "打开Excel文件",
                Filter = "Microsoft Office Excel 工作簿(*.xlsx;*.xls)|*.xlsx;*.xls",
                Multiselect = false
            };
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                //mSubInfoList = ExcelUtil.ImportDataFromExcel(null);
                List<Object> objects = new List<Object>();
                objects.Add(new OnExcelImportProgress());
                objects.Add(openDialog.FileName);
                Task task = new Task(ExcelUtil.ImportDataFromExcel, objects);
                task.Start();
            }
        }

        private class OnExcelImportProgress : ExcelUtil.IProgressCallback
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
                mSyncContext.Post(showImportProgressDialog, listPara);
            }

            public void OnProgress(int minimum, int current, int maximum)
            {
                listPara.Clear();
                listPara.Add(current);
                listPara.Add(mMin);
                listPara.Add(mMax);
                mSyncContext.Post(updateImportProgressDialog, listPara);
            }

            public void OnFinish(object o)
            {
                mSubInfoList = o as List<SubInfo>;
                listPara.Clear();
                listPara.Add(false);
                listPara.Add(mMin);
                listPara.Add(mMax);
                mSyncContext.Post(showImportProgressDialog, listPara);
            }
        }

        public static ProgressWindow progressWindow = null;

        private static void showImportProgressDialog(object o)
        {
            List<Object> list = o as List<Object>;
            if (list.Count != 3) return;
            if ("Int32".Equals(list[0].GetType().Name)) return;
            bool isShow = (bool)list[0];
            if (isShow)
            {
                progressWindow = new ProgressWindow();
                progressWindow.SetTitle("正在导入数据");
                progressWindow.ShowDialog();
            }
            else
            {
                progressWindow.End();
                progressWindow.Dispose();
            }
        }

        private static void updateImportProgressDialog(object o)
        {
            List<Object> list = o as List<Object>;
            if (list.Count != 3) return;
            String TypeName = list[0].GetType().Name;
            if ("Boolean".Equals(TypeName)) return;
            int cur = (int)list[0];
            int min = (int)list[1];
            int max = (int)list[2];
            if (cur > min && cur < max)
            {
                int i = (100 * cur) / (max - min);
                progressWindow.SetText(String.Format("请耐心等待...\n\n已经完成： {0} ， 总数： {1}", cur, max));
                progressWindow.StepTo(i);
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (mSubInfoList == null)
            {
                MessageBox.Show("当前没有数据可备份！");
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
                objects.Add(mSubInfoList);  // new List<SubInfo>() 这里需要查找出来的数据
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
                progressWindow = new ProgressWindow();
                progressWindow.SetTitle("正在导出数据");
                progressWindow.ShowDialog();
            }
            else
            {
                progressWindow.End();
                progressWindow.Dispose();
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
                progressWindow.SetText(String.Format("请耐心等待...\n\n已经完成： {0} ， 总数： {1}", cur, max));
                progressWindow.StepTo(i);
            }
        }

        private void disableButtons()
        {
            button_import.Enabled = false;
            button_export.Enabled = false;
        }

        private void enableButtons()
        {
            button_import.Enabled = true;
            button_export.Enabled = true;
        }

    }
}
