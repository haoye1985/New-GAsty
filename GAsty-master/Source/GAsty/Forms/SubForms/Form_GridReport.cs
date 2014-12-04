using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace GAsty.Forms
{
    public partial class fmGridReportForm : Form
    {
        private string m_StationName;
        private float m_TravelTime;
        private float m_EstimatedTravelTime;

        public fmGridReportForm(string pStationName, float pTravelTime, float pEstimatedTravelTime)
        {
            InitializeComponent();

            this.m_StationName = pStationName;
            this.m_TravelTime = pTravelTime;
            this.m_EstimatedTravelTime = pEstimatedTravelTime;

        }

        public void CreateGraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titiels
            myPane.Title.Text = m_StationName;
            myPane.XAxis.Title.Text = "Orignal Time Value";
            myPane.YAxis.Title.Text = "Affected Time Vlaue";

            string[] labels = {"Travel Time,", "Travel Frequency", "EstimateTravelTime", "EstimateTravelFrequency"};
            double[] y1 = {m_TravelTime};
            double[] y2 = { m_EstimatedTravelTime };

            BarItem myBar1 = myPane.AddBar("Travel Time", null, y1, Color.Blue);
            BarItem myBar2 = myPane.AddBar("Estimated Travel Time", null, y2, Color.Blue);
            myBar1.Bar.Fill = new Fill(Color.Green, Color.White,Color.Green);
            myBar2.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red);
            myPane.XAxis.Scale.TextLabels = labels;
            zgc.AxisChange();

            /*
            PointPairList list = new PointPairList();         
            list.Add(1, value1);
            list.Add(2, value2);

            //// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve", list, Color.Blue,
            SymbolType.Circle);
            //// Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve.Line.Fill = new Fill(Color.White, Color.White, 45F);
            //// Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);

            */
            // Calculate the Axis Scale Ranges

        }








    }
}
