using GeoAPI.CoordinateSystems.Transformations;
using GeoAPI.Geometries;
using SharpMap.Forms;

namespace GAsty.Network.Operation
{
    public static class NetworkProjector
    {
        public static void ProjectTileLayer(MapBox pMapbox)
        {
                IMathTransform mathTransform = Projection.Wgs84toGoogleMercator.MathTransform;
                Envelope geom = GeometryTransform.TransformBox(new Envelope(-9.205626, -9.123736, 38.690993, 38.740837), mathTransform);
                pMapbox.Map.ZoomToBox(geom);pMapbox.Map.Zoom = 20000;
        }



    }
}
