/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Line Codes - Following TfL Network Status and Train Prediction Manual
//Code      Line
//B            Bakerloo
//C            Central
//D            Distract
//H            Hammersimith & Circle
//J             Jubliee
//M            Metropotian
//N             Northern
//P             Piccadilly
//V             Victoria
//W           Waterloo & City
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace GAsty.Services
{
    public class TubeLineStatus
    {
        private string m_LineCode;
        private string m_LineName;
        private string m_LineStatus;
        private bool m_IsActive;
        private string m_Description;

        public TubeLineStatus(){}
        
        public TubeLineStatus(string LineCode, string LineService, string LineDescription, bool IsActive)
        {
            this.m_LineCode = LineCode;
            this.m_LineStatus = LineService;
            this.m_Description = LineDescription;
            this.m_IsActive = IsActive;
        }

        public string LineCode
        {
            get { return this.m_LineCode; }
            set { m_LineCode = value; }
        }

        public string LineName
        {
            get { return this.m_LineName; }
            set { m_LineName = value; }
        }

        public string LineStatus
        {
            get { return this.m_LineStatus; }
            set { m_LineStatus = value; }
        }

        public bool IsActive
        {
            get {return m_IsActive;}
            set { m_IsActive = value; }
        }

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

    }

    public class LinesOperations
    {
        public List<TubeLineStatus> LineOperationList { get; set; }

        public LinesOperations()
        {
            LineOperationList = new List<TubeLineStatus>();
        }

    }

}
