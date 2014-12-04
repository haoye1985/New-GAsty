using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GAsty.Tube;
using GAsty.Utility;
using Pan.Utilities;
using WeifenLuo.WinFormsUI.Docking;

namespace GAsty.Forms
{
    public partial class DockOperation : DockContent
    {
        public BindingList<TubeStation> GeoStationsCollection;
        public BindingList<TubeLine> GeoLinesCollection; 

        private delegate void DelSimple();

        public DockOperation()
        {
            InitializeComponent();
        }

        public void UpdateLineList()
        {
            GeoLinesCollection = new BindingList<TubeLine>(State.ServiceLines);
            dataGridViewPersistent1.DataSource = GeoLinesCollection;
            GeoLinesCollection.AllowRemove = true;
            GeoLinesCollection.AllowEdit = true;
        }

        public void UpdateStationList()
        {
            GeoStationsCollection = new BindingList<TubeStation>(State.ServiceStations);
            dataGridViewPersistent2.DataSource = GeoStationsCollection;
            GeoStationsCollection.AllowRemove = true;
            GeoStationsCollection.AllowEdit = true;
        }

        public void UpdateStatusList()
        {
            foreach (DataGridViewRow row1 in this.dataGridViewPersistent1.Rows)
            {
                if (row1.Cells[0]!=null && row1.Cells[4].Value!=null && row1.Cells[4].Value.ToString() == "Good Service")
                {
                    row1.Cells[4].Style.BackColor = Color.GreenYellow;
                }
                else
                {
                    row1.Cells[4].Style.BackColor = Color.Orange;
                }

                foreach (DataGridViewRow row2 in this.dataGridViewPersistent2.Rows)
                {
                    if (row2.Cells[0] != null && row2.Cells[3].Value != null && row2.Cells[3].Value.ToString() == "Open")
                    {
                        row2.Cells[3].Style.BackColor = Color.GreenYellow;
                    }
                    else if (row2.Cells[0] != null && row2.Cells[3].Value != null && row2.Cells[3].Value.ToString() == "DisruptedService")
                    {
                        row2.Cells[3].Style.BackColor = Color.Orange;
                    }
                    else
                    {
                        row2.Cells[3].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        public void UpdateList()
        {
            if (InvokeRequired)
            {
                Invoke(new DelSimple(UpdateList), new object[] { });
            }
            else
            {
                dataGridViewPersistent1.UpdateFrom(GeoStationsCollection);
                dataGridViewPersistent1.UpdateFrom(GeoLinesCollection);
            }
        }








    }
}
