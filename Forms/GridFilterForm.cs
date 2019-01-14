using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class GridFilterForm : Form
    {
        private readonly List<Employee> employees;
        public GridFilterParameters Parameters { get; set; }

        public GridFilterForm(List<Employee> employees)
        {
            this.employees = employees;
            Parameters = new GridFilterParameters();
            InitializeComponent();
        }

        private void GridFilter_Load(object sender, EventArgs e)
        {
            var representations = employees.Select(x => x.Representation).Distinct().OrderBy(x => x);
            foreach (var representation in representations)
                cbRepresentation.Items.Add(representation);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Parameters.IsFired = cbFiredEmployees.Checked;
            Parameters.Representation = cbRepresentation.SelectedItem.ToString();
            Parameters.HoursNumberFrom = (int)nudHoursNumberFrom.Value;
            Parameters.HoursNumberTo = (int)nudHoursNumberTo.Value;

            DialogResult = DialogResult.OK;
        }
    }
}
