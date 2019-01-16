using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class GridFilterForm : Form
    {
        private readonly List<Employee> employees;

        public GridFilterForm(List<Employee> employees)
        {
            this.employees = employees;
            Parameters = new GridFilterParameters();
            InitializeComponent();
        }

        public GridFilterParameters Parameters { get; set; }

        private void GridFilter_Load(object sender, EventArgs e)
        {
            var representations = employees
                .Select(x => x.Representation.Replace("  ", " "))
                .Distinct()
                .OrderBy(x => x);

            foreach (var representation in representations)
                cbRepresentation.Items.Add(representation);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Parameters.IsFired = cbFiredEmployees.Checked;
            Parameters.Representation = cbRepresentation.SelectedItem.ToString();
            Parameters.DaysNumberFrom = (double) nudDaysNumberFrom.Value;
            Parameters.DaysNumberTo = (double) nudDaysNumberTo.Value;

            DialogResult = DialogResult.OK;
        }
    }
}