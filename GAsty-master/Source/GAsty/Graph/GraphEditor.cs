using System.Drawing;
using System.Windows.Forms;
using NodeGraphControl;
using Oasis.Graph.Graph_Core;
using GAsty.Forms;

namespace GAsty.Graph
{
    public class GraphEditor
    {
        #region Private Field
         
        public Point m_MouseLoc;
        public GAsty.Graph.Graph_Core.GraphEnum m_enum;
        public NodeGraphPanel m_graphpanel;
        public NodeGraphConnector _inputLinkConnector;
        public NodeGraphConnector _outputLinkConnector;
        private Rectangle m_selectionRectangle;
        private Point m_SelectBoxOrigin;
        private Point m_SelectBoxCurrent;
        private Color m_SelectionFillColor;
        private Color m_SelectionOutlineColor;
        private SolidBrush m_SelectionFill;
        private Pen m_SelectionOutline;
        private float newViewZoom;
        
        #endregion

        #region Constructor

        public GraphEditor(NodeGraphPanel graphPanel)
        {
            this.m_enum = Graph_Core.GraphEnum.None;
            this.m_MouseLoc = Point.Empty;
            this.m_graphpanel = graphPanel;
            this.m_graphpanel.EditMode = NodeGraphEditMode.Idle;
            this.m_graphpanel.View.RegisterDataType(new InoperabilityDataType());
            this.m_graphpanel.View.RegisterDataType(new OperabilityDataType());
            this.m_graphpanel.View.RegisterDataType(new FloatDataType());
            this.m_SelectBoxOrigin = new Point();
            this.m_SelectBoxCurrent = new Point();
            this.m_selectionRectangle = new Rectangle();

            this.m_SelectionFillColor = Color.FromArgb(64, 128, 90, 30);
            this.m_SelectionOutlineColor = Color.FromArgb(192, 255, 180, 60);
            this.m_SelectionFill = new SolidBrush(Color.Transparent);
            this.m_SelectionOutline = new Pen(Color.Red, 2);
            this.m_graphpanel.MouseDown += GraphMouseDown;
            this.m_graphpanel.MouseMove += GraphMouseMove;
            this.m_graphpanel.MouseUp += GraphMouseUp;
            this.m_graphpanel.MouseWheel += GraphMouseWheel;
            this.m_graphpanel.Paint += GraphPaint;          
        }

        #endregion

        #region Method

        private void DrawSelectionBox(PaintEventArgs e)
        {
            if (this.m_enum == Graph_Core.GraphEnum.DrawSelectionBox)
            {
                Rectangle ViewRectangle = new Rectangle();
                if (this.m_SelectBoxOrigin.X > this.m_SelectBoxCurrent.X)
                {
                    ViewRectangle.X = this.m_SelectBoxCurrent.X;
                    ViewRectangle.Width = this.m_SelectBoxOrigin.X - this.m_SelectBoxCurrent.X;
                }
                else
                {
                    ViewRectangle.X = this.m_SelectBoxOrigin.X;
                    ViewRectangle.Width = this.m_SelectBoxCurrent.X - this.m_SelectBoxOrigin.X;
                }
                if (this.m_SelectBoxOrigin.Y > this.m_SelectBoxCurrent.Y)
                {
                    ViewRectangle.Y = this.m_SelectBoxCurrent.Y;
                    ViewRectangle.Height = this.m_SelectBoxOrigin.Y - this.m_SelectBoxCurrent.Y;
                }
                else
                {
                    ViewRectangle.Y = this.m_SelectBoxOrigin.Y;
                    ViewRectangle.Height = this.m_SelectBoxCurrent.Y - this.m_SelectBoxOrigin.Y;
                }
                e.Graphics.FillRectangle(this.m_SelectionFill, this.m_graphpanel.ViewToControl(ViewRectangle));
                e.Graphics.DrawRectangle(this.m_SelectionOutline, this.m_graphpanel.ViewToControl(ViewRectangle));
                m_selectionRectangle = ViewRectangle;
            }
        }
        
        #endregion

        #region Events

        private void GraphMouseDown(object sender, MouseEventArgs e)
        {
            this.m_graphpanel.EditMode = NodeGraphEditMode.Idle;
            this.m_enum = Graph_Core.GraphEnum.DrawSelectionBox;

            if (this.m_enum == Graph_Core.GraphEnum.DrawSelectionBox)
            {
                this.m_SelectBoxOrigin = this.m_graphpanel.ControlToView(new Point(e.X, e.Y));
                this.m_SelectBoxCurrent = this.m_graphpanel.ControlToView(new Point(e.X, e.Y));
            }
        }

        private void GraphMouseMove(object sender, MouseEventArgs e)
        {
            if (this.m_enum == Graph_Core.GraphEnum.DrawSelectionBox)
            {
                this.m_SelectBoxCurrent = this.m_graphpanel.ControlToView(new Point(e.X, e.Y));
            }
        }

        private void GraphMouseUp(object sender, MouseEventArgs e)
        {
            if (this.m_enum == Graph_Core.GraphEnum.DrawSelectionBox)
            {
                this.m_SelectBoxCurrent = this.m_graphpanel.ControlToView(new Point(e.X, e.Y));
                OasisForms.DockGraph.contextMenuStrip1.Show(e.Location);
                this.m_enum = Graph_Core.GraphEnum.None;
            }
        }

        private void GraphMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                newViewZoom = this.m_graphpanel.View.ViewZoom + ((float)e.Delta * 0.001f);
                if (newViewZoom > 0.1f && newViewZoom < 2.0f)
                    this.m_graphpanel.View.ViewZoom = newViewZoom;
            }
        }

        private void GraphPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            if (this.m_enum == Graph_Core.GraphEnum.DrawSelectionBox)
            {
                DrawSelectionBox(e);
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
        }

        #endregion

        #region Properties

        public Rectangle SelectionRectangle
        {
            get { return m_selectionRectangle; }
            set { m_selectionRectangle = value; }
        }

        #endregion
    }
}
