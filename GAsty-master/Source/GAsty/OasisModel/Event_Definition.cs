using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAsty.OasisModel
{
    public class Event_Definition
    {
        /// <summary>
        /// Unique ID of Event
        /// </summary>
        private int m_EventID;
        /// <summary>
        /// Details of Event
        /// </summary>
        private string m_EventName;
        /// <summary>
        /// Unique ID of Occurrence
        /// </summary>
        private int m_OccurenceID;
        /// <summary>
        /// Event Year
        /// </summary>
        private int m_OccYear;
        /// <summary>
        /// Event Month
        /// </summary>
        private int m_OccMonth;
        /// <summary>
        /// Event Day
        /// </summary>
        private int m_OccDay;
        /// <summary>
        /// Event Area Perial ID
        /// </summary>
        private int m_AreaperialID;
        /// <summary>
        /// Intensity Bin Index
        /// </summary>
        private int m_IntensityBinIndex;
        /// <summary>
        /// Probability
        /// </summary>
        private double m_Prob;
        /// <summary>
        /// 
        /// </summary>
        private int m_BinFrom;
        /// <summary>
        /// 
        /// </summary>
        private int m_BinTo;
        /// <summary>
        /// 
        /// </summary>
        private double m_Interpolation;
        /// <summary>
        /// 
        /// </summary>
        private int m_IntervalType;



        public Event_Definition()
        {
            this.m_EventID = 0;
            this.m_EventName = "";
            this.m_OccurenceID = 0;
            this.m_OccYear = 2014;
            this.m_OccMonth = 7;
            this.m_OccDay = 8;
        }


    }
}
