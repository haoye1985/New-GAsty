using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAsty.Helpers;
using GAsty.Utility;
using WeifenLuo.WinFormsUI.Docking;

namespace GAsty.Forms
{
    public partial class ServiceChart : DockContent
    {
        public ServiceChart()
        {
            InitializeComponent();
        }

        public void UpdateService()
        {
            ChartHelper.DrawStationService(this.zedGraphControl2, State.StationInformation);
            ChartHelper.DrawJourneyFrequency(this.zedGraphControl3, State.StationInformation);
            ChartHelper.DrawTimeSpentComparison(this.zedGraphControl4, State.network);
            ChartHelper.DrawJourneyFrequencyComparison(this.zedGraphControl5, State.network);
        }



    }
}
