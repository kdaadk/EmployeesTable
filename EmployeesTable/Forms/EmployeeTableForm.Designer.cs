using System;
using System.Runtime.Remoting.Channels;
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
            this.pbStatusImportOrder = new System.Windows.Forms.ToolStripProgressBar();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoursFullDaysBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.hoursPartialDaysBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnPaging = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bsPaging = new System.Windows.Forms.BindingSource(this.components);
            this.cbPaging = new System.Windows.Forms.CheckBox();
            this.stripMenu.SuspendLayout();
            this.stripStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnPaging)).BeginInit();
            this.bnPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPaging)).BeginInit();
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
            this.btImportOrder.Click += new System.EventHandler(this.btLoadOrder_Click);
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
            this.btnRefresh.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // stripStatus
            // 
            this.stripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbStatusImportOrder});
            this.stripStatus.Location = new System.Drawing.Point(0, 303);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(1075, 22);
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
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullName,
            this.representation,
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
            // representation
            // 
            this.representation.HeaderText = "Представительство";
            this.representation.Name = "representation";
            this.representation.ReadOnly = true;
            this.representation.Width = 250;
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
            // bnPaging
            // 
            this.bnPaging.AddNewItem = null;
            this.bnPaging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnPaging.CountItem = this.bindingNavigatorCountItem;
            this.bnPaging.DeleteItem = null;
            this.bnPaging.Dock = System.Windows.Forms.DockStyle.None;
            this.bnPaging.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnPaging.Location = new System.Drawing.Point(781, 303);
            this.bnPaging.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnPaging.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnPaging.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnPaging.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnPaging.Name = "bnPaging";
            this.bnPaging.PositionItem = this.bindingNavigatorPositionItem;
            this.bnPaging.Size = new System.Drawing.Size(234, 25);
            this.bnPaging.TabIndex = 4;
            this.bnPaging.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // cbPaging
            // 
            this.cbPaging.AutoSize = true;
            this.cbPaging.Location = new System.Drawing.Point(863, 2);
            this.cbPaging.Name = "cbPaging";
            this.cbPaging.Size = new System.Drawing.Size(58, 17);
            this.cbPaging.TabIndex = 5;
            this.cbPaging.Text = "paging";
            this.cbPaging.UseVisualStyleBackColor = true;
            this.cbPaging.CheckedChanged += new System.EventHandler(this.cbPaging_CheckedChanged);
            // 
            // EmployeeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 325);
            this.Controls.Add(this.cbPaging);
            this.Controls.Add(this.bnPaging);
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
            ((System.ComponentModel.ISupportInitialize)(this.bnPaging)).EndInit();
            this.bnPaging.ResumeLayout(false);
            this.bnPaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPaging)).EndInit();
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
        private DataGridViewTextBoxColumn representation;
        private DataGridViewButtonColumn hoursFullDaysBtn;
        private DataGridViewButtonColumn hoursPartialDaysBtn;
        private DataGridViewTextBoxColumn comment;
        private ToolStripButton btEditEmployee;
        private ToolStripButton btDeleteEmployee;
        private ToolStripButton btAddEmployee;
        private ToolStripLabel lbSearchIcon;
        private ToolStripButton btnRefresh;
        private BindingNavigator bnPaging;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private BindingSource bsPaging;
        private CheckBox cbPaging;
    }
}

