using Microsoft.Office.Interop.Excel;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excel
{
    class Excel: IFileWorker
    {
        public Workbook Workbook { get; set; }
        public Worksheet Worksheet { get; set; }

        _Application excel = new Application();
        Logger _logger = LogManager.GetCurrentClassLogger();

        public List<int> ReadFile(string path, int sheetAmount, List<int> columns)
        {
            var data = new List<int>();

            try
            {
                Workbook = excel.Workbooks.Open(path);
                Worksheet = Workbook.Worksheets[sheetAmount];

                Range xlRange = Worksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (xlRange.Cells[i, columns[j]] != null && xlRange.Cells[i, columns[j]].Value2 != null)
                            data.Add(Int32.Parse(xlRange.Cells[i, columns[j]].Value2.ToString()));
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                _logger.Fatal(e.Message);
            }
            catch (NullReferenceException e)
            {
                _logger.Fatal(e.Message);
            }
            finally
            {
                CloseConnection();
            }

            return data.Distinct().ToList();
        }

        public void WriteIntoFile(string path, int sheetAmount, List<int> numbers, int column)
        {
            try
            {
                Workbook = excel.Workbooks.Add();
                Worksheet = Workbook.Worksheets[sheetAmount];

                for (int i = 0; i < numbers.Count; i++)
                {
                    Worksheet.Cells[i + 1, column] = numbers[i];
                }

                Workbook.SaveAs(path);
            }
            catch (NullReferenceException e)
            {
                _logger.Fatal(e.Message);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                _logger.Fatal(e.Message);
            }
            finally
            {          
                CloseConnection();
            }
        }

        private void CloseConnection()
        {
            try
            {
                Workbook.Close();
                excel.Quit();
            }
            catch(NullReferenceException e)
            {
                _logger.Fatal(e.Message);
            }
        }        
    }
}
