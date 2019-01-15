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
            cbUsed.Text = Detalization.Used.GetDisplayName();
            tbHours.Text = Detalization.WorkHours.ToString(CultureInfo.InvariantCulture);
            tbComment.Text = Detalization.Comment;
            tpWorkDate.Text = Detalization.WorkDate?.ToString();
            //tbBalance.Text = Detalization.BalanceHours.ToString(CultureInfo.InvariantCulture);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Detalization.WorkDate = tpWorkDate.Value;
            Detalization.WorkHours = double.Parse(tbHours.Text);
            Detalization.Used = cbUsed.Text == @"Да"
                ? Used.YesFull
                : cbUsed.Text == @"Частично"
                    ? Used.YesPartially
                    : Used.No;
            Detalization.Comment = tbComment.Text;
            //Detalization.BalanceHours = double.Parse(tbBalance.Text);

            DialogResult = DialogResult.OK;
        }
    }
}