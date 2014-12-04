using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAsty.Forms;
using GAsty.Network.Core;
using GAsty.Utility;
using Excel = Microsoft.Office.Interop.Excel;

namespace GAsty.Tube
{
    public static class TfLDataParser
    {

        public static void ParseLineData() 
        {
            var LineList = new List<TubeLine>();

            var doc = XElement.Load(@"D:\GAsty\GAsty\XMLData\LineStatus.xml");

            IEnumerable<XElement> childElements =
                from el in doc.Elements()
                select el;

            foreach (var el in childElements)
            {
                XNode StatusdetailNode = el.FirstNode;
                XNode idNode = el.FirstNode.NextNode;
                XNode statusNode = idNode.NextNode;

                if (StatusdetailNode != null)
                {
                    var newLine = new TubeLine((idNode as XElement).Attribute("ID").Value, (idNode as XElement).Attribute("Name").Value, (statusNode as XElement).Attribute("ID").Value, (statusNode as XElement).Attribute("CssClass").Value, (statusNode as XElement).Attribute("Description").Value);
                    LineList.Add(newLine);
                }
            }

            State.ServiceLines = LineList;
            OasisForms.DockOperation.UpdateLineList();
        }

        public static void ParseStationData()
        {
            List<TubeStation> stations = new List<TubeStation>();

            var doc = XElement.Load(@"D:\GAsty\GAsty\XMLData\StationStatus.xml");
            IEnumerable<XElement> childElements =
                from el in doc.Elements()
                select el;

            foreach (var el in childElements)
            {
                XNode StatusdetailNode = el.FirstNode;
                XNode idNode = el.FirstNode.NextNode;

                if (StatusdetailNode != null)
                {
                    var newStation = new TubeStation((StatusdetailNode as XElement).Attribute("ID").Value,
                        (StatusdetailNode as XElement).Attribute("Name").Value,
                        (idNode as XElement).Attribute("Description").Value, ((idNode as XElement).Attribute("CssClass").Value));

                    //MessageBox.Show(newStation.StationID + " " + newStation.StationName +" " + newStation.StationDescription);

                    stations.Add(newStation);
                }
            }

            State.ServiceStations = stations;
            OasisForms.DockOperation.UpdateStationList();
            OasisForms.DockOperation.UpdateStatusList();
        }


        public static void ParsePredictionSummaryData()
        {
            var doc = XElement.Load(@"D:\GAsty\GAsty\XMLData\PredictionSummary.xml");
            IEnumerable<XElement> childElements =
                from el in doc.Elements()
                select el;

            foreach (var el in childElements)
            {
                XNode StatusdetailNode = el.FirstNode;
                XNode idNode = el.FirstNode.NextNode;
            }
        }

        public static void AssignServiceData()
        {
            List<TubeStation> stationList = State.ServiceStations;
            List<GeoNode> nodeList = State.network.GeoNodeCollection;

            foreach (var station in stationList)
            {
                foreach (var geonode in nodeList)
                {
                    if (station.StationName == geonode.Name)
                    {
                        geonode.CurrentStatusSDescription= station.StationDescription;
                        geonode.Service = station.StationClass;

                    }
                }               
            } 
        }


        /// <summary>
        /// Output Passenger Data
        /// </summary>
        public static void ParsePassengerData()
        {
            // Access Mode by the station
            string filePath =
                @"C:\Users\hye\Desktop\GAsty\GAsty-master\Data\PassengerData\Entry\Access Mode by Station-Zone-Time of day2012.xls";
            Excel.Application excel = null;
            Excel.Workbook wkb = null;





        }






    }
}
