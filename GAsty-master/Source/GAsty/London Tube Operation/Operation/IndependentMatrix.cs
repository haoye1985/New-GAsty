using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAsty.London_Tube_Operation.Operation;

namespace GAsty.London_Tube_Operation
{
    public class IndependentMatrix
    {
        private List<StationODUnit> ODunitCollection;
        public List<StationPassInfo> PasSumCollection;

        public IndependentMatrix(List<StationODUnit> ODcollection)
        {
            this.ODunitCollection = ODcollection;
            this.PasSumCollection = new List<StationPassInfo>();
        }

        public void BuildMatrix()
        {
            StationPassInfo info = new StationPassInfo();
            int sum =0;
            for (int i = 1; i < ODunitCollection.Count; i++)
            {
                if (ODunitCollection[i].StationFromID == ODunitCollection[i + 1].StationFromID)
                {
                    sum += Convert.ToInt32(ODunitCollection[i].WeekdayPassenger);
                }
                else
                {
                    info.StationID = ODunitCollection[i].StationFromID;
                    info.StationName = ODunitCollection[i].StationFromName;
                    info.PassengerNumber = sum;

                }
            }
        }








    }
}
