using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using GAsty.Network.Core;
using GAsty.Utility;
using GraphSharp.Sample;
using QuickGraph;
using GraphSharp;
using GraphSharp.Controls;
using QuickGraph.Serialization;

namespace WinFormsGraphSharp
{
    /// <summary>
    /// Interaction logic for GraphSharpControl.xaml
    /// </summary>
    public partial class GraphSharpControl : UserControl
    {
        private string[] vertices;

        public GraphSharpControl()
        {
            InitializeComponent();

            //if (State.network.GeoNodeCollection.Count == 0)
            //{

            //}
            //else if (State.network.GeoNodeCollection.Count > 0)
            //{
            //    int nodeCount = State.network.GeoNodeCollection.Count;
            //    var vertices = new string[nodeCount];

            //    for (int i = 0; i < nodeCount; i++)
            //    {
            //        vertices[i] = i.ToString();
            //        State.ComponentCollection.AddVertex(vertices[i]);
            //    }

            //    layout.LayoutMode = LayoutMode.Automatic;
            //    layout.LayoutAlgorithmType = "CompoundFDP";
            //    layout.OverlapRemovalConstraint = AlgorithmConstraints.Automatic;
            //    layout.OverlapRemovalAlgorithmType = "FSA";
            //    layout.HighlightAlgorithmType = "Simple";
            //    layout.Graph = State.ComponentCollection;
            //}

            //var vertices = new string[30];
            //for (int i = 0; i < 30; i++)
            //{
            //    vertices[i] = i.ToString();
            //    State.ComponentCollection.AddVertex(vertices[i]);
            //}
            //for (int i = 6; i < 15; i++)
            //{
            //    State.ComponentCollection.AddChildVertex(vertices[i % 5], vertices[i]);
            //}
            //State.ComponentCollection.AddChildVertex(vertices[5], vertices[4]);
            //State.ComponentCollection.AddChildVertex(vertices[5], vertices[2]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[0]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[1]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[3]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[20]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[21]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[22]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[23]);
            //State.ComponentCollection.AddChildVertex(vertices[16], vertices[24]);
            //State.ComponentCollection.AddChildVertex(vertices[4], vertices[25]);
            //State.ComponentCollection.AddChildVertex(vertices[4], vertices[26]);
            //State.ComponentCollection.AddChildVertex(vertices[4], vertices[27]);

            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[0], vertices[1]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[0], vertices[2]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[2], vertices[4]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[0], vertices[7]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[8], vertices[7]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[3], vertices[20]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[20], vertices[21]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[20], vertices[22]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[22], vertices[23]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[23], vertices[24]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[0], vertices[28]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[0], vertices[29]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[25], vertices[27]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[26], vertices[25]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[14], vertices[27]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[14], vertices[26]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[14], vertices[25]));
            //State.ComponentCollection.AddEdge(new Edge<object>(vertices[26], vertices[27]));

            //layout.LayoutMode = LayoutMode.Automatic;
            //layout.LayoutAlgorithmType = "CompoundFDP";
            //layout.OverlapRemovalConstraint = AlgorithmConstraints.Automatic;
            //layout.OverlapRemovalAlgorithmType = "FSA";
            //layout.HighlightAlgorithmType = "Simple";
            //layout.Graph = State.ComponentCollection;

        }

        public void UpdateComponent()
        {
            if (State.network.GeoNodeCollection.Count == 0 && State.network.GeoLinkCollection.Count == 0)
            {
                State.ComponentCollection.Clear();
            }
            else if (State.network.GeoNodeCollection.Count > 0 || State.network.GeoLinkCollection.Count > 0)
            {
                State.ComponentCollection.Clear();
                var nodeCollection = new List<GeoNode>();

                foreach (var node in State.network.GeoNodeCollection)
                {
                    if (node.NodeType == NodeEnum.Edge)
                    {
                        nodeCollection.Add(node);
                    }
                }

                int nodeCount = State.network.GeoNodeCollection.Count;

                foreach (var geoNode in State.network.GeoNodeCollection)
                {

                        State.ComponentCollection.AddVertex(geoNode.ID.ToString());
                }

                //var vertices = new string[nodeCount];

                //for (int i = 0; i < nodeCount; i++)
                //{
                //    vertices[i] = i.ToString();
                //    State.ComponentCollection.AddVertex(vertices[i]);
                //}

                foreach (var link in State.network.GeoLinkCollection)
                {
                    //State.ComponentCollection.AddEdge(new Edge<object>(vertices[link.FromNodeID], vertices[link.ToNodeID]));
                    //State.ComponentCollection.AddEdge(new Edge<object>(link.FromNodeID.ToString(), link.ToNodeID.ToString()));
                }

            }

            layout.LayoutMode = LayoutMode.Automatic;
            layout.LayoutAlgorithmType = "CompoundFDP";
            layout.OverlapRemovalConstraint = AlgorithmConstraints.Automatic;
            layout.OverlapRemovalAlgorithmType = "FSA";
            layout.HighlightAlgorithmType = "Simple";
            layout.Graph = State.ComponentCollection;
            layout.UpdateLayout();
        }

        private IBidirectionalGraph<object, IEdge<object>> ConvertGraph(PocGraph graph)
        {
            var g = new CompoundGraph<object, IEdge<object>>();

            foreach (var item in graph.Vertices)
            {
                g.AddVertex(item.ID);
            }

            foreach (var item in graph.Edges)
            {
                g.AddEdge(new Edge<object>(item.Source.ID, item.Target.ID));
            }

            return g;
        }

        private void Relayout_Click(object sender, RoutedEventArgs e)
        {
            layout.Relayout();
        }

    }
}
