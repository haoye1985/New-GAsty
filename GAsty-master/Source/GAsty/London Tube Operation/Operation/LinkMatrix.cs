using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GAsty.Network.Core;
using GAsty.Tube;
using GAsty.Utility;

namespace GAsty.London_Tube_Operation.Operation
{
    public class LinkMatrix
    {
        private StreamReader m_reader;
        private List<string[]> m_dataCollection;
        private List<LinkIndex> m_linkInfoList; 

        public LinkMatrix(string filename)
        {
            m_reader = new StreamReader(filename);
            m_dataCollection = new List<string[]>();
            m_linkInfoList = new List<LinkIndex>();
        }

        public void GetLinkModelData()
        {
            string line = "";
            while ((line = m_reader.ReadLine()) != null)
            {
                m_dataCollection.Add(line.Split(','));
            }
        }

        public void AssignDataToLinkIndex()
        {
            for (int i = 0; i < m_dataCollection.Count; i++)
            {
                if (i == 0)
                {
                }
                else
                {
                    var linkInfo = new LinkIndex();
                    linkInfo.LinkID = m_dataCollection[i][0];
                    linkInfo.LinkFromNodeName = m_dataCollection[i][2];
                    linkInfo.LinkToNodeName = m_dataCollection[i][3];
                    linkInfo.RiskAij = m_dataCollection[i][4];
                    linkInfo.RiskPij= m_dataCollection[i][5];
                    m_linkInfoList.Add(linkInfo);
                }
            }

            State.LinkInformation = m_linkInfoList;
        }

        public void AssignDataToLINK()
        {
            List<LinkIndex> linkList = State.LinkInformation;
            List<GeoLink> linkCollection = State.network.GetInfraLinkCollection();

            foreach (var linkGeometry in linkCollection)
            {
                foreach (var linkindex in linkList)
                {
                        if ((linkGeometry.FromNodeIDName == linkindex.LinkFromNodeName) && (linkGeometry.ToNodeIDName == linkindex.LinkToNodeName))
                        {
                            linkGeometry.RiskAij = float.Parse(linkindex.RiskAij);
                            linkGeometry.RiskPij = float.Parse(linkindex.RiskPij);
                        }
                }
            }

            State.network.GeoLinkCollection = linkCollection;




        }


















    }
}
