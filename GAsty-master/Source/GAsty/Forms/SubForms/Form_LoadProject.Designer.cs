namespace GAsty.Forms
{
    partial class Form_LoadProject
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
            this.btnProjectOk = new System.Windows.Forms.Button();
            this.txtInfraPath = new System.Windows.Forms.TextBox();
            this.btnProjectPath = new System.Windows.Forms.Button();
            this.btnProjectCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbServiceNetwork = new System.Windows.Forms.GroupBox();
            this.btnServiceLoader = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtServiceNodePath = new System.Windows.Forms.TextBox();
            this.txtServiceLinkPath = new System.Windows.Forms.TextBox();
            this.gbInfra = new System.Windows.Forms.GroupBox();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.txtPassengerPath = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textLineStatusPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbService = new System.Windows.Forms.CheckBox();
            this.gbHazard = new System.Windows.Forms.GroupBox();
            this.btnHazardPath = new System.Windows.Forms.Button();
            this.txtHazardPath = new System.Windows.Forms.TextBox();
            this.cbInfrastructure = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbPassenger = new System.Windows.Forms.CheckBox();
            this.cbJourney = new System.Windows.Forms.CheckBox();
            this.cbHazard = new System.Windows.Forms.CheckBox();
            this.cbAllData = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gbServiceNetwork.SuspendLayout();
            this.gbInfra.SuspendLayout();
            this.gbService.SuspendLayout();
            this.gbHazard.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProjectOk
            // 
            this.btnProjectOk.Location = new System.Drawing.Point(276, 396);
            this.btnProjectOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnProjectOk.Name = "btnProjectOk";
            this.btnProjectOk.Size = new System.Drawing.Size(80, 30);
            this.btnProjectOk.TabIndex = 0;
            this.btnProjectOk.Text = "OK";
            this.btnProjectOk.UseVisualStyleBackColor = true;
            this.btnProjectOk.Click += new System.EventHandler(this.btnProjectOk_Click);
            // 
            // txtInfraPath
            // 
            this.txtInfraPath.Location = new System.Drawing.Point(126, 37);
            this.txtInfraPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtInfraPath.Multiline = true;
            this.txtInfraPath.Name = "txtInfraPath";
            this.txtInfraPath.Size = new System.Drawing.Size(206, 21);
            this.txtInfraPath.TabIndex = 1;
            // 
            // btnProjectPath
            // 
            this.btnProjectPath.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectPath.Location = new System.Drawing.Point(17, 33);
            this.btnProjectPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnProjectPath.Name = "btnProjectPath";
            this.btnProjectPath.Size = new System.Drawing.Size(81, 31);
            this.btnProjectPath.TabIndex = 2;
            this.btnProjectPath.Text = "Path";
            this.btnProjectPath.UseVisualStyleBackColor = true;
            this.btnProjectPath.Click += new System.EventHandler(this.btnProjectPath_Click);
            // 
            // btnProjectCancel
            // 
            this.btnProjectCancel.Location = new System.Drawing.Point(423, 396);
            this.btnProjectCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnProjectCancel.Name = "btnProjectCancel";
            this.btnProjectCancel.Size = new System.Drawing.Size(82, 30);
            this.btnProjectCancel.TabIndex = 3;
            this.btnProjectCancel.Text = "Cancel";
            this.btnProjectCancel.UseVisualStyleBackColor = true;
            this.btnProjectCancel.Click += new System.EventHandler(this.btnProjectCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbServiceNetwork);
            this.groupBox1.Controls.Add(this.gbInfra);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(380, 256);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Projects From Directory";
            // 
            // gbServiceNetwork
            // 
            this.gbServiceNetwork.Controls.Add(this.btnServiceLoader);
            this.gbServiceNetwork.Controls.Add(this.button1);
            this.gbServiceNetwork.Controls.Add(this.txtServiceNodePath);
            this.gbServiceNetwork.Controls.Add(this.txtServiceLinkPath);
            this.gbServiceNetwork.Location = new System.Drawing.Point(16, 123);
            this.gbServiceNetwork.Name = "gbServiceNetwork";
            this.gbServiceNetwork.Size = new System.Drawing.Size(352, 120);
            this.gbServiceNetwork.TabIndex = 19;
            this.gbServiceNetwork.TabStop = false;
            this.gbServiceNetwork.Text = "Service Network";
            // 
            // btnServiceLoader
            // 
            this.btnServiceLoader.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceLoader.Location = new System.Drawing.Point(17, 20);
            this.btnServiceLoader.Margin = new System.Windows.Forms.Padding(2);
            this.btnServiceLoader.Name = "btnServiceLoader";
            this.btnServiceLoader.Size = new System.Drawing.Size(81, 31);
            this.btnServiceLoader.TabIndex = 12;
            this.btnServiceLoader.Text = "Stations";
            this.btnServiceLoader.UseVisualStyleBackColor = true;
            this.btnServiceLoader.Click += new System.EventHandler(this.btnServiceLoader_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(17, 73);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 31);
            this.button1.TabIndex = 15;
            this.button1.Text = "Lines";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtServiceNodePath
            // 
            this.txtServiceNodePath.Location = new System.Drawing.Point(126, 30);
            this.txtServiceNodePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtServiceNodePath.Multiline = true;
            this.txtServiceNodePath.Name = "txtServiceNodePath";
            this.txtServiceNodePath.Size = new System.Drawing.Size(206, 21);
            this.txtServiceNodePath.TabIndex = 13;
            // 
            // txtServiceLinkPath
            // 
            this.txtServiceLinkPath.Location = new System.Drawing.Point(126, 77);
            this.txtServiceLinkPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtServiceLinkPath.Multiline = true;
            this.txtServiceLinkPath.Name = "txtServiceLinkPath";
            this.txtServiceLinkPath.Size = new System.Drawing.Size(206, 21);
            this.txtServiceLinkPath.TabIndex = 14;
            // 
            // gbInfra
            // 
            this.gbInfra.Controls.Add(this.btnProjectPath);
            this.gbInfra.Controls.Add(this.txtInfraPath);
            this.gbInfra.Location = new System.Drawing.Point(16, 28);
            this.gbInfra.Name = "gbInfra";
            this.gbInfra.Size = new System.Drawing.Size(352, 89);
            this.gbInfra.TabIndex = 17;
            this.gbInfra.TabStop = false;
            this.gbInfra.Text = "Infrastructure Network";
            // 
            // gbService
            // 
            this.gbService.Controls.Add(this.txtPassengerPath);
            this.gbService.Controls.Add(this.button3);
            this.gbService.Controls.Add(this.textLineStatusPath);
            this.gbService.Controls.Add(this.button2);
            this.gbService.Location = new System.Drawing.Point(13, 123);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(352, 120);
            this.gbService.TabIndex = 20;
            this.gbService.TabStop = false;
            this.gbService.Text = "Service";
            // 
            // txtPassengerPath
            // 
            this.txtPassengerPath.Location = new System.Drawing.Point(126, 87);
            this.txtPassengerPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassengerPath.Multiline = true;
            this.txtPassengerPath.Name = "txtPassengerPath";
            this.txtPassengerPath.Size = new System.Drawing.Size(206, 21);
            this.txtPassengerPath.TabIndex = 18;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(17, 83);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 31);
            this.button3.TabIndex = 17;
            this.button3.Text = "Passenger Status";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textLineStatusPath
            // 
            this.textLineStatusPath.Location = new System.Drawing.Point(126, 33);
            this.textLineStatusPath.Margin = new System.Windows.Forms.Padding(2);
            this.textLineStatusPath.Multiline = true;
            this.textLineStatusPath.Name = "textLineStatusPath";
            this.textLineStatusPath.Size = new System.Drawing.Size(206, 21);
            this.textLineStatusPath.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(17, 29);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 31);
            this.button2.TabIndex = 16;
            this.button2.Text = "Line Status";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbService
            // 
            this.cbService.AutoSize = true;
            this.cbService.Location = new System.Drawing.Point(191, 66);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(88, 17);
            this.cbService.TabIndex = 21;
            this.cbService.Text = "Service Data";
            this.cbService.UseVisualStyleBackColor = true;
            // 
            // gbHazard
            // 
            this.gbHazard.Controls.Add(this.btnHazardPath);
            this.gbHazard.Controls.Add(this.txtHazardPath);
            this.gbHazard.Location = new System.Drawing.Point(15, 33);
            this.gbHazard.Name = "gbHazard";
            this.gbHazard.Size = new System.Drawing.Size(350, 84);
            this.gbHazard.TabIndex = 18;
            this.gbHazard.TabStop = false;
            this.gbHazard.Text = "Hazard Database";
            // 
            // btnHazardPath
            // 
            this.btnHazardPath.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHazardPath.Location = new System.Drawing.Point(15, 36);
            this.btnHazardPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnHazardPath.Name = "btnHazardPath";
            this.btnHazardPath.Size = new System.Drawing.Size(81, 31);
            this.btnHazardPath.TabIndex = 9;
            this.btnHazardPath.Text = "Path";
            this.btnHazardPath.UseVisualStyleBackColor = true;
            this.btnHazardPath.Click += new System.EventHandler(this.btnHazardPath_Click);
            // 
            // txtHazardPath
            // 
            this.txtHazardPath.Location = new System.Drawing.Point(126, 40);
            this.txtHazardPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtHazardPath.Multiline = true;
            this.txtHazardPath.Name = "txtHazardPath";
            this.txtHazardPath.Size = new System.Drawing.Size(206, 21);
            this.txtHazardPath.TabIndex = 10;
            // 
            // cbInfrastructure
            // 
            this.cbInfrastructure.AutoSize = true;
            this.cbInfrastructure.Location = new System.Drawing.Point(39, 66);
            this.cbInfrastructure.Name = "cbInfrastructure";
            this.cbInfrastructure.Size = new System.Drawing.Size(117, 17);
            this.cbInfrastructure.TabIndex = 16;
            this.cbInfrastructure.Text = "Infrastructure Data ";
            this.cbInfrastructure.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbHazard);
            this.groupBox2.Controls.Add(this.gbService);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(393, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 256);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hazard & Service";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbPassenger);
            this.groupBox3.Controls.Add(this.cbJourney);
            this.groupBox3.Controls.Add(this.cbHazard);
            this.groupBox3.Controls.Add(this.cbAllData);
            this.groupBox3.Controls.Add(this.cbInfrastructure);
            this.groupBox3.Controls.Add(this.cbService);
            this.groupBox3.Location = new System.Drawing.Point(8, 271);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(774, 100);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Default Data Loading";
            // 
            // cbPassenger
            // 
            this.cbPassenger.AutoSize = true;
            this.cbPassenger.Location = new System.Drawing.Point(334, 66);
            this.cbPassenger.Name = "cbPassenger";
            this.cbPassenger.Size = new System.Drawing.Size(102, 17);
            this.cbPassenger.TabIndex = 25;
            this.cbPassenger.Text = "Passenger Data";
            this.cbPassenger.UseVisualStyleBackColor = true;
            // 
            // cbJourney
            // 
            this.cbJourney.AutoSize = true;
            this.cbJourney.Location = new System.Drawing.Point(334, 33);
            this.cbJourney.Name = "cbJourney";
            this.cbJourney.Size = new System.Drawing.Size(89, 17);
            this.cbJourney.TabIndex = 24;
            this.cbJourney.Text = "Journey Data";
            this.cbJourney.UseVisualStyleBackColor = true;
            // 
            // cbHazard
            // 
            this.cbHazard.AutoSize = true;
            this.cbHazard.Location = new System.Drawing.Point(191, 33);
            this.cbHazard.Name = "cbHazard";
            this.cbHazard.Size = new System.Drawing.Size(89, 17);
            this.cbHazard.TabIndex = 23;
            this.cbHazard.Text = "Hazard Data ";
            this.cbHazard.UseVisualStyleBackColor = true;
            // 
            // cbAllData
            // 
            this.cbAllData.AutoSize = true;
            this.cbAllData.Checked = true;
            this.cbAllData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllData.Location = new System.Drawing.Point(39, 33);
            this.cbAllData.Name = "cbAllData";
            this.cbAllData.Size = new System.Drawing.Size(63, 17);
            this.cbAllData.TabIndex = 22;
            this.cbAllData.Text = "All Data";
            this.cbAllData.UseVisualStyleBackColor = true;
            // 
            // Form_LoadProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 452);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProjectOk);
            this.Controls.Add(this.btnProjectCancel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_LoadProject";
            this.Text = "Load Projects";
            this.Load += new System.EventHandler(this.Form_LoadProject_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbServiceNetwork.ResumeLayout(false);
            this.gbServiceNetwork.PerformLayout();
            this.gbInfra.ResumeLayout(false);
            this.gbInfra.PerformLayout();
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            this.gbHazard.ResumeLayout(false);
            this.gbHazard.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProjectOk;
        private System.Windows.Forms.TextBox txtInfraPath;
        private System.Windows.Forms.Button btnProjectPath;
        private System.Windows.Forms.Button btnProjectCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHazardPath;
        private System.Windows.Forms.Button btnHazardPath;
        private System.Windows.Forms.TextBox txtServiceNodePath;
        private System.Windows.Forms.Button btnServiceLoader;
        private System.Windows.Forms.TextBox txtServiceLinkPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbInfrastructure;
        private System.Windows.Forms.GroupBox gbServiceNetwork;
        private System.Windows.Forms.GroupBox gbHazard;
        private System.Windows.Forms.GroupBox gbInfra;
        private System.Windows.Forms.CheckBox cbService;
        private System.Windows.Forms.GroupBox gbService;
        private System.Windows.Forms.TextBox textLineStatusPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPassengerPath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbHazard;
        private System.Windows.Forms.CheckBox cbAllData;
        private System.Windows.Forms.CheckBox cbPassenger;
        private System.Windows.Forms.CheckBox cbJourney;
    }
}