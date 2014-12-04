using GAsty.Network.Core;
using Oasis;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using SharpMap.Rendering.Thematics;

namespace GAsty.Network.Visualisation
{
    public static class NetworkRender
    {

        public static VectorLayer RenderRiskLayer(GeoNetwork pNetwork)
        {
            var layer = new VectorLayer("NetworkLayer");
            var table = new FeatureDataTable();
            table.Columns.Add("RiskIndex");

            foreach (var node in pNetwork.GeoNodeCollection)
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



    }
}
