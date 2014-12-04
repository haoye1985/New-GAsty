using GAsty.Network.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;

namespace GAsty.Network.Core
{
    [Serializable]
    public class GeoService
    {
        protected int m_id;
        protected int m_objectId;
        protected InfraEnum m_infraType;
        protected NodeEnum m_nodeType;
        protected ServiceEnum m_serviceValue;
        private IGeometry m_serviceGeometry;
        private GeometryFactory m_factory;
        protected string m_name;
        protected string m_service;

        public GeoService(InfraEnum type)
        {
            this.m_id = 0;
            this.m_objectId = 0;
            this.m_infraType = type;
            this.m_nodeType = NodeEnum.None;
            this.m_name = "Service";
            this.m_serviceValue = new ServiceEnum();
            this.m_factory = new GeometryFactory();
        }

        public GeoService(GeoNode pNode)
        {
            this.m_id = 0;
            //this.m_infraType = pNode.NodeType;
            this.m_nodeType = pNode.NodeType;
            this.m_objectId = 0;
            this.m_name = "Service";
            this.m_serviceValue = new ServiceEnum();
            this.m_factory = new GeometryFactory();
            this.m_serviceGeometry = m_factory.CreatePoint(pNode.Coordinate);
        }

        public GeoService(GeoLink pLink)
        {
            this.m_id = 0;
            //this.m_infraType = pNode.NodeType;
            this.m_nodeType = pLink.CentralNode.NodeType;
            this.m_objectId = 0;
            this.m_name = "Service";
            this.m_serviceValue = new ServiceEnum();
            this.m_factory = new GeometryFactory();
            ////
            //this.m_serviceGeometry = m_factory.CreatePoint(pLink.CentralNode.Coordinate);
            this.m_serviceGeometry = m_factory.CreateLineString(new Coordinate[] { pLink.FromNodeCoordinate, pLink.ToNodeCoordinate });
        }

         public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("prop1", m_id, typeof(int));
            info.AddValue("prop2", m_objectId, typeof(int));
            info.AddValue("prop3", m_infraType, typeof(InfraEnum));
            info.AddValue("prop4", m_serviceValue, typeof(ServiceEnum));
            info.AddValue("prop4", m_name, typeof(string));
        }

        protected GeoService(SerializationInfo info, StreamingContext context)
        {
            m_id = (int)info.GetValue("prop1", typeof(int));
            m_objectId = (int)info.GetValue("prop2", typeof(int));
            m_infraType = (InfraEnum)info.GetValue("prop3", typeof(InfraEnum));
            m_serviceValue = (ServiceEnum)info.GetValue("prop4", typeof(ServiceEnum));
            m_name =(string)info.GetValue("prop5", typeof(string));
        }

        protected virtual string GetName()
        {
            return this.m_name;
        }

        protected virtual string GetService()
        {
            return this.m_service;
        }

        public int ServiceID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public int ServiceObjectID
        {
            get { return m_objectId; }
            set { m_objectId = value; }
        }

        public string Name
        {
            get { return this.GetName(); }
        }

        public IGeometry Geometry
        {
            get { return m_serviceGeometry; }
            set { m_serviceGeometry = value; }
        }

        public InfraEnum InfraType
        {
            get { return m_infraType; }
            set { m_infraType = value; }
        }


        public ServiceEnum ServiceValue
        {
            get { return m_serviceValue; }
            set { m_serviceValue = value; }
        }

    }
}
