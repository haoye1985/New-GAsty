using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAsty.Forms;
using GAsty.Network.Core;
using GAsty.Network.Visualisation;
using GAsty.Utility;
using GeoAPI.Geometries;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using SharpMap.Rendering.Thematics;

namespace GAsty.Hazard.Operation
{
    public class HazardRenderingHelper
    {
        public static void RenderNodeLayer(List<GeoNode> pNodeCollection)
        {
            List<IGeometry> geometryCollection = new List<IGeometry>();

                foreach (var geoNode in pNodeCollection)
                {
                    geometryCollection.Add(geoNode.Geometry);
                }

            VectorLayer selectedNodeLayer = new VectorLayer("SelectedNode");
            selectedNodeLayer.DataSource = new GeometryFeatureProvider(geometryCollection);
            State.SelectedNodeLayer = selectedNodeLayer;
            OasisForms.DockMap.mapBox1.Map.Layers.Add(State.SelectedNodeLayer);
            OasisForms.DockMap.mapBox1.Refresh();
        }

        public static void RenderLinkLayer(List<GeoLink> pLinkCollection)
        {
            List<IGeometry> geometryCollection = new List<IGeometry>();

                foreach (var geoLink in pLinkCollection)
                {
                    geometryCollection.Add(geoLink.Geometry);
                }
            VectorLayer selectedLinkLayer = new VectorLayer("SelectedNode");
            selectedLinkLayer.DataSource = new GeometryFeatureProvider(geometryCollection);
            State.SelectedLinkLayer = selectedLinkLayer;
            OasisForms.DockMap.mapBox1.Map.Layers.Add(State.SelectedLinkLayer);
            OasisForms.DockMap.mapBox1.Refresh();
        }
    }
}
