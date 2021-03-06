﻿using LXXCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelOperationStudy
{
    public class ExcelOperator
    {
        public static void DoSomething1()
        {
            var bmp = DisplayUtility.CaptureScreen();
            Clipboard.SetImage(bmp);

            var wb = new Excel.Application().Workbooks.Open(@"C:\Users\u851299\Desktop\Test\TotalReport.xlsm");
            try
            {
                foreach (Excel.Worksheet ws in wb.Worksheets)
                {
                    Console.WriteLine(ws.Name);

                    Excel.Range r = ws.Range["A1", "G20"];
                    foreach (Excel.Range c in r.Cells)
                    {
                        string v = c.Value as string;
                        if (!string.IsNullOrEmpty(v))
                        {
                            Console.WriteLine(v);
                            break;
                        }
                    }
                }

                var wsCount = wb.Sheets.Count;
                var lastWS = (Excel.Worksheet)wb.Worksheets.get_Item(wsCount);
                var newWS = (Excel.Worksheet)wb.Sheets.Add(Missing.Value, lastWS);
                newWS.Name = string.Format("Rai{0}", wsCount);
                newWS.Activate();
                newWS.Paste();
            }
            finally
            {
                wb.Close(true);
            }
        }
    }
}
