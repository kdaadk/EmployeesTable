﻿using System.Windows.Forms;

namespace EmployeesTable.Forms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFaired = new System.Windows.Forms.CheckBox();
            this.lbRepresentation = new System.Windows.Forms.Label();
            this.tbRepresentation = new System.Windows.Forms.TextBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lbFaired = new System.Windows.Forms.Label();
            this.btCancelbtCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFaired);
            this.groupBox1.Controls.Add(this.lbRepresentation);
            this.groupBox1.Controls.Add(this.tbRepresentation);
            this.groupBox1.Controls.Add(this.lbFullName);
            this.groupBox1.Controls.Add(this.tbFullName);
            this.groupBox1.Controls.Add(this.lbComment);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.lbFaired);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сотрудник";
            // 
            // cbFaired
            // 
            this.cbFaired.AutoSize = true;
            this.cbFaired.Location = new System.Drawing.Point(119, 101);
            this.cbFaired.Name = "cbFaired";
            this.cbFaired.Size = new System.Drawing.Size(15, 14);
            this.cbFaired.TabIndex = 4;
            this.cbFaired.UseVisualStyleBackColor = true;
            // 
            // lbRepresentation
            // 
            this.lbRepresentation.AutoSize = true;
            this.lbRepresentation.Location = new System.Drawing.Point(7, 49);
            this.lbRepresentation.Name = "lbRepresentation";
            this.lbRepresentation.Size = new System.Drawing.Size(111, 13);
            this.lbRepresentation.TabIndex = 1;
            this.lbRepresentation.Text = "Представительство:";
            // 
            // tbRepresentation
            // 
            this.tbRepresentation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRepresentation.Location = new System.Drawing.Point(119, 47);
            this.tbRepresentation.Name = "tbRepresentation";
            this.tbRepresentation.Size = new System.Drawing.Size(211, 20);
            this.tbRepresentation.TabIndex = 1;
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
            // lbFaired
            // 
            this.lbFaired.Location = new System.Drawing.Point(7, 101);
            this.lbFaired.Name = "lbFaired";
            this.lbFaired.Size = new System.Drawing.Size(61, 17);
            this.lbFaired.TabIndex = 3;
            this.lbFaired.Text = "Уволен:";
            // 
            // btCancelbtCancel
            // 
            this.btCancelbtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelbtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelbtCancel.Location = new System.Drawing.Point(201, 139);
            this.btCancelbtCancel.Name = "btCancelbtCancel";
            this.btCancelbtCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancelbtCancel.TabIndex = 1;
            this.btCancelbtCancel.Text = "Отмена";
            this.btCancelbtCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Location = new System.Drawing.Point(120, 139);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 2;
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
            this.Controls.Add(this.btCancelbtCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddEmployeeDataForm";
            this.Text = "Запись сотрудника";
            this.Load += new System.EventHandler(this.AddDataToDb_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label lbRepresentation;
        private System.Windows.Forms.TextBox tbRepresentation;
        private System.Windows.Forms.Label lbComment;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lbFaired;
        private System.Windows.Forms.Button btCancelbtCancel;
        private System.Windows.Forms.Button btOK;
        private CheckBox cbFaired;
    }
}