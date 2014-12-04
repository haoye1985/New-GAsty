using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAsty.Tube
{
    public class LineNetwork
    {
        private List<TubeLine> LineList;

        public LineNetwork(List<TubeLine> pLineList)
        {
            this.LineList = new List<TubeLine>(pLineList);

        }


        public List<TubeLine> LinesInNetwork
        {
            get { return LineList; }
            set { LineList = value; }
        }

    }
}
