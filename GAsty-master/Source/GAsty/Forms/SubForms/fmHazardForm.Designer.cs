namespace GAsty.Forms
{
    partial class fmHazardForm
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
            this.gbHazardBox = new System.Windows.Forms.GroupBox();
            this.btnHazardOK = new System.Windows.Forms.Button();
            this.btnHazardCancel = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TxtHazardFilePath = new System.Windows.Forms.TextBox();
            this.gbHazardBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHazardBox
            // 
            this.gbHazardBox.Controls.Add(this.TxtHazardFilePath);
            this.gbHazardBox.Controls.Add(this.button3);
            this.gbHazardBox.Controls.Add(this.btnHazardCancel);
            this.gbHazardBox.Controls.Add(this.btnHazardOK);
            this.gbHazardBox.Location = new System.Drawing.Point(30, 12);
            this.gbHazardBox.Name = "gbHazardBox";
            this.gbHazardBox.Size = new System.Drawing.Size(531, 313);
            this.gbHazardBox.TabIndex = 0;
            this.gbHazardBox.TabStop = false;
            this.gbHazardBox.Text = "Hazard";
            // 
            // btnHazardOK
            // 
            this.btnHazardOK.Location = new System.Drawing.Point(83, 224);
            this.btnHazardOK.Name = "btnHazardOK";
            this.btnHazardOK.Size = new System.Drawing.Size(129, 40);
            this.btnHazardOK.TabIndex = 0;
            this.btnHazardOK.Text = "OK";
            this.btnHazardOK.UseVisualStyleBackColor = true;
            this.btnHazardOK.Click += new System.EventHandler(this.btnHazardOK_Click);
            // 
            // btnHazardCancel
            // 
            this.btnHazardCancel.Location = new System.Drawing.Point(295, 224);
            this.btnHazardCancel.Name = "btnHazardCancel";
            this.btnHazardCancel.Size = new System.Drawing.Size(130, 40);
            this.btnHazardCancel.TabIndex = 1;
            this.btnHazardCancel.Text = "Cancel";
            this.btnHazardCancel.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(38, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "Path";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TxtHazardFilePath
            // 
            this.TxtHazardFilePath.Location = new System.Drawing.Point(176, 101);
            this.TxtHazardFilePath.Multiline = true;
            this.TxtHazardFilePath.Name = "TxtHazardFilePath";
            this.TxtHazardFilePath.Size = new System.Drawing.Size(316, 38);
            this.TxtHazardFilePath.TabIndex = 3;
            // 
            // fmHazardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 354);
            this.Controls.Add(this.gbHazardBox);
            this.Name = "fmHazardForm";
            this.Text = "Hazard";
            this.gbHazardBox.ResumeLayout(false);
            this.gbHazardBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHazardBox;
        private System.Windows.Forms.TextBox TxtHazardFilePath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnHazardCancel;
        private System.Windows.Forms.Button btnHazardOK;
    }
}