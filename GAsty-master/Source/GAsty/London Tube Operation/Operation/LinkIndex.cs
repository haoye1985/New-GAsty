using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAsty.London_Tube_Operation.Operation
{
    public class LinkIndex
    {
        private string m_linkID;
        private string m_linkFromNodeName;
        private string m_linkToNodeName;
        private string m_RiskAij;
        private string m_RiskPij;

        public LinkIndex ()
        {
            this.m_linkID = String.Empty;
            this.m_linkFromNodeName = String.Empty;
            this.m_linkToNodeName = String.Empty;
            this.m_RiskAij = String.Empty;
            this.m_RiskPij = String.Empty;
        }

        public string LinkID
        {
            get { return m_linkID; }
            set { m_linkID = value; }
        }

        public string LinkFromNodeName
        {
            get { return m_linkFromNodeName; }
            set { m_linkFromNodeName = value; }
        }

        public string LinkToNodeName
        {
            get { return m_linkToNodeName; }
            set { m_linkToNodeName = value; }
        }

        public string RiskAij
        {
            get { return m_RiskAij; }
            set { m_RiskAij = value; }
        }

        public string RiskPij
        {
            get { return m_RiskPij; }
            set { m_RiskPij = value; }
        }



    }
}
