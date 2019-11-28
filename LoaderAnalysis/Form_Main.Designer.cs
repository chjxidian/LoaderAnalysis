namespace LoaderAnalysis
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.button_quit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_watch_load = new System.Windows.Forms.Button();
            this.button_add_load = new System.Windows.Forms.Button();
            this.button_dispose_load = new System.Windows.Forms.Button();
            this.button_create_load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_quit
            // 
            this.button_quit.Location = new System.Drawing.Point(340, 334);
            this.button_quit.Name = "button_quit";
            this.button_quit.Size = new System.Drawing.Size(75, 23);
            this.button_quit.TabIndex = 0;
            this.button_quit.Text = "退出";
            this.button_quit.UseVisualStyleBackColor = true;
            this.button_quit.Click += new System.EventHandler(this.button_quit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "D 查看一个载荷谱";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "C 从数据库中的载荷谱叠加生成新载荷谱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "B 处理数据库中的载荷谱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "A 通过表格文件创建载荷谱";
            // 
            // button_watch_load
            // 
            this.button_watch_load.Location = new System.Drawing.Point(32, 233);
            this.button_watch_load.Name = "button_watch_load";
            this.button_watch_load.Size = new System.Drawing.Size(105, 31);
            this.button_watch_load.TabIndex = 13;
            this.button_watch_load.Text = "查看载荷谱";
            this.button_watch_load.UseVisualStyleBackColor = true;
            this.button_watch_load.Click += new System.EventHandler(this.button_watch_load_Click);
            // 
            // button_add_load
            // 
            this.button_add_load.Location = new System.Drawing.Point(32, 164);
            this.button_add_load.Name = "button_add_load";
            this.button_add_load.Size = new System.Drawing.Size(105, 31);
            this.button_add_load.TabIndex = 12;
            this.button_add_load.Text = "叠加载荷谱";
            this.button_add_load.UseVisualStyleBackColor = true;
            this.button_add_load.Click += new System.EventHandler(this.button_add_load_Click);
            // 
            // button_dispose_load
            // 
            this.button_dispose_load.Location = new System.Drawing.Point(32, 91);
            this.button_dispose_load.Name = "button_dispose_load";
            this.button_dispose_load.Size = new System.Drawing.Size(105, 31);
            this.button_dispose_load.TabIndex = 11;
            this.button_dispose_load.Text = "处理载荷谱";
            this.button_dispose_load.UseVisualStyleBackColor = true;
            this.button_dispose_load.Click += new System.EventHandler(this.button_dispose_load_Click);
            // 
            // button_create_load
            // 
            this.button_create_load.Location = new System.Drawing.Point(32, 25);
            this.button_create_load.Name = "button_create_load";
            this.button_create_load.Size = new System.Drawing.Size(105, 31);
            this.button_create_load.TabIndex = 10;
            this.button_create_load.Text = "创建载荷谱";
            this.button_create_load.UseVisualStyleBackColor = true;
            this.button_create_load.Click += new System.EventHandler(this.button_create_load_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 374);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_watch_load);
            this.Controls.Add(this.button_add_load);
            this.Controls.Add(this.button_dispose_load);
            this.Controls.Add(this.button_create_load);
            this.Controls.Add(this.button_quit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "载荷谱分析程序";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onMainFormClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_quit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_watch_load;
        private System.Windows.Forms.Button button_add_load;
        private System.Windows.Forms.Button button_dispose_load;
        private System.Windows.Forms.Button button_create_load;
    }
}

