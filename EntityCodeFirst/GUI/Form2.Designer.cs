
namespace EntityCodeFirst
{
    partial class Form2
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
            this.cbbLSH2 = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.groupGender = new System.Windows.Forms.GroupBox();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
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
            this.groupTTSV.Controls.Add(this.cbbLSH2);
            this.groupTTSV.Controls.Add(this.txtName);
            this.groupTTSV.Controls.Add(this.txtMSSV);
            this.groupTTSV.Controls.Add(this.butCancel);
            this.groupTTSV.Controls.Add(this.butOK);
            this.groupTTSV.Controls.Add(this.groupGender);
            this.groupTTSV.Controls.Add(this.dateTimePicker1);
            this.groupTTSV.Controls.Add(this.labLopSH);
            this.groupTTSV.Controls.Add(this.labName);
            this.groupTTSV.Controls.Add(this.labMSSV);
            this.groupTTSV.Location = new System.Drawing.Point(23, 25);
            this.groupTTSV.Name = "groupTTSV";
            this.groupTTSV.Size = new System.Drawing.Size(598, 301);
            this.groupTTSV.TabIndex = 5;
            this.groupTTSV.TabStop = false;
            this.groupTTSV.Text = "Thông tin sinh viên";
            // 
            // cbbLSH2
            // 
            this.cbbLSH2.FormattingEnabled = true;
            this.cbbLSH2.Location = new System.Drawing.Point(75, 170);
            this.cbbLSH2.Name = "cbbLSH2";
            this.cbbLSH2.Size = new System.Drawing.Size(182, 24);
            this.cbbLSH2.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(74, 108);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 22);
            this.txtName.TabIndex = 8;
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(74, 46);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(183, 22);
            this.txtMSSV.TabIndex = 7;
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
            this.groupGender.Controls.Add(this.rdbFemale);
            this.groupGender.Controls.Add(this.rdbMale);
            this.groupGender.Location = new System.Drawing.Point(335, 108);
            this.groupGender.Name = "groupGender";
            this.groupGender.Size = new System.Drawing.Size(237, 100);
            this.groupGender.TabIndex = 4;
            this.groupGender.TabStop = false;
            this.groupGender.Text = "Gender";
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Location = new System.Drawing.Point(7, 73);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(75, 21);
            this.rdbFemale.TabIndex = 1;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "Female";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Location = new System.Drawing.Point(7, 34);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(59, 21);
            this.rdbMale.TabIndex = 0;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Male";
            this.rdbMale.UseVisualStyleBackColor = true;
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
            this.labLopSH.Location = new System.Drawing.Point(13, 170);
            this.labLopSH.Name = "labLopSH";
            this.labLopSH.Size = new System.Drawing.Size(55, 17);
            this.labLopSH.TabIndex = 2;
            this.labLopSH.Text = "Lớp SH";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(10, 108);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(45, 17);
            this.labName.TabIndex = 1;
            this.labName.Text = "Name";
            // 
            // labMSSV
            // 
            this.labMSSV.AutoSize = true;
            this.labMSSV.Location = new System.Drawing.Point(7, 46);
            this.labMSSV.Name = "labMSSV";
            this.labMSSV.Size = new System.Drawing.Size(46, 17);
            this.labMSSV.TabIndex = 0;
            this.labMSSV.Text = "MSSV";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 355);
            this.Controls.Add(this.groupTTSV);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupTTSV.ResumeLayout(false);
            this.groupTTSV.PerformLayout();
            this.groupGender.ResumeLayout(false);
            this.groupGender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupTTSV;
        private System.Windows.Forms.ComboBox cbbLSH2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.GroupBox groupGender;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labLopSH;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labMSSV;
    }
}