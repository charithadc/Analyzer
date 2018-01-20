using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelIntrop = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Analyzer.Data.Excel
{
    class CExcelFile
    {
        public ExcelIntrop.Application App {  get; private set; }
        public ExcelIntrop.Workbook Workbook { get; private set; }
        public ExcelIntrop._Worksheet Worksheet { get; private set; }
        public ExcelIntrop.Range UsedRange { get; private set; }
        public string Path { get; private set; }
        public bool IsExcelOpen { get; private set; }
        public int SheetNo { get; private set; }

        public CExcelFile(string path)
        {
            Path = path;

            App = null;
            Workbook = null;
            Worksheet = null;
            UsedRange = null;
            IsExcelOpen = false;
            SheetNo = 1; 
        }

        public bool Open()
        {
            try
            {
                App = new ExcelIntrop.Application();
                Workbook = App.Workbooks.Open(this.Path);
                Worksheet = Workbook.Sheets[SheetNo];
                UsedRange = Worksheet.UsedRange;
                IsExcelOpen = true;
                return true;
            }
            catch
            {
                this.Close();
                return false;
            }

        }

        public void Close()
        {
            IsExcelOpen = false;

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            if (UsedRange != null)
            {
                Marshal.ReleaseComObject(UsedRange);
                UsedRange = null;
            }
            if (Worksheet != null)
            {
                Marshal.ReleaseComObject(Worksheet);
                Worksheet = null;
            }

            //close and release
            if (Workbook != null)
            {
                Workbook.Close();
                Marshal.ReleaseComObject(Workbook);
                Workbook = null;
            }

            //quit and release
            if (App != null)
            {
                App.Quit();
                Marshal.ReleaseComObject(App);
                App = null;
            }
        }
    }
}
