using System.Collections.Generic;
using System.IO;
using GAsty.Network.Core;
using GAsty.Utility;

namespace GAsty.Tube
{
    class PassengerMode
    {
        private StreamReader m_reader;
        private List<string[]> m_dataCollection;
        private List<StationInfo> m_stationInfoList; 

        public PassengerMode(string filename)
        {
            m_reader = new StreamReader(filename);
            m_dataCollection = new List<string[]>();
            m_stationInfoList = new List<StationInfo>();
        }

        public void GetStationModeData()
        {
            string line = "";
            while ((line = m_reader.ReadLine()) != null)
            {
                m_dataCollection.Add(line.Split(','));
            }
        }

        public void AssignDataToStation()
        {
            for (int i = 0; i < m_dataCollection.Count; i++)
            {
                if (i == 0)
                {
                }
                else
                {
                    var stationInfo = new StationInfo();
                    stationInfo.StationID = m_dataCollection[i][0];
                    stationInfo.StationName = m_dataCollection[i][1];
                    stationInfo.StationTimePeriod = m_dataCollection[i][2];
                    stationInfo.StationTotalTimeSpent = m_dataCollection[i][3];
                    stationInfo.StationAverageTimeSpent = m_dataCollection[i][4];
                    stationInfo.StationJourneyFrequency = m_dataCollection[i][5];
                    m_stationInfoList.Add(stationInfo);
                }
            }

            State.StationInformation = m_stationInfoList;
        }

        public void AssignDataToNode()
        {
            List<StationInfo> stationList = State.StationInformation;
            List<GeoNode> nodeList = State.network.GeoNodeCollection;
            List<GeoLink> linkList = State.network.GeoLinkCollection;

            foreach (var stationinfo in stationList)
            {
                foreach (var geonode in nodeList)
                {
                    if (stationinfo.StationName.Trim() == geonode.Name)
                    {
                        geonode.CurrentTravelTime = stationinfo.StationAverageTimeSpent;
                        geonode.CurrentTravelFrequency = int.Parse(stationinfo.StationJourneyFrequency);
                    }
                }

                foreach (var geonode in nodeList)
                {
                    foreach (var geoLink in linkList)
                    {
                        if (geonode.ID == geoLink.FromNodeID)
                        {
                            geoLink.FromNodeIDName =geonode.Name;
                        }

                        if (geonode.ID == geoLink.ToNodeID)
                        {
                            geoLink.ToNodeIDName = geonode.Name;
                        }
                    }
                }
            } 
            
        }




    }
}
