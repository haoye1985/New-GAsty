using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NodeGraphControl;
using NodeGraphControl.Xml;

namespace Oasis
{
    public class IOPConnector : NodeGraphConnector
    {
        #region Private Variable

        private int m_Length;

        #endregion

        #region Constructor

        public IOPConnector(string p_Name, NodeGraphNode p_parent, ConnectorType p_ConnectorType, int p_ConnectorIndex, string p_NodeGraphDataTypeName)
            : base(p_Name, p_parent, p_ConnectorType, p_ConnectorIndex)
        {
            this.m_Name = p_Name;
            this.m_Length = 30;
            this.m_oParentNode = p_parent;
            this.m_oView = p_parent.ParentView;
            this.m_oConnectorType = p_ConnectorType;
            this.m_iConnectorIndex = p_ConnectorIndex;
            this.m_oDataType = p_parent.ParentView.KnownDataTypes[p_NodeGraphDataTypeName];
        }

        #endregion

        #region Methods

        protected override Point GetTextPosition(System.Windows.Forms.PaintEventArgs e)
        {
            Point v_TextPosition;

            if (m_oConnectorType == ConnectorType.InputConnector)
            {
                // Note: here the code is used to determine the position of comments for connectors
                v_TextPosition = m_oView.ParentPanel.ViewToControl(new Point(m_oParentNode.X + 30, m_oParentNode.Y + m_oView.ParentPanel.NodeHeaderSize + 4 + (m_iConnectorIndex * 16)));
            }
            else
            {
                SizeF measure = e.Graphics.MeasureString(this.Name, m_oView.ParentPanel.NodeScaledConnectorFont);
                v_TextPosition = m_oView.ParentPanel.ViewToControl(new Point(m_oParentNode.X + (m_oParentNode.HitRectangle.Width), m_oParentNode.Y + m_oView.ParentPanel.NodeHeaderSize + 4 + (m_iConnectorIndex * 16)));
                v_TextPosition.X = v_TextPosition.X - (int)(60.0f * m_oView.CurrentViewZoom) - (int)measure.Width;
            }

            return v_TextPosition;
        }

        public override Rectangle GetHitArea()
        {
            Point v_Position;
            Rectangle v_ConnectorRectangle;
            int Bleed = m_oView.ParentPanel.ConnectorHitZoneBleed;

            if (m_oConnectorType == ConnectorType.InputConnector)
            {
                v_Position = m_oView.ParentPanel.ViewToControl(new Point(m_oParentNode.X, (m_oParentNode.Y + m_oView.ParentPanel.NodeHeaderSize + 6 + (m_iConnectorIndex * 16))));

                v_ConnectorRectangle = new Rectangle(v_Position.X - Bleed, v_Position.Y - Bleed,
                                                       (int)(12 * m_oView.CurrentViewZoom) + (2 * Bleed),
                                                       (int)(8 * m_oView.CurrentViewZoom) + (2 * Bleed));
            }
            else
            {

                v_Position = m_oView.ParentPanel.ViewToControl(new Point(m_oParentNode.X + (m_oParentNode.HitRectangle.Width - 12), (m_oParentNode.Y + m_oView.ParentPanel.NodeHeaderSize + 6 + (m_iConnectorIndex * 16))));
                v_ConnectorRectangle = new Rectangle(v_Position.X - Bleed, v_Position.Y - Bleed,
                                                       (int)(12 * m_oView.CurrentViewZoom) + (2 * Bleed),
                                                       (int)(8 * m_oView.CurrentViewZoom) + (2 * Bleed));
            }

            return v_ConnectorRectangle;
        }

        public override Rectangle GetArea()
        {
            Point v_Position;
            Rectangle v_ConnectorRectangle;

            if (m_oConnectorType == ConnectorType.InputConnector)
            {

                v_Position = m_oView.ParentPanel.ViewToControl(new Point(m_oParentNode.X, (m_oParentNode.Y + m_oView.ParentPanel.NodeHeaderSize + 6 + (m_iConnectorIndex * 16))));
                v_ConnectorRectangle = new Rectangle(v_Position.X, v_Position.Y,
                                                       (int)(12 * m_oView.CurrentViewZoom),
                                                       (int)(8 * m_oView.CurrentViewZoom));
            }
            else
            {
                // Note: here the code is used to determine the length for connectors
                v_Position = m_oView.ParentPanel.ViewToControl(new Point(m_oParentNode.X + (m_oParentNode.HitRectangle.Width - m_Length), (m_oParentNode.Y + m_oView.ParentPanel.NodeHeaderSize + 6 + (m_iConnectorIndex * 16))));
                v_ConnectorRectangle = new Rectangle(v_Position.X, v_Position.Y,
                                                       (int)(m_Length * m_oView.CurrentViewZoom),
                                                       (int)(8 * m_oView.CurrentViewZoom));
            }

            return v_ConnectorRectangle;
        }

        #endregion

        #region Events

        public override void Draw(System.Windows.Forms.PaintEventArgs e, int ConnectorIndex)
        {
            Rectangle v_ConnectorRectangle = this.GetArea();

            // CONNECTOR COLORING
            // TODO: ADD BOOLEAN FOR COLORING
            Pen v_ConnectorOutline;
            SolidBrush v_ConnectorFill;
            if (this.m_oView.ParentPanel.UseLinkColoring)
            {
                v_ConnectorOutline = this.m_oDataType.ConnectorOutlinePen;
                v_ConnectorFill = this.m_oDataType.ConnectorFillBrush;
            }
            else
            {
                v_ConnectorOutline = this.m_oView.ParentPanel.ConnectorOutline;
                v_ConnectorFill = this.m_oView.ParentPanel.ConnectorFill;
            }

            e.Graphics.FillRectangle(v_ConnectorFill, v_ConnectorRectangle);
            e.Graphics.DrawRectangle(v_ConnectorOutline, v_ConnectorRectangle);

            // If under zoom requirements for connector text...
            if (m_oView.CurrentViewZoom > m_oView.ParentPanel.NodeConnectorTextZoomTreshold)
            {
                Point v_TextPosition = GetTextPosition(e);
                e.Graphics.DrawString(this.Name, m_oView.ParentPanel.NodeScaledConnectorFont, m_oView.ParentPanel.ConnectorText, (float)v_TextPosition.X, (float)v_TextPosition.Y);
            }
        }

        #endregion

        #region Properties

        public int Length
        {
            get { return m_Length; }
            set { m_Length = value; }
        }

        #endregion
    }
}
