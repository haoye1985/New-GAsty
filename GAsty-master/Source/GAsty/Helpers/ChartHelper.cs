using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Documents;
using GAsty.Network.Core;
using GAsty.Tube;
using Oasis;
using ZedGraph;

namespace GAsty.Helpers
{
    public static class ChartHelper
    {

        public static void DrawTimeSpentComparison(ZedGraphControl zgc, GeoNetwork pNetwork)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.BarSettings.Type = BarType.Stack;

            myPane.Title.Text = "Journey Time Spent Comparision *1000";
            myPane.XAxis.Title.Text = "Station ID";
            myPane.YAxis.Title.Text = "Average Time Spent";

            int count = pNetwork.GeoNodeCollection.Count;
            double[] Xi = new double[count];
            double[] Wi = new double[count];

            for (int i = 0; i < count; i++)
            {
                Wi[i] = Convert.ToDouble(pNetwork.GeoNodeCollection[i].CurrentTravelTime) / 1000;
                Xi[i] = Convert.ToDouble(pNetwork.GeoNodeCollection[i].EstimateTimeSpent) / 1000;
            }
            //BarItem InOper = myPane.AddBar("Inoperability", null, Xi, Color.Red);
            BarItem Oper = myPane.AddBar("Current Time Spent", null, Wi, Color.Green);
            BarItem InOper = myPane.AddBar("Estimate Time Spent", null, Xi, Color.Red);
            //InOper.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);
            Oper.Bar.Fill = new Fill(Color.GreenYellow, Color.GreenYellow, Color.GreenYellow);
            InOper.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);
            zgc.AxisChange();
        }

        public static void DrawJourneyFrequencyComparison(ZedGraphControl zgc, GeoNetwork pNetwork)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.BarSettings.Type = BarType.Stack;

            myPane.Title.Text = "Journey Time Spent Comparision";
            myPane.XAxis.Title.Text = "Station ID";
            myPane.YAxis.Title.Text = "Average Time Spent";

            int count = pNetwork.GeoNodeCollection.Count;
            double[] Xi = new double[count];
            double[] Wi = new double[count];

            for (int i = 0; i < count; i++)
            {
                Wi[i] = Convert.ToDouble(pNetwork.GeoNodeCollection[i].CurrentTravelFrequency) / 10000;
                Xi[i] = Convert.ToDouble(pNetwork.GeoNodeCollection[i].EstimateTravelFrequency) / 10000;
            }
            //BarItem InOper = myPane.AddBar("Inoperability", null, Xi, Color.Red);
            BarItem Oper = myPane.AddBar("Current Time Spent", null, Wi, Color.Green);
            BarItem InOper = myPane.AddBar("Estimate Time Spent", null, Xi, Color.Red);
            //InOper.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);
            Oper.Bar.Fill = new Fill(Color.GreenYellow, Color.GreenYellow, Color.GreenYellow);
            InOper.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);
            zgc.AxisChange();
        }



        public static void DrawJourneyFrequency(ZedGraphControl zgc, List<StationInfo> stationInformation)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.BarSettings.Type = BarType.Stack;

            myPane.Title.Text = "Journey Frequency Distribution";
            myPane.XAxis.Title.Text = "Station ID";
            myPane.YAxis.Title.Text = "Average Journal Frequency";

            int count = stationInformation.Count;
            double[] Xi = new double[count];
            double[] Wi = new double[count];

            for (int i = 0; i < stationInformation.Count; i++)
            {
                //Xi[i] = stationInformation[i].StationName;
                Wi[i] = Convert.ToDouble(stationInformation[i].StationJourneyFrequency);
            }
            //BarItem InOper = myPane.AddBar("Inoperability", null, Xi, Color.Red);
            BarItem Oper = myPane.AddBar("Average Journal Frequency", null, Wi, Color.Green);
            //InOper.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);
            Oper.Bar.Fill = new Fill(Color.GreenYellow, Color.GreenYellow, Color.GreenYellow);
            zgc.AxisChange();
        }

        public static void DrawStationService(ZedGraphControl zgc, List<StationInfo> stationInformation)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.BarSettings.Type = BarType.Stack;

            myPane.Title.Text = "Station Passenger Distribution";
            myPane.XAxis.Title.Text = "Station ID";
            myPane.YAxis.Title.Text = "Average Journal Time";

            int count = stationInformation.Count;
            double[] Xi = new double[count];
            double[] Wi = new double[count];
            for (int i = 0; i < stationInformation.Count; i++)
            {
                //Xi[i] = stationInformation[i].StationName;
                Wi[i] = Convert.ToDouble(stationInformation[i].StationAverageTimeSpent);
            }
            //BarItem InOper = myPane.AddBar("Inoperability", null, Xi, Color.Red);
            BarItem Oper = myPane.AddBar("Average Journal Time", null, Wi, Color.Green);
            //InOper.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);
            Oper.Bar.Fill = new Fill(Color.GreenYellow, Color.GreenYellow, Color.GreenYellow);
            zgc.AxisChange();
        }

        public static void DrawNodeXDij(ZedGraphControl zgc, GeoNetwork network)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.BarSettings.Type = BarType.Stack;

            myPane.Title.Text = "Xij Distribution";
            myPane.XAxis.Title.Text = "Node IDs";
            myPane.YAxis.Title.Text = "Node Value";

            int count = network.GeoNodeCollection.Count;
            double[] Xi = new double[count];
            double[] Wi = new double[count];
            for (int i = 0; i < count; i++)
            {
                Xi[i] = network.GeoNodeCollection[i].RiskXi;
                Wi[i] = 1 - network.GeoNodeCollection[i].RiskXi;
            }
            BarItem InOper = myPane.AddBar("Inoperability", null, Xi, Color.Red);
            BarItem Oper = myPane.AddBar("Operability", null, Wi, Color.Green);
            InOper.Bar.Fill = new Fill(Color.Red, Color.Red, Color.Red);
            Oper.Bar.Fill = new Fill(Color.GreenYellow, Color.GreenYellow, Color.GreenYellow);
            zgc.AxisChange();
        }

        public static void DrawLinkAij(ZedGraphControl zgc, GeoNetwork network)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.Text = "Aij Distribution";
            myPane.XAxis.Title.Text = "Link IDs";
            myPane.YAxis.Title.Text = "Link Value";

            int count = network.GeoLinkCollection.Count;
            double[] Aij = new double[count];
            double[] Pij = new double[count];
            for (int i = 0; i < count; i++)
            {
                Aij[i] = network.GeoLinkCollection[i].RiskAij;
                Pij[i] = network.GeoLinkCollection[i].RiskPij;
            }
            BarItem AijBar = myPane.AddBar("Aij", null, Aij, Color.Blue);
            BarItem PijBar = myPane.AddBar("Pij", null, Pij, Color.Green);
            AijBar.Bar.Fill = new Fill(Color.Brown, Color.Brown, Color.Brown);
            PijBar.Bar.Fill = new Fill(Color.Green, Color.Green, Color.Green);
            zgc.AxisChange();
        }

        public static void DrawNodeCi(ZedGraphControl zgc, GeoNetwork network)
        {
            GraphPane myPane = zgc.GraphPane;

            myPane.Title.Text = "Ci Distribution";
            myPane.XAxis.Title.Text = "Node IDs";
            myPane.YAxis.Title.Text = "Node Ci Value";

            int count = network.GeoNodeCollection.Count;
            double[] Ci = new double[count];
            for (int i = 0; i < count; i++)
            {
                Ci[i] = network.GeoNodeCollection[i].RiskCi;
            }

            BarItem CiBar = myPane.AddBar("Ci", null, Ci, Color.Blue);
            CiBar.Bar.Fill = new Fill(Color.Orange, Color.White, Color.Orange);
            zgc.AxisChange();
        }

        public static void DrawNodeDegree(ZedGraphControl zgc, GeoNetwork network)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.Title.Text = "Node Degree Distribution";
            myPane.XAxis.Title.Text = "Node IDs";
            myPane.YAxis.Title.Text = "Node Degree Value";

            int count = network.GeoNodeCollection.Count;
            double[] Degree = new double[count];

            for (int i = 0; i < count; i++)
            {
                Degree[i] = network.GeoNodeCollection[i].Degree;
            }

            BarItem CiBar = myPane.AddBar("Degree", null, Degree, Color.Blue);
            CiBar.Bar.Fill = new Fill(Color.DarkMagenta, Color.White, Color.DarkMagenta);
            zgc.AxisChange();
        }

    }
}
