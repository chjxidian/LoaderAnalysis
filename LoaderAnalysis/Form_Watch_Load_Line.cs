using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ZedGraph;
using System.Data.OleDb;
using LoaderAnalysis.DataBean;
using System.Drawing.Imaging;

namespace LoaderAnalysis
{
    public partial class Form_Watch_Load_Line : Form
    {
        private Form_Main mParentForm;
        //private Random ran = new Random();
        private PointPairList list = null;

        public Form_Watch_Load_Line()
        {
            InitializeComponent();
        }

        public Form_Watch_Load_Line(Form_Main ParentForm)
        {
            InitializeComponent();
            mParentForm = ParentForm;
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
            dataGridView_all.Columns[2].HeaderText = "工况";
            dataGridView_all.Columns[3].HeaderText = "型号";
            dataGridView_all.Columns[4].HeaderText = "创建时间";
            dataGridView_all.Columns[5].HeaderText = "创建者";
        }

        private void onFormLoad(object sender, EventArgs e)
        {
            this.zedGraphControl_draw.GraphPane.Title.Text = "载荷图谱";
            this.zedGraphControl_draw.GraphPane.XAxis.Title.Text = "时间";
            this.zedGraphControl_draw.GraphPane.YAxis.Title.Text = "数值";
            //this.zedGraphControl_draw.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
            this.zedGraphControl_draw.GraphPane.Chart.Fill = new Fill(Color.FromArgb(225, Color.ForestGreen));//Fill(Color.White, Color.FromArgb(255, Color.ForestGreen), 45.0F);
            this.zedGraphControl_draw.GraphPane.BarSettings.Type = BarType.SortedOverlay;
            //Display grid...
            this.zedGraphControl_draw.GraphPane.YAxis.MajorGrid.IsVisible = true;
            this.zedGraphControl_draw.GraphPane.XAxis.MajorGrid.IsVisible = true;
            //
            initDataGridView();
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            //             zedGraphControl_draw.GraphPane.XAxis.Scale.MaxAuto = true;
            //             double x = (double)new XDate(DateTime.Now);
            //             double y = ran.NextDouble();
            //             list.Add(x, y);
            //             this.zedGraphControl_draw.AxisChange();
            //             this.zedGraphControl_draw.Refresh();
            // 
            //             if (list.Count >= 100)
            //             {
            //                 list.RemoveAt(0);
            //             }
        }

        private void button_draw_Click(object sender, EventArgs e)
        {
            disableButtons();
            int ID;
            try
            {
                if (dataGridView_all.RowCount <= 1)
                {
                    enableButtons();
                    return;
                }
                ID = Convert.ToInt32(this.dataGridView_all.SelectedCells[0].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("" + ex.Message);
                MessageBox.Show("请先选择数据集！");
                enableButtons();
                return;
            }
            MainInfo mainInfo = mParentForm.getFromDataBase(ID);
            List<SubInfo> subInfos = mainInfo.SubInfos;
            //Remove current curve...
            this.zedGraphControl_draw.GraphPane.CurveList.Clear();
            this.zedGraphControl_draw.GraphPane.GraphObjList.Clear();
            this.zedGraphControl_draw.AxisChange();
            this.zedGraphControl_draw.Refresh();
            for (int i = 0; i < subInfos.Count; i++)
            {
                list = new PointPairList();
                int pointCount = subInfos[0].Points.Count;
                for (int j = 0; j < pointCount; j++)
                {
                    list.Add(subInfos[i].Points[j].TimeCount, subInfos[i].Points[j].Value);
                }
                LineItem curve = zedGraphControl_draw.GraphPane.AddCurve("通道号：" + (i + 1) + "   ", list, getIndentyColor(i), SymbolType.None);
                curve.Line.Width = 1.5F;
                curve.Line.IsAntiAlias = true;
                curve.Symbol.Fill = new Fill(Color.FromArgb(255, Color.ForestGreen));
                curve.Symbol.Size = 12;
            }
            this.zedGraphControl_draw.AxisChange();
            this.zedGraphControl_draw.Refresh();
            //             for (int i = 0; i <= 100; i++)
            //             {
            //                 double x = (double)new XDate(DateTime.Now.AddSeconds(-(100 - i)));
            //                 double y = ran.NextDouble();
            //                 list.Add(x, y);
            //             }
            // 
            //             for (int i = 0; i <= 100; i++)
            //             {
            //                 double x = (double)new XDate(DateTime.Now.AddSeconds(-(100 - i)));
            //                 double y = 0;
            //                 list.Add(x, y);
            //             }
            //            DateTime dt = DateTime.Now;
            enableButtons();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            string sFile = string.Empty;
            dialog.Title = "图谱另存为";
            dialog.Filter = "图像 文件(*.jpg) |.jpeg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string FileName = dialog.FileName;
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 200L);
                EncoderParameters myEncoderParameters = new EncoderParameters(1); ;
                myEncoderParameters.Param[0] = myEncoderParameter;
                zedGraphControl_draw.GraphPane.GetImage().Save(FileName, myImageCodecInfo, myEncoderParameters);
            }
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private Color getIndentyColor(int index)
        {
            Color[] colors = new Color[]{
            Color.Blue, Color.DeepPink,Color.DeepSkyBlue,Color.Brown,
            Color.DarkOrange,Color.Red,Color.DarkKhaki,Color.DarkMagenta,Color.Pink,Color.Chocolate,
            Color.DarkSeaGreen,Color.DarkSlateBlue,Color.DarkSlateGray,Color.DarkTurquoise,
            Color.DimGray,Color.DodgerBlue,Color.Firebrick,Color.BlanchedAlmond,Color.BlueViolet,
            Color.AliceBlue,Color.AntiqueWhite,Color.Aqua,Color.Aquamarine,Color.DarkGray,
            Color.Azure,Color.Beige,Color.Bisque,Color.Black,Color.DarkOrchid,Color.MediumTurquoise,
            Color.BurlyWood,Color.CadetBlue,Color.Chartreuse,Color.MediumSeaGreen,Color.MediumSlateBlue,
            Color.Coral,Color.CornflowerBlue,Color.Cornsilk,Color.Crimson,Color.DarkSalmon,
            Color.Cyan,Color.DarkBlue,Color.DarkCyan,Color.DarkGoldenrod,Color.DarkGreen,Color.Orange,
            Color.Moccasin,Color.NavajoWhite,Color.Navy,Color.OldLace,Color.Olive,Color.OliveDrab,
            Color.OrangeRed,Color.Orchid,Color.PaleGoldenrod,Color.PaleGreen,Color.PaleTurquoise,
            Color.PeachPuff,Color.Peru,Color.Pink,Color.Plum,Color.PowderBlue,Color.Purple,
            Color.FloralWhite,Color.ForestGreen,Color.Fuchsia,Color.Gainsboro,Color.GhostWhite,
            Color.Gold,Color.Goldenrod,Color.Gray,Color.Green,Color.GreenYellow,Color.PapayaWhip,
            Color.Honeydew,Color.HotPink,Color.IndianRed,Color.Indigo,Color.Ivory,Color.PaleVioletRed,
            Color.Khaki,Color.Lavender,Color.LavenderBlush,Color.LawnGreen,Color.LemonChiffon,
            Color.LightBlue,Color.LightCoral,Color.LightCyan,Color.LightGoldenrodYellow,Color.LightGray,
            Color.LightGreen,Color.LightPink,Color.LightSalmon,Color.LightSeaGreen,Color.LightSkyBlue,
            Color.LightSlateGray,Color.LightSteelBlue,Color.LightYellow,Color.Lime,Color.LimeGreen,
            Color.Linen,Color.Magenta,Color.Maroon,Color.MediumAquamarine,Color.MediumBlue,
            Color.MediumOrchid,Color.MediumPurple,Color.MediumSpringGreen,Color.MediumVioletRed
            };

            if (index < 0 || index > colors.Length)
            {
                return Color.Black;
            }
            else
            {
                return colors[index];
            }
        }

        private Color getRandomColor()
        {
            int R = new Random().Next(255);
            int G = new Random().Next(255);
            int B = new Random().Next(255);
            B = (R + G > 400) ? R + G - 400 : B;//0 : 380 - R - G;
            B = (B > 255) ? 255 : B;
            return Color.FromArgb(R, G, B);
        }

        private void disableButtons()
        {
            button_draw.Enabled = false;
            button_save.Enabled = false;
        }

        private void enableButtons()
        {
            button_draw.Enabled = true;
            button_save.Enabled = true;
        }

    }
}
