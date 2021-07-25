using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Utilities
{
    public class Utility
    {
        public string GetData(DataRow drow, string Format) 
        {
            string ReturnData = "";
            string[] SplitStr = Format.Split('%');
            if (SplitStr.Length == 1)
            {
                ReturnData = Format;
            }
            else 
            {
                string TempData = "";
                foreach (string str in SplitStr) 
                {
                    if (str.Length == 0) continue;
                    string[] SplitStr1 = str.Split('#');
                    if (SplitStr1.Length == 1)
                    {
                        string tempstr = str;
                        tempstr = tempstr.Trim();
                        if (tempstr.Length == 0)
                        {
                            TempData += str;
                        }
                        else 
                        {
                            if (drow.Table.Columns.Contains(str))
                            {
                                TempData += drow[str].ToString();
                            }
                            else 
                            {
                                TempData += str;
                            }
                        }
                    }
                    else 
                    {
                        int Startndx = Convert.ToInt32(SplitStr1[1].Substring(0, 3));
                        int Len = Convert.ToInt32(SplitStr1[1].Substring(3, 3));
                        TempData += drow[SplitStr1[0]].ToString().Substring(Startndx,Len);
                    }
                }
                ReturnData = TempData;
            }
            return ReturnData;
        }

        public string GetData(DataRow drow, string Format, char Separator)
        {
            string ReturnData = "";
            string[] SplitStr = Format.Split(Separator);
            if (SplitStr.Length == 1)
            {
                ReturnData = Format;
            }
            else
            {
                string TempData = "";
                foreach (string str in SplitStr)
                {
                    if (str.Length == 0) continue;
                    string[] SplitStr1 = str.Split('#');
                    if (SplitStr1.Length == 1)
                    {
                        string tempstr = str;
                        tempstr = tempstr.Trim();
                        if (tempstr.Length == 0)
                        {
                            TempData += str;
                        }
                        else
                        {
                            if (drow.Table.Columns.Contains(str))
                            {
                                TempData += drow[str].ToString();
                            }
                            else
                            {
                                TempData += str;
                            }
                        }
                    }
                    else
                    {
                        int Startndx = Convert.ToInt32(SplitStr1[1].Substring(0, 3));
                        int Len = Convert.ToInt32(SplitStr1[1].Substring(3, 3));
                        TempData += drow[SplitStr1[0]].ToString().Substring(Startndx, Len);
                    }
                }
                ReturnData = TempData;
            }
            return ReturnData;
        }

        public DataTable ReadExcel(string FileName)
        {
            DataTable dt = new DataTable();
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            //Add DataTable Column Name
            for (int j = 1; j <= colCount; j++)
            {
                //write the value to the console
                if (xlRange.Cells[1, j] != null && xlRange.Cells[1, j].Value2 != null)
                    dt.Columns.Add(xlRange.Cells[1, j].Value2.ToString());

                //add useful things here!   
            }
            for (int i = 2; i <= rowCount; i++)
            {
                dt.Rows.Add(xlRange.Cells[i, 1]);
                for (int j = 1; j <= colCount; j++)
                {
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        dt.Rows[i - 2][j - 1] = xlRange.Cells[i, j].Value2.ToString();
                    }
                }
            }

            //cleanup
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
            return dt;
        }

        public String getDateToday()
        {
            return DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Year.ToString();
        }
    }
}
