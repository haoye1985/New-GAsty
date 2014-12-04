using System.Collections.Generic;
using GAsty.Network.Core;
using GAsty.Hazard.Core;

namespace GAsty.Geospatial
{
    public static class BufferAnalysis
    {

        public static List<GeoNode> ExecuteIntersection(List<GeoHazardCell> pCellList, List<GeoNode> pNodeList)
        {
            var selectedNodeList = new List<GeoNode>();

            foreach (var Cell in pCellList)
            {
                foreach (var node in pNodeList)
                {
                    if ((float.Parse(Cell.HazardValue) > 0.7) && Cell.Geometry.Intersects(node.Geometry))
                    {
                        node.RiskCi = 0.4f;
                        selectedNodeList.Add(node);
                    }

                    if ((float.Parse(Cell.HazardValue) > 0.5) && (float.Parse(Cell.HazardValue) <= 0.7) && Cell.Geometry.Intersects(node.Geometry))
                    {
                        node.RiskCi = 0.6f;
                        selectedNodeList.Add(node);
                    }

                    if ((float.Parse(Cell.HazardValue) >= 0 && float.Parse(Cell.HazardValue) < 0.5) && Cell.Geometry.Intersects(node.Geometry))
                    {
                        node.RiskCi = 0.2f;
                        selectedNodeList.Add(node);
                    }
                }
            }
            return selectedNodeList;
        }

        public static List<GeoLink> ExcuteIntersectionLink(List<GeoHazardCell> pCellList, List<GeoLink> pLinkList)
        {
            var selectedLinkList = new List<GeoLink>();

            foreach (var Cell in pCellList)
            {
                foreach (var link in pLinkList)
                {
                    if ((float.Parse(Cell.HazardValue) > 0.5) && Cell.Geometry.Intersects(link.Geometry))
                    {
                        
                        selectedLinkList.Add(link);
                    }
                }
            }

            return selectedLinkList;
        }

        public static List<GeoHazardCell> ExcuteIntersectionHazard(List<GeoHazardCell> pCellList, float HazardValue)
        {
            var selectedHazardCells = new List<GeoHazardCell>();

            foreach (var Cell in pCellList)
            {
                if ((float.Parse(Cell.HazardValue) > HazardValue))
                {
                    selectedHazardCells.Add(Cell);
                }
            }

            return selectedHazardCells;
        }





    }
}
