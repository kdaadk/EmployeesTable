using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    partial class EmployeeTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeTableForm));
            this.stripMenu = new System.Windows.Forms.ToolStrip();
            this.tstbFullNameSearcher = new System.Windows.Forms.ToolStripTextBox();
            this.btAdd = new System.Windows.Forms.ToolStripButton();
            this.btDeleteSelectRow = new System.Windows.Forms.ToolStripButton();
            this.editBtn = new System.Windows.Forms.ToolStripButton();
            this.btImportOrder = new System.Windows.Forms.ToolStripButton();
            this.btExportTable = new System.Windows.Forms.ToolStripButton();
            this.stripStatus = new System.Windows.Forms.StatusStrip();
            this.pbStatusImportOrder = new System.Windows.Forms.ToolStripProgressBar();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoursFullDaysBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.hoursPartialDaysBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnGridFilter = new System.Windows.Forms.ToolStripButton();
            this.stripMenu.SuspendLayout();
            this.stripStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // stripMenu
            // 
            this.stripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbFullNameSearcher,
            this.btAdd,
            this.btDeleteSelectRow,
            this.editBtn,
            this.btImportOrder,
            this.btExportTable,
            this.BtnGridFilter});
            this.stripMenu.Location = new System.Drawing.Point(0, 0);
            this.stripMenu.Name = "stripMenu";
            this.stripMenu.Size = new System.Drawing.Size(795, 25);
            this.stripMenu.TabIndex = 0;
            // 
            // tstbFullNameSearcher
            // 
            this.tstbFullNameSearcher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbFullNameSearcher.Name = "tstbFullNameSearcher";
            this.tstbFullNameSearcher.Size = new System.Drawing.Size(100, 25);
            this.tstbFullNameSearcher.TextChanged += new System.EventHandler(this.tstbFullNameSearcher_TextChanged);
            // 
            // btAdd
            // 
            this.btAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(63, 22);
            this.btAdd.Text = "Добавить";
            this.btAdd.ToolTipText = "Добавить запись";
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDeleteSelectRow
            // 
            this.btDeleteSelectRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btDeleteSelectRow.Name = "btDeleteSelectRow";
            this.btDeleteSelectRow.Size = new System.Drawing.Size(55, 22);
            this.btDeleteSelectRow.Text = "Удалить";
            this.btDeleteSelectRow.ToolTipText = "Удалить выбранную запись";
            this.btDeleteSelectRow.Click += new System.EventHandler(this.btDeleteSelectRow_Click);
            // 
            // editBtn
            // 
            this.editBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(91, 22);
            this.editBtn.Text = "Редактировать";
            this.editBtn.ToolTipText = "Редактировать выбранную запись";
            this.editBtn.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btImportOrder
            // 
            this.btImportOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btImportOrder.Name = "btImportOrder";
            this.btImportOrder.Size = new System.Drawing.Size(65, 22);
            this.btImportOrder.Text = "Загрузить";
            this.btImportOrder.ToolTipText = "Загрузить приказ с диска";
            this.btImportOrder.Click += new System.EventHandler(this.btLoadOrder_Click);
            // 
            // btExportTable
            // 
            this.btExportTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btExportTable.Name = "btExportTable";
            this.btExportTable.Size = new System.Drawing.Size(68, 22);
            this.btExportTable.Text = "Выгрузить";
            this.btExportTable.ToolTipText = "Выгрузить данные из таблицы";
            this.btExportTable.Click += new System.EventHandler(this.btExportTable_Click);
            // 
            // stripStatus
            // 
            this.stripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbStatusImportOrder});
            this.stripStatus.Location = new System.Drawing.Point(0, 262);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(795, 22);
            this.stripStatus.TabIndex = 3;
            // 
            // pbStatusImportOrder
            // 
            this.pbStatusImportOrder.Name = "pbStatusImportOrder";
            this.pbStatusImportOrder.Size = new System.Drawing.Size(100, 16);
            this.pbStatusImportOrder.Visible = false;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullName,
            this.representation,
            this.hoursFullDaysBtn,
            this.hoursPartialDaysBtn,
            this.comment});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 25);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.Size = new System.Drawing.Size(795, 237);
            this.dgvEmployees.TabIndex = 2;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeesDataGridView_CellContentClick);
            // 
            // fullName
            // 
            this.fullName.HeaderText = "ФИО";
            this.fullName.Name = "fullName";
            this.fullName.Width = 200;
            // 
            // representation
            // 
            this.representation.HeaderText = "Представительство";
            this.representation.Name = "representation";
            this.representation.Width = 200;
            // 
            // hoursFullDaysBtn
            // 
            this.hoursFullDaysBtn.HeaderText = "Полные дни";
            this.hoursFullDaysBtn.Name = "hoursFullDaysBtn";
            // 
            // hoursPartialDaysBtn
            // 
            this.hoursPartialDaysBtn.HeaderText = "Неполные дни";
            this.hoursPartialDaysBtn.Name = "hoursPartialDaysBtn";
            // 
            // comment
            // 
            this.comment.HeaderText = "Комментарий";
            this.comment.Name = "comment";
            this.comment.Width = 150;
            // 
            // BtnGridFilter
            // 
            this.BtnGridFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnGridFilter.Image = ((System.Drawing.Image)(resources.GetObject("BtnGridFilter.Image")));
            this.BtnGridFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGridFilter.Name = "BtnGridFilter";
            this.BtnGridFilter.Size = new System.Drawing.Size(52, 22);
            this.BtnGridFilter.Text = "Фильтр";
            this.BtnGridFilter.Click += new System.EventHandler(this.BtnGridFilter_Click);
            // 
            // EmployeeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 284);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.stripStatus);
            this.Controls.Add(this.stripMenu);
            this.Name = "EmployeeTableForm";
            this.Text = "Реестр сотрудников";
            this.Load += new System.EventHandler(this.EmployeeTableForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeTableForm_FormClosing);
            this.stripMenu.ResumeLayout(false);
            this.stripMenu.PerformLayout();
            this.stripStatus.ResumeLayout(false);
            this.stripStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip stripMenu;
        private ToolStripButton btAdd;
        private StatusStrip stripStatus;
        private DataGridView dgvEmployees;
        private ToolStripButton btDeleteSelectRow;
        private DataGridViewTextBoxColumn fullName;
        private DataGridViewTextBoxColumn representation;
        private DataGridViewButtonColumn hoursFullDaysBtn;
        private DataGridViewButtonColumn hoursPartialDaysBtn;
        private DataGridViewTextBoxColumn comment;
        private ToolStripButton editBtn;
        private ToolStripButton btImportOrder;
        private ToolStripButton btExportTable;
        private ToolStripTextBox tstbFullNameSearcher;
        private ToolStripProgressBar pbStatusImportOrder;
        private ToolStripButton BtnGridFilter;
    }
}

