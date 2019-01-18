using System;
using System.Globalization;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class AddPartialDayDetalizationDataForm : Form
    {
        public PartialDayDetalization Detalization { get; set; }
        private readonly string headName;

        public AddPartialDayDetalizationDataForm(PartialDayDetalization Detalization, string headName)
        {
            this.headName = headName;
            this.Detalization = Detalization;
            InitializeComponent();
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
            Detalization.Used = cbRest.Text == @"Да"
                ? Used.YesFull
                : cbRest.Text == @"Частично"
                    ? Used.YesPartially
                    : Used.No;
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