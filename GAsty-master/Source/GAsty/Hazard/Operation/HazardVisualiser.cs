using System;
using System.Collections.Generic;
using System.Drawing;
using GAsty.Hazard.Core;
using GAsty.Utility;
using SharpMap.Forms;
using SharpMap.Layers;
using SharpMap.Data.Providers;
using GeoAPI.Geometries;
using SharpMap.Data;
using GAsty.Hazard.Visualisation;
using SharpMap.Rendering.Symbolizer;
using SharpMap.Rendering.Thematics;
using SharpMap.Styles;
using GAsty.Utility;


namespace GAsty.Hazard.Operation
{
    public class HazardVisualiser
    {
        private List<GeoHazardCell> m_hazardCellCollection;
        private List<IGeometry> m_hazardGeometry;
        public MapBox m_mapBox;
        public VectorLayer m_hazardLayer;

        public HazardVisualiser(List<GeoHazardCell> Cells, MapBox pMapBox)
        {
            this.m_mapBox = pMapBox;
            this.m_hazardLayer = new VectorLayer("Hazard Layer");
            this.m_hazardCellCollection = new List<GeoHazardCell>();
            this.m_hazardGeometry = new List<IGeometry>();
            this.m_hazardCellCollection.AddRange(Cells);

            ReturnGeometry();
            GenerateHazardVisualisation();

            m_mapBox.Map.ZoomToBox(this.m_hazardLayer.Envelope);
            m_mapBox.Paint += m_mapBox_Paint;
        }

        private void ReturnGeometry()
        {
            foreach (var cell in m_hazardCellCollection)
            {
                m_hazardGeometry.Add(cell.Geometry);
            }
        }

        private void GenerateHazardVisualisation()
        {
            var table = new FeatureDataTable();
            table.Columns.Add("Hazard_Val");
            foreach (var cell in m_hazardCellCollection)
            {
                FeatureDataRow row = table.NewRow();
                row.Geometry = cell.Geometry;
                row["Hazard_Val"] = cell.HazardValue.ToString();
                table.AddRow(row);
            }

            this.m_hazardLayer.DataSource = new GeometryFeatureProvider(table);
            this.m_hazardLayer.IsQueryEnabled = true;
            var theme = new CustomTheme(HazardStyle.HazardFillStyle);
            this.m_hazardLayer.Theme = theme;
        }

        private void m_mapBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (State.SelectedNodeLayer.DataSource != null)
            {
                State.SelectedNodeLayer.Style.PointSymbolizer = PathPointSymbolizer.CreateCircle(new Pen(Color.BlueViolet), Brushes.Yellow, 16);
                State.SelectedNodeLayer.Render(e.Graphics, m_mapBox.Map);
            }

            this.m_hazardLayer.Render(e.Graphics, m_mapBox.Map);
        }


    }
}
