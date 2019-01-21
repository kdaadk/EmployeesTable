using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class GridFilterForm : Form
    {
        private readonly List<string> centralOffices = new List<string>
        {
            @"Бюро администрирования функциональных комплексов",
            @"Бюро развития IT",
            @"Бюро системного администрирования и защиты информации",
            @"Бюро технического и системного сопровождения",
            @"Нормативно-правовой отдел",
            @"Операционная дирекция",
            @"Отдел документационного обеспечения",
            @"Отдел по работе с государственными информационными системами",
            @"Отдел по работе с персоналом",
            @"Отдел по работе с физическими лицами",
            @"Отдел по работе с юридическими лицами",
            @"Отдел по сопровождению договоров и планированию",
            @"Отдел претензионно-исковой работы",
            @"Планово - экономический отдел",
            @"Правовое управление",
            @"Сектор по работе с задолженностью потребителей",
            @"Сектор по расчетам мер социальной поддержки",
            @"Транспортный отдел",
            @"Управление",
            @"Управление информационных технологий",
            @"Управление логистики",
            @"Управление реализации",
            @"Финансово - экономическое управление",
            @"Финансовый отдел"
        };
        private readonly List<Employee> allEmployees;
        private readonly Dictionary<string, List<string>> representationDictionary;
        public GridFilterParameters Parameters { get; set; }


        public GridFilterForm(List<Employee> allEmployees, GridFilterParameters parameters)
        {
            this.allEmployees = allEmployees;
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
            cbRepresentation.SelectedText = Parameters.RepresentationGroupName;
            cbAnyDaysNumber.Checked = Parameters.AnyDaysNumber;

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
            var allRepresentations = allEmployees.Select(x => x.Representation).Distinct();
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

            foreach (var representation in representationDictionary.OrderBy(r => r.Key))
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

        private void cbRepresentation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRepresentation.SelectedItem.ToString() == @"Все")
            {
                Parameters.RepresentationGroupName = @"Все";
                for (int i = 0; i < clbRepresentation.Items.Count; i++)
                    clbRepresentation.SetItemChecked(i, true);
            }

            if (cbRepresentation.SelectedItem.ToString() == @"Центральный офис")
            {
                UncheckedAll();
                Parameters.RepresentationGroupName = @"Центральный офис";
                foreach (var centralOffice in centralOffices)
                {
                    var index = clbRepresentation.Items.IndexOf(centralOffice);
                    clbRepresentation.SetItemChecked(index, true);
                }
            }

            if (cbRepresentation.SelectedItem.ToString() == @"Выбрать из списка")
            {
                Parameters.RepresentationGroupName = @"Выбрать из списка";
                UncheckedAll();
            }
        }

        private void UncheckedAll()
        {
            for (int i = 0; i < clbRepresentation.Items.Count; i++)
                clbRepresentation.SetItemChecked(i, false);
        }

        private void cbAnyDaysNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAnyDaysNumber.Checked)
            {
                Parameters.AnyDaysNumber = true;
                nudDaysNumberFrom.Enabled = false;
                nudDaysNumberTo.Enabled = false;
            }
            else
            {
                Parameters.AnyDaysNumber = false;
                nudDaysNumberFrom.Enabled = true;
                nudDaysNumberTo.Enabled = true;
            }

        }
    }
}