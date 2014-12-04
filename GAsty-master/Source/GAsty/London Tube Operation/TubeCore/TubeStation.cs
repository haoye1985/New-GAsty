using System;
using System.Collections.Generic;



namespace GAsty.Tube
{
    public class TubeStation
    {
        private string m_stationID;
        private string m_stationName;
        private string m_numOfPlatform;
        private string m_stationStatus;
        private string m_stationDescription;
        private string m_stationCssClass;

        public TubeStation()
        {
        }

        public TubeStation(string pstationID, string pStationName, string pStationDescription, string pClass)
        {
            this.m_stationID = pstationID;
            this.m_stationName = pStationName;
            this.m_stationDescription = pStationDescription;
            this.m_stationCssClass = pClass;
        }

        public string StationID
        {
            get { return this.m_stationID; }
            set { m_stationID = value; }
        }

        public string StationName
        {
            get { return this.m_stationName; }
            set { m_stationName = value; }
        }

        public string StationDescription
        {
            get { return this.m_stationDescription; }
            set { m_stationDescription = value; }
        }

        public string StationClass
        {
            get { return this.m_stationCssClass; }
            set { m_stationCssClass = value; }
        }


    }
}
