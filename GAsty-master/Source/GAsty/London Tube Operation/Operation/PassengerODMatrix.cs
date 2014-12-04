using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAsty.Tube;
using GAsty.Utility;

namespace GAsty.London_Tube_Operation.Operation
{
    public class PassengerODMatrix
    {
        private StreamReader m_reader;
        private List<string[]> m_dataCollection;
        private List<StationODUnit> m_stationODList;

        public PassengerODMatrix(string filename)
        {
            m_reader = new StreamReader(filename);
            m_dataCollection = new List<string[]>();
            m_stationODList = new List<StationODUnit>();
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
                    var stationODunit = new StationODUnit();
                    stationODunit.StationFromName = m_dataCollection[i][1];
                    stationODunit.StationFromID = m_dataCollection[i][0];
                    stationODunit.StationToID = m_dataCollection[i][2];
                    stationODunit.StationToName = m_dataCollection[i][3];
                    stationODunit.WeekdayPassenger = m_dataCollection[i][4];
                    m_stationODList.Add(stationODunit);
                }
            }

            State.StationPassengerODMatrix = m_stationODList;

        }





    }
}
