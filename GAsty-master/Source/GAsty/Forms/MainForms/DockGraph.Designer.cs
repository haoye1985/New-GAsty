namespace GAsty.Forms
{
    partial class DockGraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nodeGraphPanel1 = new NodeGraphControl.NodeGraphPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nodeGraphPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(1139, 654);
            this.splitContainer1.SplitterDistance = 952;
            this.splitContainer1.TabIndex = 0;
            // 
            // nodeGraphPanel1
            // 
            this.nodeGraphPanel1.BackColor = System.Drawing.Color.White;
            this.nodeGraphPanel1.ConnectorFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nodeGraphPanel1.ConnectorFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.nodeGraphPanel1.ConnectorHitZoneBleed = 2;
            this.nodeGraphPanel1.ConnectorOutlineColor = System.Drawing.Color.DimGray;
            this.nodeGraphPanel1.ConnectorOutlineSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nodeGraphPanel1.ConnectorTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nodeGraphPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeGraphPanel1.DrawShadow = true;
            this.nodeGraphPanel1.EditMode = NodeGraphControl.NodeGraphEditMode.Idle;
            this.nodeGraphPanel1.EnableDrawDebug = true;
            this.nodeGraphPanel1.ForeColor = System.Drawing.Color.Black;
            this.nodeGraphPanel1.GridAlpha = ((byte)(32));
            this.nodeGraphPanel1.GridPadding = 256;
            this.nodeGraphPanel1.LinkColor = System.Drawing.Color.Red;
            this.nodeGraphPanel1.LinkEditableColor = System.Drawing.Color.Red;
            this.nodeGraphPanel1.LinkHardness = 2F;
            this.nodeGraphPanel1.LinkVisualStyle = NodeGraphControl.LinkVisualStyle.Curve;
            this.nodeGraphPanel1.Location = new System.Drawing.Point(0, 0);
            this.nodeGraphPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.nodeGraphPanel1.Name = "nodeGraphPanel1";
            this.nodeGraphPanel1.NodeConnectorFont = new System.Drawing.Font("Tahoma", 7F);
            this.nodeGraphPanel1.NodeConnectorTextZoomTreshold = 0.8F;
            this.nodeGraphPanel1.NodeFillColor = System.Drawing.Color.White;
            this.nodeGraphPanel1.NodeFillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(128)))), ((int)(((byte)(100)))));
            this.nodeGraphPanel1.NodeHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.nodeGraphPanel1.NodeHeaderSize = 24;
            this.nodeGraphPanel1.NodeOutlineColor = System.Drawing.Color.Black;
            this.nodeGraphPanel1.NodeOutlineSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.nodeGraphPanel1.NodeScaledConnectorFont = new System.Drawing.Font("Tahoma", 7F);
            this.nodeGraphPanel1.NodeScaledTitleFont = new System.Drawing.Font("Arial Narrow", 8F);
            this.nodeGraphPanel1.NodeSignalInvalidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nodeGraphPanel1.NodeSignalValidColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.nodeGraphPanel1.NodeTextColor = System.Drawing.Color.Black;
            this.nodeGraphPanel1.NodeTextShadowColor = System.Drawing.Color.White;
            this.nodeGraphPanel1.NodeTitleFont = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeGraphPanel1.NodeTitleZoomThreshold = 0.5F;
            this.nodeGraphPanel1.SelectionFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.nodeGraphPanel1.SelectionOutlineColor = System.Drawing.Color.Red;
            this.nodeGraphPanel1.ShowGrid = false;
            this.nodeGraphPanel1.Size = new System.Drawing.Size(952, 654);
            this.nodeGraphPanel1.SmoothBehavior = true;
            this.nodeGraphPanel1.TabIndex = 0;
            this.nodeGraphPanel1.UseLinkColoring = true;
            this.nodeGraphPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nodeGraphPanel1_MouseDown);
            this.nodeGraphPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nodeGraphPanel1_MouseUp);
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(183, 654);
            this.treeView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectNoneToolStripMenuItem,
            this.selectLinksToolStripMenuItem,
            this.selectNodesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 70);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.selectNoneToolStripMenuItem.Text = "Select None";
            // 
            // selectLinksToolStripMenuItem
            // 
            this.selectLinksToolStripMenuItem.Name = "selectLinksToolStripMenuItem";
            this.selectLinksToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.selectLinksToolStripMenuItem.Text = "Select Links";
            this.selectLinksToolStripMenuItem.Click += new System.EventHandler(this.selectLinksToolStripMenuItem_Click);
            // 
            // selectNodesToolStripMenuItem
            // 
            this.selectNodesToolStripMenuItem.Name = "selectNodesToolStripMenuItem";
            this.selectNodesToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.selectNodesToolStripMenuItem.Text = "Select Nodes";
            this.selectNodesToolStripMenuItem.Click += new System.EventHandler(this.selectNodesToolStripMenuItem_Click);
            // 
            // DockGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 654);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DockGraph";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.DockGraph_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public NodeGraphControl.NodeGraphPanel nodeGraphPanel1;
        private System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem selectLinksToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem selectNodesToolStripMenuItem;
    }
}