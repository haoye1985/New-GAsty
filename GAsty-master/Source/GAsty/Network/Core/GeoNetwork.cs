using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using GAsty.Control;
using GAsty.Utility;
using GeoAPI.Geometries;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Oasis;
using ProtoBuf;
using GAsty.Network.Service;

namespace GAsty.Network.Core
{
    [Serializable]
    public class GeoNetwork : IEnumerable, ISerializable
    {
        #region Private Field

        private string m_networkId;
        private string m_networkName;
        private int m_nodeCount;
        private int m_linkCount;

        // Infrastructure
        private List<GeoNode> m_geoNodes;
        private List<GeoLink> m_geoLinks;
        private List<IGeometry> m_geoNGeometries;
        private List<IGeometry> m_geoLGeometries;
        // Service
        private List<GeoNode> m_serviceNodeCollection;
        private List<GeoLink> m_serviceLinkCollection;
        private List<IGeometry> m_geoServiceNodeGeometries;
        private List<IGeometry> m_geoServiceLinkGeometries;
        private List<GeoService> m_geoService;
        #endregion

        #region Constructors

        public GeoNetwork()
        {
            this.m_geoNodes = new List<GeoNode>();
            this.m_geoLinks = new List<GeoLink>();
            this.m_geoService = new List<GeoService>();
            this.m_serviceNodeCollection = new List<GeoNode>();
            this.m_serviceLinkCollection = new List<GeoLink>();
            this.m_geoNGeometries = new List<IGeometry>();
            this.m_geoLGeometries = new List<IGeometry>();
            this.m_geoServiceNodeGeometries = new List<IGeometry>();
            this.m_geoServiceLinkGeometries = new List<IGeometry>();
        }

        #endregion

        #region Serialisation

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Prop1", m_geoNGeometries, typeof(List<IGeometry>));
            info.AddValue("Prop2", m_geoLGeometries, typeof(List<IGeometry>));
            info.AddValue("Prop3", m_geoNodes, typeof(List<GeoNode>));
            info.AddValue("Prop4", m_geoLinks, typeof(List<GeoLink>));
            info.AddValue("Prop5", m_geoService, typeof(List<GeoService>));
            info.AddValue("Prop6", m_geoServiceNodeGeometries, typeof(List<IGeometry>));
            info.AddValue("Prop7", m_geoServiceLinkGeometries, typeof(List<IGeometry>));
            info.AddValue("Prop8", m_serviceNodeCollection, typeof(List<GeoNode>));
            info.AddValue("Prop9", m_serviceLinkCollection, typeof(List<GeoLink>));
        }

        public GeoNetwork(SerializationInfo info, StreamingContext context)
        {
            m_geoNGeometries = (List<IGeometry>)info.GetValue("Prop1", typeof(List<IGeometry>));
            m_geoLGeometries = (List<IGeometry>)info.GetValue("Prop2", typeof(List<IGeometry>));
            m_geoNodes = (List<GeoNode>)info.GetValue("Prop3", typeof(List<GeoNode>));
            m_geoLinks = (List<GeoLink>)info.GetValue("Prop4", typeof(List<GeoLink>));
            m_geoService = (List<GeoService>)info.GetValue("Prop5", typeof(List<GeoService>));
            m_geoServiceNodeGeometries = (List <IGeometry>) info.GetValue("Prop6", typeof(List<IGeometry>));
            m_geoServiceLinkGeometries = (List<IGeometry>) info.GetValue("Prop7", typeof(List<IGeometry>));
            m_serviceNodeCollection = (List<GeoNode>)info.GetValue("Prop8", typeof(List<GeoNode>));
            m_serviceLinkCollection = (List<GeoLink>)info.GetValue("Prop9", typeof(List<GeoLink>));
        }

        #endregion

        #region Method

        public void AddGeoEdgeNode(GeoNode pNode, NodeEnum pType)
        {
            pNode.NodeType = pType;
            this.m_geoNodes.Add(pNode);
            this.m_geoNGeometries.Add((pNode.Geometry));
            pNode.ID = m_geoNGeometries.Count;
            this.LinkCount++;
            GraphControlHelper.AddControlVertices(pNode.ID.ToString());
        }

        public void AddGeoCentroidNode(GeoNode pNode, NodeEnum pType)
        {
            pNode.NodeType = pType;
            this.m_geoNodes.Add(pNode);
            this.m_geoNGeometries.Add((pNode.Geometry));
            this.m_nodeCount++;
            pNode.ID = m_geoNGeometries.Count;
        }

        public void AddNodeService(GeoNode pNode, GeoService pService, ServiceEnum pServiceValue)
        {
            pService.ServiceValue = pServiceValue;
            pService.Geometry = pNode.Geometry;
            this.m_nodeCount++;
            this.m_geoService.Add(pService);
            this.m_geoServiceNodeGeometries.Add(pNode.Geometry);
            this.m_serviceNodeCollection.Add(pNode);
            pService.ServiceID = m_geoService.Count;
            pService.ServiceObjectID = pNode.ID;
        }

        public void AddLinkService(GeoLink pLink, GeoService pService, ServiceEnum pServiceValue)
        {
            pService.ServiceValue = pServiceValue;
            this.m_geoService.Add(pService);
            this.m_geoServiceLinkGeometries.Add(pLink.Geometry);
            this.m_serviceLinkCollection.Add(pLink);
            pService.ServiceID = m_geoService.Count;
            pService.ServiceObjectID = pLink.ID;
        }

        public void AddGeoLink(GeoLink pLink)
        {
            this.m_geoLinks.Add(pLink);
            this.m_geoLGeometries.Add(pLink.Geometry);
            pLink.ID = m_geoLGeometries.Count;
            PopulateLinkID(pLink);

            GraphControlHelper.AddControlEdge(pLink.FromNodeID.ToString(), pLink.ToNodeID.ToString());
        }

        private void PopulateLinkID(GeoLink pLink)
        {
            List<GeoNode> temp = State.network.GeoNodeCollection;

            if (temp.Count > 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if (pLink.FromNode.Coordinate.Equals(temp[i].Coordinate))
                    {
                        pLink.FromNode = temp[i];
                        pLink.FromNodeID = temp[i].ID;
                    }

                    if (pLink.ToNode.Coordinate.Equals(temp[i].Coordinate))
                    {
                        pLink.ToNode = temp[i];
                        pLink.ToNodeID = temp[i].ID;
                    }

                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (object o in m_geoNodes)
            {
                if (o == null)
                {
                    break;
                }

                yield return o;
            }
        }

#endregion

        #region Properties

        public string NetworkID
        {
            get { return m_networkId; }
            set { m_networkId = value; }
        }

        public string NetworkName
        {
            get { return m_networkName; }
            set { m_networkName = value; }
        }

        public int NodeCount
        {
            get { return m_nodeCount; }
            set { m_nodeCount = value; }
        }

        public int LinkCount
        {
            get { return m_linkCount; }
            set { m_linkCount = value; }
        }

        public List<GeoLink> GetInfraLinkCollection()
        {
            return m_geoLinks;
        }

        public List<GeoNode> GetInfraNodeCollection()
        {
            return m_geoNodes;
        }

        public List<IGeometry> GeoInfraNodeGeometries()
        {
             return m_geoNGeometries;
        }

        public List<IGeometry> GeoInfraLinksGeometries()
        {
            return m_geoLGeometries; 
        }

        public List<GeoNode> GetServiceNodeCollection()
        {
            return m_serviceNodeCollection;
        }

        public List<GeoLink> GetServiceLinkCollection()
        {
            return m_serviceLinkCollection;
        }

        public List<GeoService> GeoGeoServiceCollection()
        {
            return m_geoService;
        }

        public List<IGeometry> GetServiceGeometryNode()
        {
            return m_geoServiceNodeGeometries;
        }

        public List<IGeometry> GetServiceGeometryLink()
        {
            return m_geoServiceLinkGeometries;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<GeoLink> GeoLinkCollection
        {
            get { return m_geoLinks; }
            set { m_geoLinks = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<GeoNode> GeoNodeCollection
        {
            get { return m_geoNodes; }
            set { m_geoNodes = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<GeoService> GetServiceCollection
        {
            get { return m_geoService; }
            set { m_geoService = value; }
        }

        #endregion
    }
}
