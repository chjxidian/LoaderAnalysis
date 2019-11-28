using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using LoaderAnalysis.DataBean;
using ZedGraph;

namespace LoaderAnalysis
{
    public partial class Form_Main : Form
    {
        public OleDbConnection mDataBaseConn;
        private String mUserName = "Admin";
        private String mPassWord = "Admin";
        private String mDataBaseDir = "";

        public Form_Main()
        {
            InitializeComponent();
            Task task = new Task(connectDataSource);
            task.Start();
        }

        private void connectDataSource()
        {
            try
            {
                mDataBaseDir = Environment.CurrentDirectory + "\\Database.accdb";
                mDataBaseConn = connectDataBase(mDataBaseDir, mUserName, mPassWord);
                mDataBaseConn.Open();
            }
            catch (Exception ex)
            {
                DelegateMethod delegateMethod = new DelegateMethod(onDataSourceConnecteFaiure);
                this.Invoke(delegateMethod);
            }
        }

        protected delegate void DelegateMethod();

        private void onDataSourceConnecteFaiure()
        {
            MessageBox.Show("数据库连接失败！");
            this.Close();
        }

        public OleDbConnection connectDataBase(String dir, String userName, String passWord)
        {
            StringBuilder strBuild = new StringBuilder();
            //Microsoft.Jet.OLEDB.4.0
            strBuild.AppendFormat("Provider=Microsoft.ACE.OLEDB.12.0; Jet OLEDB:DataBase Password=\"{0}\"; User ID={1}; Data Source={2}; Mode={3}", passWord, userName, dir, "ReadWrite");
            //strBuild.AppendFormat("Provider=Microsoft.ACE.OLEDB.12.0; Jet OLEDB:DataBase Password=\"{0}\"; Data Source={1}; Mode={2}", passWord, dir, "ReadWrite");
            OleDbConnection conn = new OleDbConnection(strBuild.ToString());
            return (conn);
        }

        private OleDbDataReader readData(string strCommand)
        {
            OleDbCommand command = new OleDbCommand(strCommand, mDataBaseConn);
            OleDbDataReader reader = command.ExecuteReader();
            return reader;
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void onMainFormClose(object sender, FormClosedEventArgs e)
        {
            mDataBaseConn.Close();
        }

        private void button_create_load_Click(object sender, EventArgs e)
        {
            Form_Create_Load_Line createLoadForm = new Form_Create_Load_Line(this);
            if (createLoadForm.ShowDialog() == DialogResult.OK)
            {
                String str = createLoadForm.mLoadName;
                str = createLoadForm.mLoadName;
                str = createLoadForm.mStituation;
                str = createLoadForm.mLoad;
                str = createLoadForm.mModel;
                //createLoadForm.mTestTime;
                str = createLoadForm.mCreaterName;
            }
        }

        private void button_add_load_Click(object sender, EventArgs e)
        {
            //             MessageBox.Show("暂时不支持此功能！");
            //             return;
            Form_Add_Load_Line addLoadForm = new Form_Add_Load_Line(this);
            if (addLoadForm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button_watch_load_Click(object sender, EventArgs e)
        {
            Form_Watch_Load_Line watchLoadForm = new Form_Watch_Load_Line(this);
            if (watchLoadForm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void button_dispose_load_Click(object sender, EventArgs e)
        {
            Form_Dispose_Load_Line disposeLoad = new Form_Dispose_Load_Line(this);
            if (disposeLoad.ShowDialog() == DialogResult.OK)
            {

            }
        }

        public OleDbDataAdapter getMainInfoAdapter()
        {
            List<MainInfo> mainInfos = new List<MainInfo>();
            OleDbCommand cmd = new OleDbCommand();
            if (mDataBaseConn.State == System.Data.ConnectionState.Closed) mDataBaseConn.Open();
            cmd.Connection = mDataBaseConn;
            cmd.CommandText = "SELECT * FROM MainInfo";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //OleDbDataReader reader = cmd.ExecuteReader();
            //             int index = 0;
            //             while (reader.Read())
            //             {
            //                 mainInfos[index].init(reader);
            //             }
            return da;
        }

        public MainInfo getFromDataBase(int mainID)
        {
            //OleDbDataReader reader = readData("SELECT * FROM BasicInfo");
            //SELECT * FROM SubInfo WHERE MainID IN (SELECT ID FROM MainInfo);
            MainInfo MainInfo = new MainInfo();
            OleDbCommand cmd = new OleDbCommand();
            if (mDataBaseConn.State == System.Data.ConnectionState.Closed) mDataBaseConn.Open();
            cmd.Connection = mDataBaseConn;
            cmd.Transaction = mDataBaseConn.BeginTransaction();
            try
            {
                cmd.CommandText = String.Format("SELECT * FROM MainInfo WHERE ID = {0}", mainID);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MainInfo.init(reader);
                    reader.Close();
                }
                else
                {
                    throw new Exception();
                }
                cmd.CommandText = String.Format("SELECT * FROM QueryTestRecord WHERE MainID = {0}", mainID);
                OleDbDataReader subReader = cmd.ExecuteReader();
                while (subReader.Read())
                {
                    SubInfo SubInfo = new SubInfo();
                    SubInfo.init(subReader);
                    MainInfo.SubInfos.Add(SubInfo);
                }
                cmd.Transaction.Commit();
                subReader.Close();
                //MessageBox.Show("数据查找成功！");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                cmd.Transaction.Rollback();
                MessageBox.Show("数据查找失败！");
            }
            return MainInfo;
            //             string selectstr = "SELECT * FROM BasicInfo";
            //             OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(selectstr, mDataBaseConn);
            //             //建立OleDbCommandBuilder，必须！
            //             OleDbCommandBuilder mybuilder = new OleDbCommandBuilder(myDataAdapter);
            //             DataSet ds = new DataSet(); //建立DataSet()实例
            //             myDataAdapter.Fill(ds, "BasicInfo");
            //             //下面的可以简化，由于我开始是选择了所有的记录，所以就用的是集合方式
            //             foreach (DataRow dr in ds.Tables["BasicInfo"].Rows)
            //             {
            //                 if (dr["id"].ToString().Equals("delid"))
            //                 {
            //                     dr.Delete();
            //                 }
            //             }
            //             myDataAdapter.Update(ds, "BasicInfo");
        }

        public void insertIntoDataBase(MainInfo mainInfo)
        {
            if (mainInfo == null) return;
            else
            {
                OleDbCommand cmd = new OleDbCommand();
                if (mDataBaseConn.State == System.Data.ConnectionState.Closed) mDataBaseConn.Open();
                cmd.Connection = mDataBaseConn;
                cmd.Transaction = mDataBaseConn.BeginTransaction();
                try
                {
                    //Insert into MainInfo...
                    string sql = "INSERT INTO MainInfo (Name, WorkingCondition, Model, TestTime, Creater) VALUES (@Name, @WorkingCondition, @Model, @TestTime, @Creater)";//; SELECT @ID = @@identity
                    OleDbParameter[] paraMain = {new OleDbParameter("@Name", OleDbType.VarChar),
                                         new OleDbParameter("@WorkingCondition", OleDbType.VarChar),
                                         new OleDbParameter("@Model", OleDbType.VarChar),
                                         new OleDbParameter("@TestTime", OleDbType.DBTimeStamp),
                                         new OleDbParameter("@Creater", OleDbType.VarChar)};
                    paraMain[0].Value = mainInfo.Name;
                    paraMain[1].Value = mainInfo.WorkingCondition;
                    paraMain[2].Value = mainInfo.Model;
                    paraMain[3].Value = DateTime.Now.ToString();//mainInfo.TestTime
                    paraMain[4].Value = mainInfo.Creater;
                    int addLineID = 0;
                    int rows = 0;
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(paraMain);
                    rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        cmd.CommandText = "SELECT @@identity";
                        addLineID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    else
                    {
                        throw new Exception();
                    }
                    if (addLineID > 0) Console.WriteLine("Insert MainInfo data success...");
                    //Insert into SubInfo...
                    foreach (SubInfo info in (mainInfo.SubInfos))
                    {
                        info.MainID = addLineID;
                        string sqlSub = "INSERT INTO SubInfo (MainID, ChannelNo, TimeCounts, Points) VALUES (@MainID, @ChannelNo, @TimeCounts, @Points)";
                        OleDbParameter[] paraSub = {new OleDbParameter("@MainID", OleDbType.Integer),
                                         new OleDbParameter("@ChannelNo", OleDbType.VarChar),
                                         new OleDbParameter("@TimeCounts", OleDbType.Integer),
                                         new OleDbParameter("@Points", OleDbType.Binary)};//VarChar
                        paraSub[0].Value = info.MainID;
                        paraSub[1].Value = info.ChannelNo;
                        paraSub[2].Value = info.TimeCounts;
                        paraSub[3].Value = info.convertStringToBytes(info.convertSubInfosToString(info.Points));
                        rows = 0;
                        //using (OleDbCommand cmd = new OleDbCommand(sqlSub, mDataBaseConn))
                        cmd.CommandText = sqlSub;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(paraSub);
                        rows = cmd.ExecuteNonQuery();
                        if (rows > 0) Console.WriteLine("Insert SubInfo data success...");
                    }
                    cmd.Transaction.Commit();
                    MessageBox.Show("插入数据成功！");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    cmd.Transaction.Rollback();
                    MessageBox.Show("插入数据失败！");
                }
            }
        }

        public void deleteFromDataBase(int mainID)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (mDataBaseConn.State == System.Data.ConnectionState.Closed) mDataBaseConn.Open();
            cmd.Connection = mDataBaseConn;
            cmd.Transaction = mDataBaseConn.BeginTransaction();
            try
            {
                cmd.CommandText = String.Format("DELETE FROM MainInfo WHERE ID = {0}", mainID);
                cmd.ExecuteNonQuery();
                cmd.CommandText = String.Format("DELETE FROM SubInfo WHERE MainID = {0}", mainID);
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
                MessageBox.Show("删除数据成功！");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                cmd.Transaction.Rollback();
                MessageBox.Show("删除数据失败！");
            }
        }
    }
}
