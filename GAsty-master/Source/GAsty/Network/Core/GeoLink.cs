using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Serialization;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using Oasis;
using ProtoBuf;
using SharpMap;

namespace GAsty.Network.Core
{
    [Serializable]
    public class GeoLink: IEnumerable, ISerializable
    {
    public int ID { get; set; }
    public string m_name;
    public string m_service;
    private System.Drawing.Point m_pointStart;
    private System.Drawing.Point m_pointEnd;
    private System.Drawing.Point m_centralPoint;
    private Map m_map;
    private string m_FromNodeName;
    private string m_toNodeName;


    private Coordinate m_coordinateStart;
    private Coordinate m_coordinateEnd;
    private Coordinate m_coordinateCentrol;
    private GeometryFactory m_factory;
    private IGeometry m_linkGeometry;
    private GeoNode m_fromNode;
    private GeoNode m_toNode;
    private GeoNode m_centrolNode;
    private int m_FromID;
    private int m_ToID;

        public GeoLink()
        {
        }

         protected GeoLink(SerializationInfo info, StreamingContext context)
        {
            m_coordinateStart = (Coordinate)info.GetValue("Prop1", typeof(Coordinate));
            m_coordinateEnd = (Coordinate)info.GetValue("Prop2", typeof(Coordinate));
            m_linkGeometry = (IGeometry) info.GetValue("Prop3", typeof (IGeometry));
            m_pointStart = (System.Drawing.Point)info.GetValue("Prop4", typeof(System.Drawing.Point));
            m_pointEnd = (System.Drawing.Point)info.GetValue("Prop5", typeof(System.Drawing.Point));
            m_centralPoint = (System.Drawing.Point)info.GetValue("Prop6", typeof (System.Drawing.Point));
            m_fromNode = (GeoNode)info.GetValue("Prop7", typeof(GeoNode));
            m_toNode = (GeoNode)info.GetValue("Prop8", typeof(GeoNode));
            m_FromID = (int)info.GetValue("Prop9", typeof(int));
            m_ToID = (int)info.GetValue("Prop10", typeof(int));
            m_name = (string)info.GetValue("Prop11", typeof(string));
            m_service = (string)info.GetValue("Prop12", typeof(string));
            m_coordinateCentrol = (Coordinate)info.GetValue("Prop13", typeof(Coordinate));
            ID = (int)info.GetValue("Prop14", typeof(int));
            m_centrolNode = (GeoNode)info.GetValue("Prop15", typeof(GeoNode));
        }

        public GeoLink(System.Drawing.Point pStart, System.Drawing.Point pEnd, Map pmap)
        {
            this.m_FromID = 1;
            this.m_ToID = 1;
            this.m_name = "GeoLink";
            this.m_service = "Unknown";
            this.m_pointStart = pStart;
            this.m_pointEnd = pEnd;
            this.m_map = pmap;
            this.m_coordinateStart = new Coordinate(pmap.ImageToWorld((PointF) pStart));
            this.m_coordinateEnd = new Coordinate(pmap.ImageToWorld((PointF) pStart));
            this.m_factory = new GeometryFactory();
            this.m_linkGeometry = m_factory.CreateLineString(new Coordinate[] {m_coordinateStart, m_coordinateEnd});
            this.m_coordinateCentrol = m_linkGeometry.Centroid.Coordinate;
            this.m_fromNode = new GeoNode(pStart.X, pStart.Y, pmap, NodeEnum.Edge);
            this.m_toNode = new GeoNode(pEnd.X, pEnd.Y, pmap, NodeEnum.Edge);
            System.Drawing.Point centrolPoint = FindCentral(pStart, pEnd);
            this.m_centrolNode = new GeoNode(centrolPoint.X, centrolPoint.Y, pmap, NodeEnum.Centroid);
        }

        public GeoLink(GeoNode pStartNode, GeoNode pEndNode, Map pmap)
        {
            this.m_FromID = 1;
            this.m_ToID = 1;
            this.m_name = "GeoLink";
            this.m_service = "Unknown";
            this.m_pointStart.X = pStartNode.X;
            this.m_pointStart.Y = pStartNode.Y;
            this.m_pointEnd.X = pEndNode.X;
            this.m_pointEnd.Y = pEndNode.Y;
            this.m_map = pmap;
            this.m_coordinateStart = new Coordinate(pmap.ImageToWorld(new PointF(pStartNode.X, pEndNode.Y)));
            this.m_coordinateEnd = new Coordinate(pmap.ImageToWorld(new PointF(pStartNode.X, pEndNode.Y)));
            this.m_factory = new GeometryFactory();
            this.m_linkGeometry = m_factory.CreateLineString(new Coordinate[] {m_coordinateStart, m_coordinateEnd});
            this.m_coordinateCentrol = m_linkGeometry.Centroid.Coordinate;
            m_fromNode = pStartNode;
            m_toNode = pEndNode;
            System.Drawing.Point centrolPoint = FindCentral(new System.Drawing.Point(pStartNode.X,pEndNode.Y), new System.Drawing.Point(pEndNode.X, pEndNode.Y));
            this.m_centrolNode = new GeoNode(centrolPoint.X, centrolPoint.Y, pmap, NodeEnum.Centroid);
        }

        public GeoLink(Coordinate pStartCoordinate, Coordinate pEndCoordinate, Map pmap)
        {
            this.m_name = "GeoLink";
            this.m_service = "Unknown";
            this.m_map = pmap;
            this.m_coordinateStart = pStartCoordinate;
            this.m_coordinateEnd = pEndCoordinate;
            this.m_fromNode = new GeoNode(pStartCoordinate, pmap, NodeEnum.Edge);
            this.m_toNode = new GeoNode(pEndCoordinate, pmap, NodeEnum.Edge);
            this.m_pointStart = System.Drawing.Point.Ceiling(pmap.WorldToImage(pStartCoordinate));
            this.m_pointEnd = System.Drawing.Point.Ceiling(pmap.WorldToImage(pEndCoordinate));
            System.Drawing.Point centralpoint = FindCentral(this.m_pointStart, this.m_pointEnd);

            this.m_centrolNode = new GeoNode(centralpoint.X, centralpoint.Y, pmap, NodeEnum.Centroid);

            this.m_factory = new GeometryFactory();
            this.m_linkGeometry = m_factory.CreateLineString(new Coordinate[] {pStartCoordinate, pEndCoordinate});
            this.m_coordinateCentrol = m_linkGeometry.Centroid.Coordinate;
        }

        public GeoLink(System.Drawing.Point pStart, System.Drawing.Point pEnd, Coordinate pStartCoordinate, Coordinate pEndCoordinate, Map pmap)
        {
            this.m_pointStart = pStart;
            this.m_pointEnd = pEnd;
            this.m_centralPoint = FindCentral(pStart, pEnd);
            this.m_name = "GeoLink";
            this.m_service = "Unknown";
            this.m_map = pmap;
            this.m_coordinateStart = pStartCoordinate;
            this.m_coordinateEnd = pEndCoordinate;

            m_fromNode = new GeoNode(pStartCoordinate, pmap, NodeEnum.Edge);
            m_toNode = new GeoNode(pEndCoordinate, pmap, NodeEnum.Edge);
            System.Drawing.Point centralpoint = FindCentral(this.m_pointStart, this.m_pointEnd);
            this.m_centrolNode = new GeoNode(centralpoint.X, centralpoint.Y, pmap, NodeEnum.Centroid);

            this.m_pointStart = System.Drawing.Point.Ceiling(pmap.WorldToImage(pStartCoordinate));
            this.m_pointEnd = System.Drawing.Point.Ceiling(pmap.WorldToImage(pEndCoordinate));
            this.m_factory = new GeometryFactory();
            this.m_linkGeometry = m_factory.CreateLineString(new Coordinate[] { pStartCoordinate, pEndCoordinate });
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Prop1", m_coordinateStart, typeof(Coordinate));
            info.AddValue("Prop2", m_coordinateEnd, typeof(Coordinate));
            info.AddValue("Prop3", m_linkGeometry, typeof(IGeometry));
            info.AddValue("Prop4", m_pointStart, typeof(System.Drawing.Point));
            info.AddValue("Prop5", m_pointEnd, typeof(System.Drawing.Point));
            info.AddValue("Prop6", m_centralPoint, typeof(System.Drawing.Point));
            info.AddValue("Prop7", m_fromNode, typeof(GeoNode));
            info.AddValue("Prop8", m_toNode, typeof(GeoNode));
            info.AddValue("Prop9", m_FromID, typeof(int));
            info.AddValue("Prop10", m_ToID, typeof(int));
            info.AddValue("Prop11", m_name, typeof(string));
            info.AddValue("Prop12", m_service, typeof(string));
            info.AddValue("Prop13", m_coordinateCentrol, typeof(Coordinate));
            info.AddValue("Prop14", ID, typeof(int));
            info.AddValue("Prop15", m_centrolNode, typeof(GeoNode));
        }

        private System.Drawing.Point FindCentral(System.Drawing.Point pstart, System.Drawing.Point pend)
        {
            m_centralPoint.X = (pend.X + pstart.X)/2;
            m_centralPoint.Y = (pend.Y + pstart.Y)/2;
            return m_centralPoint;
        }

    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }

    [Browsable(false)]
    public string Service
    {
        get { return m_service; }
        set { m_service = value; }
    }

    [Browsable(false)]
    public IGeometry Geometry
    {
        get { return m_linkGeometry; }
    }

    public int FromNodeID
    {
        get { return m_FromID; }
        set { m_FromID = value; }
    }


    public int ToNodeID
    {
        get { return m_ToID; }
        set { m_ToID = value; }
    }

    public string FromNodeIDName
    {
        get { return m_FromNodeName; }
        set { m_FromNodeName = value; }
    }

    public string ToNodeIDName
    {
        get { return m_toNodeName; }
        set { m_toNodeName = value; }
    }

    public float RiskAij { get; set; }

    public float RiskPij { get; set; }

    public System.Drawing.Point FromPoint
    {
        get
        {
            return m_pointStart;
        }
        set
        {
            m_pointEnd = value;
        }
    }

    public System.Drawing.Point ToPoint
    {
        get { return m_pointEnd; }
        set { m_pointEnd = value; }
    }

    public System.Drawing.Point CentrolPoint
    {
        get { return m_centralPoint; }
        set { m_centralPoint = value; }
    }

    [Browsable(false)]
    public Coordinate FromNodeCoordinate
    {
        get { return m_coordinateStart; }
        set { m_coordinateStart = value; }
    }

    [Browsable(false)]
    public Coordinate ToNodeCoordinate
    {
        get { return m_coordinateEnd; }
        set { m_coordinateEnd = value; }
    }

    [Browsable(false)]
    public Coordinate CentroidCoordinate
    {
        get { return m_coordinateCentrol;}
        set { m_coordinateCentrol = value; }
    }

    [Browsable(false)]
    public GeoNode FromNode
    {
        get { return m_fromNode; }
        set { m_fromNode = value; }
    }

    [Browsable(false)]
    public GeoNode ToNode
    {
        get { return m_toNode; }
        set { m_toNode = value; }
    }

    [Browsable(false)]
    public GeoNode CentralNode
    {
        get { return m_centrolNode; }
        set { m_centrolNode= value; }
    }


    public IEnumerator GetEnumerator()
    {
        return (IEnumerator) GetEnumerator();
    }


    }
}
