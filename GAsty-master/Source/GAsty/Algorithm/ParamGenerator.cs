using System;
using GAsty.Utility;
using Oasis;

namespace GAsty.Algorithm
{
    public static class ParamGenerator
    {

        public static void GenerateRandam()
        {
            var random = new Random();

            foreach (var node in State.network.GeoNodeCollection)
            {
                node.RiskCi = random.Next(0, 10) * 0.1f;
            }
            foreach (var link in State.network.GetInfraLinkCollection())
            {
                link.RiskAij = random.Next(0, 10) * 0.1f;
                link.RiskPij = random.Next(0, 10) * 0.1f;
            }
        }

        public static void GenerateFixedSample(float pRiskAij, float pRiskCi, float pPij)
        {
            foreach (var node in State.network.GetInfraNodeCollection())
            {
                node.RiskCi = pRiskCi;
            }
            foreach (var link in State.network.GetInfraLinkCollection())
            {
                link.RiskAij = pRiskAij;
                link.RiskPij = pPij;
            }
        }

        public static void GenerateSpatialInterdependency()
        {
            foreach (var node in State.network.GeoNodeCollection)
            {
                 foreach (var link in State.network.GetInfraLinkCollection())
                {
                    if (link.FromNodeID == node.ID || link.ToNodeID==node.ID)
                    {
                        link.RiskAij = 0.2f;
                    }

                }    
            }
        }


    }
}
