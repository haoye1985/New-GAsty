using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using GAsty.OasisModel;
using System.Windows.Forms;
using GAsty.Utility;

namespace GAsty.Forms
{
    public partial class fmResultForm : Form
    {
        public fmResultForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResultOutput.ToCSV(State.network.GeoNodeCollection, exclude: "Service,Geometry,ConnectedGeoLinks,Degree,Width,Height,HitRectangle", path: textBox1.Text);
            ResultOutput.ToCSV(State.network.GeoLinkCollection, exclude: "Service,Geometry,FromNodeID,ToNodeID,FromNode,ToNode,FromPoint,ToPoint,FromNodeCoordinate,ToNodeCoordinate", path: textBox2.Text);
            this.Close();

            MessageBox.Show("Oasis modelling results saved!");     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\OasisResults\";
            saveFileDialog1.FileName = "Nodes.csv";
            saveFileDialog1.Filter = "CSV files (*.csv) | *.csv| all files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\Partition-HaoYe\Projects\Oasis\OasisResults\";
            saveFileDialog1.FileName = "Links.csv";
            saveFileDialog1.Filter = "CSV files (*.csv) | *.csv| all files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
