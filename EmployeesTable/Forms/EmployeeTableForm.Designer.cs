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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeTableForm));
            this.stripMenu = new System.Windows.Forms.ToolStrip();
            this.lbSearchIcon = new System.Windows.Forms.ToolStripLabel();
            this.tstbFullNameSearcher = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btAddEmployee = new System.Windows.Forms.ToolStripButton();
            this.btEditEmployee = new System.Windows.Forms.ToolStripButton();
            this.btDeleteEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btImportOrder = new System.Windows.Forms.ToolStripButton();
            this.btExportTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnGridFilter = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.stripStatus = new System.Windows.Forms.StatusStrip();
            this.slbEmployeesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbStatusImportOrder = new System.Windows.Forms.ToolStripProgressBar();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.office = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoursFullDaysBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.hoursPartialDaysBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stripMenu.SuspendLayout();
            this.stripStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // stripMenu
            // 
            this.stripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbSearchIcon,
            this.tstbFullNameSearcher,
            this.toolStripSeparator3,
            this.btAddEmployee,
            this.btEditEmployee,
            this.btDeleteEmployee,
            this.toolStripSeparator1,
            this.btImportOrder,
            this.btExportTable,
            this.toolStripSeparator2,
            this.BtnGridFilter,
            this.btnRefresh});
            this.stripMenu.Location = new System.Drawing.Point(0, 0);
            this.stripMenu.Name = "stripMenu";
            this.stripMenu.Size = new System.Drawing.Size(1075, 25);
            this.stripMenu.TabIndex = 0;
            // 
            // lbSearchIcon
            // 
            this.lbSearchIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lbSearchIcon.Image = global::EmployeesTable.Properties.Resources.lbSearcher_Image;
            this.lbSearchIcon.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.lbSearchIcon.Name = "lbSearchIcon";
            this.lbSearchIcon.Size = new System.Drawing.Size(16, 22);
            this.lbSearchIcon.ToolTipText = "Поиск по ФИО";
            // 
            // tstbFullNameSearcher
            // 
            this.tstbFullNameSearcher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbFullNameSearcher.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.tstbFullNameSearcher.Name = "tstbFullNameSearcher";
            this.tstbFullNameSearcher.Size = new System.Drawing.Size(150, 25);
            this.tstbFullNameSearcher.ToolTipText = "Поиск по ФИО";
            this.tstbFullNameSearcher.TextChanged += new System.EventHandler(this.tstbFullNameSearcher_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btAddEmployee
            // 
            this.btAddEmployee.Image = global::EmployeesTable.Properties.Resources.btAddEmployee_Image;
            this.btAddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAddEmployee.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.btAddEmployee.Name = "btAddEmployee";
            this.btAddEmployee.Size = new System.Drawing.Size(79, 22);
            this.btAddEmployee.Text = "Добавить";
            this.btAddEmployee.ToolTipText = "Добавить сотрудника";
            this.btAddEmployee.Click += new System.EventHandler(this.btEmployeeAdd_Click);
            // 
            // btEditEmployee
            // 
            this.btEditEmployee.Image = global::EmployeesTable.Properties.Resources.btEditEmployee_Image;
            this.btEditEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btEditEmployee.Name = "btEditEmployee";
            this.btEditEmployee.Size = new System.Drawing.Size(107, 22);
            this.btEditEmployee.Text = "Редактировать";
            this.btEditEmployee.ToolTipText = "Редактировать сотрудника";
            this.btEditEmployee.Click += new System.EventHandler(this.btEmployeeEdit_Click);
            // 
            // btDeleteEmployee
            // 
            this.btDeleteEmployee.Image = global::EmployeesTable.Properties.Resources.btDeleteEmployee_Image;
            this.btDeleteEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDeleteEmployee.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btDeleteEmployee.Name = "btDeleteEmployee";
            this.btDeleteEmployee.Size = new System.Drawing.Size(71, 22);
            this.btDeleteEmployee.Text = "Удалить";
            this.btDeleteEmployee.ToolTipText = "Удалить сотрудника";
            this.btDeleteEmployee.Click += new System.EventHandler(this.btEmployeeDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btImportOrder
            // 
            this.btImportOrder.Image = global::EmployeesTable.Properties.Resources.btImportOrder_Image;
            this.btImportOrder.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.btImportOrder.Name = "btImportOrder";
            this.btImportOrder.Size = new System.Drawing.Size(81, 22);
            this.btImportOrder.Text = "Загрузить";
            this.btImportOrder.ToolTipText = "Загрузить приказ с диска";
            this.btImportOrder.Click += new System.EventHandler(this.btImportOrder_Click);
            // 
            // btExportTable
            // 
            this.btExportTable.Image = global::EmployeesTable.Properties.Resources.btExportTable1;
            this.btExportTable.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.btExportTable.Name = "btExportTable";
            this.btExportTable.Size = new System.Drawing.Size(84, 22);
            this.btExportTable.Text = "Выгрузить";
            this.btExportTable.ToolTipText = "Выгрузить данные из таблицы";
            this.btExportTable.Click += new System.EventHandler(this.btExportTable_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnGridFilter
            // 
            this.BtnGridFilter.Image = global::EmployeesTable.Properties.Resources.BtnGridFilter_Image;
            this.BtnGridFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnGridFilter.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.BtnGridFilter.Name = "BtnGridFilter";
            this.BtnGridFilter.Size = new System.Drawing.Size(68, 22);
            this.BtnGridFilter.Text = "Фильтр";
            this.BtnGridFilter.Click += new System.EventHandler(this.BtnGridFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::EmployeesTable.Properties.Resources.btnRefresh1;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.ToolTipText = "Обновить информацию";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // stripStatus
            // 
            this.stripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slbEmployeesCount,
            this.pbStatusImportOrder});
            this.stripStatus.Location = new System.Drawing.Point(0, 303);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(1075, 22);
            this.stripStatus.TabIndex = 3;
            // 
            // slbEmployeesCount
            // 
            this.slbEmployeesCount.Name = "slbEmployeesCount";
            this.slbEmployeesCount.Size = new System.Drawing.Size(0, 17);
            // 
            // pbStatusImportOrder
            // 
            this.pbStatusImportOrder.Name = "pbStatusImportOrder";
            this.pbStatusImportOrder.Size = new System.Drawing.Size(100, 16);
            this.pbStatusImportOrder.Visible = false;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullName,
            this.office,
            this.hoursFullDaysBtn,
            this.hoursPartialDaysBtn,
            this.comment});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 25);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.Size = new System.Drawing.Size(1075, 278);
            this.dgvEmployees.TabIndex = 2;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeesDataGridView_CellContentClick);
            // 
            // fullName
            // 
            this.fullName.HeaderText = "ФИО";
            this.fullName.Name = "fullName";
            this.fullName.ReadOnly = true;
            this.fullName.Width = 250;
            // 
            // office
            // 
            this.office.HeaderText = "Представительство";
            this.office.Name = "office";
            this.office.ReadOnly = true;
            this.office.Width = 250;
            // 
            // hoursFullDaysBtn
            // 
            this.hoursFullDaysBtn.HeaderText = "Полные дни (д)";
            this.hoursFullDaysBtn.Name = "hoursFullDaysBtn";
            this.hoursFullDaysBtn.ReadOnly = true;
            // 
            // hoursPartialDaysBtn
            // 
            this.hoursPartialDaysBtn.HeaderText = "Неполные дни (ч)";
            this.hoursPartialDaysBtn.Name = "hoursPartialDaysBtn";
            this.hoursPartialDaysBtn.ReadOnly = true;
            // 
            // comment
            // 
            this.comment.HeaderText = "Комментарий";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Width = 300;
            // 
            // EmployeeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 325);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.stripStatus);
            this.Controls.Add(this.stripMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeeTableForm";
            this.Text = "Реестр сотрудников";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeTableForm_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeTableForm_Load);
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
        private StatusStrip stripStatus;
        private DataGridView dgvEmployees;
        private ToolStripButton btImportOrder;
        private ToolStripButton btExportTable;
        private ToolStripTextBox tstbFullNameSearcher;
        private ToolStripProgressBar pbStatusImportOrder;
        private ToolStripButton BtnGridFilter;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private DataGridViewTextBoxColumn fullName;
        private DataGridViewTextBoxColumn office;
        private DataGridViewButtonColumn hoursFullDaysBtn;
        private DataGridViewButtonColumn hoursPartialDaysBtn;
        private DataGridViewTextBoxColumn comment;
        private ToolStripButton btEditEmployee;
        private ToolStripButton btDeleteEmployee;
        private ToolStripButton btAddEmployee;
        private ToolStripLabel lbSearchIcon;
        private ToolStripButton btnRefresh;
        private ToolStripStatusLabel slbEmployeesCount;
    }
}