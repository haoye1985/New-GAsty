using System;
using System.Collections.Generic;
using System.Linq;
using GAsty.Tube;

namespace GAsty.Tube
{
    public class TubeLine
    {
        #region Private Fields

            private string m_lineID;
            private string m_lineName;
            private string m_linestatusID;
            private string m_lineCssClass;
            private string m_lineDescription;

            private List<TubeStation> m_lineStations;
            private List<TubeLink> m_lineLinks;
            
        #endregion

        #region Constructors

            public TubeLine(){}

            public TubeLine(string pLineId, string pLineName, string pLineStatusID, string pLineCssClass, string pLineDescription)
            {
                this.m_lineID = pLineId;
                this.m_lineName = pLineName;
                this.m_linestatusID = pLineStatusID;
                this.m_lineCssClass = pLineCssClass;
                this.m_lineDescription = pLineDescription;
            }

        #endregion


            #region Methods

            public void BuildTubeLine(List<TubeStation> pTubeStations, List<TubeLink> pTubeLinks  )
            {
                m_lineStations = pTubeStations;
                m_lineLinks = pTubeLinks;
            }


        #endregion

            #region Properties

            public string LineID
            {
                get { return this.m_lineID; }
                set { m_lineID= value; }
            }

            public string LineName
            {
                get { return this.m_lineName; }
                set { m_lineName = value; }
            }

            public string LineStatus
            {
                get { return this.m_linestatusID; }
                set { m_linestatusID = value; }
            }

            public string LineCssClass
            {
                get {return m_lineCssClass;}
                set { m_lineCssClass = value; }
            }

            public string Description
            {
                get { return m_lineDescription; }
                set { m_lineDescription = value; }
            }

        #endregion

    }
}
