using GAsty.Network.Core;
using GAsty.Network.Visualisation;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using SharpMap.Rendering.Thematics;
using System.Drawing;

namespace GAsty.Network.Service
{
    public class ServiceRender
    {
        public static VectorLayer RenderServiceNodeLayer(GeoNetwork pNetwork)
        {
            var layer = new VectorLayer("ServiceNodeLayer");
            var table = new FeatureDataTable();
            table.Columns.Add("Service");
            foreach (var node in pNetwork.GeoNodeCollection)
            {
                FeatureDataRow row = table.NewRow();
                row.Geometry = node.Geometry;
                row["Service"] = node.Service;
                table.AddRow(row);
            }
            layer.DataSource = new GeometryFeatureProvider(table);
            var theme = new CustomTheme(ServiceStyle.GetNodeServiceStyle);
            layer.IsQueryEnabled = true;
            layer.Theme = theme;

            return layer;
        }

        public static VectorLayer RenderServiceLinkLayer(GeoNetwork pNetwork)
        {
            var layer = new VectorLayer("ServiceLinkLayer");
            var table = new FeatureDataTable();
            table.Columns.Add("Service");
            foreach (var link in pNetwork.GetInfraLinkCollection())
            {
                FeatureDataRow row = table.NewRow();
                row.Geometry = link.Geometry;
                row["Service"] = link.Service;
                table.AddRow(row);
            }
            layer.Style.Line = new Pen(Color.Gold, 5);
            layer.Style.Line.Width = 5;
            layer.Style.EnableOutline = true;
            layer.Style.Outline = new System.Drawing.Pen(System.Drawing.Color.Blue, 2);

            var theme = new CustomTheme(ServiceStyle.GetLinkServiceStyle);
            layer.IsQueryEnabled = true;
            layer.Theme = theme;
            layer.DataSource = new GeometryFeatureProvider(table);


            return layer;
        }

    }
}
