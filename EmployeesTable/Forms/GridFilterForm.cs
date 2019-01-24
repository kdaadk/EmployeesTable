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

        private readonly Dictionary<string, List<string>> officeDictionary;


        public GridFilterForm(GridFilterParameters parameters)
        {
            Parameters = parameters;
            officeDictionary = new Dictionary<string, List<string>>();
            InitializeComponent();
        }

        public GridFilterParameters Parameters { get; set; }


        private void GridFilter_Load(object sender, EventArgs e)
        {
            LoadOfficesToCheckedListBox();
            cbFiredEmployees.Checked = Parameters.IsFired;
            nudDaysNumberFrom.Value = (decimal) Parameters.DaysNumberFrom;
            nudDaysNumberTo.Value = (decimal) Parameters.DaysNumberTo;
            cbOffice.SelectedText = Parameters.OfficeGroupName;
            cbAnyDaysNumber.Checked = Parameters.AnyDaysNumber;

            if (clbOffice.Items.Count == 0)
                return;

            if (Parameters.OfficeGroupName == @"Все")
            {
                SetAllItemChecked(true);
                return;
            }

            for (var i = 0; i < clbOffice.Items.Count; i++)
            {
                var valuesOffice = officeDictionary[(string) clbOffice.Items[i]];
                if (valuesOffice.Any(x => Parameters.SelectedOffices.Contains(x)))
                    clbOffice.SetItemChecked(i, true);
            }
        }

        private void LoadOfficesToCheckedListBox()
        {
            var allOffices = Parameters.AllOffices;
            var officesWithTwoWhiteSpace = allOffices.Where(x => x.Contains("  "));

            foreach (var r in officesWithTwoWhiteSpace)
                officeDictionary.Add(r.Replace("  ", " "), new List<string> {r});

            var officesWithOneWhiteSpace = allOffices.Where(x => !x.Contains("  "));

            foreach (var r in officesWithOneWhiteSpace)
                if (!officeDictionary.ContainsKey(r))
                    officeDictionary.Add(r, new List<string> {r});
                else
                    officeDictionary[r].Add(r);

            foreach (var office in officeDictionary.OrderBy(r => r.Key))
                clbOffice.Items.Add(office.Key);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Parameters.IsFired = cbFiredEmployees.Checked;
            Parameters.DaysNumberFrom = (double) nudDaysNumberFrom.Value;
            Parameters.DaysNumberTo = (double) nudDaysNumberTo.Value;
            Parameters.SelectedOffices.Clear();
            var offices = clbOffice.CheckedItems.OfType<string>().ToList();

            foreach (var office in offices)
                Parameters.SelectedOffices.AddRange(officeDictionary[office]);

            DialogResult = DialogResult.OK;
        }

        private void clOffice_MouseClick(object sender, MouseEventArgs e)
        {
            clbOffice.CheckOnClick = true;
        }

        private void cbOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOffice.SelectedItem.ToString() == @"Все")
            {
                Parameters.OfficeGroupName = @"Все";
                for (var i = 0; i < clbOffice.Items.Count; i++)
                    clbOffice.SetItemChecked(i, true);
            }

            if (cbOffice.SelectedItem.ToString() == @"Центральный офис")
            {
                SetAllItemChecked(false);
                Parameters.OfficeGroupName = @"Центральный офис";
                foreach (var centralOffice in centralOffices)
                {
                    var index = clbOffice.Items.IndexOf(centralOffice);
                    if (index != -1)
                        clbOffice.SetItemChecked(index, true);
                }
            }

            if (cbOffice.SelectedItem.ToString() == @"Выбрать из списка")
            {
                Parameters.OfficeGroupName = @"Выбрать из списка";
                SetAllItemChecked(false);
            }
        }

        private void SetAllItemChecked(bool value)
        {
            for (var i = 0; i < clbOffice.Items.Count; i++)
                clbOffice.SetItemChecked(i, value);
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