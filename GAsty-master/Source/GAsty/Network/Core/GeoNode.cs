using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Drawing;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using ProtoBuf;
using SharpMap;

namespace GAsty.Network.Core
{
    [Serializable]
    public class GeoNode : IEnumerable, ISerializable
    {
        #region Private Field

        private int m_x;
        private int m_y;
        private int m_width;
        private int m_height;

        private int m_ID;
        private int m_journeyFrequency;
        private NodeEnum m_type;
        private bool m_isContained;
        private readonly IGeometry m_nodeGeometry;
        private Coordinate m_coordinate;
        private Map m_map;

        protected string m_timeSpent;
        protected string m_estimateTimeSpent;
        protected string m_estimateJourneyFrequency;
        protected string m_name;
        protected string m_serviceDescription;
        protected string m_estimateStatusDescription;

        protected string m_service;
        private GeometryFactory m_factory;
        private Rectangle m_hitRectangle;
        private List<GeoLink> m_connectedLinks; 

        #endregion

        #region Constructor

        public GeoNode()
        {
        }

        public GeoNode(int pX, int pY, Map pmap, NodeEnum pType)
        {
            this.m_ID = 0;
            this.m_x = pX;
            this.m_y = pY;
            this.m_width = 15;
            this.m_height = 15;
            this.m_name = "GeoNode";
            this.m_type = pType;
            this.m_service = "Unknown";
            this.m_map = pmap;
            this.m_isContained = false;
            UpdateHitRectangle();
            this.m_factory = new GeometryFactory();
            this.m_coordinate = new Coordinate(pmap.ImageToWorld(new PointF(pX, pY)));
            this.m_nodeGeometry = m_factory.CreatePoint(m_coordinate);
            m_connectedLinks = new List<GeoLink>();
        }

        public GeoNode(Coordinate pCoordinate, Map pmap, NodeEnum pType)
        {
            this.m_ID = 0;
            PointF point = pmap.WorldToImage(pCoordinate);
            this.m_coordinate = pCoordinate;
            this.m_x = (int) point.X;
            this.m_y = (int)point.Y;
            this.m_width = 15;
            this.m_height = 15;
            this.m_name = "GeoNode";
            this.m_type = pType;
            this.m_service = "Unknown";
            this.m_map = pmap;
            this.m_isContained = false;

            UpdateHitRectangle();

            this.m_factory = new GeometryFactory();
            this.m_nodeGeometry = m_factory.CreatePoint(m_coordinate);
            m_connectedLinks = new List<GeoLink>();
        }

        public GeoNode(string pName, Coordinate pCoordinate, Map pmap, NodeEnum pType)
        {
            this.m_ID = 0;
            PointF point = pmap.WorldToImage(pCoordinate);
            this.m_coordinate = pCoordinate;
            this.m_x = (int)point.X;
            this.m_y = (int)point.Y;
            this.m_width = 15;
            this.m_height = 15;
            this.m_name = pName;
            this.m_type = pType;
            this.m_service = "Unknown";
            this.m_map = pmap;
            this.m_isContained = false;

            UpdateHitRectangle();

            this.m_factory = new GeometryFactory();
            this.m_nodeGeometry = m_factory.CreatePoint(m_coordinate);
            m_connectedLinks = new List<GeoLink>();
        }




        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("prop1", m_coordinate, typeof(Coordinate));
            info.AddValue("prop2", m_x, typeof(int));
            info.AddValue("prop3", m_y, typeof(int));
            info.AddValue("prop4", m_ID, typeof(int));
            info.AddValue("prop5", m_width, typeof(int));
            info.AddValue("prop6", m_height, typeof(int));
            info.AddValue("prop7", m_type, typeof(NodeEnum));
            info.AddValue("prop8", m_name, typeof(string));
            info.AddValue("prop9", m_service, typeof(string));
            info.AddValue("prop10", m_factory, typeof(GeometryFactory));
            info.AddValue("prop11", m_nodeGeometry, typeof(IGeometry));
            info.AddValue("prop12", m_hitRectangle, typeof(Rectangle));
            //info.AddValue("prop13", m_map, typeof(Map));
        }

        protected GeoNode(SerializationInfo info, StreamingContext context)
        {
            m_coordinate = (Coordinate)info.GetValue("prop1", typeof(Coordinate));
            m_x = (int)info.GetValue("prop2", typeof(int));
            m_y = (int)info.GetValue("prop3", typeof(int));
            m_ID = (int)info.GetValue("prop4", typeof(int));
            m_width = (int)info.GetValue("prop5", typeof(int));
            m_height = (int)info.GetValue("prop6", typeof(int));
            m_type = (NodeEnum)info.GetValue("prop7", typeof(NodeEnum));
            m_name = (string)info.GetValue("prop8", typeof(string));
            m_service = (string)info.GetValue("prop9", typeof(string));
            m_factory = (GeometryFactory)info.GetValue("prop10", typeof(GeometryFactory));
            m_nodeGeometry = (IGeometry)info.GetValue("prop11", typeof(IGeometry));
            m_hitRectangle = (Rectangle)info.GetValue("prop12", typeof(Rectangle));
            //m_map = (Map)info.GetValue("prop13", typeof(Map));
        }

        #endregion

        #region Methods

        private void UpdateHitRectangle()
        {
            this.m_hitRectangle = new Rectangle(m_x - m_width/2, m_y - m_height/2, m_width, m_height);
        }

        protected virtual string GetName()
        {
            return this.m_name;
        }

        protected virtual string GetService()
        {
            return this.m_service;

        }

        public bool ScreenPointContain(System.Drawing.Point pClickPoint)
        {
            return m_isContained = this.m_hitRectangle.Contains(pClickPoint);
        }

        #endregion

        #region Properties

        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        public string Name
        {
            get { return this.GetName(); }
            set { m_name = value; }
        }

        [Browsable(false)]
        public string Service
        {
            get { return this.GetService(); }
            set { m_service = value; }
        }

        public int X
        {
            get { return m_x; }
            set { m_x = value; }
        }

        public int Y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public NodeEnum NodeType
        {
            get { return m_type; } 
            set {m_type = value;} 
        }

        public float RiskXi { get; set; }

        public float RiskCi { get; set; }

        [Browsable(false)]
        public Coordinate Coordinate
        {
            get { return m_coordinate; }
        }

        public int CurrentTravelFrequency
        {
            get { return m_journeyFrequency; }
            set { m_journeyFrequency = value; }
        }

        public string CurrentTravelTime
        {
            get { return m_timeSpent; }
            set { m_timeSpent = value; }
        }

        public string CurrentStatusSDescription
        {
            get
            {
                return m_serviceDescription;
            }
            set
            {
                m_serviceDescription = value;
            }
        }

        public string EstimateTimeSpent
        {
            get { return m_estimateTimeSpent; }
            set { m_estimateTimeSpent = value; }
        }

        public string EstimateTravelFrequency
        {
            get { return m_estimateJourneyFrequency; }
            set { m_estimateJourneyFrequency = value; }
        }

        public string EstimateStatusDescription
        {
            get { return m_estimateStatusDescription; }
            set { m_estimateJourneyFrequency = value; }
        }


        [Browsable(false)]
        public List<GeoLink> ConnectedGeoLinks
        {
            get { return m_connectedLinks; }
            set { m_connectedLinks = value; }}

        [Browsable(false)]
        public IGeometry Geometry
        {
            get { return m_nodeGeometry; }
        }

        [Browsable(false)]
        public int Degree { get; set; }

        [Browsable(false)]
        public Rectangle HitRectangle
        {
            get { return m_hitRectangle; }
        }

        [Browsable(false)]
        public int Width
        {
            get { return this.m_width; }
            set { this.m_width = value; this.UpdateHitRectangle(); }
        }

        [Browsable(false)]
        public int Height
        {
            get { return this.m_height; }
            set { this.m_height = value; this.UpdateHitRectangle(); }
        }

        #endregion


        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

    }
}
