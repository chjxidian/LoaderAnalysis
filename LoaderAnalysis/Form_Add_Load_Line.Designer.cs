namespace LoaderAnalysis
{
    partial class Form_Add_Load_Line
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Add_Load_Line));
            this.button_merge = new System.Windows.Forms.Button();
            this.textBox_creater = new System.Windows.Forms.TextBox();
            this.textBox_model = new System.Windows.Forms.TextBox();
            this.textBox_load = new System.Windows.Forms.TextBox();
            this.textBox_stituation = new System.Windows.Forms.TextBox();
            this.textBox_load_name = new System.Windows.Forms.TextBox();
            this.dataGridView_total = new System.Windows.Forms.DataGridView();
            this.dataGridView_select = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_pop_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Ratio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_select)).BeginInit();
            this.contextMenuStrip_pop_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_merge
            // 
            this.button_merge.Location = new System.Drawing.Point(396, 444);
            this.button_merge.Name = "button_merge";
            this.button_merge.Size = new System.Drawing.Size(110, 31);
            this.button_merge.TabIndex = 21;
            this.button_merge.Text = "叠加出新载荷";
            this.button_merge.UseVisualStyleBackColor = true;
            this.button_merge.Click += new System.EventHandler(this.button_merge_Click);
            // 
            // textBox_creater
            // 
            this.textBox_creater.Location = new System.Drawing.Point(377, 406);
            this.textBox_creater.Name = "textBox_creater";
            this.textBox_creater.Size = new System.Drawing.Size(147, 20);
            this.textBox_creater.TabIndex = 36;
            // 
            // textBox_model
            // 
            this.textBox_model.Location = new System.Drawing.Point(377, 363);
            this.textBox_model.Name = "textBox_model";
            this.textBox_model.Size = new System.Drawing.Size(147, 20);
            this.textBox_model.TabIndex = 34;
            // 
            // textBox_load
            // 
            this.textBox_load.Location = new System.Drawing.Point(377, 314);
            this.textBox_load.Name = "textBox_load";
            this.textBox_load.Size = new System.Drawing.Size(147, 20);
            this.textBox_load.TabIndex = 32;
            // 
            // textBox_stituation
            // 
            this.textBox_stituation.Location = new System.Drawing.Point(377, 267);
            this.textBox_stituation.Name = "textBox_stituation";
            this.textBox_stituation.Size = new System.Drawing.Size(147, 20);
            this.textBox_stituation.TabIndex = 30;
            // 
            // textBox_load_name
            // 
            this.textBox_load_name.Location = new System.Drawing.Point(377, 221);
            this.textBox_load_name.Name = "textBox_load_name";
            this.textBox_load_name.Size = new System.Drawing.Size(147, 20);
            this.textBox_load_name.TabIndex = 28;
            // 
            // dataGridView_total
            // 
            this.dataGridView_total.AllowUserToAddRows = false;
            this.dataGridView_total.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_total.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_total.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_total.Location = new System.Drawing.Point(13, 12);
            this.dataGridView_total.MultiSelect = false;
            this.dataGridView_total.Name = "dataGridView_total";
            this.dataGridView_total.ReadOnly = true;
            this.dataGridView_total.RowHeadersVisible = false;
            this.dataGridView_total.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_total.Size = new System.Drawing.Size(528, 186);
            this.dataGridView_total.TabIndex = 37;
            this.dataGridView_total.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GridTotalMouseDown);
            // 
            // dataGridView_select
            // 
            this.dataGridView_select.AllowDrop = true;
            this.dataGridView_select.AllowUserToAddRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_select.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_select.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_select.Location = new System.Drawing.Point(13, 213);
            this.dataGridView_select.MultiSelect = false;
            this.dataGridView_select.Name = "dataGridView_select";
            this.dataGridView_select.ReadOnly = true;
            this.dataGridView_select.RowHeadersVisible = false;
            this.dataGridView_select.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_select.Size = new System.Drawing.Size(333, 262);
            this.dataGridView_select.TabIndex = 38;
            this.dataGridView_select.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridSelectDoubleClick);
            this.dataGridView_select.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridSelectCellMouseDown);
            this.dataGridView_select.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridSelDragDrop);
            this.dataGridView_select.DragEnter += new System.Windows.Forms.DragEventHandler(this.GridSelDragEnter);
            // 
            // contextMenuStrip_pop_menu
            // 
            this.contextMenuStrip_pop_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Ratio,
            this.toolStripMenuItem_Delete});
            this.contextMenuStrip_pop_menu.Name = "contextMenuStrip_pop_menu";
            this.contextMenuStrip_pop_menu.Size = new System.Drawing.Size(147, 48);
            this.contextMenuStrip_pop_menu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_pop_menu_Opening);
            this.contextMenuStrip_pop_menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnContextMenuStripItemSelected);
            // 
            // toolStripMenuItem_Ratio
            // 
            this.toolStripMenuItem_Ratio.Name = "toolStripMenuItem_Ratio";
            this.toolStripMenuItem_Ratio.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_Ratio.Text = "设置权重";
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_Delete.Text = "删除该条记录";
            // 
            // Form_Add_Load_Line
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 489);
            this.Controls.Add(this.dataGridView_select);
            this.Controls.Add(this.dataGridView_total);
            this.Controls.Add(this.textBox_creater);
            this.Controls.Add(this.textBox_model);
            this.Controls.Add(this.textBox_load);
            this.Controls.Add(this.textBox_stituation);
            this.Controls.Add(this.textBox_load_name);
            this.Controls.Add(this.button_merge);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Add_Load_Line";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "叠加载荷谱";
            this.Load += new System.EventHandler(this.OnFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_select)).EndInit();
            this.contextMenuStrip_pop_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_merge;
        private System.Windows.Forms.TextBox textBox_creater;
        private System.Windows.Forms.TextBox textBox_model;
        private System.Windows.Forms.TextBox textBox_load;
        private System.Windows.Forms.TextBox textBox_stituation;
        private System.Windows.Forms.TextBox textBox_load_name;
        private System.Windows.Forms.DataGridView dataGridView_total;
        private System.Windows.Forms.DataGridView dataGridView_select;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_pop_menu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Ratio;
    }
}