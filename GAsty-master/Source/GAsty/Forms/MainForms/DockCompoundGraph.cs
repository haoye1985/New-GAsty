using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsGraphSharp;
using GraphSharp.Sample;
using WeifenLuo.WinFormsUI.Docking;


namespace GAsty.Forms
{
    public partial class DockCompoundGraph : DockContent
    {
        public GraphSharpControl GraphControl { get; set; }

        public DockCompoundGraph()
        {
            InitializeComponent();

            GraphControl = new GraphSharpControl();

            elementHost1.Child = GraphControl;
        }
    }
}
