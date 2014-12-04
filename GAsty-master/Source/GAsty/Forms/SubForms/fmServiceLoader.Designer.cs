namespace GAsty
{
    partial class fmServiceLoader
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnServiceCancel = new System.Windows.Forms.Button();
            this.BtnServiceOK = new System.Windows.Forms.Button();
            this.NodeServicePath = new System.Windows.Forms.TextBox();
            this.NodeServiceBtn = new System.Windows.Forms.Button();
            this.LinkServicePath = new System.Windows.Forms.TextBox();
            this.linkServiceBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnServiceCancel);
            this.groupBox1.Controls.Add(this.BtnServiceOK);
            this.groupBox1.Controls.Add(this.NodeServicePath);
            this.groupBox1.Controls.Add(this.NodeServiceBtn);
            this.groupBox1.Controls.Add(this.LinkServicePath);
            this.groupBox1.Controls.Add(this.linkServiceBtn);
            this.groupBox1.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(371, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Services";
            // 
            // btnServiceCancel
            // 
            this.btnServiceCancel.Location = new System.Drawing.Point(291, 155);
            this.btnServiceCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnServiceCancel.Name = "btnServiceCancel";
            this.btnServiceCancel.Size = new System.Drawing.Size(65, 25);
            this.btnServiceCancel.TabIndex = 6;
            this.btnServiceCancel.Text = "Cancel";
            this.btnServiceCancel.UseVisualStyleBackColor = true;
            // 
            // BtnServiceOK
            // 
            this.BtnServiceOK.Location = new System.Drawing.Point(199, 155);
            this.BtnServiceOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnServiceOK.Name = "BtnServiceOK";
            this.BtnServiceOK.Size = new System.Drawing.Size(73, 25);
            this.BtnServiceOK.TabIndex = 5;
            this.BtnServiceOK.Text = "OK";
            this.BtnServiceOK.UseVisualStyleBackColor = true;
            this.BtnServiceOK.Click += new System.EventHandler(this.BtnServiceOK_Click);
            // 
            // NodeServicePath
            // 
            this.NodeServicePath.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NodeServicePath.Location = new System.Drawing.Point(157, 118);
            this.NodeServicePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NodeServicePath.Name = "NodeServicePath";
            this.NodeServicePath.Size = new System.Drawing.Size(159, 23);
            this.NodeServicePath.TabIndex = 4;
            // 
            // NodeServiceBtn
            // 
            this.NodeServiceBtn.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NodeServiceBtn.Location = new System.Drawing.Point(42, 114);
            this.NodeServiceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NodeServiceBtn.Name = "NodeServiceBtn";
            this.NodeServiceBtn.Size = new System.Drawing.Size(93, 26);
            this.NodeServiceBtn.TabIndex = 3;
            this.NodeServiceBtn.Text = "Link Service";
            this.NodeServiceBtn.UseVisualStyleBackColor = true;
            this.NodeServiceBtn.Click += new System.EventHandler(this.NodeServiceBtn_Click);
            // 
            // LinkServicePath
            // 
            this.LinkServicePath.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkServicePath.Location = new System.Drawing.Point(157, 56);
            this.LinkServicePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LinkServicePath.Name = "LinkServicePath";
            this.LinkServicePath.Size = new System.Drawing.Size(159, 23);
            this.LinkServicePath.TabIndex = 2;
            // 
            // linkServiceBtn
            // 
            this.linkServiceBtn.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkServiceBtn.Location = new System.Drawing.Point(42, 53);
            this.linkServiceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.linkServiceBtn.Name = "linkServiceBtn";
            this.linkServiceBtn.Size = new System.Drawing.Size(93, 25);
            this.linkServiceBtn.TabIndex = 0;
            this.linkServiceBtn.Text = "Node Service";
            this.linkServiceBtn.UseVisualStyleBackColor = true;
            this.linkServiceBtn.Click += new System.EventHandler(this.linkServiceBtn_Click);
            // 
            // fmServiceLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 217);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fmServiceLoader";
            this.Text = "fmServiceLoader";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button linkServiceBtn;
        private System.Windows.Forms.TextBox NodeServicePath;
        private System.Windows.Forms.Button NodeServiceBtn;
        private System.Windows.Forms.TextBox LinkServicePath;
        private System.Windows.Forms.Button btnServiceCancel;
        private System.Windows.Forms.Button BtnServiceOK;
    }
}