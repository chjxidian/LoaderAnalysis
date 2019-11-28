using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
/*using Microsoft.Office.Interop.Excel;*/
using System.Reflection;
using System.IO;
using System.Data;
using System.Drawing;
using System.Collections;
using LoaderAnalysis.DataBean;

namespace LoaderAnalysis.Utils
{
    class ExcelUtil
    {
        public static void ImportDataFromExcel(Object o)
        {
            List<Object> listObjects = o as List<Object>;
            if (listObjects.Count != 2) throw new Exception();
            ExcelUtil.IProgressCallback callback = listObjects[0] as ExcelUtil.IProgressCallback;
            String filepath = listObjects[1] as string;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = null;
            List<SubInfo> listSubInfo = new List<SubInfo>();
            try
            {
                DataTable datatable = new DataTable("excel");
                excel.Visible = false;
                excel.DisplayAlerts = false;
                workbook = excel.Workbooks.Open(filepath);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];
                int rowCount = worksheet.UsedRange.Rows.Count; // 取得行数
                int colCount = worksheet.UsedRange.Columns.Count; // 取得列数
                if (callback != null) callback.OnStart(0, rowCount * colCount);
                for (int j = 2; j <= colCount; j++)
                {
                    SubInfo subInfo = new SubInfo();
                    List<PointUnit> listPoints = new List<PointUnit>();
                    for (int i = 1; i <= rowCount; i++)
                    {
                        float time = (float)worksheet.Cells[i, 1].value2;
                        float value = (float)worksheet.Cells[i, j].value2;
                        listPoints.Add(new PointUnit(time, value));
                        if (callback != null) callback.OnProgress(0, j * rowCount + i, rowCount * colCount);
                        //Console.Write("Cell [{0},{1}]: Value:{2}\n", i, j, value.ToString());
                    }
                    subInfo.Points = listPoints;
                    listSubInfo.Add(subInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message:{0},ex.StackTrace:{1}", ex.Message, ex.StackTrace);
                MessageBox.Show("导入Excel时遇到错误");
            }
            finally
            {
                if (callback != null) callback.OnFinish(listSubInfo);
                if (workbook != null) workbook.Close();
                excel = null;
            }
        }

        public static void ExportDataToExcel(Object o)
        {
            List<Object> listObjects = o as List<Object>;
            if (listObjects.Count != 3) throw new Exception();
            List<SubInfo> listSubInfo = listObjects[0] as List<SubInfo>;
            ExcelUtil.IProgressCallback callback = listObjects[1] as ExcelUtil.IProgressCallback;
            String filename = listObjects[2] as string;
            try
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workBook = excel.Workbooks.Add(true);
                Excel.Worksheet workSheet = (Excel.Worksheet)workBook.ActiveSheet;
                //workSheet.Name = filename;
                excel.Visible = false;
                excel.DisplayAlerts = false;
                int col = listSubInfo.Count;
                int row = listSubInfo[0].Points.Count;
                if (callback != null) callback.OnStart(0, row * (col + 1));
                for (int i = 0; i < col; i++)
                {
                    if (0 == i)
                    {//time count
                        for (int j = 0; j < row; j++)
                        {
                            workSheet.Cells[j + 1, i + 1].Value2 = listSubInfo[i].Points[j].TimeCount;
                            workSheet.Cells[j + 1, i + 1 + 1].Value2 = listSubInfo[i].Points[j].Value;
                            if (callback != null) callback.OnProgress(0, (i + 1) * row + j, row * (col + 1));
                            //Console.Write("Cell [{0},{1}]: Value:{2}\n", j, i, listSubInfo[i].Points[j].Value.ToString());
                        }
                    }
                    else
                    { //points
                        for (int j = 0; j < row; j++)
                        {
                            workSheet.Cells[j + 1, i + 1 + 1].Value2 = listSubInfo[i].Points[j].Value;
                            if (callback != null) callback.OnProgress(0, (i + 1) * row + j, row * (col + 1));
                            //Console.Write("Cell [{0},{1}]: Value:{2}\n", j, i, listSubInfo[i].Points[j].Value.ToString());
                        }
                    }
                }
                /************************************************************************************************************
                                DataTable datatable = new DataTable();
                                // 写入标题
                                int visibleColumnCount = 0;
                                foreach (DataColumn col in datatable.Columns)
                                {
                                    visibleColumnCount++;
                                    workSheet.Cells[1, visibleColumnCount].Value2 = col.ColumnName.ToString();
                                    //设置字体为粗体
                                    workSheet.Cells[1, visibleColumnCount].Font.Bold = true;
                                }
                                // 逐行写入
                                // ValueType=String,Decimal,Int32,DateTime
                                int i = 2;
                                foreach (DataRow row in datatable.Rows)
                                {
                                    visibleColumnCount = 0;
                                    foreach (DataColumn col in datatable.Columns)
                                    {
                                        visibleColumnCount++;
                                        if (col.DataType.Name.Equals("DateTime"))
                                        {
                                            workSheet.Cells[i, visibleColumnCount].Value2 = dataToString(row, col.ColumnName, string.Empty);
                                            workSheet.Cells[i, visibleColumnCount].NumberFormatLocal = @"yyyy-mm-dd HH:mm:ss";
                                            workSheet.Cells[i, visibleColumnCount].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Blue);
                                        }
                                        else if (col.DataType.Name.Equals("Decimal"))
                                        {
                                            workSheet.Cells[i, visibleColumnCount].Value2 = dataToString(row, col.ColumnName, "0");
                                            workSheet.Cells[i, visibleColumnCount].NumberFormat = "0.00";
                                        }
                                        else if (col.DataType.Name.Equals("Int32"))
                                        {
                                            workSheet.Cells[i, visibleColumnCount].Value2 = dataToString(row, col.ColumnName, "0");
                                            workSheet.Cells[i, visibleColumnCount].NumberFormat = "0";
                                        }
                                        else
                                        {
                                            workSheet.Cells[i, visibleColumnCount].Value2 = dataToString(row, col.ColumnName, string.Empty);
                                            workSheet.Cells[i, visibleColumnCount].NumberFormatLocal = @"@";
                                        }
                                    }
                                    i++;
                                }
                **********************************************************************************************************************************/
                // 保存Excel 51表示2007-2010格式的xlsx
                workSheet.SaveAs(filename, 51, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing);
                workBook.Close(true, Type.Missing, Type.Missing);
                excel.Quit();
                // 安全回收进程
                System.GC.GetGeneration(excel);
                if (MessageBox.Show("已经导出Excel, 您是否要打开？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    System.Diagnostics.Process.Start(filename);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ex.Message:{0},ex.StackTrace:{1}", ex.Message, ex.StackTrace);
                MessageBox.Show("导出Excel时遇到错误");
            }
            finally
            {
                if (callback != null) callback.OnFinish(listSubInfo);
            }
        }

        private static string dataToString(DataRow row, string name, string nullValue)
        {
            if (row == null || row[name] == null || string.IsNullOrEmpty(row[name].ToString()))
                return nullValue;
            else
                return row[name].ToString();
        }

        public interface IProgressCallback
        {

            void OnStart(int minimum, int maximum);

            void OnProgress(int minimum, int current, int maximum);

            void OnFinish(object o);
        }
    }
}