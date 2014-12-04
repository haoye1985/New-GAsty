using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAsty.Tube;
using WeifenLuo.WinFormsUI.Docking;
using GAsty.Network.Core;
using GAsty.Utility;

namespace GAsty.Forms
{
    public partial class Service : DockContent
    {
        public BindingList<GeoService> GeoServiceCollection;
        public BindingList<GeoNetwork> GeoNetwork; 

        private delegate void DelSimple();

        public Service()
        {
            InitializeComponent();
        }

        public void UpdateServiceList()
        {
            if (State.StationInformation.Count != 0 || State.StationPassengerODMatrix.Count !=0)
            {
                dataGridViewPersistent1.DataSource = State.StationInformation;
                dataGridViewPersistent2.DataSource = State.StationPassengerODMatrix;
            }
            else
            {
                dataGridViewPersistent1.DataSource = State.ServiceNetworkCollection;

                //GeoServiceCollection = new BindingList<GeoService>(State.network.GetServiceCollection);
                //dataGridViewPersistent1.DataSource = GeoServiceCollection;
                //GeoServiceCollection.AllowRemove = true;
                //GeoServiceCollection.AllowEdit = true;
            }
        }

        private void dataGridViewPersistent2_CellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            //// If this is the row for new records, no values are needed.   
            //if (e.RowIndex == this.dataGridViewPersistent2.RowCount)
            //    return;
            //// 从记录集中读取数据   
            //string colName = this.dataGridViewPersistent2.Columns[e.ColumnIndex].Name;
            //if (colName.Equals(NumberColName))
            //{
            //    e.Value = e.RowIndex + 1;
            //}
            //else
            //{
            //    oRst.MoveTo(e.RowIndex + 1);
            //    e.Value = oRst.GetFieldValueText(colName);
            //} 
        }



    }
}
