using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaderAnalysis.DataBean
{
    public class MainInfo
    {
        public int ID = 0;
        public String Name = "";
        public String WorkingCondition = "";
        public String Model = "";
        public DateTime TestTime = new DateTime();
        public String Creater = "";
        public List<SubInfo> SubInfos = new List<SubInfo>();

        public bool init(OleDbDataReader reader)
        {
            try
            {
                this.ID = (int)reader["ID"];
                this.Name = reader["Name"].ToString();
                this.WorkingCondition = reader["WorkingCondition"].ToString();
                this.Model = reader["Model"].ToString();
                this.TestTime = (DateTime)reader["TestTime"];
                this.Creater = reader["Creater"].ToString();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, error message is: " + e.Message);
                return false;
            }
        }
    }

    public class SubInfo
    {
        public int ID = 0;
        public int MainID = 0;
        public String ChannelNo = "";
        public int TimeCounts = 0;
        public List<PointUnit> Points = new List<PointUnit>();

        public bool init(OleDbDataReader reader)
        {
            try
            {
                this.ID = (int)reader["ID"];
                this.MainID = (int)reader["MainID"];
                this.ChannelNo = reader["ChannelNo"].ToString();
                this.TimeCounts = (int)reader["TimeCounts"];
                byte[] bytes = (byte[])reader["Points"];
                String str = convertBytesToString(bytes);
                this.Points = convertStringToPoints(str);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, error message is: " + e.Message);
                return false;
            }
        }

        public List<PointUnit> convertStringToPoints(String str)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<PointUnit>>(str);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, error message is: " + e.Message);
                return new List<PointUnit>();
            }
        }

        public String convertSubInfosToString(List<PointUnit> points)
        {
            try
            {
                return JsonConvert.SerializeObject(points);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, error message is: " + e.Message);
                return "";
            }
        }

        public byte[] convertStringToBytes(String str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }

        public String convertBytesToString(byte[] bytes)
        {
            return System.Text.Encoding.Default.GetString(bytes);
        }
    }

    public class PointUnit
    {
        public float TimeCount;
        public float Value;

        public PointUnit(float timecount, float value)
        {
            this.TimeCount = timecount;
            this.Value = value;
        }
    }
}
