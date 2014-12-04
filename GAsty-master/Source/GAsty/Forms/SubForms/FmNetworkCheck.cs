using System.Data;
using System.Windows.Forms;
using GAsty.Utility;
using Oasis;

namespace GAsty.Forms
{
    public partial class FmNetworkCheck : Form
    {
        public FmNetworkCheck()
        {
            InitializeComponent();

            UpdateDataGrid();}

        public void UpdateDataGrid()
        {
            this.dataGridViewPersistent1.DataSource = null;
            var dataTable = new DataTable();
            dataTable.Clear();

            dataTable.Columns.Add("Node Count");
            dataTable.Columns.Add("Link Count");

            var _row = dataTable.NewRow();
            _row["Node Count"] = State.network.GetInfraNodeCollection().Count;
            _row["Link Count"] = State.network.GetInfraLinkCollection().Count;
            dataTable.Rows.Add(_row);

            this.dataGridViewPersistent1.DataSource = dataTable;
            this.dataGridViewPersistent1.Rows[0].HeaderCell.Value = "Nodes";
        }


    }
}
