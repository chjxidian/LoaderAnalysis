using LoaderAnalysis.DataBean;
using LoaderAnalysis.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgressWnd;

namespace LoaderAnalysis
{
    public partial class Form_Add_Load_Line : Form
    {
        public Form_Main mParentForm;
        private List<TableUnit> mTableUnits = new List<TableUnit>();
        private List<MainInfo> mMainInfos = new List<MainInfo>();
        public static SynchronizationContext mSyncContext = null;

        public Form_Add_Load_Line()
        {
            InitializeComponent();
        }

        public Form_Add_Load_Line(Form_Main ParentForm)
        {
            InitializeComponent();
            mParentForm = ParentForm;
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            //Add Hint of TextBox...
            Win32Utility.SetCueText(this.textBox_load_name, "请输入载荷谱名称");
            Win32Utility.SetCueText(this.textBox_stituation, "请输入载荷谱工况");
            Win32Utility.SetCueText(this.textBox_load, "请输入载荷");
            Win32Utility.SetCueText(this.textBox_model, "请输入产品型号");
            Win32Utility.SetCueText(this.textBox_creater, "请输入创建者");
            mSyncContext = SynchronizationContext.Current;
            //this.dataGridView_total.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //this.dataGridView_select.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            initDataGridView();
        }

        private void initDataGridView()
        {
            OleDbDataAdapter da = mParentForm.getMainInfoAdapter();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_total.DataSource = dt;
            dataGridView_total.Columns[0].HeaderText = "编号";
            dataGridView_total.Columns[0].Width = 60;
            dataGridView_total.Columns[1].HeaderText = "名称";
            dataGridView_total.Columns[1].Width = 100;
            dataGridView_total.Columns[2].HeaderText = "工况";
            dataGridView_total.Columns[2].Width = 95;
            dataGridView_total.Columns[3].HeaderText = "型号";
            dataGridView_total.Columns[3].Width = 100;
            dataGridView_total.Columns[4].HeaderText = "创建时间";
            dataGridView_total.Columns[4].Width = 100;
            dataGridView_total.Columns[5].HeaderText = "创建者";
            dataGridView_total.Columns[5].Width = 70;
            //
            dataGridView_select.ColumnCount = 4;
            //dataGridView_select.Columns.Add();
            dataGridView_select.Columns[0].HeaderText = "编号";
            dataGridView_select.Columns[0].Width = 60;
            dataGridView_select.Columns[0].ReadOnly = false;
            dataGridView_select.Columns[1].HeaderText = "名称";
            dataGridView_select.Columns[1].Width = 100;
            dataGridView_select.Columns[1].ReadOnly = false;
            dataGridView_select.Columns[2].HeaderText = "创建时间";
            dataGridView_select.Columns[2].Width = 100;
            dataGridView_select.Columns[2].ReadOnly = false;
            dataGridView_select.Columns[3].Name = "Ratio";
            dataGridView_select.Columns[3].HeaderText = "权重";
            dataGridView_select.Columns[3].Width = 70;
            dataGridView_select.Columns[3].ReadOnly = true;
        }

        private void addSelectedData()
        {

            //dataGridView_select

        }

        private void GridTotalMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo info = this.dataGridView_total.HitTest(e.X, e.Y);
                if (info.RowIndex >= 0)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        TableUnit tableunit = new TableUnit();
                        tableunit.ID = (int)this.dataGridView_total.Rows[info.RowIndex].Cells[0].Value;
                        tableunit.name = (String)this.dataGridView_total.Rows[info.RowIndex].Cells[1].Value;
                        tableunit.date = ((DateTime)this.dataGridView_total.Rows[info.RowIndex].Cells[4].Value);//.ToString();
                        //tableunit.ratio = (String)this.dataGridView_total.Rows[info.RowIndex].Cells[5].Value;
                        this.dataGridView_total.DoDragDrop(tableunit, DragDropEffects.Copy);
                    }
                }
            }
        }

        private void GridSelDragDrop(object sender, DragEventArgs e)
        {
            TableUnit tableunit = (TableUnit)e.Data.GetData(typeof(TableUnit));
            object[] objects = { tableunit.ID, tableunit.name, tableunit.date, tableunit.ratio };
            int row = dataGridView_select.Rows.Add(objects);
            dataGridView_select.Rows[row].Cells[3].Style.ForeColor = System.Drawing.Color.Red;
            dataGridView_select.Rows[row].Cells[3].Style.Font = new Font(dataGridView_select.Font, FontStyle.Bold);
            //dataGridView_select.Columns[3].Attribus.Add("readonly","true");
            //得到要拖拽到的位置
            //             Point p = this.dataGridView_select.PointToClient(new Point(e.X, e.Y));
            //             DataGridView.HitTestInfo hit = this.dataGridView_select.HitTest(p.X, p.Y);
            //             if (hit.Type == DataGridViewHitTestType.Cell)
            //             {
            //                 DataGridViewCell clickedCell = this.dataGridView_select.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            //                 clickedCell.Value = (System.String)e.Data.GetData(typeof(System.String));
            //                 //如果只想允许拖拽到某一个特定列，比如Target Field Expression，则先要判断列是否为Target Field Expression，如下：
            //                 //if (0 == string.Compare(clickedCell.OwningColumn.Name, "Target Field Expression"))
            //                 //{
            //                 //    clickedCell.Value = (System.String)e.Data.GetData(typeof(System.String));
            //                 //}
            //             }
        }

        private void GridSelDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            //e.Effect = DragDropEffects.Move;
        }

        private void GridSelectCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dataGridView_select.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView_select.ClearSelection();
                        dataGridView_select.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView_select.SelectedRows.Count == 1)
                    {
                        dataGridView_select.CurrentCell = dataGridView_select.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    contextMenuStrip_pop_menu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void contextMenuStrip_pop_menu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void OnContextMenuStripItemSelected(object sender, ToolStripItemClickedEventArgs e)
        {
            int curIndex = dataGridView_select.CurrentRow.Index;
            //if (curIndex >= dataGridView_select.Rows.Count) return;
            if (e.ClickedItem.Equals(toolStripMenuItem_Ratio))
            {
                //float ratio = (float)(this.dataGridView_select.SelectedCells[3].Value);
                //string inMsg = InputBox.ShowInputBox("输入信息", string.Empty);
                String value = InputDialog.Show("请设定权重数值");
                if (value == null) return; //Cancel...
                float ratio;
                try
                {
                    bool b = float.TryParse(value, out ratio);
                }
                catch
                {
                    MessageBox.Show("您输入的加权数值不合法！");
                    return;
                }
                dataGridView_select.Rows[dataGridView_select.CurrentRow.Index].Cells[3].Value = ratio;
            }
            else if (e.ClickedItem.Equals(toolStripMenuItem_Delete))
            {
                dataGridView_select.Rows.RemoveAt(curIndex);
            }
        }

        private void OnGridSelectDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int curIndex = dataGridView_select.CurrentRow.Index;
            //             if (curIndex >= dataGridView_select.Rows.Count) return;
            String value = InputDialog.Show("请设定权重数值");
            if (value == null) return; //Cancel...
            float ratio;
            try
            {
                bool b = float.TryParse(value, out ratio);
            }
            catch
            {
                MessageBox.Show("您输入的加权数值不合法！");
                return;
            }
            dataGridView_select.Rows[dataGridView_select.CurrentRow.Index].Cells[3].Value = ratio;
        }

        private void button_merge_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_load_name.Text.ToString()) ||
                String.IsNullOrEmpty(textBox_stituation.Text.ToString()) ||
                String.IsNullOrEmpty(textBox_load.Text.ToString()) ||
                String.IsNullOrEmpty(textBox_model.Text.ToString()) ||
                String.IsNullOrEmpty(textBox_creater.Text.ToString()))
            {
                MessageBox.Show("请先完善载荷基本信息");
                return;
            }
            int rows = dataGridView_select.Rows.Count;
            int cols = dataGridView_select.ColumnCount;
            if (rows <= 0 || cols <= 0) return;
            List<DataUnit> list = new List<DataUnit>();
            for (int i = 0; i < rows; i++)
            {
                int ID = (int)dataGridView_select.Rows[i].Cells[0].Value;
                float ratio = (float)dataGridView_select.Rows[i].Cells[3].Value;
                if (ratio > 0f)
                {
                    list.Add(new DataUnit(ID, ratio));
                }
                else
                {
                    MessageBox.Show("有权重未设置，请先完善各个权重设置！");
                    return;
                }
            }

            //Get Data.
            if (mMainInfos.Count != 0) mMainInfos.Clear();
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                MainInfo mainInfo = mParentForm.getFromDataBase(list[i].ID);
                if (mainInfo != null)
                    mMainInfos.Add(mainInfo);
            }

            //Merge.
            MainInfo MainInfoDst = new MainInfo();
            MainInfoDst.Model = textBox_model.Text.ToString();
            MainInfoDst.Name = textBox_load_name.Text.ToString();
            MainInfoDst.TestTime = DateTime.Now;
            MainInfoDst.WorkingCondition = textBox_stituation.Text.ToString();
            MainInfoDst.Creater = textBox_creater.Text.ToString();
            List<Object> listPara = new List<Object>();
            listPara.Add(MainInfoDst);
            listPara.Add(mMainInfos);
            listPara.Add(list);
            new Task(mergeDataList, listPara).Start();
        }

        public void mergeDataList(object o)
        {
            mSyncContext.Post(enableButtons, false);
            List<Object> listPara = o as List<Object>;
            if (listPara == null)
            {
                mSyncContext.Post(enableButtons, true); return;
            }
            MainInfo mainInfoDst = (MainInfo)listPara[0];
            List<MainInfo> mainInfosSrc = (List<MainInfo>)listPara[1];
            List<DataUnit> ratioList = (List<DataUnit>)listPara[2];
            if (mainInfoDst == null || mainInfosSrc == null || ratioList == null)
            {
                mSyncContext.Post(enableButtons, true); return;
            }
            List<SubInfo> SubInfos = new List<SubInfo>();
            //Find the largest row and column.
            int maxRow = 0;
            int maxCol = 0;
            List<PointUnit> points = null;
            for (int i = 1; i < mainInfosSrc.Count; i++)
            {
                maxCol = mainInfosSrc[i].SubInfos.Count >= mainInfosSrc[i - 1].SubInfos.Count ?
                mainInfosSrc[i].SubInfos.Count : mainInfosSrc[i - 1].SubInfos.Count;
                if (mainInfosSrc[i].SubInfos[0].Points.Count >= mainInfosSrc[i - 1].SubInfos[0].Points.Count)
                {
                    maxRow = mainInfosSrc[i].SubInfos[0].Points.Count;
                    points = mainInfosSrc[i].SubInfos[0].Points;
                }
                else
                {
                    maxRow = mainInfosSrc[i - 1].SubInfos[0].Points.Count;
                    points = mainInfosSrc[i - 1].SubInfos[0].Points;
                }
            }
            if (points == null)
            {
                mSyncContext.Post(enableButtons, true); return;
            }
            for (int i = 0; i < maxCol; i++)
            {
                SubInfo info = new SubInfo();
                info.ChannelNo = (i + 1).ToString();
                List<PointUnit> pointsTemp = new List<PointUnit>();
                foreach (PointUnit point in points)
                {
                    pointsTemp.Add(new PointUnit(point.TimeCount, 0f));
                }
                info.Points = pointsTemp;
                SubInfos.Add(info);
            }
            for (int i = 0; i < mainInfosSrc.Count; i++)
            {
                float index = ratioList[i].Ratio;
                MainInfo MainInfoTemp = mainInfosSrc[i];
                for (int j = 0; j < MainInfoTemp.SubInfos.Count; j++) //Column
                {
                    for (int k = 0; k < MainInfoTemp.SubInfos[j].Points.Count; k++) //Row
                    {
                        SubInfos[j].Points[k].Value += MainInfoTemp.SubInfos[j].Points[k].Value * index;
                    }
                    //Console.WriteLine(SubInfos[j].Points[0].Value.ToString());
                }
            }
            //Insert into database.
            mainInfoDst.SubInfos = SubInfos;
            mSyncContext.Post(insertInToDatabase, mainInfoDst);
            mSyncContext.Post(enableButtons, true);
        }

        public Object DeepCopy(Object obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (Object)retval;
        }

        public void insertInToDatabase(object o)
        {
            MainInfo mainInfo = o as MainInfo;
            if (mainInfo != null)
                mParentForm.insertIntoDataBase(mainInfo);
            //Refresh DataGridView...
            OleDbDataAdapter da = mParentForm.getMainInfoAdapter();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView_total.DataSource = dt;
            dataGridView_total.Refresh();
            dataGridView_select.Rows.Clear();

        }

        public void enableButtons(Object o)
        {
            Boolean isEnable = (Boolean)o;
            button_merge.Enabled = isEnable;
        }

        private class TableUnit
        {
            public int ID = 0;
            public String name = "";
            public DateTime date = DateTime.Now;
            public float ratio = 0f;
        }

        private class DataUnit
        {
            public int ID = 0;
            public float Ratio = 0f;

            public DataUnit(int ID, float Ratio)
            {
                this.ID = ID;
                this.Ratio = Ratio;
            }
        }
    }
}
