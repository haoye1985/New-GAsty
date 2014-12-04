using System;
using System.Collections.Generic;
using SharpMap.Forms;
using SharpMap.Layers;
using GAsty.Network.Operation;
using GAsty.Hazard.Core;
using GAsty.Hazard.Operation;
using SharpMap.Data.Providers;
using GAsty.Forms;
using SharpMap.Data;
using GAsty.Utility;


namespace GAsty.Hazard
{
    public class HazardBuilder
    {
        private ShapeFile m_hazardFile;
        private List<GeoHazardCell> m_hazardCells;
        private MapBox m_map;
        private VectorLayer m_hazardLayer;
        private HazardVisualiser m_visualier;
        private int m_HazardLayerSRID;

        public HazardBuilder(string pHazardFileName, MapBox pMapBox)
        {
            this.m_hazardFile = new ShapeFile(pHazardFileName);
            this.m_hazardCells = new List<GeoHazardCell>();
            this.m_map = pMapBox;      
        }

        public void BuildHazard()
        {
            BuildHazardFromFile();
            m_visualier = new HazardVisualiser(m_hazardCells, m_map);
            State.HazardCellCollection = m_hazardCells;
            OasisForms.DockHazard.UpdateHazardList();
        }

        private void  BuildHazardFromFile()
        {
            if (m_hazardFile != null)
            {
                m_hazardFile.Open();
                this.m_HazardLayerSRID = m_hazardFile.SRID;
                int featureCounter = m_hazardFile.GetFeatureCount();   
                for (uint i = 0; i < featureCounter; i++)
                {
                    var feature = m_hazardFile.GetFeature(i);
                    var hazardCell = new GeoHazardCell(Convert.ToInt32(i), feature.Geometry, OasisForms.DockMap.mapBox1.Map, feature["Hazard_Val"].ToString());
                    m_hazardCells.Add(hazardCell);
                }
            }

            this.m_hazardFile.Close();
        }

    }
}
