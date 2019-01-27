using System.Collections.Generic;
using System.Windows.Forms;
using NsExcel = Microsoft.Office.Interop.Excel;

namespace EmployeesTable.Feature.ExportExcel
{
    public class ExportExcel
    {
        private ToolStripButton buttonExport;

        public ExportExcel(ToolStripButton buttonExport)
        {
            this.buttonExport = buttonExport;
        }

        public void Perform(List<Employee> employees)
        {
            buttonExport.Enabled = false;

            var excapp = new NsExcel.Application { Visible = true };
            var xlWorkbook = excapp.Workbooks.Add(NsExcel.XlWBATemplate.xlWBATWorksheet);
            var sheet = (NsExcel.Worksheet)xlWorkbook.Sheets[1];
            int counter = 1;

            foreach (var employee in employees)
            {
                var cellNameA = "A" + counter;
                var cellNameB = "B" + counter;
                var cellNameC = "C" + counter;
                var cellNameD = "D" + counter;
                var cellNameE = "E" + counter;
                sheet.Range[cellNameA, cellNameA].Value2 = employee.FullName;
                sheet.Range[cellNameB, cellNameB].Value2 = employee.Office;
                sheet.Range[cellNameC, cellNameC].Value2 = employee.HoursFullDays / 8;
                sheet.Range[cellNameD, cellNameD].Value2 = employee.HoursPartialDays;
                sheet.Range[cellNameE, cellNameE].Value2 = employee.Comment;
                ++counter;
            }

            buttonExport.Enabled = true;
        }
    }
}
