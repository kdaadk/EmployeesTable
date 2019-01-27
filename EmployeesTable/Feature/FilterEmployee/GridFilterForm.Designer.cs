using System.Windows.Forms;

namespace EmployeesTable.Feature.FilterEmployee
{
    partial class GridFilterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridFilterForm));
            this.btOK = new System.Windows.Forms.Button();
            this.btCancelbtCancel = new System.Windows.Forms.Button();
            this.lbFiredEmployees = new System.Windows.Forms.Label();
            this.cbFiredEmployees = new System.Windows.Forms.CheckBox();
            this.lbOffice = new System.Windows.Forms.Label();
            this.lbDaysNumberFrom = new System.Windows.Forms.Label();
            this.lbDaysNumberTo = new System.Windows.Forms.Label();
            this.nudDaysNumberFrom = new System.Windows.Forms.NumericUpDown();
            this.nudDaysNumberTo = new System.Windows.Forms.NumericUpDown();
            this.clbOffice = new System.Windows.Forms.CheckedListBox();
            this.cbOffice = new System.Windows.Forms.ComboBox();
            this.cbAnyDaysNumber = new System.Windows.Forms.CheckBox();
            this.lbAnyDaysNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysNumberFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysNumberTo)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Location = new System.Drawing.Point(163, 562);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancelbtCancel
            // 
            this.btCancelbtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelbtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelbtCancel.Location = new System.Drawing.Point(244, 562);
            this.btCancelbtCancel.Name = "btCancelbtCancel";
            this.btCancelbtCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancelbtCancel.TabIndex = 8;
            this.btCancelbtCancel.Text = "Отмена";
            this.btCancelbtCancel.UseVisualStyleBackColor = true;
            // 
            // lbFiredEmployees
            // 
            this.lbFiredEmployees.AutoSize = true;
            this.lbFiredEmployees.Location = new System.Drawing.Point(21, 20);
            this.lbFiredEmployees.Name = "lbFiredEmployees";
            this.lbFiredEmployees.Size = new System.Drawing.Size(113, 13);
            this.lbFiredEmployees.TabIndex = 10;
            this.lbFiredEmployees.Text = "Показать уволенных";
            // 
            // cbFiredEmployees
            // 
            this.cbFiredEmployees.AutoSize = true;
            this.cbFiredEmployees.Location = new System.Drawing.Point(135, 20);
            this.cbFiredEmployees.Name = "cbFiredEmployees";
            this.cbFiredEmployees.Size = new System.Drawing.Size(15, 14);
            this.cbFiredEmployees.TabIndex = 1;
            this.cbFiredEmployees.UseVisualStyleBackColor = true;
            // 
            // lbOffice
            // 
            this.lbOffice.AutoSize = true;
            this.lbOffice.Location = new System.Drawing.Point(20, 110);
            this.lbOffice.Name = "lbOffice";
            this.lbOffice.Size = new System.Drawing.Size(108, 13);
            this.lbOffice.TabIndex = 10;
            this.lbOffice.Text = "Представительство";
            // 
            // lbDaysNumberFrom
            // 
            this.lbDaysNumberFrom.AutoSize = true;
            this.lbDaysNumberFrom.Location = new System.Drawing.Point(21, 50);
            this.lbDaysNumberFrom.Name = "lbDaysNumberFrom";
            this.lbDaysNumberFrom.Size = new System.Drawing.Size(107, 13);
            this.lbDaysNumberFrom.TabIndex = 10;
            this.lbDaysNumberFrom.Text = "Количество дней от";
            // 
            // lbDaysNumberTo
            // 
            this.lbDaysNumberTo.AutoSize = true;
            this.lbDaysNumberTo.Location = new System.Drawing.Point(177, 50);
            this.lbDaysNumberTo.Name = "lbDaysNumberTo";
            this.lbDaysNumberTo.Size = new System.Drawing.Size(19, 13);
            this.lbDaysNumberTo.TabIndex = 2;
            this.lbDaysNumberTo.Text = "до";
            // 
            // nudDaysNumberFrom
            // 
            this.nudDaysNumberFrom.Enabled = false;
            this.nudDaysNumberFrom.Location = new System.Drawing.Point(135, 48);
            this.nudDaysNumberFrom.Name = "nudDaysNumberFrom";
            this.nudDaysNumberFrom.Size = new System.Drawing.Size(36, 20);
            this.nudDaysNumberFrom.TabIndex = 2;
            // 
            // nudDaysNumberTo
            // 
            this.nudDaysNumberTo.Enabled = false;
            this.nudDaysNumberTo.Location = new System.Drawing.Point(202, 48);
            this.nudDaysNumberTo.Name = "nudDaysNumberTo";
            this.nudDaysNumberTo.Size = new System.Drawing.Size(36, 20);
            this.nudDaysNumberTo.TabIndex = 3;
            // 
            // clbOffice
            // 
            this.clbOffice.FormattingEnabled = true;
            this.clbOffice.Location = new System.Drawing.Point(24, 137);
            this.clbOffice.Name = "clbOffice";
            this.clbOffice.Size = new System.Drawing.Size(385, 409);
            this.clbOffice.TabIndex = 6;
            this.clbOffice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clOffice_MouseClick);
            // 
            // cbOffice
            // 
            this.cbOffice.FormattingEnabled = true;
            this.cbOffice.Items.AddRange(new object[] {
            "Все",
            "Выбрать из списка",
            "Центральный офис"});
            this.cbOffice.Location = new System.Drawing.Point(134, 107);
            this.cbOffice.Name = "cbOffice";
            this.cbOffice.Size = new System.Drawing.Size(275, 21);
            this.cbOffice.TabIndex = 5;
            this.cbOffice.SelectedIndexChanged += new System.EventHandler(this.cbOffice_SelectedIndexChanged);
            // 
            // cbAnyDaysNumber
            // 
            this.cbAnyDaysNumber.AutoSize = true;
            this.cbAnyDaysNumber.Location = new System.Drawing.Point(135, 80);
            this.cbAnyDaysNumber.Name = "cbAnyDaysNumber";
            this.cbAnyDaysNumber.Size = new System.Drawing.Size(15, 14);
            this.cbAnyDaysNumber.TabIndex = 4;
            this.cbAnyDaysNumber.UseVisualStyleBackColor = true;
            this.cbAnyDaysNumber.CheckedChanged += new System.EventHandler(this.cbAnyDaysNumber_CheckedChanged);
            // 
            // lbAnyDaysNumber
            // 
            this.lbAnyDaysNumber.AutoSize = true;
            this.lbAnyDaysNumber.Location = new System.Drawing.Point(21, 80);
            this.lbAnyDaysNumber.Name = "lbAnyDaysNumber";
            this.lbAnyDaysNumber.Size = new System.Drawing.Size(104, 13);
            this.lbAnyDaysNumber.TabIndex = 10;
            this.lbAnyDaysNumber.Text = "Любое кол-во дней";
            // 
            // GridFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 597);
            this.Controls.Add(this.cbAnyDaysNumber);
            this.Controls.Add(this.lbAnyDaysNumber);
            this.Controls.Add(this.cbOffice);
            this.Controls.Add(this.clbOffice);
            this.Controls.Add(this.nudDaysNumberTo);
            this.Controls.Add(this.nudDaysNumberFrom);
            this.Controls.Add(this.lbDaysNumberTo);
            this.Controls.Add(this.lbDaysNumberFrom);
            this.Controls.Add(this.lbOffice);
            this.Controls.Add(this.cbFiredEmployees);
            this.Controls.Add(this.lbFiredEmployees);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancelbtCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GridFilterForm";
            this.Text = "Фильтр";
            this.Load += new System.EventHandler(this.GridFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysNumberFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysNumberTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancelbtCancel;
        private System.Windows.Forms.Label lbFiredEmployees;
        private System.Windows.Forms.CheckBox cbFiredEmployees;
        private System.Windows.Forms.Label lbOffice;
        private System.Windows.Forms.Label lbDaysNumberFrom;
        private System.Windows.Forms.Label lbDaysNumberTo;
        private System.Windows.Forms.NumericUpDown nudDaysNumberFrom;
        private System.Windows.Forms.NumericUpDown nudDaysNumberTo;
        private System.Windows.Forms.CheckedListBox clbOffice;
        private ComboBox cbOffice;
        private CheckBox cbAnyDaysNumber;
        private Label lbAnyDaysNumber;
    }
}