using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAsty.Network.Core;
using GAsty.Network.Service;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using SharpMap.Rendering.Thematics;

namespace GAsty
{
    public static class ServiceLayer
    {
        public static VectorLayer CreateServiceNodeLayer(GeoNetwork network)
        {
            var layer = new VectorLayer("ServiceNode");
            var table = new FeatureDataTable();      
            layer.DataSource = new GeometryFeatureProvider(table);
            var theme = new CustomTheme(ServiceStyle.GetNodeServiceStyle);
            layer.Theme = theme;
            return layer;
        }

        public static VectorLayer CreateServiceLinkLayer(GeoNetwork network)
        {
            var layer = new VectorLayer("ServiceLink");
            var table = new FeatureDataTable();
            layer.DataSource = new GeometryFeatureProvider(table);
            var theme = new CustomTheme(ServiceStyle.GetNodeServiceStyle);
            layer.Theme = theme;
            return layer;
        }


    }
}
