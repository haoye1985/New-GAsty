namespace GAsty.Forms
{
    partial class fmConnector
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
            this.gbBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmConnectorType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModelVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBox
            // 
            this.gbBox.Controls.Add(this.textBox1);
            this.gbBox.Controls.Add(this.label3);
            this.gbBox.Controls.Add(this.txtModelVersion);
            this.gbBox.Controls.Add(this.label2);
            this.gbBox.Controls.Add(this.cmConnectorType);
            this.gbBox.Controls.Add(this.label1);
            this.gbBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBox.Location = new System.Drawing.Point(12, 3);
            this.gbBox.Name = "gbBox";
            this.gbBox.Size = new System.Drawing.Size(454, 490);
            this.gbBox.TabIndex = 0;
            this.gbBox.TabStop = false;
            this.gbBox.Text = "Connector Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connector Type:";
            // 
            // cmConnectorType
            // 
            this.cmConnectorType.FormattingEnabled = true;
            this.cmConnectorType.Items.AddRange(new object[] {
            "Intensity Connector",
            "Vulnerability Connector"});
            this.cmConnectorType.Location = new System.Drawing.Point(220, 99);
            this.cmConnectorType.Name = "cmConnectorType";
            this.cmConnectorType.Size = new System.Drawing.Size(202, 29);
            this.cmConnectorType.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object Model Version:";
            // 
            // txtModelVersion
            // 
            this.txtModelVersion.Location = new System.Drawing.Point(220, 42);
            this.txtModelVersion.Name = "txtModelVersion";
            this.txtModelVersion.Size = new System.Drawing.Size(202, 28);
            this.txtModelVersion.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(220, 161);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 28);
            this.textBox1.TabIndex = 4;
            // 
            // fmConnector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 507);
            this.Controls.Add(this.gbBox);
            this.Name = "fmConnector";
            this.Text = "Connector";
            this.gbBox.ResumeLayout(false);
            this.gbBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmConnectorType;
        private System.Windows.Forms.TextBox txtModelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}