using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeGraphControl;

namespace Oasis.Graph.Graph_Core
{
    public class TransLink : NodeGraphLink
    {
        public TransLink(NodeGraphConnector p_Input, NodeGraphConnector p_Output, NodeGraphDataType p_DataType)
            : base(p_Input, p_Output, p_DataType) { }


    }
}
