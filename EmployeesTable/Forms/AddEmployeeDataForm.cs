using System;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class AddEmployeeDataForm : Form
    {
        public AddEmployeeDataForm(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
        }

        public Employee Employee { get; set; }

        private void AddDataToDb_Load(object sender, EventArgs e)
        {
            if (Employee != null)
            {
                tbFullName.Text = Employee.FullName;
                tbRepresentation.Text = Employee.Representation;
                tbComment.Text = Employee.Comment;
                cbFired.Checked = Employee.Fired;
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Employee.FullName = tbFullName.Text;
            Employee.Representation = tbRepresentation.Text;
            Employee.Comment = tbComment.Text;
            Employee.Fired = cbFired.Checked;

            DialogResult = DialogResult.OK;
        }
    }
}