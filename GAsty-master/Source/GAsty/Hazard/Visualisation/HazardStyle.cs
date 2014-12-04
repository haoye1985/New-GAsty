using System;
using System.Collections.Generic;
using SharpMap.Styles;
using SharpMap.Data;
using System.Drawing;


namespace GAsty.Hazard.Visualisation
{
    public class HazardStyle
    {
        public static VectorStyle HazardFillStyle(FeatureDataRow row)
        {
            var rowStyle = new VectorStyle();
            int risk = 0;
            float temp;
            if (row["Hazard_Val"] != null && (row["Hazard_Val"].ToString() != "0"))
            {
                temp = float.Parse(row["Hazard_Val"].ToString());
                risk = (int)(temp * 10);
            }

            switch (risk.ToString())
            {
                case "0":
                    Color colour1 = Color.FromArgb(60, Color.LawnGreen);
                    Brush brush1 = new SolidBrush(colour1);
                    rowStyle.Fill = brush1;
                    rowStyle.Outline = new Pen(Color.LightBlue, 1);
                    rowStyle.EnableOutline = true;
                    break;
                case "1":
                    Color colour2 = Color.FromArgb(60, Color.LawnGreen);
                    Brush brush2 = new SolidBrush(colour2);
                    rowStyle.Fill = brush2;
                    rowStyle.Outline = new Pen(Color.LightBlue, 1);
                    rowStyle.EnableOutline = true;
                    break;
                case "2":
                    Color colour3 = Color.FromArgb(60, Color.LawnGreen);
                    Brush brush3= new SolidBrush(colour3);
                    rowStyle.Fill = brush3;
                    rowStyle.Outline = new Pen(Color.LightBlue, 1);
                    rowStyle.EnableOutline = true;
                    break;
                case "3":
                    Color colour4= Color.FromArgb(60, Color.LawnGreen);
                    Brush brush4 = new SolidBrush(colour4);
                    rowStyle.Fill = brush4;
                    rowStyle.Outline = new Pen(Color.LightBlue, 1);
                    rowStyle.EnableOutline = true;
                    break;
                case "4":
                    Color colour5 = Color.FromArgb(60, Color.LawnGreen);
                    Brush brush5 = new SolidBrush(colour5);
                    rowStyle.Fill = brush5;
                    rowStyle.Outline = new Pen(Color.LightBlue, 1);
                    rowStyle.EnableOutline = true;
                    break;
                case "5":
                    rowStyle.Fill = Brushes.Green;
                    break;
                case "6":
                    Color colour6 = Color.FromArgb(70, Color.OrangeRed);
                    Brush brush6 = new SolidBrush(colour6);
                    rowStyle.Fill = brush6;
                    rowStyle.Outline = new Pen(Color.LightGray, 1);
                    rowStyle.EnableOutline = true;
                    break;
                case "7":
                    rowStyle.Fill = Brushes.Green;
                    break;
                case "8":
                    Color colour8 = Color.FromArgb(90, Color.Red);
                    Brush brush8 = new SolidBrush(colour8);
                    rowStyle.Fill = brush8;
                    break;
                case "9":
                    rowStyle.Fill = Brushes.Green;
                    break;
                case "10":
                    rowStyle.Fill = Brushes.Green;
                    break;
                default:
                    rowStyle.Fill = Brushes.Green;
                    break;
            }

            return rowStyle;
        }
    }
}
