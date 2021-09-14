
namespace QLMA
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupDSSV = new System.Windows.Forms.GroupBox();
            this.cbbSort = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butSort = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.txtboxSearch = new System.Windows.Forms.TextBox();
            this.cbbMA = new System.Windows.Forms.ComboBox();
            this.labLopSH = new System.Windows.Forms.Label();
            this.groupDSSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(725, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Search";
            // 
            // groupDSSV
            // 
            this.groupDSSV.Controls.Add(this.cbbSort);
            this.groupDSSV.Controls.Add(this.dataGridView1);
            this.groupDSSV.Controls.Add(this.butSort);
            this.groupDSSV.Controls.Add(this.butDel);
            this.groupDSSV.Controls.Add(this.butAdd);
            this.groupDSSV.Controls.Add(this.butEdit);
            this.groupDSSV.Location = new System.Drawing.Point(26, 69);
            this.groupDSSV.Name = "groupDSSV";
            this.groupDSSV.Size = new System.Drawing.Size(960, 451);
            this.groupDSSV.TabIndex = 47;
            this.groupDSSV.TabStop = false;
            this.groupDSSV.Text = "Quản lý sản phẩm";
            // 
            // cbbSort
            // 
            this.cbbSort.FormattingEnabled = true;
            this.cbbSort.Location = new System.Drawing.Point(746, 402);
            this.cbbSort.Name = "cbbSort";
            this.cbbSort.Size = new System.Drawing.Size(202, 24);
            this.cbbSort.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(942, 342);
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
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(419, 396);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(83, 34);
            this.butDel.TabIndex = 4;
            this.butDel.Text = "Delete";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(16, 396);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(79, 34);
            this.butAdd.TabIndex = 2;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butEdit
            // 
            this.butEdit.Location = new System.Drawing.Point(217, 396);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(79, 34);
            this.butEdit.TabIndex = 3;
            this.butEdit.Text = "Edit";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // txtboxSearch
            // 
            this.txtboxSearch.Location = new System.Drawing.Point(785, 32);
            this.txtboxSearch.Name = "txtboxSearch";
            this.txtboxSearch.Size = new System.Drawing.Size(196, 22);
            this.txtboxSearch.TabIndex = 46;
            this.txtboxSearch.TextChanged += new System.EventHandler(this.txtboxSearch_TextChanged);
            // 
            // cbbMA
            // 
            this.cbbMA.FormattingEnabled = true;
            this.cbbMA.Location = new System.Drawing.Point(140, 28);
            this.cbbMA.Name = "cbbMA";
            this.cbbMA.Size = new System.Drawing.Size(171, 24);
            this.cbbMA.TabIndex = 45;
            this.cbbMA.SelectedIndexChanged += new System.EventHandler(this.cbbMA_SelectedIndexChanged);
            // 
            // labLopSH
            // 
            this.labLopSH.AutoSize = true;
            this.labLopSH.Location = new System.Drawing.Point(23, 31);
            this.labLopSH.Name = "labLopSH";
            this.labLopSH.Size = new System.Drawing.Size(55, 17);
            this.labLopSH.TabIndex = 44;
            this.labLopSH.Text = "Món ăn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 530);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupDSSV);
            this.Controls.Add(this.txtboxSearch);
            this.Controls.Add(this.cbbMA);
            this.Controls.Add(this.labLopSH);
            this.Name = "Form1";
            this.Text = "Lehoangngochan_MF";
            this.groupDSSV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupDSSV;
        private System.Windows.Forms.ComboBox cbbSort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butSort;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.TextBox txtboxSearch;
        private System.Windows.Forms.ComboBox cbbMA;
        private System.Windows.Forms.Label labLopSH;
    }
}

