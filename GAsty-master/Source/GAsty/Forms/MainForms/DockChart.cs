using GAsty.Helpers;
using GAsty.Utility;
using Oasis;
using WeifenLuo.WinFormsUI.Docking;

namespace GAsty.Forms
{
    public partial class DockChart : DockContent
    {
        public DockChart()
        {
            InitializeComponent();
        }

        public void UpdateCharts()
        {
            ChartHelper.DrawLinkAij(zedGraphControl1, State.network);
            ChartHelper.DrawNodeCi(zedGraphControl2, State.network);
            ChartHelper.DrawNodeDegree(zedGraphControl3,State.network);
            ChartHelper.DrawNodeXDij(zedGraphControl4, State.network);

            ChartHelper.DrawNodeXDij(zedGraphControl5, State.network);
            ChartHelper.DrawLinkAij(zedGraphControl6, State.network);
            ChartHelper.DrawNodeCi(zedGraphControl7,State.network);
            ChartHelper.DrawNodeDegree(zedGraphControl8, State.network);
        }


    }
}
