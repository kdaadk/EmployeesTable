using System;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    partial class AddFullDayDetalizationDataForm
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
            this.cbUsed = new System.Windows.Forms.ComboBox();
            this.cbPayment = new System.Windows.Forms.ComboBox();
            this.lbComment = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.tpRestDate = new System.Windows.Forms.DateTimePicker();
            this.lbRestDate = new System.Windows.Forms.Label();
            this.tpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lbPayment = new System.Windows.Forms.Label();
            this.lbWorkDate = new System.Windows.Forms.Label();
            this.lbHours = new System.Windows.Forms.Label();
            this.tbHours = new System.Windows.Forms.TextBox();
            this.lbRest = new System.Windows.Forms.Label();
            this.btCancelbtCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUsed);
            this.groupBox1.Controls.Add(this.cbPayment);
            this.groupBox1.Controls.Add(this.lbComment);
            this.groupBox1.Controls.Add(this.tbComment);
            this.groupBox1.Controls.Add(this.tpRestDate);
            this.groupBox1.Controls.Add(this.lbRestDate);
            this.groupBox1.Controls.Add(this.tpWorkDate);
            this.groupBox1.Controls.Add(this.lbPayment);
            this.groupBox1.Controls.Add(this.lbWorkDate);
            this.groupBox1.Controls.Add(this.lbHours);
            this.groupBox1.Controls.Add(this.tbHours);
            this.groupBox1.Controls.Add(this.lbRest);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Детализация";
            // 
            // cbUsed
            // 
            this.cbUsed.FormattingEnabled = true;
            this.cbUsed.Items.AddRange(new object[] {
            "Да",
            "Частично",
            "Нет"});
            this.cbUsed.Location = new System.Drawing.Point(90, 99);
            this.cbUsed.Name = "cbUsed";
            this.cbUsed.Size = new System.Drawing.Size(130, 21);
            this.cbUsed.TabIndex = 10;
            // 
            // cbPayment
            // 
            this.cbPayment.FormattingEnabled = true;
            this.cbPayment.Items.AddRange(new object[] {
            "Оплата",
            "Отгул"});
            this.cbPayment.Location = new System.Drawing.Point(90, 45);
            this.cbPayment.Name = "cbPayment";
            this.cbPayment.Size = new System.Drawing.Size(130, 21);
            this.cbPayment.TabIndex = 9;
            // 
            // lbComment
            // 
            this.lbComment.Location = new System.Drawing.Point(7, 154);
            this.lbComment.Name = "lbComment";
            this.lbComment.Size = new System.Drawing.Size(81, 23);
            this.lbComment.TabIndex = 7;
            this.lbComment.Text = "Комментарий:";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(90, 151);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(130, 20);
            this.tbComment.TabIndex = 8;
            // 
            // tpRestDate
            // 
            this.tpRestDate.CustomFormat = " ";
            this.tpRestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tpRestDate.Location = new System.Drawing.Point(90, 125);
            this.tpRestDate.Name = "tpRestDate";
            this.tpRestDate.Size = new System.Drawing.Size(130, 20);
            this.tpRestDate.TabIndex = 6;
            this.tpRestDate.ValueChanged += new System.EventHandler(this.tpUsedDate_ValueChanged);
            // 
            // lbRestDate
            // 
            this.lbRestDate.AutoSize = true;
            this.lbRestDate.Location = new System.Drawing.Point(8, 128);
            this.lbRestDate.Name = "lbRestDate";
            this.lbRestDate.Size = new System.Drawing.Size(75, 13);
            this.lbRestDate.TabIndex = 5;
            this.lbRestDate.Text = "Дата отдыха:";
            // 
            // tpWorkDate
            // 
            this.tpWorkDate.CustomFormat = "dd.MM.yyyy";
            this.tpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tpWorkDate.Location = new System.Drawing.Point(90, 19);
            this.tpWorkDate.Name = "tpWorkDate";
            this.tpWorkDate.Size = new System.Drawing.Size(130, 20);
            this.tpWorkDate.TabIndex = 4;
            // 
            // lbPayment
            // 
            this.lbPayment.AutoSize = true;
            this.lbPayment.Location = new System.Drawing.Point(7, 49);
            this.lbPayment.Name = "lbPayment";
            this.lbPayment.Size = new System.Drawing.Size(81, 13);
            this.lbPayment.TabIndex = 1;
            this.lbPayment.Text = "Оплата/Отгул:";
            // 
            // lbWorkDate
            // 
            this.lbWorkDate.AutoSize = true;
            this.lbWorkDate.Location = new System.Drawing.Point(8, 23);
            this.lbWorkDate.Name = "lbWorkDate";
            this.lbWorkDate.Size = new System.Drawing.Size(76, 13);
            this.lbWorkDate.TabIndex = 0;
            this.lbWorkDate.Text = "Дата работы:";
            // 
            // lbHours
            // 
            this.lbHours.Location = new System.Drawing.Point(7, 76);
            this.lbHours.Name = "lbHours";
            this.lbHours.Size = new System.Drawing.Size(51, 13);
            this.lbHours.TabIndex = 2;
            this.lbHours.Text = "Часы:";
            // 
            // tbHours
            // 
            this.tbHours.Location = new System.Drawing.Point(90, 73);
            this.tbHours.Name = "tbHours";
            this.tbHours.Size = new System.Drawing.Size(130, 20);
            this.tbHours.TabIndex = 2;
            this.tbHours.Text = "8";
            // 
            // lbRest
            // 
            this.lbRest.Location = new System.Drawing.Point(7, 102);
            this.lbRest.Name = "lbRest";
            this.lbRest.Size = new System.Drawing.Size(51, 23);
            this.lbRest.TabIndex = 3;
            this.lbRest.Text = "Использован?";
            // 
            // btCancelbtCancel
            // 
            this.btCancelbtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelbtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelbtCancel.Location = new System.Drawing.Point(157, 211);
            this.btCancelbtCancel.Name = "btCancelbtCancel";
            this.btCancelbtCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancelbtCancel.TabIndex = 1;
            this.btCancelbtCancel.Text = "Отмена";
            this.btCancelbtCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Location = new System.Drawing.Point(76, 211);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // AddFullDayDetalizationDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 246);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancelbtCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddFullDayDetalizationDataForm";
            this.Text = "Запись детализации";
            this.Load += new System.EventHandler(this.AddDataToDb_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbWorkDate;
        private System.Windows.Forms.Label lbPayment;
        private System.Windows.Forms.Label lbHours;
        private System.Windows.Forms.TextBox tbHours;
        private System.Windows.Forms.Label lbRest;
        private System.Windows.Forms.Button btCancelbtCancel;
        private System.Windows.Forms.Button btOK;
        private DateTimePicker tpWorkDate;
        private DateTimePicker tpRestDate;
        private Label lbRestDate;
        private Label lbComment;
        private TextBox tbComment;
        private ComboBox cbUsed;
        private ComboBox cbPayment;
    }
}