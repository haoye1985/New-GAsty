using GAsty.Network.Core;
using Oasis;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using SharpMap.Rendering.Thematics;

namespace GAsty.Network.Visualisation
{
    public static class NetRiskLayer
    {
        public static VectorLayer CreateNodeRiskLayer(GeoNetwork network)
        {
            var layer = new VectorLayer("RenderedNetworkNode");
            var table = new FeatureDataTable();
            table.Columns.Add("RiskIndex");
            foreach (var node in network.GeoNodeCollection)
            {
                FeatureDataRow row = table.NewRow();
                row.Geometry = node.Geometry;
                row["RiskIndex"] = node.RiskXi.ToString();
                table.AddRow(row);
            }

            layer.DataSource = new GeometryFeatureProvider(table);
            var theme = new CustomTheme(NetworkStyle.GetMyPointStyle);
            layer.IsQueryEnabled = true;
            layer.Theme = theme;

            return layer;
        }

        public static VectorLayer CreateInfraLayer(GeoNetwork network)
        {
            var layer = new VectorLayer("RenderedNetworkNode");
            var table = new FeatureDataTable();
            table.Columns.Add("RiskIndex");
            table.Columns.Add("Type");

            foreach (var node in network.GeoNodeCollection)
            {
                FeatureDataRow row = table.NewRow();
                row.Geometry = node.Geometry;
                row["RiskIndex"] = node.RiskXi.ToString();
                row["Type"] = node.NodeType.ToString();
                table.AddRow(row);
            }             

            layer.DataSource = new GeometryFeatureProvider(table);
            var theme1 = new CustomTheme(NetworkStyle.GetMyCentroidStyle);
            layer.IsQueryEnabled = true;
            layer.Theme = theme1;

            return layer;
        }
    }
}
