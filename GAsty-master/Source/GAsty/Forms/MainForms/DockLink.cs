using System.ComponentModel;
using GAsty.Network.Core;
using GAsty.Utility;
using Oasis;
using WeifenLuo.WinFormsUI.Docking;

namespace GAsty.Forms
{
    public partial class DockLink : DockContent
    {
        public BindingList<GeoLink> GeoLinkCollection;

        public BindingList<GeoLink> ImpactLinkCollection; 

        public DockLink()
        {
            InitializeComponent();
            GeoLinkCollection = new BindingList<GeoLink>();

            ImpactLinkCollection = new BindingList<GeoLink>();
        }

        public void UpdateLinkList()
        {
            if (ImpactLinkCollection.Count == null)
            {
                this.dataGridViewPersistent1.DataSource =
                    new BindingList<GeoLink>(State.network.GetInfraLinkCollection());
            }
            else
            {
                
                this.dataGridViewPersistent1.DataSource = new BindingList<GeoLink>(State.network.GetInfraLinkCollection());
                this.dataGridViewPersistent2.DataSource = State.impactedLink;
            }
        }

    }
}
