using System;
using System.Collections.Generic;
using GAsty.Network.Core;
using GeoAPI.Geometries;
using SharpMap;
using System.Runtime.Serialization;
using System.Collections;
using System.ComponentModel;

namespace GAsty.Hazard.Core
{
    [Serializable]
    public class GeoHazardCell : IEnumerable, ISerializable
    {
        private Map m_map;
        private int m_hazardCellID;
        private IGeometry m_hazardCellGeometry;
        private string m_HazardValue;
        private int p1;
        private Map map;
        private object p2;

        public GeoHazardCell(int pCellId, IGeometry pGeometry, Map pmap, string pHazardValue)
        {
            this.m_hazardCellID = pCellId;
            this.m_hazardCellGeometry = pGeometry;
            this.m_map = pmap;
            this.m_HazardValue = pHazardValue;
        }

         public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Prop1", m_hazardCellID, typeof(int));
            info.AddValue("Prop2", m_hazardCellGeometry, typeof(List<IGeometry>));
            info.AddValue("Prop3", m_HazardValue, typeof(string));
        }

         public GeoHazardCell(SerializationInfo info, StreamingContext context)
        {
            m_hazardCellID = (int)info.GetValue("Prop1", typeof(int));
            m_hazardCellGeometry = (IGeometry)info.GetValue("Prop2", typeof(IGeometry));
            m_HazardValue = (string)info.GetValue("Prop3", typeof(string));
        }


        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public int CellID
        {
            get { return m_hazardCellID; }
            set { m_hazardCellID = value; }
        }

        public string HazardValue
        {
            get { return m_HazardValue; }
            set { m_HazardValue = value; }
        }

        [Browsable(false)]
        public IGeometry Geometry
        {
            get { return m_hazardCellGeometry; }
            set { m_hazardCellGeometry = value; }
        }
    }
}
