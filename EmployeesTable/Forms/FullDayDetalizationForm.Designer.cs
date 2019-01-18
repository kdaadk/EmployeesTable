using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    partial class FullDayDetalizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullDayDetalizationForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.btDeleteSelectRow = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgvFullDayDetalization = new System.Windows.Forms.DataGridView();
            this.workDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.used = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFullDayDetalization)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btAdd,
            this.editBtn,
            this.btDeleteSelectRow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btAdd
            // 
            this.btAdd.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.Image")));
            this.btAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(79, 22);
            this.btAdd.Text = "Добавить";
            this.btAdd.ToolTipText = "Добавить запись";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(107, 22);
            this.editBtn.Text = "Редактировать";
            this.editBtn.ToolTipText = "Редактировать выбранную запись";
            this.editBtn.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDeleteSelectRow
            // 
            this.btDeleteSelectRow.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteSelectRow.Image")));
            this.btDeleteSelectRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDeleteSelectRow.Name = "btDeleteSelectRow";
            this.btDeleteSelectRow.Size = new System.Drawing.Size(71, 22);
            this.btDeleteSelectRow.Text = "Удалить";
            this.btDeleteSelectRow.ToolTipText = "Удалить выбранную запись";
            this.btDeleteSelectRow.Click += new System.EventHandler(this.btDeleteSelectRow_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 262);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgvFullDayDetalization
            // 
            this.dgvFullDayDetalization.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workDate,
            this.payment,
            this.hours,
            this.used,
            this.usedDate,
            this.comment});
            this.dgvFullDayDetalization.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvFullDayDetalization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFullDayDetalization.Location = new System.Drawing.Point(0, 25);
            this.dgvFullDayDetalization.Name = "dgvFullDayDetalization";
            this.dgvFullDayDetalization.ReadOnly = true;
            this.dgvFullDayDetalization.Size = new System.Drawing.Size(800, 237);
            this.dgvFullDayDetalization.TabIndex = 2;
            // 
            // workDate
            // 
            this.workDate.HeaderText = "Дата работы";
            this.workDate.Name = "workDate";
            this.workDate.ReadOnly = true;
            // 
            // payment
            // 
            this.payment.HeaderText = "Оплата/Отгул";
            this.payment.Name = "payment";
            this.payment.ReadOnly = true;
            // 
            // hours
            // 
            this.hours.HeaderText = "Кол-во часов";
            this.hours.Name = "hours";
            this.hours.ReadOnly = true;
            // 
            // used
            // 
            this.used.HeaderText = "Использован?";
            this.used.Name = "used";
            this.used.ReadOnly = true;
            // 
            // usedDate
            // 
            this.usedDate.HeaderText = "Дата отдыха";
            this.usedDate.Name = "usedDate";
            this.usedDate.ReadOnly = true;
            // 
            // comment
            // 
            this.comment.HeaderText = "Комментарий";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            // 
            // FullDayDetalizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 284);
            this.Controls.Add(this.dgvFullDayDetalization);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FullDayDetalizationForm";
            this.Text = id;
            this.Load += new System.EventHandler(this.EmployeeFullDayDetalizationForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFullDayDetalization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btAdd;
        private StatusStrip statusStrip1;
        private DataGridView dgvFullDayDetalization;
        private ToolStripButton btDeleteSelectRow;
        private DataGridViewTextBoxColumn workDate;
        private DataGridViewTextBoxColumn payment;
        private DataGridViewTextBoxColumn hours;
        private DataGridViewTextBoxColumn used;
        private DataGridViewTextBoxColumn usedDate;
        private DataGridViewTextBoxColumn comment;
        private ToolStripButton editBtn;
    }
}

