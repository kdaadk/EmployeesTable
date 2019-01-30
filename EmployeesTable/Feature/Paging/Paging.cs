using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeesTable.Model;

namespace EmployeesTable.Feature.Paging
{
    public class Paging
    {
        private readonly BindingNavigator bnPaging;
        private readonly BindingSource bsPaging;
        private readonly DataGridView dgvEmployees;
        private readonly List<Employee> filteredEmployees;

        public Paging(BindingNavigator bnPaging, BindingSource bsPaging,
            DataGridView dgvEmployees, List<Employee> filteredEmployees)
        {
            this.bnPaging = bnPaging;
            this.bsPaging = bsPaging;
            this.dgvEmployees = dgvEmployees;
            this.filteredEmployees = filteredEmployees;
        }

        private void bsPaging_CurrentChanged(object sender, EventArgs e)
        {
            var offset = (int)bsPaging.Current;
            dgvEmployees.Rows.Clear();
            for (var i = offset; i < offset + 50 && i < filteredEmployees.Count; i++)
                dgvEmployees.Rows.Add(filteredEmployees[i].FullName, filteredEmployees[i].Office,
                    filteredEmployees[i].HoursFullDays / 8, filteredEmployees[i].HoursPartialDays,
                    filteredEmployees[i].Comment);
        }

        public void Checked()
        {
            bnPaging.BindingSource = bsPaging;
            bsPaging.Position = 0;
            bsPaging.CurrentChanged += bsPaging_CurrentChanged;
            bsPaging.DataSource = new PageOffsetList(filteredEmployees.Count);
        }
    }
}
