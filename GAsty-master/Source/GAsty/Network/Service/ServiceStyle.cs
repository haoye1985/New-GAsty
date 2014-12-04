using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpMap.Data;
using SharpMap.Rendering.Symbolizer;
using SharpMap.Styles;

namespace GAsty.Network.Service
{
    public static class ServiceStyle
    {

        public static VectorStyle GetNodeServiceStyle(FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();

            if (row["Service"] != null)
            {
                string temp = row["Service"].ToString();

                switch (temp)
                {
                    case "Unknown":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Black), Brushes.White,
                            14);
                        break;
                    case "Normal":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.GreenYellow), Brushes.LawnGreen, 14);
                        break;
                    case "Weak":
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.Gold),
                            Brushes.MediumSpringGreen, 14);
                        break;

                    default:
                        rowStyle.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.AliceBlue), Brushes.GreenYellow,
                            14);
                        break;
                }
            }

            return rowStyle;
        }

        public static VectorStyle GetLinkServiceStyle(FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();

            if (row["Service"] != null)
            {
                string temp = row["Service"].ToString();

                switch (temp)
                {
                    case "Good":
                    rowStyle.Line.Color = Color.GreenYellow;
                    rowStyle.Line.Width = 5;                 
                        break;
                    case "Normal":
                    rowStyle.Line.Color = Color.Chartreuse;
                    rowStyle.Line.Width = 5;
                        break;
                    case "Weak":
                    rowStyle.Line.Color = Color.OrangeRed;
                    rowStyle.Line.Width = 5;
                        break;

                    default:
                    rowStyle.Line.Color = Color.Black;
                    rowStyle.EnableOutline = true;
                    rowStyle.Outline.Color = Color.GreenYellow;
                    rowStyle.Line.Width = 5;
                    break;
                }
            }
            else
            {
                rowStyle.Line.Color = Color.Green;
                rowStyle.EnableOutline = true;
                rowStyle.Outline.Color = Color.GreenYellow;
                rowStyle.Line.Width = 5;
            }
            return rowStyle;
        }

        public static VectorStyle GetLinkRiskServiceStyle(FeatureDataRow row)
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
                    rowStyle.Line.Color = Color.LightGreen;
                    rowStyle.Line.Width = 7;
                    break;
                case "1":
                    rowStyle.Line.Color = Color.LawnGreen;
                    rowStyle.Line.Width = 7;
                    break;
                case "2":
                    rowStyle.Line.Color = Color.MediumSpringGreen;
                    rowStyle.Line.Width = 7;
                    break;
                case "3":
                    rowStyle.Line.Color = Color.LightGreen;
                    rowStyle.Line.Width = 7;
                    break;
                case "4":
                    rowStyle.Line.Color = Color.LightYellow;
                    rowStyle.Line.Width = 7;
                    break;
                case "5":
                    rowStyle.Line.Color = Color.Yellow;
                    rowStyle.Line.Width = 7;
                    break;
                case "6":
                    rowStyle.Line.Color = Color.Orange;
                    rowStyle.Line.Width = 7;
                    break;
                case "7":
                    rowStyle.Line.Color = Color.DarkOrange;
                    rowStyle.Line.Width = 7;
                    break;
                case "8":
                    rowStyle.Line.Color = Color.Salmon;
                    rowStyle.Line.Width = 7;
                    break;
                case "9":
                    rowStyle.Line.Color = Color.OrangeRed;
                    rowStyle.Line.Width = 7;
                    break;
                case "10":
                    rowStyle.Line.Color = Color.Red;
                    rowStyle.Line.Width = 7;
                    break;

                default:
                    rowStyle.Line.Color = Color.Gray;
                    rowStyle.Line.Width = 7;
                    break;
            }

            //var rowStyle = new VectorStyle();

            //if (row["Service"] != null)
            //{
            //    string temp = row["Service"].ToString();

            //    switch (temp)
            //    {
            //        case "Good":
            //            rowStyle.Line.Color = Color.LightGreen;
            //            rowStyle.Line.Width = 7;
            //            break;
            //        case "Normal":
            //            rowStyle.Line.Color = Color.Yellow;
            //            rowStyle.Line.Width = 7;
            //            break;
            //        case "Weak":
            //            rowStyle.Line.Color = Color.Red;
            //            rowStyle.Line.Width = 7;
            //            break;

            //        default:
            //            rowStyle.Line.Color = Color.Blue;
            //            rowStyle.EnableOutline = true;
            //            rowStyle.Outline.Color = Color.GreenYellow;
            //            rowStyle.Line.Width = 7;
            //            break;
            //    }
            //}
            //else
            //{
            //    rowStyle.Line.Color = Color.LawnGreen;
            //    rowStyle.EnableOutline = true;
            //    rowStyle.Outline.Color = Color.GreenYellow;
            //    rowStyle.Line.Width = 7;
            //}
            return rowStyle;
        }




    }
}
