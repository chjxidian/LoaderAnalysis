namespace LoaderAnalysis
{
    partial class Form_Create_Load_Line
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Create_Load_Line));
            this.button_import = new System.Windows.Forms.Button();
            this.textBox_creater = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_model = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_load = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_stituation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_load_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_read_excel = new System.Windows.Forms.Button();
            this.button_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(35, 333);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(98, 30);
            this.button_import.TabIndex = 29;
            this.button_import.Text = "导入数据库";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // textBox_creater
            // 
            this.textBox_creater.Location = new System.Drawing.Point(144, 188);
            this.textBox_creater.Name = "textBox_creater";
            this.textBox_creater.Size = new System.Drawing.Size(195, 20);
            this.textBox_creater.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "创建者：";
            // 
            // textBox_model
            // 
            this.textBox_model.Location = new System.Drawing.Point(144, 147);
            this.textBox_model.Name = "textBox_model";
            this.textBox_model.Size = new System.Drawing.Size(195, 20);
            this.textBox_model.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "产品型号：";
            // 
            // textBox_load
            // 
            this.textBox_load.Location = new System.Drawing.Point(144, 105);
            this.textBox_load.Name = "textBox_load";
            this.textBox_load.Size = new System.Drawing.Size(195, 20);
            this.textBox_load.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "载荷：";
            // 
            // textBox_stituation
            // 
            this.textBox_stituation.Location = new System.Drawing.Point(144, 63);
            this.textBox_stituation.Name = "textBox_stituation";
            this.textBox_stituation.Size = new System.Drawing.Size(195, 20);
            this.textBox_stituation.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "载荷谱工况：";
            // 
            // textBox_load_name
            // 
            this.textBox_load_name.Location = new System.Drawing.Point(144, 23);
            this.textBox_load_name.Name = "textBox_load_name";
            this.textBox_load_name.Size = new System.Drawing.Size(195, 20);
            this.textBox_load_name.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "载荷谱名称：";
            // 
            // button_read_excel
            // 
            this.button_read_excel.Location = new System.Drawing.Point(144, 233);
            this.button_read_excel.Name = "button_read_excel";
            this.button_read_excel.Size = new System.Drawing.Size(195, 24);
            this.button_read_excel.TabIndex = 30;
            this.button_read_excel.Text = "读取Excel文件";
            this.button_read_excel.UseVisualStyleBackColor = true;
            this.button_read_excel.Click += new System.EventHandler(this.button_read_excel_Click);
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(241, 333);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(98, 30);
            this.button_export.TabIndex = 32;
            this.button_export.Text = "备份到Excel";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // Form_Create_Load_Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 377);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.button_read_excel);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.textBox_creater);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_model);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_load);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_stituation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_load_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Create_Load_Line";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建载荷谱";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.TextBox textBox_creater;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_model;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_load;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_stituation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_load_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_read_excel;
        private System.Windows.Forms.Button button_export;
    }
}