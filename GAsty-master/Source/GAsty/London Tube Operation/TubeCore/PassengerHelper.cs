using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Com.StellmanGreene.CSVReader;
using GAsty.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace GAsty.Tube.TubeCore
{
    public class PassengerHelper
    {
        private string filePath =
            @"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData\Entry\Access Mode by Station-Zone-Time of day2012.xls";
        private string fileName;

        public PassengerHelper()
        {

        }


        public void DoDataImport()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv) | *.csv";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataTable table = CSVReader.ReadCSVFile(dialog.FileName, true);
                OasisForms.DockNode.dataGridViewPersistent1.DataSource = table;
            }


        }




    }
}
