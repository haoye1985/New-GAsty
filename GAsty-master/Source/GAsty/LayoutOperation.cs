using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GeoAPI.Geometries;
using SharpMap;

namespace GAsty
{
    class LayoutOperation
    {
        private Map m_map;
        private int m_hazardCellID;
        private IGeometry m_hazardCellGeometry;
        private string m_HazardValue;
        private int p1;
        private Map map;
        private object p2;

        public LayoutOperation(int pCellId, IGeometry pGeometry, Map pmap, string pHazardValue)
        {
            this.m_hazardCellID = pCellId;
            this.m_hazardCellGeometry = pGeometry;
            this.m_map = pmap;
            this.m_HazardValue = pHazardValue;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
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
