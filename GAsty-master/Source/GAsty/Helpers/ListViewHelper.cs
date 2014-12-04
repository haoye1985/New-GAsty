using System;
using System.Windows.Forms;
using GAsty.Network.Core;
using Oasis;
using SharpMap.Layers;

namespace GAsty.Helpers
{
    public class ListViewHelper
    {


        public static void AddLayerToView(TreeNode pTreeNode, Layer layer)
        {
            pTreeNode.Nodes.Add(new TreeNode(layer.LayerName) { Tag = layer });
        }

        public static void AddListNodeView(TreeNode pTreeNode, GeoNode pNode)
        {
            pTreeNode.Nodes.Add(new TreeNode(String.Format(pNode.ID + " " + pNode.Name)));
        }

        public static void AddListLinkView(TreeNode pTreeNode, GeoLink pLink){
            pTreeNode.Nodes.Add(new TreeNode(String.Format(pLink.ID + " " + pLink.Name)) {Tag = pLink});
        }

        public static void UpdateNodeListView(TreeNode pTreeNode, GeoNetwork network)
        {
            if (pTreeNode != null)
            {
                if (network.GeoNodeCollection.Count > 0)
                {
                    foreach (var node in network.GeoNodeCollection)
                    {
                        AddListNodeView(pTreeNode, node);
                    }
                }
            }
        }

        public static void UpdateLinkListView(TreeNode pTreeNode, GeoNetwork network)
        {
            if (pTreeNode != null)
            {
                if (network.GeoNodeCollection.Count > 0)
                {
                    foreach (var link in network.GeoLinkCollection)
                    {
                        AddListLinkView(pTreeNode, link);
                    }
                }
            }
        }




    }
}
