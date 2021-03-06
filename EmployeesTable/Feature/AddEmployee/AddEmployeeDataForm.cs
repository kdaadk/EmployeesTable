﻿using System;
using System.Windows.Forms;
using EmployeesTable.Model;

namespace EmployeesTable.Feature.AddEmployee
{
    public sealed partial class AddEmployeeDataForm : Form
    {
        public AddEmployeeDataForm(Employee employee, string headName)
        {
            Employee = employee;
            InitializeComponent();
            Text = headName;

        }

        public Employee Employee { get; set; }

        private void AddDataToDb_Load(object sender, EventArgs e)
        {
            if (Employee != null)
            {
                tbFullName.Text = Employee.FullName;
                tbOffice.Text = Employee.Office;
                tbComment.Text = Employee.Comment;
                cbFired.Checked = Employee.Fired;
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Employee.FullName = tbFullName.Text;
            Employee.Office = tbOffice.Text;
            Employee.Comment = tbComment.Text;
            Employee.Fired = cbFired.Checked;

            DialogResult = DialogResult.OK;
        }
    }
}