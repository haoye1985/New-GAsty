using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAsty.London_Tube_Operation.Operation
{
    public class StationODUnit
    {
        private string m_stationFromID;
        private string m_stationFromName;
        private string m_stationToID;
        private string m_stationToName;
        private string m_stationWeekdayPassenger;

        public StationODUnit()
        {
            this.m_stationFromID = String.Empty;
            this.m_stationFromName = String.Empty;
            this.m_stationToID = String.Empty;
            this.m_stationToName = String.Empty;
            this.m_stationWeekdayPassenger = String.Empty;
        }

        public string StationFromID
        {
            get { return this.m_stationFromID; }
            set { m_stationFromID = value; }
        }

        public string StationFromName
        {
            get { return this.m_stationFromName; }
            set { m_stationFromName = value; }
        }

        public string StationToID
        {
            get { return this.m_stationToID; }
            set { m_stationToID = value; }
        }

        public string StationToName
        {
            get { return this.m_stationToName; }
            set { m_stationToName = value; }
        }

        public string WeekdayPassenger
        {
            get { return this.m_stationWeekdayPassenger; }
            set { m_stationWeekdayPassenger = value; }
        }




    }
}
