using System.Windows.Forms;

namespace EmployeesTable.Feature.AddEmployee
{
    partial class AddEmployeeDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEmployeeDataForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFired = new System.Windows.Forms.CheckBox();
            this.lbOffice = new System.Windows.Forms.Label();
            this.tbOffice = new System.Windows.Forms.TextBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lbFired = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFired);
            this.groupBox1.Controls.Add(this.lbOffice);
            this.groupBox1.Controls.Add(this.tbOffice);
            this.groupBox1.Controls.Add(this.lbFullName);
            this.groupBox1.Controls.Add(this.tbFullName);
            this.groupBox1.Controls.Add(this.lbComment);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.lbFired);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сотрудник";
            // 
            // cbFired
            // 
            this.cbFired.AutoSize = true;
            this.cbFired.Location = new System.Drawing.Point(119, 101);
            this.cbFired.Name = "cbFired";
            this.cbFired.Size = new System.Drawing.Size(15, 14);
            this.cbFired.TabIndex = 3;
            this.cbFired.UseVisualStyleBackColor = true;
            // 
            // lbOffice
            // 
            this.lbOffice.AutoSize = true;
            this.lbOffice.Location = new System.Drawing.Point(7, 49);
            this.lbOffice.Name = "lbOffice";
            this.lbOffice.Size = new System.Drawing.Size(111, 13);
            this.lbOffice.TabIndex = 1;
            this.lbOffice.Text = "Представительство:";
            // 
            // tbOffice
            // 
            this.tbOffice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOffice.Location = new System.Drawing.Point(119, 47);
            this.tbOffice.Name = "tbOffice";
            this.tbOffice.Size = new System.Drawing.Size(211, 20);
            this.tbOffice.TabIndex = 1;
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.Location = new System.Drawing.Point(7, 23);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(37, 13);
            this.lbFullName.TabIndex = 0;
            this.lbFullName.Text = "ФИО:";
            // 
            // tbFullName
            // 
            this.tbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFullName.Location = new System.Drawing.Point(119, 21);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(211, 20);
            this.tbFullName.TabIndex = 0;
            // 
            // lbComment
            // 
            this.lbComment.Location = new System.Drawing.Point(7, 76);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(82, 13);
            this.lbComment.TabIndex = 2;
            this.lbComment.Text = "Комментарий:";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(119, 73);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(211, 20);
            this.tbComment.TabIndex = 2;
            // 
            // lbFired
            // 
            this.lbFired.Location = new System.Drawing.Point(7, 101);
            this.lbFired.Name = "lbFired";
            this.lbFired.Size = new System.Drawing.Size(61, 17);
            this.lbFired.TabIndex = 3;
            this.lbFired.Text = "Уволен:";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Location = new System.Drawing.Point(201, 139);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Отмена";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Location = new System.Drawing.Point(120, 139);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // AddEmployeeDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 170);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEmployeeDataForm";
            this.Load += new System.EventHandler(this.AddDataToDb_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label lbOffice;
        private System.Windows.Forms.TextBox tbOffice;
        private System.Windows.Forms.Label lbComment;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lbFired;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
        private CheckBox cbFired;
    }
}