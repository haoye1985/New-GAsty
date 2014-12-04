using System.Collections.Generic;
using GAsty.London_Tube_Operation.Operation;
using GAsty.Network.Core;
using GAsty.Tube;
using GraphSharp;
using QuickGraph;
using SharpMap.Layers;
using GAsty.Hazard.Core;
using QuickGraph.Serialization;

namespace GAsty.Utility
{
    public static class State
    {
        // Multiple networks overlaying for interdependency analysis
        public static List<GeoNetwork> ServiceNetworkCollection = new List<GeoNetwork>(); 
        public static List<VectorLayer> ServiceLayersCollection = new List<VectorLayer>(); 
        public static GeoNetwork network = new GeoNetwork();
        public static GeoNetwork servicenetwork = new GeoNetwork();

        // Service Operation
        public static List<TubeStation> ServiceStations = new List<TubeStation>(); 
        public static List<TubeLine> ServiceLines = new List<TubeLine>(); 

        // Service Status
        public static List<StationInfo> StationInformation = new List<StationInfo>(); 
        public static List<LinkIndex> LinkInformation = new List<LinkIndex>(); 
        public static List<StationODUnit> StationPassengerODMatrix = new List<StationODUnit>();

        // Selected Nodes
        public static List<GeoNode> impactedNode = new List<GeoNode>(); 
        public static List<GeoLink> impactedLink = new List<GeoLink>();
        public static List<GeoHazardCell> impactedHazardCells = new List<GeoHazardCell>();

        // Hazard
        public static List<GeoHazardCell> HazardCellCollection = new List<GeoHazardCell>();

        // Service

        //Graph layout
        public static CompoundGraph<object, IEdge<object>> ComponentCollection = new CompoundGraph<object, IEdge<object>>(); 


        public static VectorLayer layer = new VectorLayer("cacheLayer");
        public static VectorLayer NetworkNodeLayer = new VectorLayer("Infra Nodes");
        public static VectorLayer NetworkLinkLayer = new VectorLayer("Infra Links");
        public static VectorLayer NetworkServiceNodeLayer = new VectorLayer("ServiceNode");
        public static VectorLayer NetworkServiceLinkLayer = new VectorLayer("ServiceLink");
        public static VectorLayer ServiceNodeLayer = new VectorLayer("ServiceNodeLayer");
        public static VectorLayer ServiceLinkLayer = new VectorLayer("ServiceLinkLayer");
        public static VectorLayer UpdateService = new VectorLayer("UpdateService");
        public static VectorLayer ServiceRouteNodeLayer = new VectorLayer("RouteNodeService");
        public static VectorLayer ServiceRouteLinkLayer = new VectorLayer("RouteLinkService");
        public static VectorLayer SelectedNodeLayer = new VectorLayer("SelectedNodesLayer");
        public static VectorLayer SelectedLinkLayer = new VectorLayer("SelectedLinkLayer");

        public static VectorLayer RiskServiceNodeLayer = new VectorLayer("RiskServiceNodeLayer");
        public static VectorLayer RiskServiceLinkLayer = new VectorLayer("RiskServiceLinkLayer");

        public static bool RenderInfrastructure { get; set; }
        public static bool RenderService { get; set; }
        public static bool RenderRiskServiceLine { get; set; }
        public static bool IsProjectModeled { get; set; }
        public static bool IsComputionCompleted { get; set; }

        public static float ServiceValue {get; set;}
        public static bool RenderServiceEditing { get; set; }
    }
}