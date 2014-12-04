using System;
using System.Collections.Generic;
using GAsty.Forms;
using GeoAPI.Geometries;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;

namespace GAsty.Helpers
{
    public class VectorLayerReader : IDisposable
    {
        private List<IGeometry> m_GeometryShapes;
        private VectorLayer m_GeoLayer;

        public VectorLayerReader()
        {
            this.m_GeometryShapes = new List<IGeometry>();
            this.m_GeoLayer = new VectorLayer("GeoLayer");
        }

        public void ReadVectorLayers(string filename)
        {
            var layer = new VectorLayer("temp");
            var p1 = new ShapeFile(filename, true);
            p1.Open();var fds = new FeatureDataSet();
            p1.ExecuteIntersectionQuery(p1.GetExtents(), fds);
            layer.DataSource = new GeometryFeatureProvider(fds.Tables[0]);
            m_GeoLayer.DataSource = layer.DataSource;
            p1.Close();

            OasisForms.DockMap.mapBox1.Map.Layers.Add(m_GeoLayer);
            OasisForms.DockMap.mapBox1.Map.ZoomToExtents();
            OasisForms.DockMap.mapBox1.Refresh();

        }

        public void ReadShapes(string filename)
        {
            var shapefile = new ShapeFile(filename, true);
            shapefile.Open();

            int featureCounter = shapefile.GetFeatureCount();
   
            for (uint i = 0; i < featureCounter; i++)
            {
                var feature = shapefile.GetFeature(i);
                var geometry = feature.Geometry;
                m_GeometryShapes.Add(geometry);
            }

            shapefile.Close();

            var featureGeometries = new GeometryFeatureProvider(this.m_GeometryShapes);
            m_GeoLayer.DataSource = featureGeometries;

            OasisForms.DockMap.mapBox1.Map.Layers.Add(m_GeoLayer);
            OasisForms.DockMap.mapBox1.Map.ZoomToExtents();
            OasisForms.DockMap.mapBox1.Refresh();
        }

        public VectorLayer GeometryLayer
        {
            get { return m_GeoLayer; }
            set { m_GeoLayer = value; }
        }

        public List<IGeometry> PointShapes
        {
            get { return m_GeometryShapes; }
            set { m_GeometryShapes = value; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
