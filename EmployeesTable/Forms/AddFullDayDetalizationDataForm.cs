using System;
using System.Globalization;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class AddFullDayDetalizationDataForm : Form
    {
        public AddFullDayDetalizationDataForm(FullDayDetalization Detalization)
        {
            InitializeComponent();
            this.Detalization = Detalization;
        }

        public FullDayDetalization Detalization { get; set; }

        private void AddDataToDb_Load(object sender, EventArgs e)
        {
            cbPayment.Text = Detalization.Payment.GetDisplayName();
            cbUsed.Text = Detalization.Used.GetDisplayName();
            tbHours.Text = Detalization.WorkHours.ToString(CultureInfo.InvariantCulture);
            tbComment.Text = Detalization.Comment;
            if (Detalization.RestDate != null)
                tpRestDate.Text = Detalization.RestDate.ToString();
            tpWorkDate.Text = Detalization.WorkDate.ToString();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Detalization.RestDate =
                string.IsNullOrWhiteSpace(tpRestDate.CustomFormat) ? (DateTime?) null : tpRestDate.Value;
            Detalization.Payment = cbPayment.Text == @"Оплата" ? Payment.Money : Payment.Rest;
            Detalization.WorkDate = tpWorkDate.Value;
            Detalization.WorkHours = double.Parse(tbHours.Text);
            Detalization.Used = cbUsed.Text == @"Да"
                ? Used.YesFull
                : cbUsed.Text == @"Частично"
                    ? Used.YesPartially
                    : Used.No;
            Detalization.Comment = tbComment.Text;

            DialogResult = DialogResult.OK;
        }

        private void tpUsedDate_ValueChanged(object sender, EventArgs e)
        {
            tpRestDate.CustomFormat = @"dd.MM.yyyy";
        }
    }
}