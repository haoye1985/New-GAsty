using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAsty.London_Tube_Operation
{
    public class StationPassInfo
    {
        private string m_stationID;
        private string m_stationName;
        private int m_passenger;

        public StationPassInfo()
        {
            this.m_stationID = String.Empty;
            this.m_stationName = String.Empty;
            this.m_passenger = 0;
        }

        public string StationID
        {
            get { return m_stationID; }
            set { m_stationID = value; }
        }

        public string StationName
        {
            get { return m_stationName; }
            set { m_stationName = value; }
        }

        public int PassengerNumber
        {
            get { return m_passenger; }
            set { m_passenger = value; }
        }






    }
}
