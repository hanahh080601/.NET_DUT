
namespace GK_102190161_Lê_Hoàng_Ngọc_Hân
{
    partial class Form1
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
            this.groupDSGV = new System.Windows.Forms.GroupBox();
            this.cbb_sort = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butSort = new System.Windows.Forms.Button();
            this.butShow = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbb_CS = new System.Windows.Forms.ComboBox();
            this.lab_CS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupDSGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupDSGV
            // 
            this.groupDSGV.Controls.Add(this.cbb_sort);
            this.groupDSGV.Controls.Add(this.dataGridView1);
            this.groupDSGV.Controls.Add(this.butSort);
            this.groupDSGV.Controls.Add(this.butShow);
            this.groupDSGV.Controls.Add(this.butDel);
            this.groupDSGV.Controls.Add(this.butAdd);
            this.groupDSGV.Controls.Add(this.butEdit);
            this.groupDSGV.Location = new System.Drawing.Point(31, 73);
            this.groupDSGV.Name = "groupDSGV";
            this.groupDSGV.Size = new System.Drawing.Size(960, 436);
            this.groupDSGV.TabIndex = 22;
            this.groupDSGV.TabStop = false;
            this.groupDSGV.Text = "Danh sách giảng viên";
            // 
            // cbb_sort
            // 
            this.cbb_sort.FormattingEnabled = true;
            this.cbb_sort.Location = new System.Drawing.Point(746, 402);
            this.cbb_sort.Name = "cbb_sort";
            this.cbb_sort.Size = new System.Drawing.Size(202, 24);
            this.cbb_sort.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(942, 328);
            this.dataGridView1.TabIndex = 11;
            // 
            // butSort
            // 
            this.butSort.Location = new System.Drawing.Point(635, 396);
            this.butSort.Name = "butSort";
            this.butSort.Size = new System.Drawing.Size(86, 34);
            this.butSort.TabIndex = 5;
            this.butSort.Text = "Sort";
            this.butSort.UseVisualStyleBackColor = true;
            this.butSort.Click += new System.EventHandler(this.butSort_Click);
            // 
            // butShow
            // 
            this.butShow.Location = new System.Drawing.Point(6, 396);
            this.butShow.Name = "butShow";
            this.butShow.Size = new System.Drawing.Size(76, 34);
            this.butShow.TabIndex = 1;
            this.butShow.Text = "Show";
            this.butShow.UseVisualStyleBackColor = true;
            this.butShow.Click += new System.EventHandler(this.butShow_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(472, 396);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(83, 34);
            this.butDel.TabIndex = 4;
            this.butDel.Text = "Delete";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(142, 396);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(79, 34);
            this.butAdd.TabIndex = 2;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butEdit
            // 
            this.butEdit.Location = new System.Drawing.Point(303, 396);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(79, 34);
            this.butEdit.TabIndex = 3;
            this.butEdit.Text = "Edit";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(795, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 22);
            this.textBox1.TabIndex = 21;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cbb_CS
            // 
            this.cbb_CS.FormattingEnabled = true;
            this.cbb_CS.Location = new System.Drawing.Point(88, 24);
            this.cbb_CS.Name = "cbb_CS";
            this.cbb_CS.Size = new System.Drawing.Size(226, 24);
            this.cbb_CS.TabIndex = 20;
            // 
            // lab_CS
            // 
            this.lab_CS.AutoSize = true;
            this.lab_CS.Location = new System.Drawing.Point(28, 27);
            this.lab_CS.Name = "lab_CS";
            this.lab_CS.Size = new System.Drawing.Size(46, 17);
            this.lab_CS.TabIndex = 18;
            this.lab_CS.Text = "Cơ Sở";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(704, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tìm kiếm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 547);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupDSGV);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbb_CS);
            this.Controls.Add(this.lab_CS);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupDSGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDSGV;
        private System.Windows.Forms.ComboBox cbb_sort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butSort;
        private System.Windows.Forms.Button butShow;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbb_CS;
        private System.Windows.Forms.Label lab_CS;
        private System.Windows.Forms.Label label1;
    }
}

