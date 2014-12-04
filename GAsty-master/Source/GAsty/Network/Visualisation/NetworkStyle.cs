using System.Drawing;
using SharpMap.Rendering.Symbolizer;
using SharpMap.Styles;
using GAsty.Network.Core;

namespace GAsty.Network.Visualisation
{
    public static class NetworkStyle
    {

        public static VectorStyle GetRiskLineStyle(SharpMap.Data.FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();
            int risk = 0;
            float temp;

            if (row["Service"] != null && (row["Service"].ToString() != "0"))
            {
                temp = float.Parse(row["Service"].ToString());
                risk = (int)(temp * 10);
            }

            switch (risk.ToString())
            {
                case "0":
                    var cls = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls;
                    break;
                case "1":
                    var cls1 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls1.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls1;
                    break;
                case "2":
                    var cls2 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls2.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls2;
                    break;
                case "3":
                    var cls3 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls3.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls3;
                    break;
                case "4":
                    var cls4 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls4.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls4;
                    break;
                case "5":
                    var cls5 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls5.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls5;
                    break;
                case "6":
                    var cls6 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls6.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls6;
                    break;
                case "7":
                    var cls7 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls7.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls7;
                    break;
                case "8":
                    var cls8 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls8.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls8;
                    break;
                case "9":
                    var cls9 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls9.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls9;
                    break;
                case "10":
                    var cls10 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls10.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls10;
                    break;
                default:
                    var cls11 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls11.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls11;
                    break;
            }

            return rowStyle;
        }

        public static VectorStyle GetMyLineStyle(SharpMap.Data.FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();
            int risk = 0;
            float temp;

            if (row["Service"] != null && (row["Service"].ToString() != "0"))
            {
                temp = float.Parse(row["Service"].ToString());
                risk = (int)(temp * 10);
            }

            switch (risk.ToString())
            {
                case "0":
                    var cls = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls;
                    break;
                case "1":
                    var cls1 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls1.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls1;
                    break;
                case "2":
                    var cls2 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls2.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls2;
                    break;
                case "3":
                    var cls3 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls3.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls3;
                    break;
                case "4":
                    var cls4 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls4.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls4;
                    break;
                case "5":
                     var cls5 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls5.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls5;
                    break;
                case "6":
                    var cls6 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls6.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls6;
                    break;
                case "7":
                    var cls7 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls7.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls7;
                    break;
                case "8":
                    var cls8 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls8.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls8;
                    break;
                case "9":
                    var cls9 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls9.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls9;
                    break;
                case "10":
                   var cls10 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls10.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls10;
                    break;
                default:
                    var cls11 = new SharpMap.Rendering.Symbolizer.CachedLineSymbolizer();
                    cls11.LineSymbolizeHandlers.Add(new SharpMap.Rendering.Symbolizer.PlainLineSymbolizeHandler { Line = new System.Drawing.Pen(System.Drawing.Color.Gold, 1) });
                    rowStyle.LineSymbolizer = cls11;
                    break;
            }

            return rowStyle;
        }

        public static VectorStyle GetMyPointStyle(SharpMap.Data.FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();
            int risk = 0;
            float temp;

            if (row["RiskIndex"] != null && (row["RiskIndex"].ToString() != "0"))
            {
                temp = float.Parse(row["RiskIndex"].ToString());
                risk = (int)(temp * 10);
            }

            switch (risk.ToString())
            {
                case "0":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Green, 12);
                    break;
                case "1":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LawnGreen, 12);
                    break;
                case "2":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.MediumSpringGreen, 12);
                    break;
                case "3":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LightGreen, 12);
                    break;
                case "4":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LightYellow, 12);
                    break;
                case "5":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Yellow, 12);
                    break;
                case "6":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Orange, 12);
                    break;
                case "7":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.DarkOrange, 12);
                    break;
                case "8":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Salmon, 12);
                    break;
                case "9":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.OrangeRed, 12);
                    break;
                case "10":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Red, 12);
                    break;

                default:
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.White), Brushes.Gray, 12);
                    break;
            }
             return rowStyle;   
        }

        public static VectorStyle GetMyCentroidStyle(SharpMap.Data.FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();
            int risk = 0;
            float temp;

            if (row["Type"].ToString() == NodeEnum.Centroid.ToString())
            {
                if (row["RiskIndex"] != null && (row["RiskIndex"].ToString() != "0"))
                {
                    temp = float.Parse(row["RiskIndex"].ToString());
                    risk = (int)(temp * 10);
                }

                switch (risk.ToString())
                {
                    case "0":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Blue, 12);
                        break;
                    case "1":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LawnGreen, 12);
                        break;
                    case "2":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.MediumSpringGreen, 11);
                        break;
                    case "3":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LightGreen, 11);
                        break;
                    case "4":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LightYellow, 11);
                        break;
                    case "5":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Yellow, 11);
                        break;
                    case "6":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Orange, 11);
                        break;
                    case "7":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.DarkOrange, 11);
                        break;
                    case "8":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Salmon, 11);
                        break;
                    case "9":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.OrangeRed, 11);
                        break;
                    case "10":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Yellow, 11);
                        break;

                    default:
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.White), Brushes.Gray, 11);
                        break;
            }
        }

            return rowStyle;

        }

        public static VectorStyle GetMyServiceStyle(SharpMap.Data.FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();
            int risk = 0;
            float temp;

            if (row["Service"] != null && (row["Service"].ToString() != "0"))
            {
                 temp = float.Parse(row["Service"].ToString());
                risk = (int)(temp * 10);
            }

            switch (risk.ToString())
            {
                case "0":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LightGreen, 20);
                    break;
                case "1":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LawnGreen, 20);
                    break;
                case "2":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.MediumSpringGreen, 20);
                    break;
                case "3":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LightGreen, 20);
                    break;
                case "4":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LightYellow, 20);
                    break;
                case "5":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Yellow, 20);
                    break;
                case "6":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Orange, 20);
                    break;
                case "7":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.DarkOrange, 20);
                    break;
                case "8":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.Salmon, 20);
                    break;
                case "9":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.OrangeRed, 20);
                    break;
                case "10":
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.LawnGreen, 20);
                    break;

                default:
                    rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.White), Brushes.YellowGreen, 20);
                    break;
            }

            return rowStyle;

        }
    }
}
