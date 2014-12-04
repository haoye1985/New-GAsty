using System;
using System.Windows.Forms;
using SharpMap.Forms;
using SharpMap.Layers;
using System.Collections.Generic;
using GAsty.Network.Core;
using SharpMap.Data.Providers;
using GeoAPI.Geometries;
using GAsty.Utility;
using GAsty.Network.Service;
using GAsty.Network.Operation;
using GAsty.Forms;
using SharpMap.Styles;

namespace GAsty
{
    public class ServiceEditor
    {
        private MapBox m_map;
        private List<GeoNode> m_serviceNodes;
        private List<GeoLink> m_serviceLinks;
        private List<GeoService> m_services;
        private GeoNetwork m_network;
        private VectorLayer m_ServiceNodeLayer;
        private VectorLayer m_ServiceLinkLayer;
        private NetworkVisualier m_visualiser;

        public ServiceEditor(MapBox pMapbox)
        {
            this.m_map = pMapbox;
            this.m_serviceNodes = new List<GeoNode>();
            this.m_serviceLinks = new List<GeoLink>();
            this.m_services = new List<GeoService>();
            this.m_network = new GeoNetwork();
            this.m_ServiceNodeLayer = new VectorLayer("NodeService");
            this.m_ServiceLinkLayer = new VectorLayer("LinkService");
            this.m_map.MouseDown += m_mapMouseDown;
            this.m_map.MouseUp += m_mapMouseUp;
            this.m_map.Paint += m_mapPaint;
        }

        private void m_mapMouseDown(Coordinate worldPos, MouseEventArgs imagePos)
        {
            if (State.network.GeoNodeCollection.Count > 0 || State.network.GeoLinkCollection.Count > 0)
            {
                 for (int i = 0; i < State.network.GeoNodeCollection.Count; i++)
                 {
                        if (State.network.GeoNodeCollection[i].ScreenPointContain(imagePos.Location))
                        {
                            var service = new GeoService(State.network.GeoNodeCollection[i]);
                            this.m_serviceNodes.Add(State.network.GeoNodeCollection[i]);
                            this.m_services.Add(service);
                            this.m_network.AddNodeService(State.network.GeoNodeCollection[i], service, GAsty.Network.Service.ServiceEnum.Good);
                        }
                  }

                 for (int i = 0; i < State.network.GeoLinkCollection.Count; i++)
                 {
                     if (State.network.GeoLinkCollection[i].CentralNode.ScreenPointContain(imagePos.Location))
                     {
                         var service = new GeoService(State.network.GeoLinkCollection[i]);
                         this.m_serviceLinks.Add(State.network.GeoLinkCollection[i]);
                         this.m_services.Add(service);
                         this.m_network.AddLinkService(State.network.GeoLinkCollection[i], service, GAsty.Network.Service.ServiceEnum.Good);
                     }
                 }




            }




        }

        private void m_mapMouseUp(Coordinate worldPos, MouseEventArgs imagePos)
        {
            State.ServiceNetworkCollection.Clear();
            State.ServiceNetworkCollection.Add(m_network);

            foreach (var network in State.ServiceNetworkCollection)
            {
                m_visualiser = new NetworkVisualier(network);
                m_ServiceNodeLayer = m_visualiser.RenderServiceNodeLayer();
                //m_ServiceLinkLayer = m_visualiser.RenderServiceLineLayer();


                State.NetworkServiceLinkLayer = ServiceRender.RenderServiceLinkLayer(network);
                //m_ServiceLinkLayer = m_visualiser.RenderServiceLineLayer();
                State.NetworkServiceNodeLayer = m_ServiceNodeLayer;
                //State.NetworkServiceLinkLayer = m_ServiceLinkLayer;
                //State.NetworkServiceLinkLayer = m_ServiceLinkLayer;
            }
            State.ServiceLayersCollection.Clear();

            State.ServiceLayersCollection.Add(State.NetworkServiceNodeLayer);
            State.ServiceLayersCollection.Add(State.NetworkServiceLinkLayer);

            foreach (var layer in State.ServiceLayersCollection)
            {
                OasisForms.DockMap.mapBox1.Map.Layers.Add(layer);

            }
            State.RenderServiceEditing = true;
            //OasisForms.DockMap.UpdateServiceMap();
            OasisForms.DockService.UpdateServiceList();
            this.m_map.Invalidate();
        }

        private void m_mapPaint(object sender, PaintEventArgs e)
        {
            if (State.RenderServiceEditing)
            {
                foreach (var layer in State.ServiceLayersCollection)
                {
                    layer.Render(e.Graphics, m_map.Map);
                }

                //foreach (var network in State.ServiceNetworkCollection)
                //{
                //    State.ServiceRouteNodeLayer = ServiceRender.RenderServiceNodeLayer(network);
                //    State.ServiceRouteLinkLayer = ServiceRender.RenderServiceLinkLayer(network);
                //    State.ServiceRouteNodeLayer.Render(e.Graphics, m_map.Map);
                //    State.ServiceRouteLinkLayer.Render(e.Graphics, m_map.Map);
                //}
 
            }
        }

    }
}
