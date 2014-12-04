using Pan.Docks;
using WeifenLuo.WinFormsUI.Docking;

namespace GAsty.Forms
{
    public static class OasisForms
    {
        public static DockManager FormManager = new DockManager();
        public static DockMain DockMain;
        public static DockMap DockMap;
        public static DockGraph DockGraph;
        public static DockCompoundGraph DockCompoundGraph;
        public static DockNode DockNode;
        public static DockLink DockLink;
        public static Service DockService;
        public static DockOperation DockOperation;
        public static DockHazard DockHazard;
        public static DockConsole DockConsole;
        public static DockChart DockChart;
        public static ServiceChart DockServiceChart;

        public static void Initialise()
        {
            DockMain = new DockMain();
            FormManager.Initialize(DockMain.dockPanel1);
            var dockContents = new DockContent[]
            {
                 DockMap = new DockMap(),
                 DockGraph = new DockGraph(),
                 DockCompoundGraph = new DockCompoundGraph(),
                 DockNode = new DockNode(),
                 DockLink = new DockLink(),
                 DockService = new Service(),
                 DockOperation = new DockOperation(),
                 DockHazard = new DockHazard(),
                 DockConsole = new DockConsole(),
                 DockChart = new DockChart(),
                 DockServiceChart = new ServiceChart()
            };
            FormManager.AddDocks(dockContents);
            DockMain.Initialize();
        }

    }
}
