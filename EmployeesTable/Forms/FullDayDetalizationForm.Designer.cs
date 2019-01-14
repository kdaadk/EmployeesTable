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
            this.btDeleteSelectRow = new System.Windows.Forms.ToolStripButton();
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.detalizationDataGridView = new System.Windows.Forms.DataGridView();
            this.workDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.used = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detalizationDataGridView)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(647, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btAdd
            // 
            this.btAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btAdd.Image = ((System.Drawing.Image)(resources.GetObject("btAdd.Image")));
            this.btAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(63, 22);
            this.btAdd.Text = "Добавить";
            this.btAdd.ToolTipText = "Добавить запись";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDeleteSelectRow
            // 
            this.btDeleteSelectRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btDeleteSelectRow.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteSelectRow.Image")));
            this.btDeleteSelectRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDeleteSelectRow.Name = "btDeleteSelectRow";
            this.btDeleteSelectRow.Size = new System.Drawing.Size(55, 22);
            this.btDeleteSelectRow.Text = "Удалить";
            this.btDeleteSelectRow.ToolTipText = "Удалить выбранную запись";
            this.btDeleteSelectRow.Click += new System.EventHandler(this.btDeleteSelectRow_Click);
            // 
            // editBtn
            // 
            this.editBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(91, 22);
            this.editBtn.Text = "Редактировать";
            this.editBtn.ToolTipText = "Редактировать выбранную запись";
            this.editBtn.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 262);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // detalizationDataGridView
            // 
            this.detalizationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detalizationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.workDate,
            this.payment,
            this.hours,
            this.used,
            this.usedDate,
            this.comment});
            this.detalizationDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detalizationDataGridView.Location = new System.Drawing.Point(0, 25);
            this.detalizationDataGridView.Name = "detalizationDataGridView";
            this.detalizationDataGridView.Size = new System.Drawing.Size(647, 237);
            this.detalizationDataGridView.TabIndex = 2;
            // 
            // workDate
            // 
            this.workDate.HeaderText = "Дата работы";
            this.workDate.Name = "workDate";
            // 
            // payment
            // 
            this.payment.HeaderText = "Оплата/Отгул";
            this.payment.Name = "payment";
            // 
            // hours
            // 
            this.hours.HeaderText = "Кол-во часов";
            this.hours.Name = "hours";
            // 
            // used
            // 
            this.used.HeaderText = "Использован?";
            this.used.Name = "used";
            // 
            // usedDate
            // 
            this.usedDate.HeaderText = "Дата отдыха";
            this.usedDate.Name = "usedDate";
            // 
            // comment
            // 
            this.comment.HeaderText = "Комментарий";
            this.comment.Name = "comment";
            // 
            // FullDayDetalizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 284);
            this.Controls.Add(this.detalizationDataGridView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FullDayDetalizationForm";
            this.Text = id;
            this.Load += new System.EventHandler(this.EmployeeFDetalizationForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detalizationDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btAdd;
        private StatusStrip statusStrip1;
        private DataGridView detalizationDataGridView;
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

