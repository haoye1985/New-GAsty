using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace GAsty
{
    public class ExcelHelper
    {
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;

        public ExcelHelper()
        {
            MyApp = new Excel.Application();
            MyBook = new Excel.Workbook();
        }
        
        


    }
}
