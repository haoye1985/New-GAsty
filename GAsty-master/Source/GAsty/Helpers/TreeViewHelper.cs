using System.Windows.Forms;
using BruTile.Web.Wms;

namespace GAsty.Helpers
{
    public class TreeViewHelper
    {
        private TreeView m_treeView;

        public TreeViewHelper(TreeView ptreeView)
        {
            this.m_treeView = ptreeView;
        }

        public void ClearTree()
        {
            this.m_treeView.Nodes.Clear();
        }

        public void AddLayerToView(TreeNode pParentNode, Layer layer)
        {
            this.m_treeView.Nodes.Add(new TreeNode(layer.Name) {Tag = layer});
        }

        public TreeNodeCollection Nodes
        {
            get { return m_treeView.Nodes; }
        }
    }
}
