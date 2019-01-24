using System;
using System.Globalization;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public sealed partial class AddPartialDayDetalizationDataForm : Form
    {
        public PartialDayDetalization Detalization { get; set; }

        public AddPartialDayDetalizationDataForm(PartialDayDetalization Detalization, string headName)
        {
            this.Detalization = Detalization;
            InitializeComponent();
            Text = headName;
        }


        private void AddDataToDb_Load(object sender, EventArgs e)
        {
            cbRest.Text = Detalization.Used.GetDisplayName();
            tbHours.Text = Detalization.WorkHours.ToString(CultureInfo.InvariantCulture);
            tbComment.Text = Detalization.Comment;
            tpWorkDate.Text = Detalization.WorkDate?.ToString();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Detalization.WorkDate = tpWorkDate.Value;
            Detalization.WorkHours = double.Parse(tbHours.Text);
            Detalization.Used = UsedDetector.DetectFromComboBox(cbRest.Text);
            Detalization.Comment = tbComment.Text;

            DialogResult = DialogResult.OK;
        }

        private void cbRest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRest.SelectedItem.ToString() == @"Да")
            {
                tbHours.Text = @"0";
                tbHours.ReadOnly = true;
            }
            else
            {
                tbHours.ReadOnly = false;
            }
        }
    }
}