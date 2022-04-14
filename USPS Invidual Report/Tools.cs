using Csv;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace USPS_Invidual_Report
{
    internal class Tools
    {

        private static string priceConverter(string price)
        {
            string myPrice = price.Insert(price.Length - 3, ".");
            myPrice = "$" + myPrice;
            return myPrice;
        }

        public static string[] getFiles(string directory)
        {
            try
            {
                string[] fileArray = Directory.GetFiles(@directory, "*.pse");
                return fileArray;
            }
            catch (Exception e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }

            return null;
        }

        public static string createExcelFile(string directory)
        {
            //Create excel file
            string excelFileName = "USPS-report-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            string fileDirectory = @directory + "\\" + excelFileName;
            Console.WriteLine(fileDirectory);

            //Enter parameter name
            //// Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;

            //Create Excel application
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                Console.WriteLine("Excel is not installed");
                return null;
            }

            //Create Excel Workbook and Worksheet
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            //Adding parameter names
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "Transaction ID";
            xlWorkSheet.Cells[1, 2] = "Tracking Number";
            xlWorkSheet.Cells[1, 3] = "Amount";

            //Save Excel File
            xlWorkBook.SaveAs(fileDirectory, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            //release Excel Object 
            try
            {
                Marshal.ReleaseComObject(xlApp);
                xlApp = null;
            }
            catch (Exception ex)
            {
                xlApp = null;
                Console.Write("Error " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
            return fileDirectory;
        }

        public static void extractData(string excelFileDirectory, string[] fileArray)
        {
            Cursor.Current = Cursors.WaitCursor;

            //Create Excel application
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                Console.WriteLine("Excel is not installed");
            }

            //Create Excel Workbook and Worksheet
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFileDirectory);
            Excel._Worksheet xlWorksheet = xlWorkbook.Worksheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            xlWorksheet.Columns[1].NumberFormat = "@";
            xlWorksheet.Columns[2].NumberFormat = "@";
           
            xlWorksheet.Columns[1].ColumnWidth = 25;
            xlWorksheet.Columns[2].ColumnWidth = 27;
            xlWorksheet.Columns[3].ColumnWidth = 20;

            //Adding parameter names
            if (fileArray != null)
            {
                int row = 2;
                foreach (string fileName in fileArray)
                {
                    var csv = File.ReadAllText(@fileName);
                    CsvOptions csvOptions = new CsvOptions();
                    csvOptions.HeaderMode = HeaderMode.HeaderAbsent;
                    csvOptions.Separator = ',';
                    csvOptions.RowsToSkip = 1;
                    foreach (var line in CsvReader.ReadFromText(csv, csvOptions))
                    {
                        // Header is handled, each line will contain the actual row data
                        string trackingNum = line[1];
                        string price = line[27];
                        string transactionID = line[25];

                        xlWorksheet.Cells[row, 1] = transactionID;
                        xlWorksheet.Cells[row, 2] = trackingNum;
                        xlWorksheet.Cells[row, 3] = priceConverter(price);

                        row++;
                    }
                }
                xlWorksheet.Cells[row, 3] = "=SUM(C2:C" + (row - 1) + ")";
                xlWorksheet.Cells[row, 4] = "Total";

            }
            //Save Excel File
            xlApp.Visible = false;
            xlApp.UserControl = false;
            xlWorkbook.Save();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }
        

    }
}
