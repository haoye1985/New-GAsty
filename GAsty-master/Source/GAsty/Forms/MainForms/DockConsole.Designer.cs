namespace GAsty.Forms
{
    partial class DockConsole
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
            this.messages1 = new Pan.Utilities.Messages();
            this.SuspendLayout();
            // 
            // messages1
            // 
            this.messages1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messages1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.messages1.Location = new System.Drawing.Point(0, 0);
            this.messages1.Name = "messages1";
            this.messages1.Size = new System.Drawing.Size(1048, 669);
            this.messages1.TabIndex = 0;
            // 
            // DockConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 669);
            this.Controls.Add(this.messages1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DockConsole";
            this.Text = "Console";
            this.ResumeLayout(false);

        }

        #endregion

        private Pan.Utilities.Messages messages1;
    }
}