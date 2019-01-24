using System;
using System.Globalization;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public sealed partial class AddFullDayDetalizationDataForm : Form
    {
        public AddFullDayDetalizationDataForm(FullDayDetalization Detalization, string headName)
        {
            InitializeComponent();
            Text = headName;
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
            Detalization.Payment = PaymentDetector.DetectFromComboBox(cbPayment.Text);
            Detalization.WorkDate = tpWorkDate.Value;
            Detalization.WorkHours = double.Parse(tbHours.Text);
            Detalization.Used = UsedDetector.DetectFromComboBox(cbUsed.Text);
            Detalization.Comment = tbComment.Text;

            DialogResult = DialogResult.OK;
        }

        private void tpUsedDate_ValueChanged(object sender, EventArgs e)
        {
            tpRestDate.CustomFormat = @"dd.MM.yyyy";
        }

        private void cbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPayment.SelectedItem.ToString() == @"Отгул")
            {
                tbHours.Text = @"8";
                cbUsed.SelectedItem = @"Не использован";
            }
            else
            {
                tbHours.Text = @"0";
                cbUsed.SelectedItem = @"Да";
            }
        }

        private void cbUsed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUsed.SelectedItem.ToString() == @"Да")
            {
                tbHours.Text = @"0";
                tbHours.ReadOnly = true;
            }
            else
            {
                tbHours.ReadOnly = false;
            }
        }

        private void btDeleteRestDate_Click(object sender, EventArgs e)
        {
            tpRestDate.CustomFormat = @" ";
        }
    }
}