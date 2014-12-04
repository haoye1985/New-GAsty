using System.Windows.Forms;
using SharpMap.Data;

namespace GAsty.Forms
{
    public partial class fmQueryWindow : Form{

        public fmQueryWindow(FeatureDataTable pDataTable)
        {
            InitializeComponent();

            this.dataGridViewPersistent1.DataSource = pDataTable;

        }


        

    }
}
