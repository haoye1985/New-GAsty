using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using GAsty.Network.Core;
using GAsty.Utility;
using Pan.Utilities;
using WeifenLuo.WinFormsUI.Docking;

namespace GAsty.Forms
{
    public partial class DockNode : DockContent
    {
        public BindingList<GeoNode> GeoNodeCollection;
        public BindingList<GeoNode> ImpactedNodeCollection;

        private delegate void DelSimple();

        public DockNode()
        {
            InitializeComponent();
        }

        private void DockNode_Load(object sender, EventArgs e)
        {

        }

        public void UpdateNodeList()
        {
            GeoNodeCollection = new BindingList<GeoNode>(State.network.GeoNodeCollection);
            ImpactedNodeCollection = new BindingList<GeoNode>(State.impactedNode);

            if (ImpactedNodeCollection.Count == 0)
            {
                dataGridViewPersistent1.DataSource = GeoNodeCollection;
                GeoNodeCollection.AllowRemove = true;
                GeoNodeCollection.AllowEdit = true;
            }
            else
            {
                dataGridViewPersistent1.DataSource = GeoNodeCollection;
                GeoNodeCollection.AllowRemove = true;
                GeoNodeCollection.AllowEdit = true;
                dataGridViewPersistent2.DataSource = State.impactedNode;
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
                dataGridViewPersistent1.UpdateFrom(GeoNodeCollection);
            }
        }


        private void dataGridViewPersistent1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Cut"));
                m.MenuItems.Add(new MenuItem("Copy"));
                m.MenuItems.Add(new MenuItem("Paste"));

                int currentMouseOverRow = dataGridViewPersistent1.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                    //m.MenuItems.Add(new MenuItem(string.Format("the number of rows {0}", selectedCellCount.ToString())));
                }

                m.Show(dataGridViewPersistent1, new Point(e.X, e.Y));
            }
        }

        private void dataGridViewPersistent1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewPersistent1.SelectedRows)
            {
                if (dataGridViewPersistent1.SelectedRows.Count != 0)
                {
                    if (dataGridViewPersistent1.CurrentCell.RowIndex == 1)
                    {

                    }
                    else
                    {
                        if (row.Cells[7].Value != null && row.Cells[8].Value != null && State.IsComputionCompleted)
                        {
                            string stationName = row.Cells[1].Value.ToString();
                            float value1 = float.Parse(row.Cells[8].Value.ToString());
                            float value2 = float.Parse(row.Cells[10].Value.ToString());
                            var form = new fmGridReportForm(stationName, value1, value2);
                            form.Show();
                            form.CreateGraph(form.zedGraphControl1);
                        }
                        
                    }
                }


            }

        }









    }
}
