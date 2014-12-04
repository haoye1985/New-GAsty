namespace GAsty.Forms
{
    partial class DockMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockMap));
            this.mapBox1 = new SharpMap.Forms.MapBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ItemSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TSScreenToWorld = new System.Windows.Forms.ToolStripButton();
            this.TSCoordinate = new System.Windows.Forms.ToolStripLabel();
            this.TSCoord = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.naviBar1 = new Guifreaks.NavigationBar.NaviBar(this.components);
            this.naviBand3 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.naviBand2 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.naviBand1 = new Guifreaks.NavigationBar.NaviBand(this.components);
            this.LayerView = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.TSInfo = new System.Windows.Forms.ToolStripLabel();
            this.TSEarth = new System.Windows.Forms.ToolStripButton();
            this.TSCoordValue = new System.Windows.Forms.ToolStripLabel();
            this.TSMapScale = new System.Windows.Forms.ToolStripLabel();
            this.TSScaleValue = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).BeginInit();
            this.naviBar1.SuspendLayout();
            this.naviBand3.ClientArea.SuspendLayout();
            this.naviBand3.SuspendLayout();
            this.naviBand2.ClientArea.SuspendLayout();
            this.naviBand2.SuspendLayout();
            this.naviBand1.ClientArea.SuspendLayout();
            this.naviBand1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapBox1
            // 
            this.mapBox1.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this.mapBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.mapBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.mapBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.mapBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapBox1.FineZoomFactor = 10D;
            this.mapBox1.Location = new System.Drawing.Point(0, 0);
            this.mapBox1.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mapBox1.Name = "mapBox1";
            this.mapBox1.QueryGrowFactor = 5F;
            this.mapBox1.QueryLayerIndex = 0;
            this.mapBox1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.ShowProgressUpdate = false;
            this.mapBox1.Size = new System.Drawing.Size(1035, 595);
            this.mapBox1.TabIndex = 0;
            this.mapBox1.Text = "mapBox1";
            this.mapBox1.WheelZoomMagnitude = -2D;
            this.mapBox1.MouseMove += new SharpMap.Forms.MapBox.MouseEventHandler(this.mapBox1_MouseMove);
            this.mapBox1.MapZoomChanged += new SharpMap.Forms.MapBox.MapZoomHandler(this.mapBox1_MapZoomChanged);
            this.mapBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.mapBox1_Paint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSelect,
            this.ItemAnalysis});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 48);
            this.contextMenuStrip1.Text = "Select";
            // 
            // ItemSelect
            // 
            this.ItemSelect.Name = "ItemSelect";
            this.ItemSelect.Size = new System.Drawing.Size(174, 22);
            this.ItemSelect.Text = "Select";
            // 
            // ItemAnalysis
            // 
            this.ItemAnalysis.Name = "ItemAnalysis";
            this.ItemAnalysis.Size = new System.Drawing.Size(174, 22);
            this.ItemAnalysis.Text = "Select and Analysis";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(232, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(836, 25);
            this.miniToolStrip.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "Info";
            // 
            // TSScreenToWorld
            // 
            this.TSScreenToWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSScreenToWorld.Image = ((System.Drawing.Image)(resources.GetObject("TSScreenToWorld.Image")));
            this.TSScreenToWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSScreenToWorld.Name = "TSScreenToWorld";
            this.TSScreenToWorld.Size = new System.Drawing.Size(23, 22);
            this.TSScreenToWorld.Text = "toolStripButton1";
            this.TSScreenToWorld.Click += new System.EventHandler(this.TSScreenToWorld_Click);
            // 
            // TSCoordinate
            // 
            this.TSCoordinate.Name = "TSCoordinate";
            this.TSCoordinate.Size = new System.Drawing.Size(0, 22);
            // 
            // TSCoord
            // 
            this.TSCoord.Name = "TSCoord";
            this.TSCoord.Size = new System.Drawing.Size(66, 22);
            this.TSCoord.Text = "Coordinate";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Enabled = false;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel3.Text = "EPSG";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TSScreenToWorld,
            this.TSCoordinate,
            this.TSCoord,
            this.toolStripLabel3,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 666);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(836, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.naviBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.mapBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1181, 595);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // naviBar1
            // 
            this.naviBar1.ActiveBand = this.naviBand3;
            this.naviBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("naviBar1.BackgroundImage")));
            this.naviBar1.ButtonHeight = 25;
            this.naviBar1.Controls.Add(this.naviBand3);
            this.naviBar1.Controls.Add(this.naviBand2);
            this.naviBar1.Controls.Add(this.naviBand1);
            this.naviBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.naviBar1.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naviBar1.HeaderHeight = 24;
            this.naviBar1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBar1.Location = new System.Drawing.Point(0, 0);
            this.naviBar1.Name = "naviBar1";
            this.naviBar1.Size = new System.Drawing.Size(145, 595);
            this.naviBar1.TabIndex = 0;
            this.naviBar1.Text = "naviBar1";
            this.naviBar1.VisibleLargeButtons = 3;
            // 
            // naviBand3
            // 
            // 
            // naviBand3.ClientArea
            // 
            this.naviBand3.ClientArea.Controls.Add(this.treeView2);
            this.naviBand3.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand3.ClientArea.Name = "ClientArea";
            this.naviBand3.ClientArea.Size = new System.Drawing.Size(143, 456);
            this.naviBand3.ClientArea.TabIndex = 0;
            this.naviBand3.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand3.Location = new System.Drawing.Point(1, 24);
            this.naviBand3.Name = "naviBand3";
            this.naviBand3.Size = new System.Drawing.Size(143, 456);
            this.naviBand3.TabIndex = 7;
            this.naviBand3.Text = "Link Collection";
            // 
            // treeView2
            // 
            this.treeView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(143, 456);
            this.treeView2.TabIndex = 0;
            // 
            // naviBand2
            // 
            // 
            // naviBand2.ClientArea
            // 
            this.naviBand2.ClientArea.Controls.Add(this.treeView1);
            this.naviBand2.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand2.ClientArea.Name = "ClientArea";
            this.naviBand2.ClientArea.Size = new System.Drawing.Size(143, 456);
            this.naviBand2.ClientArea.TabIndex = 0;
            this.naviBand2.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand2.Location = new System.Drawing.Point(1, 24);
            this.naviBand2.Name = "naviBand2";
            this.naviBand2.Size = new System.Drawing.Size(143, 456);
            this.naviBand2.TabIndex = 5;
            this.naviBand2.Text = "Node Collection";
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(143, 456);
            this.treeView1.TabIndex = 0;
            // 
            // naviBand1
            // 
            this.naviBand1.BackColor = System.Drawing.Color.White;
            // 
            // naviBand1.ClientArea
            // 
            this.naviBand1.ClientArea.Controls.Add(this.LayerView);
            this.naviBand1.ClientArea.Location = new System.Drawing.Point(0, 0);
            this.naviBand1.ClientArea.Name = "ClientArea";
            this.naviBand1.ClientArea.Size = new System.Drawing.Size(143, 456);
            this.naviBand1.ClientArea.TabIndex = 0;
            this.naviBand1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Silver;
            this.naviBand1.Location = new System.Drawing.Point(1, 24);
            this.naviBand1.Name = "naviBand1";
            this.naviBand1.Size = new System.Drawing.Size(143, 456);
            this.naviBand1.SmallImage = ((System.Drawing.Image)(resources.GetObject("naviBand1.SmallImage")));
            this.naviBand1.TabIndex = 0;
            this.naviBand1.Text = "Map Layers";
            // 
            // LayerView
            // 
            this.LayerView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LayerView.CheckBoxes = true;
            this.LayerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayerView.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LayerView.Location = new System.Drawing.Point(0, 0);
            this.LayerView.Name = "LayerView";
            this.LayerView.Size = new System.Drawing.Size(143, 456);
            this.LayerView.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSInfo,
            this.TSEarth,
            this.TSCoordValue,
            this.TSMapScale,
            this.TSScaleValue,
            this.toolStripLabel2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 570);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1035, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // TSInfo
            // 
            this.TSInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSInfo.Name = "TSInfo";
            this.TSInfo.Size = new System.Drawing.Size(25, 22);
            this.TSInfo.Text = "Info";
            // 
            // TSEarth
            // 
            this.TSEarth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSEarth.Image = ((System.Drawing.Image)(resources.GetObject("TSEarth.Image")));
            this.TSEarth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSEarth.Name = "TSEarth";
            this.TSEarth.Size = new System.Drawing.Size(23, 22);
            this.TSEarth.Text = "toolStripButton2";
            this.TSEarth.Click += new System.EventHandler(this.TSEarth_Click);
            // 
            // TSCoordValue
            // 
            this.TSCoordValue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSCoordValue.Name = "TSCoordValue";
            this.TSCoordValue.Size = new System.Drawing.Size(30, 22);
            this.TSCoordValue.Text = "X: Y:";
            // 
            // TSMapScale
            // 
            this.TSMapScale.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSMapScale.Name = "TSMapScale";
            this.TSMapScale.Size = new System.Drawing.Size(37, 22);
            this.TSMapScale.Text = "Zoom:";
            // 
            // TSScaleValue
            // 
            this.TSScaleValue.Name = "TSScaleValue";
            this.TSScaleValue.Size = new System.Drawing.Size(11, 22);
            this.TSScaleValue.Text = ":";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel2.Text = "Loading Progress";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // DockMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1181, 595);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DockMap";
            this.Text = "Map";
            this.Load += new System.EventHandler(this.DockMap_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.naviBar1)).EndInit();
            this.naviBar1.ResumeLayout(false);
            this.naviBand3.ClientArea.ResumeLayout(false);
            this.naviBand3.ResumeLayout(false);
            this.naviBand2.ClientArea.ResumeLayout(false);
            this.naviBand2.ResumeLayout(false);
            this.naviBand1.ClientArea.ResumeLayout(false);
            this.naviBand1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public SharpMap.Forms.MapBox mapBox1;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton TSScreenToWorld;
        private System.Windows.Forms.ToolStripLabel TSCoordinate;
        private System.Windows.Forms.ToolStripLabel TSCoord;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Guifreaks.NavigationBar.NaviBar naviBar1;
        private Guifreaks.NavigationBar.NaviBand naviBand1;
        private System.Windows.Forms.TreeView LayerView;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel TSInfo;
        private System.Windows.Forms.ToolStripButton TSEarth;
        private System.Windows.Forms.ToolStripLabel TSCoordValue;
        private System.Windows.Forms.ToolStripLabel TSMapScale;
        private System.Windows.Forms.ToolStripLabel TSScaleValue;
        private Guifreaks.NavigationBar.NaviBand naviBand2;
        private Guifreaks.NavigationBar.NaviBand naviBand3;
        public System.Windows.Forms.TreeView treeView1;
        public System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ItemSelect;
        private System.Windows.Forms.ToolStripMenuItem ItemAnalysis;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;

    }
}