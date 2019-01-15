namespace EmployeesTable.Forms
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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancelbtCancel = new System.Windows.Forms.Button();
            this.lbFiredEmployees = new System.Windows.Forms.Label();
            this.cbFiredEmployees = new System.Windows.Forms.CheckBox();
            this.lbRepresentation = new System.Windows.Forms.Label();
            this.cbRepresentation = new System.Windows.Forms.ComboBox();
            this.lbHoursNumberFrom = new System.Windows.Forms.Label();
            this.lbHoursNumberTo = new System.Windows.Forms.Label();
            this.nudHoursNumberFrom = new System.Windows.Forms.NumericUpDown();
            this.nudHoursNumberTo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursNumberFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursNumberTo)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Location = new System.Drawing.Point(184, 112);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancelbtCancel
            // 
            this.btCancelbtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelbtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelbtCancel.Location = new System.Drawing.Point(265, 112);
            this.btCancelbtCancel.Name = "btCancelbtCancel";
            this.btCancelbtCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancelbtCancel.TabIndex = 3;
            this.btCancelbtCancel.Text = "Отмена";
            this.btCancelbtCancel.UseVisualStyleBackColor = true;
            // 
            // lbFiredEmployees
            // 
            this.lbFiredEmployees.AutoSize = true;
            this.lbFiredEmployees.Location = new System.Drawing.Point(20, 20);
            this.lbFiredEmployees.Name = "lbFiredEmployees";
            this.lbFiredEmployees.Size = new System.Drawing.Size(113, 13);
            this.lbFiredEmployees.TabIndex = 5;
            this.lbFiredEmployees.Text = "Показать уволенных";
            // 
            // cbFiredEmployees
            // 
            this.cbFiredEmployees.AutoSize = true;
            this.cbFiredEmployees.Location = new System.Drawing.Point(138, 20);
            this.cbFiredEmployees.Name = "cbFiredEmployees";
            this.cbFiredEmployees.Size = new System.Drawing.Size(15, 14);
            this.cbFiredEmployees.TabIndex = 6;
            this.cbFiredEmployees.UseVisualStyleBackColor = true;
            // 
            // lbRepresentation
            // 
            this.lbRepresentation.AutoSize = true;
            this.lbRepresentation.Location = new System.Drawing.Point(20, 48);
            this.lbRepresentation.Name = "lbRepresentation";
            this.lbRepresentation.Size = new System.Drawing.Size(108, 13);
            this.lbRepresentation.TabIndex = 7;
            this.lbRepresentation.Text = "Представительство";
            // 
            // cbRepresentation
            // 
            this.cbRepresentation.FormattingEnabled = true;
            this.cbRepresentation.Items.AddRange(new object[] {
            "Все"});
            this.cbRepresentation.Location = new System.Drawing.Point(138, 45);
            this.cbRepresentation.Name = "cbRepresentation";
            this.cbRepresentation.Size = new System.Drawing.Size(270, 21);
            this.cbRepresentation.TabIndex = 8;
            this.cbRepresentation.Text = "Все";
            // 
            // lbHoursNumberFrom
            // 
            this.lbHoursNumberFrom.AutoSize = true;
            this.lbHoursNumberFrom.Location = new System.Drawing.Point(20, 78);
            this.lbHoursNumberFrom.Name = "lbHoursNumberFrom";
            this.lbHoursNumberFrom.Size = new System.Drawing.Size(112, 13);
            this.lbHoursNumberFrom.TabIndex = 9;
            this.lbHoursNumberFrom.Text = "Количество часов от";
            // 
            // lbHoursNumberTo
            // 
            this.lbHoursNumberTo.AutoSize = true;
            this.lbHoursNumberTo.Location = new System.Drawing.Point(180, 78);
            this.lbHoursNumberTo.Name = "lbHoursNumberTo";
            this.lbHoursNumberTo.Size = new System.Drawing.Size(19, 13);
            this.lbHoursNumberTo.TabIndex = 10;
            this.lbHoursNumberTo.Text = "до";
            // 
            // nudHoursNumberFrom
            // 
            this.nudHoursNumberFrom.Location = new System.Drawing.Point(138, 76);
            this.nudHoursNumberFrom.Name = "nudHoursNumberFrom";
            this.nudHoursNumberFrom.Size = new System.Drawing.Size(36, 20);
            this.nudHoursNumberFrom.TabIndex = 11;
            // 
            // nudHoursNumberTo
            // 
            this.nudHoursNumberTo.Location = new System.Drawing.Point(205, 76);
            this.nudHoursNumberTo.Name = "nudHoursNumberTo";
            this.nudHoursNumberTo.Size = new System.Drawing.Size(36, 20);
            this.nudHoursNumberTo.TabIndex = 12;
            this.nudHoursNumberTo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // GridFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 147);
            this.Controls.Add(this.nudHoursNumberTo);
            this.Controls.Add(this.nudHoursNumberFrom);
            this.Controls.Add(this.lbHoursNumberTo);
            this.Controls.Add(this.lbHoursNumberFrom);
            this.Controls.Add(this.cbRepresentation);
            this.Controls.Add(this.lbRepresentation);
            this.Controls.Add(this.cbFiredEmployees);
            this.Controls.Add(this.lbFiredEmployees);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancelbtCancel);
            this.Name = "GridFilterForm";
            this.Text = "Фильтр";
            this.Load += new System.EventHandler(this.GridFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursNumberFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursNumberTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancelbtCancel;
        private System.Windows.Forms.Label lbFiredEmployees;
        private System.Windows.Forms.CheckBox cbFiredEmployees;
        private System.Windows.Forms.Label lbRepresentation;
        private System.Windows.Forms.ComboBox cbRepresentation;
        private System.Windows.Forms.Label lbHoursNumberFrom;
        private System.Windows.Forms.Label lbHoursNumberTo;
        private System.Windows.Forms.NumericUpDown nudHoursNumberFrom;
        private System.Windows.Forms.NumericUpDown nudHoursNumberTo;
    }
}