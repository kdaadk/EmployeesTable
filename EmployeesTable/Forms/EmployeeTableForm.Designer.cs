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
            this.lbSearchIcon = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dDBtnEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.miAddEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.miEditEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btImportOrder = new System.Windows.Forms.ToolStripButton();
            this.btExportTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnGridFilter = new System.Windows.Forms.ToolStripButton();
            this.stripStatus = new System.Windows.Forms.StatusStrip();
            this.pbStatusImportOrder = new System.Windows.Forms.ToolStripProgressBar();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.fullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representation = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tstbFullNameSearcher,
            this.lbSearchIcon,
            this.toolStripSeparator3,
            this.dDBtnEdit,
            this.toolStripSeparator1,
            this.btImportOrder,
            this.btExportTable,
            this.toolStripSeparator2,
            this.BtnGridFilter});
            this.stripMenu.Location = new System.Drawing.Point(0, 0);
            this.stripMenu.Name = "stripMenu";
            this.stripMenu.Size = new System.Drawing.Size(912, 25);
            this.stripMenu.TabIndex = 0;
            // 
            // tstbFullNameSearcher
            // 
            this.tstbFullNameSearcher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbFullNameSearcher.Name = "tstbFullNameSearcher";
            this.tstbFullNameSearcher.Size = new System.Drawing.Size(100, 25);
            this.tstbFullNameSearcher.TextChanged += new System.EventHandler(this.tstbFullNameSearcher_TextChanged);
            // 
            // lbSearchIcon
            // 
            this.lbSearchIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbSearchIcon.Name = "lbSearchIcon";
            this.lbSearchIcon.Size = new System.Drawing.Size(19, 22);
            this.lbSearchIcon.Text = "🔍";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // dDBtnEdit
            // 
            this.dDBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dDBtnEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddEmployee,
            this.miEditEmployee,
            this.miDeleteEmployee});
            this.dDBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("dDBtnEdit.Image")));
            this.dDBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dDBtnEdit.Name = "dDBtnEdit";
            this.dDBtnEdit.Size = new System.Drawing.Size(143, 22);
            this.dDBtnEdit.Text = "Действия над записью";
            this.dDBtnEdit.ToolTipText = "dDBtnEdit";
            // 
            // miAddEmployee
            // 
            this.miAddEmployee.Name = "miAddEmployee";
            this.miAddEmployee.Size = new System.Drawing.Size(154, 22);
            this.miAddEmployee.Text = "Добавить";
            this.miAddEmployee.Click += new System.EventHandler(this.miAddEmployee_Click);
            // 
            // miEditEmployee
            // 
            this.miEditEmployee.Name = "miEditEmployee";
            this.miEditEmployee.Size = new System.Drawing.Size(154, 22);
            this.miEditEmployee.Text = "Редактировать";
            this.miEditEmployee.Click += new System.EventHandler(this.miEditEmployee_Click);
            // 
            // miDeleteEmployee
            // 
            this.miDeleteEmployee.Name = "miDeleteEmployee";
            this.miDeleteEmployee.Size = new System.Drawing.Size(154, 22);
            this.miDeleteEmployee.Text = "Удалить";
            this.miDeleteEmployee.Click += new System.EventHandler(this.miDeleteEmployee_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // stripStatus
            // 
            this.stripStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbStatusImportOrder});
            this.stripStatus.Location = new System.Drawing.Point(0, 262);
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(912, 22);
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
            this.dgvEmployees.Size = new System.Drawing.Size(912, 237);
            this.dgvEmployees.TabIndex = 2;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeesDataGridView_CellContentClick);
            // 
            // fullName
            // 
            this.fullName.HeaderText = "ФИО";
            this.fullName.Name = "fullName";
            this.fullName.Width = 250;
            // 
            // representation
            // 
            this.representation.HeaderText = "Представительство";
            this.representation.Name = "representation";
            this.representation.Width = 250;
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
            // EmployeeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 284);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.stripStatus);
            this.Controls.Add(this.stripMenu);
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
        private DataGridViewTextBoxColumn fullName;
        private DataGridViewTextBoxColumn representation;
        private DataGridViewButtonColumn hoursFullDaysBtn;
        private DataGridViewButtonColumn hoursPartialDaysBtn;
        private DataGridViewTextBoxColumn comment;
        private ToolStripButton btImportOrder;
        private ToolStripButton btExportTable;
        private ToolStripTextBox tstbFullNameSearcher;
        private ToolStripProgressBar pbStatusImportOrder;
        private ToolStripButton BtnGridFilter;
        private ToolStripDropDownButton dDBtnEdit;
        private ToolStripMenuItem miAddEmployee;
        private ToolStripMenuItem miEditEmployee;
        private ToolStripMenuItem miDeleteEmployee;
        private ToolStripLabel lbSearchIcon;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
    }
}

