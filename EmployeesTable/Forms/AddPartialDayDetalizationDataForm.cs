using System;
using System.Globalization;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class AddPartialDayDetalizationDataForm : Form
    {
        public AddPartialDayDetalizationDataForm(PartialDayDetalization Detalization)
        {
            this.Detalization = Detalization;
            InitializeComponent();
        }

        public PartialDayDetalization Detalization { get; set; }

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
            Detalization.Used = cbRest.Text == @"Да"
                ? Used.YesFull
                : cbRest.Text == @"Частично"
                    ? Used.YesPartially
                    : Used.No;
            Detalization.Comment = tbComment.Text;

            DialogResult = DialogResult.OK;
        }
    }
}