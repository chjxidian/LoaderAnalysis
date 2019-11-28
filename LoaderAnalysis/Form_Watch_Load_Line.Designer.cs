namespace LoaderAnalysis
{
    partial class Form_Watch_Load_Line
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Watch_Load_Line));
            this.zedGraphControl_draw = new ZedGraph.ZedGraphControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dataGridView_all = new System.Windows.Forms.DataGridView();
            this.button_draw = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_all)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl_draw
            // 
            this.zedGraphControl_draw.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl_draw.Name = "zedGraphControl_draw";
            this.zedGraphControl_draw.ScrollGrace = 0D;
            this.zedGraphControl_draw.ScrollMaxX = 0D;
            this.zedGraphControl_draw.ScrollMaxY = 0D;
            this.zedGraphControl_draw.ScrollMaxY2 = 0D;
            this.zedGraphControl_draw.ScrollMinX = 0D;
            this.zedGraphControl_draw.ScrollMinY = 0D;
            this.zedGraphControl_draw.ScrollMinY2 = 0D;
            this.zedGraphControl_draw.Size = new System.Drawing.Size(823, 346);
            this.zedGraphControl_draw.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.onTimerTick);
            // 
            // dataGridView_all
            // 
            this.dataGridView_all.AllowUserToAddRows = false;
            this.dataGridView_all.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_all.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_all.Location = new System.Drawing.Point(12, 364);
            this.dataGridView_all.MultiSelect = false;
            this.dataGridView_all.Name = "dataGridView_all";
            this.dataGridView_all.ReadOnly = true;
            this.dataGridView_all.RowHeadersVisible = false;
            this.dataGridView_all.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_all.Size = new System.Drawing.Size(563, 192);
            this.dataGridView_all.TabIndex = 1;
            // 
            // button_draw
            // 
            this.button_draw.Location = new System.Drawing.Point(644, 381);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(125, 32);
            this.button_draw.TabIndex = 2;
            this.button_draw.Text = "绘制图谱";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button_draw_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(644, 499);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(125, 32);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "存储图谱";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // Form_Watch_Load_Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 568);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_draw);
            this.Controls.Add(this.dataGridView_all);
            this.Controls.Add(this.zedGraphControl_draw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Watch_Load_Line";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查看载荷谱";
            this.Load += new System.EventHandler(this.onFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_all)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl_draw;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dataGridView_all;
        private System.Windows.Forms.Button button_draw;
        private System.Windows.Forms.Button button_save;
    }
}