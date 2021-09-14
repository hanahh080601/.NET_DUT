
namespace BookManagement
{
    partial class DetailForm
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
            this.groupTTSV = new System.Windows.Forms.GroupBox();
            this.cbbAuthor2 = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.groupGender = new System.Windows.Forms.GroupBox();
            this.rdbForeign = new System.Windows.Forms.RadioButton();
            this.rdbHome = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labLopSH = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labMSSV = new System.Windows.Forms.Label();
            this.groupTTSV.SuspendLayout();
            this.groupGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupTTSV
            // 
            this.groupTTSV.Controls.Add(this.cbbAuthor2);
            this.groupTTSV.Controls.Add(this.txtName);
            this.groupTTSV.Controls.Add(this.txtBookID);
            this.groupTTSV.Controls.Add(this.butCancel);
            this.groupTTSV.Controls.Add(this.butOK);
            this.groupTTSV.Controls.Add(this.groupGender);
            this.groupTTSV.Controls.Add(this.dateTimePicker1);
            this.groupTTSV.Controls.Add(this.labLopSH);
            this.groupTTSV.Controls.Add(this.labName);
            this.groupTTSV.Controls.Add(this.labMSSV);
            this.groupTTSV.Location = new System.Drawing.Point(25, 24);
            this.groupTTSV.Name = "groupTTSV";
            this.groupTTSV.Size = new System.Drawing.Size(598, 301);
            this.groupTTSV.TabIndex = 7;
            this.groupTTSV.TabStop = false;
            this.groupTTSV.Text = "Book Informantion ";
            // 
            // cbbAuthor2
            // 
            this.cbbAuthor2.FormattingEnabled = true;
            this.cbbAuthor2.Location = new System.Drawing.Point(109, 181);
            this.cbbAuthor2.Name = "cbbAuthor2";
            this.cbbAuthor2.Size = new System.Drawing.Size(182, 24);
            this.cbbAuthor2.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(108, 108);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 22);
            this.txtName.TabIndex = 8;
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(110, 41);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(183, 22);
            this.txtBookID.TabIndex = 7;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(342, 247);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(111, 36);
            this.butCancel.TabIndex = 6;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(111, 247);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(103, 36);
            this.butOK.TabIndex = 5;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupGender
            // 
            this.groupGender.Controls.Add(this.rdbForeign);
            this.groupGender.Controls.Add(this.rdbHome);
            this.groupGender.Location = new System.Drawing.Point(335, 108);
            this.groupGender.Name = "groupGender";
            this.groupGender.Size = new System.Drawing.Size(237, 100);
            this.groupGender.TabIndex = 4;
            this.groupGender.TabStop = false;
            this.groupGender.Text = "Book Published Area";
            // 
            // rdbForeign
            // 
            this.rdbForeign.AutoSize = true;
            this.rdbForeign.Location = new System.Drawing.Point(7, 73);
            this.rdbForeign.Name = "rdbForeign";
            this.rdbForeign.Size = new System.Drawing.Size(127, 21);
            this.rdbForeign.TabIndex = 1;
            this.rdbForeign.TabStop = true;
            this.rdbForeign.Text = "Other countries";
            this.rdbForeign.UseVisualStyleBackColor = true;
            // 
            // rdbHome
            // 
            this.rdbHome.AutoSize = true;
            this.rdbHome.Location = new System.Drawing.Point(7, 34);
            this.rdbHome.Name = "rdbHome";
            this.rdbHome.Size = new System.Drawing.Size(80, 21);
            this.rdbHome.TabIndex = 0;
            this.rdbHome.TabStop = true;
            this.rdbHome.Text = "Vietnam";
            this.rdbHome.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(335, 44);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(237, 22);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // labLopSH
            // 
            this.labLopSH.AutoSize = true;
            this.labLopSH.Location = new System.Drawing.Point(41, 184);
            this.labLopSH.Name = "labLopSH";
            this.labLopSH.Size = new System.Drawing.Size(50, 17);
            this.labLopSH.TabIndex = 2;
            this.labLopSH.Text = "Author";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(10, 111);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(81, 17);
            this.labName.TabIndex = 1;
            this.labName.Text = "Book Name";
            // 
            // labMSSV
            // 
            this.labMSSV.AutoSize = true;
            this.labMSSV.Location = new System.Drawing.Point(34, 41);
            this.labMSSV.Name = "labMSSV";
            this.labMSSV.Size = new System.Drawing.Size(53, 17);
            this.labMSSV.TabIndex = 0;
            this.labMSSV.Text = "BookID";
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 347);
            this.Controls.Add(this.groupTTSV);
            this.Name = "DetailForm";
            this.Text = "DetailForm";
            this.Load += new System.EventHandler(this.DetailForm_Load);
            this.groupTTSV.ResumeLayout(false);
            this.groupTTSV.PerformLayout();
            this.groupGender.ResumeLayout(false);
            this.groupGender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTTSV;
        private System.Windows.Forms.ComboBox cbbAuthor2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.GroupBox groupGender;
        private System.Windows.Forms.RadioButton rdbForeign;
        private System.Windows.Forms.RadioButton rdbHome;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labLopSH;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labMSSV;
    }
}