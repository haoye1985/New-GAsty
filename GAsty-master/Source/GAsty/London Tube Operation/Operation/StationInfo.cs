using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAsty.Tube
{
    public class StationInfo
    {
        private string m_stationID;
        private string m_stationName;
        private string m_stationTimePeriod;
        private string m_stationTotalTimeSpent;
        private string m_stationAverageTimeSpent;
        private string m_stationJourneyFrequency;


        public StationInfo()
        {
            this.m_stationID = String.Empty;
            this.m_stationName = String.Empty;
            this.m_stationTimePeriod = String.Empty;
            this.m_stationTotalTimeSpent = String.Empty;
            this.m_stationAverageTimeSpent = String.Empty;
            this.m_stationJourneyFrequency = String.Empty;
        }

        #region

        public string StationID
        {
            get { return m_stationID; }
            set { m_stationID = value; }
        }

        public string StationName
        {
            get { return m_stationName;}
            set { m_stationName = value; }
        }

        public string StationTimePeriod
        {
            get { return m_stationTimePeriod; }
            set { m_stationTimePeriod = value; }
        }

        public string StationTotalTimeSpent 
        {
            get { return m_stationTotalTimeSpent; }
            set { m_stationTotalTimeSpent = value; }
        }

        public string StationAverageTimeSpent
        {
            get { return m_stationAverageTimeSpent; }
            set { m_stationAverageTimeSpent = value; }
        }

        public string StationJourneyFrequency
        {
            get { return m_stationJourneyFrequency; }
            set { m_stationJourneyFrequency = value; }
        }




        #endregion






    }
}
