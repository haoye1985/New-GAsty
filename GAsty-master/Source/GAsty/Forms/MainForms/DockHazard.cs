using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using GAsty.Hazard.Core;
using WeifenLuo.WinFormsUI.Docking;
using GAsty.Utility;

namespace GAsty.Forms
{
    public partial class DockHazard : DockContent
    {
        public BindingList<GeoHazardCell> HazardCellCollection;

        public DockHazard()
        {
            InitializeComponent();
        }

        public void UpdateHazardList()
        {
            this.dataGridViewPersistent1.DataSource = new BindingList<GeoHazardCell>(State.HazardCellCollection);
            this.dataGridViewPersistent2.DataSource = new BindingList<GeoHazardCell>(State.impactedHazardCells);
        }


    }
}
