using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class GridFilterForm : Form
    {
        private readonly List<Employee> employees;
        private readonly Dictionary<string, List<string>> representationDictionary;
        public GridFilterParameters Parameters { get; set; }


        public GridFilterForm(List<Employee> employees, GridFilterParameters parameters)
        {
            this.employees = employees;
            Parameters = parameters;
            representationDictionary = new Dictionary<string, List<string>>();
            InitializeComponent();
        }


        private void GridFilter_Load(object sender, EventArgs e)
        {
            LoadRepresentationsToCheckedListBox();
            cbFiredEmployees.Checked = Parameters.IsFired;
            nudDaysNumberFrom.Value = (decimal) Parameters.DaysNumberFrom;
            nudDaysNumberTo.Value = (decimal)Parameters.DaysNumberTo;

            if (clbRepresentation.Items.Count == 0)
                return;

            for (int i = 0; i < clbRepresentation.Items.Count; i++)
            {
                var valuesRepresentation = representationDictionary[(string)clbRepresentation.Items[i]];
                if (valuesRepresentation.Any(x => Parameters.Representations.Contains(x)))
                    clbRepresentation.SetItemChecked(i, true);
            }
        }

        private void LoadRepresentationsToCheckedListBox()
        {
            representationDictionary.Add("Все", new List<string>{"Все"});
            var allRepresentations = employees.Select(x => x.Representation).Distinct();
            var representationsWithTwoWhiteSpace = allRepresentations.Where(x => x.Contains("  "));

            foreach (var r in representationsWithTwoWhiteSpace)
                representationDictionary.Add(r.Replace("  ", " "), new List<string> {r});

            var representationsWithOneWhiteSpace = allRepresentations.Where(x => !x.Contains("  "));

            foreach (var r in representationsWithOneWhiteSpace)
            {
                if (!representationDictionary.ContainsKey(r))
                    representationDictionary.Add(r, new List<string> {r});
                else
                    representationDictionary[r].Add(r);
            }

            clbRepresentation.Items.Add(representationDictionary.First().Key);
            foreach (var representation in representationDictionary.Skip(1).OrderBy(r => r.Key))
                clbRepresentation.Items.Add(representation.Key);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Parameters.IsFired = cbFiredEmployees.Checked;
            Parameters.DaysNumberFrom = (double)nudDaysNumberFrom.Value;
            Parameters.DaysNumberTo = (double)nudDaysNumberTo.Value;
            Parameters.Representations.Clear();
            var representations = clbRepresentation.CheckedItems.OfType<string>().ToList();

            foreach (var representation in representations)
                 Parameters.Representations.AddRange(representationDictionary[representation]);

            DialogResult = DialogResult.OK;
        }

        private void clRepresentation_MouseClick(object sender, MouseEventArgs e)
        {
            clbRepresentation.CheckOnClick = true;
        }

        private void clRepresentation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedListBoxRepresentation = (CheckedListBox) sender;
            if ((string)checkedListBoxRepresentation?.SelectedItem == "Все")
            {
                var itemChecked =
                    checkedListBoxRepresentation.GetItemChecked(checkedListBoxRepresentation.SelectedIndex);
                for (int i = 0; i < clbRepresentation.Items.Count; i++)
                    clbRepresentation.SetItemChecked(i, itemChecked);
            }
        }
    }
}