namespace GAsty.Forms
{
    partial class FmFilePath
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
            this.NodeLayer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNodePath = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnLinkPath = new System.Windows.Forms.Button();
            this.txtLinkPath = new System.Windows.Forms.TextBox();
            this.txtNodePath = new System.Windows.Forms.TextBox();
            this.btnDialogOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NodeLayer
            // 
            this.NodeLayer.AutoSize = true;
            this.NodeLayer.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NodeLayer.Location = new System.Drawing.Point(6, 57);
            this.NodeLayer.Name = "NodeLayer";
            this.NodeLayer.Size = new System.Drawing.Size(161, 18);
            this.NodeLayer.TabIndex = 0;
            this.NodeLayer.Text = "Node Layer Path: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Link Layer Path: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDialogOK);
            this.groupBox1.Controls.Add(this.btnNodePath);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.BtnLinkPath);
            this.groupBox1.Controls.Add(this.txtLinkPath);
            this.groupBox1.Controls.Add(this.txtNodePath);
            this.groupBox1.Controls.Add(this.NodeLayer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 234);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Construction";
            // 
            // btnNodePath
            // 
            this.btnNodePath.Location = new System.Drawing.Point(190, 47);
            this.btnNodePath.Name = "btnNodePath";
            this.btnNodePath.Size = new System.Drawing.Size(79, 39);
            this.btnNodePath.TabIndex = 8;
            this.btnNodePath.Text = "From";
            this.btnNodePath.UseVisualStyleBackColor = true;
            this.btnNodePath.Click += new System.EventHandler(this.btnNodePath_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(434, 171);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 47);
            this.button4.TabIndex = 7;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtnLinkPath
            // 
            this.BtnLinkPath.Location = new System.Drawing.Point(190, 113);
            this.BtnLinkPath.Name = "BtnLinkPath";
            this.BtnLinkPath.Size = new System.Drawing.Size(79, 38);
            this.BtnLinkPath.TabIndex = 5;
            this.BtnLinkPath.Text = "From";
            this.BtnLinkPath.UseVisualStyleBackColor = true;
            this.BtnLinkPath.Click += new System.EventHandler(this.BtnLinkPath_Click);
            // 
            // txtLinkPath
            // 
            this.txtLinkPath.Location = new System.Drawing.Point(287, 113);
            this.txtLinkPath.Multiline = true;
            this.txtLinkPath.Name = "txtLinkPath";
            this.txtLinkPath.Size = new System.Drawing.Size(270, 38);
            this.txtLinkPath.TabIndex = 3;
            // 
            // txtNodePath
            // 
            this.txtNodePath.Location = new System.Drawing.Point(287, 47);
            this.txtNodePath.Multiline = true;
            this.txtNodePath.Name = "txtNodePath";
            this.txtNodePath.Size = new System.Drawing.Size(270, 39);
            this.txtNodePath.TabIndex = 2;
            // 
            // btnDialogOK
            // 
            this.btnDialogOK.Location = new System.Drawing.Point(312, 171);
            this.btnDialogOK.Name = "btnDialogOK";
            this.btnDialogOK.Size = new System.Drawing.Size(100, 47);
            this.btnDialogOK.TabIndex = 9;
            this.btnDialogOK.Text = "OK";
            this.btnDialogOK.UseVisualStyleBackColor = true;
            this.btnDialogOK.Click += new System.EventHandler(this.btnDialogOK_Click);
            // 
            // FmFilePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 264);
            this.Controls.Add(this.groupBox1);
            this.Name = "FmFilePath";
            this.Text = "ShapeFile Builder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NodeLayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BtnLinkPath;
        private System.Windows.Forms.TextBox txtLinkPath;
        private System.Windows.Forms.TextBox txtNodePath;
        private System.Windows.Forms.Button btnNodePath;
        private System.Windows.Forms.Button btnDialogOK;
    }
}