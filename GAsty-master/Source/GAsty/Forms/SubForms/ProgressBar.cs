using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAsty.Forms
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
            this.progressBar1.Maximum = 5;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Step = 1;
        }

        public void UpdateProgress(int progress)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.BeginInvoke(new Action(() => progressBar1.Value = progress));
            else
                progressBar1.Value = progress;
        }

        public void UpdateLabel(string text)
        {
            if (textLoad.InvokeRequired)
            {
                textLoad.BeginInvoke(new Action(() => textLoad.Text = text));
                this.Refresh();
            }
            else
            {
                textLoad.Text = text;
                this.Refresh();
            }
        }




    }
}
