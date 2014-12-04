namespace GAsty.Forms
{
    partial class DockOperation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPersistent1 = new Pan.Utilities.DataGridViewPersistent();
            this.dataGridViewPersistent2 = new Pan.Utilities.DataGridViewPersistent();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersistent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersistent2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewPersistent2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewPersistent1);
            this.splitContainer1.Size = new System.Drawing.Size(678, 572);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewPersistent1
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewPersistent1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPersistent1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPersistent1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPersistent1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPersistent1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPersistent1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersistent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPersistent1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewPersistent1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPersistent1.Name = "dataGridViewPersistent1";
            this.dataGridViewPersistent1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPersistent1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPersistent1.RowTemplate.Height = 30;
            this.dataGridViewPersistent1.Size = new System.Drawing.Size(349, 572);
            this.dataGridViewPersistent1.TabIndex = 1;
            // 
            // dataGridViewPersistent2
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewPersistent2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPersistent2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPersistent2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPersistent2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPersistent2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPersistent2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersistent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPersistent2.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewPersistent2.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPersistent2.Name = "dataGridViewPersistent2";
            this.dataGridViewPersistent2.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewPersistent2.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPersistent2.RowTemplate.Height = 30;
            this.dataGridViewPersistent2.Size = new System.Drawing.Size(325, 572);
            this.dataGridViewPersistent2.TabIndex = 1;
            // 
            // DockOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 572);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DockOperation";
            this.Text = "Network Status";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersistent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersistent2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public Pan.Utilities.DataGridViewPersistent dataGridViewPersistent1;
        public Pan.Utilities.DataGridViewPersistent dataGridViewPersistent2;
    }
}