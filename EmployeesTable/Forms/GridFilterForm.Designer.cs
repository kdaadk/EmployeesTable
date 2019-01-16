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
            this.lbDaysNumberFrom = new System.Windows.Forms.Label();
            this.lbDaysNumberTo = new System.Windows.Forms.Label();
            this.nudDaysNumberFrom = new System.Windows.Forms.NumericUpDown();
            this.nudDaysNumberTo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysNumberFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDaysNumberTo)).BeginInit();
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
            this.btCancelbtCancel.TabIndex = 5;
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
            this.cbFiredEmployees.TabIndex = 0;
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
            this.cbRepresentation.TabIndex = 1;
            this.cbRepresentation.Text = "Все";
            // 
            // lbDaysNumberFrom
            // 
            this.lbDaysNumberFrom.AutoSize = true;
            this.lbDaysNumberFrom.Location = new System.Drawing.Point(20, 78);
            this.lbDaysNumberFrom.Name = "lbDaysNumberFrom";
            this.lbDaysNumberFrom.Size = new System.Drawing.Size(107, 13);
            this.lbDaysNumberFrom.TabIndex = 9;
            this.lbDaysNumberFrom.Text = "Количество дней от";
            // 
            // lbDaysNumberTo
            // 
            this.lbDaysNumberTo.AutoSize = true;
            this.lbDaysNumberTo.Location = new System.Drawing.Point(180, 78);
            this.lbDaysNumberTo.Name = "lbDaysNumberTo";
            this.lbDaysNumberTo.Size = new System.Drawing.Size(19, 13);
            this.lbDaysNumberTo.TabIndex = 10;
            this.lbDaysNumberTo.Text = "до";
            // 
            // nudDaysNumberFrom
            // 
            this.nudDaysNumberFrom.Location = new System.Drawing.Point(138, 76);
            this.nudDaysNumberFrom.Name = "nudDaysNumberFrom";
            this.nudDaysNumberFrom.Size = new System.Drawing.Size(36, 20);
            this.nudDaysNumberFrom.TabIndex = 2;
            // 
            // nudDaysNumberTo
            // 
            this.nudDaysNumberTo.Location = new System.Drawing.Point(205, 76);
            this.nudDaysNumberTo.Name = "nudDaysNumberTo";
            this.nudDaysNumberTo.Size = new System.Drawing.Size(36, 20);
            this.nudDaysNumberTo.TabIndex = 3;
            this.nudDaysNumberTo.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GridFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 147);
            this.Controls.Add(this.nudDaysNumberTo);
            this.Controls.Add(this.nudDaysNumberFrom);
            this.Controls.Add(this.lbDaysNumberTo);
            this.Controls.Add(this.lbDaysNumberFrom);
            this.Controls.Add(this.cbRepresentation);
            this.Controls.Add(this.lbRepresentation);
            this.Controls.Add(this.cbFiredEmployees);
            this.Controls.Add(this.lbFiredEmployees);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancelbtCancel);
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
        private System.Windows.Forms.Label lbRepresentation;
        private System.Windows.Forms.ComboBox cbRepresentation;
        private System.Windows.Forms.Label lbDaysNumberFrom;
        private System.Windows.Forms.Label lbDaysNumberTo;
        private System.Windows.Forms.NumericUpDown nudDaysNumberFrom;
        private System.Windows.Forms.NumericUpDown nudDaysNumberTo;
    }
}