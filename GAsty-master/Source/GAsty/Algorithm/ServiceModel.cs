using GAsty.Utility;
using System.Collections.Generic;

namespace GAsty
{
    public static class ServiceModel
    {
        public static void QuantifyService()
        {
                foreach (var node in State.network.GeoNodeCollection)
                {
                    if (node.RiskXi != null && node.CurrentTravelTime!=null)
                    {
                        node.EstimateTimeSpent = (float.Parse(node.CurrentTravelTime)/node.RiskXi).ToString();
                        node.EstimateTravelFrequency = (float.Parse(node.CurrentTravelFrequency.ToString())/(node.RiskXi)).ToString();
                    }
                }
            
        }

        public static void DoServiceComputation()
        {
            AssignRisk();
            ComputeStatus();
        }

        public static void AssignRisk()
        {
            foreach (var network in State.ServiceNetworkCollection)
            {
                //foreach (var node in network.GetServiceNodeCollection())
                foreach (var node in network.GeoNodeCollection)
                {
                    foreach (var calculatedNode in State.network.GeoNodeCollection)
                    {
                        if (node.ID == calculatedNode.ID)
                        {
                            node.RiskXi = calculatedNode.RiskXi;
                        }
                    }
                }
            }
        }

        public static void ComputeStatus()
        {
            List<float> riskCollection = new List<float>();

            float allRisk = 0;
            int allNodes = 0;

            foreach (var network in State.ServiceNetworkCollection)
            {
                foreach (var node in network.GeoNodeCollection)
                {
                    riskCollection.Add(node.RiskXi);
                }
            }

            foreach (var index in riskCollection)
            {
                allNodes = riskCollection.Count;
                allRisk += index;
            }

            allRisk = allRisk / allNodes;

            State.ServiceValue = allRisk;
        }






    }
}
