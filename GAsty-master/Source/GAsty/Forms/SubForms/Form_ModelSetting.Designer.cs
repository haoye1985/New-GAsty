namespace GAsty.Forms.SubForms
{
    partial class Form_ModelSetting
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
            this.gbNetworkInfo = new System.Windows.Forms.GroupBox();
            this.txtNetworkNum = new System.Windows.Forms.TextBox();
            this.txtHazard = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbelNetwork = new System.Windows.Forms.Label();
            this.txtLinkNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNodeNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbModel = new System.Windows.Forms.GroupBox();
            this.cbIOServiceModel = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbIOModelEnable = new System.Windows.Forms.CheckBox();
            this.lblIOModel = new System.Windows.Forms.Label();
            this.gbParameter = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHazard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbValuSetting = new System.Windows.Forms.GroupBox();
            this.cbMin = new System.Windows.Forms.ComboBox();
            this.cbMax = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbForAij = new System.Windows.Forms.GroupBox();
            this.cbCi = new System.Windows.Forms.ComboBox();
            this.cbAij = new System.Windows.Forms.ComboBox();
            this.lbForCi = new System.Windows.Forms.Label();
            this.lbForAij = new System.Windows.Forms.Label();
            this.btnModelOK = new System.Windows.Forms.Button();
            this.btnModelCancel = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.gbNetworkInfo.SuspendLayout();
            this.gbModel.SuspendLayout();
            this.gbParameter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbValuSetting.SuspendLayout();
            this.gbForAij.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNetworkInfo
            // 
            this.gbNetworkInfo.Controls.Add(this.txtNetworkNum);
            this.gbNetworkInfo.Controls.Add(this.txtHazard);
            this.gbNetworkInfo.Controls.Add(this.label3);
            this.gbNetworkInfo.Controls.Add(this.lbelNetwork);
            this.gbNetworkInfo.Controls.Add(this.txtLinkNum);
            this.gbNetworkInfo.Controls.Add(this.label2);
            this.gbNetworkInfo.Controls.Add(this.txtNodeNum);
            this.gbNetworkInfo.Controls.Add(this.label1);
            this.gbNetworkInfo.Location = new System.Drawing.Point(12, 0);
            this.gbNetworkInfo.Name = "gbNetworkInfo";
            this.gbNetworkInfo.Size = new System.Drawing.Size(352, 108);
            this.gbNetworkInfo.TabIndex = 0;
            this.gbNetworkInfo.TabStop = false;
            this.gbNetworkInfo.Text = "Network Information";
            // 
            // txtNetworkNum
            // 
            this.txtNetworkNum.Location = new System.Drawing.Point(247, 28);
            this.txtNetworkNum.Name = "txtNetworkNum";
            this.txtNetworkNum.ReadOnly = true;
            this.txtNetworkNum.Size = new System.Drawing.Size(87, 20);
            this.txtNetworkNum.TabIndex = 5;
            // 
            // txtHazard
            // 
            this.txtHazard.Location = new System.Drawing.Point(247, 62);
            this.txtHazard.Name = "txtHazard";
            this.txtHazard.ReadOnly = true;
            this.txtHazard.Size = new System.Drawing.Size(87, 20);
            this.txtHazard.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hazard Cells:";
            // 
            // lbelNetwork
            // 
            this.lbelNetwork.AutoSize = true;
            this.lbelNetwork.Location = new System.Drawing.Point(181, 31);
            this.lbelNetwork.Name = "lbelNetwork";
            this.lbelNetwork.Size = new System.Drawing.Size(50, 13);
            this.lbelNetwork.TabIndex = 4;
            this.lbelNetwork.Text = "Network:";
            // 
            // txtLinkNum
            // 
            this.txtLinkNum.Location = new System.Drawing.Point(69, 62);
            this.txtLinkNum.Name = "txtLinkNum";
            this.txtLinkNum.ReadOnly = true;
            this.txtLinkNum.Size = new System.Drawing.Size(87, 20);
            this.txtLinkNum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Links:";
            // 
            // txtNodeNum
            // 
            this.txtNodeNum.Location = new System.Drawing.Point(69, 28);
            this.txtNodeNum.Name = "txtNodeNum";
            this.txtNodeNum.ReadOnly = true;
            this.txtNodeNum.Size = new System.Drawing.Size(87, 20);
            this.txtNodeNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nodes:";
            // 
            // gbModel
            // 
            this.gbModel.Controls.Add(this.cbIOServiceModel);
            this.gbModel.Controls.Add(this.label6);
            this.gbModel.Controls.Add(this.cbIOModelEnable);
            this.gbModel.Controls.Add(this.lblIOModel);
            this.gbModel.Location = new System.Drawing.Point(370, 0);
            this.gbModel.Name = "gbModel";
            this.gbModel.Size = new System.Drawing.Size(323, 108);
            this.gbModel.TabIndex = 1;
            this.gbModel.TabStop = false;
            this.gbModel.Text = "Model Information";
            // 
            // cbIOServiceModel
            // 
            this.cbIOServiceModel.AutoSize = true;
            this.cbIOServiceModel.Checked = true;
            this.cbIOServiceModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIOServiceModel.Location = new System.Drawing.Point(178, 62);
            this.cbIOServiceModel.Name = "cbIOServiceModel";
            this.cbIOServiceModel.Size = new System.Drawing.Size(65, 17);
            this.cbIOServiceModel.TabIndex = 11;
            this.cbIOServiceModel.Text = "Enabled";
            this.cbIOServiceModel.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Static Service Model";
            // 
            // cbIOModelEnable
            // 
            this.cbIOModelEnable.AutoSize = true;
            this.cbIOModelEnable.Checked = true;
            this.cbIOModelEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIOModelEnable.Location = new System.Drawing.Point(178, 30);
            this.cbIOModelEnable.Name = "cbIOModelEnable";
            this.cbIOModelEnable.Size = new System.Drawing.Size(65, 17);
            this.cbIOModelEnable.TabIndex = 9;
            this.cbIOModelEnable.Text = "Enabled";
            this.cbIOModelEnable.UseVisualStyleBackColor = true;
            // 
            // lblIOModel
            // 
            this.lblIOModel.AutoSize = true;
            this.lblIOModel.Location = new System.Drawing.Point(25, 31);
            this.lblIOModel.Name = "lblIOModel";
            this.lblIOModel.Size = new System.Drawing.Size(128, 13);
            this.lblIOModel.TabIndex = 8;
            this.lblIOModel.Text = "Static Input-Output Model";
            // 
            // gbParameter
            // 
            this.gbParameter.Controls.Add(this.groupBox2);
            this.gbParameter.Controls.Add(this.gbValuSetting);
            this.gbParameter.Controls.Add(this.gbForAij);
            this.gbParameter.Location = new System.Drawing.Point(12, 114);
            this.gbParameter.Name = "gbParameter";
            this.gbParameter.Size = new System.Drawing.Size(681, 171);
            this.gbParameter.TabIndex = 2;
            this.gbParameter.TabStop = false;
            this.gbParameter.Text = "Parameter Setting";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHazard);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(453, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 121);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From File";
            // 
            // btnHazard
            // 
            this.btnHazard.Location = new System.Drawing.Point(40, 27);
            this.btnHazard.Name = "btnHazard";
            this.btnHazard.Size = new System.Drawing.Size(121, 23);
            this.btnHazard.TabIndex = 4;
            this.btnHazard.Text = "Hazard File";
            this.btnHazard.UseVisualStyleBackColor = true;
            this.btnHazard.Click += new System.EventHandler(this.btnHazard_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load Matrix File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbValuSetting
            // 
            this.gbValuSetting.Controls.Add(this.cbMin);
            this.gbValuSetting.Controls.Add(this.cbMax);
            this.gbValuSetting.Controls.Add(this.label5);
            this.gbValuSetting.Controls.Add(this.label4);
            this.gbValuSetting.Location = new System.Drawing.Point(279, 33);
            this.gbValuSetting.Name = "gbValuSetting";
            this.gbValuSetting.Size = new System.Drawing.Size(168, 121);
            this.gbValuSetting.TabIndex = 5;
            this.gbValuSetting.TabStop = false;
            this.gbValuSetting.Text = "For Value Range (For Random)";
            // 
            // cbMin
            // 
            this.cbMin.FormattingEnabled = true;
            this.cbMin.Items.AddRange(new object[] {
            "0.5",
            "0.4",
            "0.3",
            "0.2",
            "0.1"});
            this.cbMin.Location = new System.Drawing.Point(88, 79);
            this.cbMin.Name = "cbMin";
            this.cbMin.Size = new System.Drawing.Size(57, 21);
            this.cbMin.TabIndex = 5;
            // 
            // cbMax
            // 
            this.cbMax.FormattingEnabled = true;
            this.cbMax.Items.AddRange(new object[] {
            "1",
            "0.9",
            "0.8",
            "0.7",
            "0.6",
            "0.5"});
            this.cbMax.Location = new System.Drawing.Point(88, 29);
            this.cbMax.Name = "cbMax";
            this.cbMax.Size = new System.Drawing.Size(57, 21);
            this.cbMax.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Minimum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Maximun";
            // 
            // gbForAij
            // 
            this.gbForAij.Controls.Add(this.cbCi);
            this.gbForAij.Controls.Add(this.cbAij);
            this.gbForAij.Controls.Add(this.lbForCi);
            this.gbForAij.Controls.Add(this.lbForAij);
            this.gbForAij.Location = new System.Drawing.Point(12, 33);
            this.gbForAij.Name = "gbForAij";
            this.gbForAij.Size = new System.Drawing.Size(247, 121);
            this.gbForAij.TabIndex = 4;
            this.gbForAij.TabStop = false;
            this.gbForAij.Text = "For Interdependent Matrix";
            // 
            // cbCi
            // 
            this.cbCi.FormattingEnabled = true;
            this.cbCi.Items.AddRange(new object[] {
            "Random Para",
            "Fix Para"});
            this.cbCi.Location = new System.Drawing.Point(98, 79);
            this.cbCi.Name = "cbCi";
            this.cbCi.Size = new System.Drawing.Size(121, 21);
            this.cbCi.TabIndex = 0;
            // 
            // cbAij
            // 
            this.cbAij.FormattingEnabled = true;
            this.cbAij.Items.AddRange(new object[] {
            "Random Para",
            "Fix Para"});
            this.cbAij.Location = new System.Drawing.Point(98, 29);
            this.cbAij.Name = "cbAij";
            this.cbAij.Size = new System.Drawing.Size(121, 21);
            this.cbAij.TabIndex = 0;
            this.cbAij.Tag = "1";
            // 
            // lbForCi
            // 
            this.lbForCi.AutoSize = true;
            this.lbForCi.Location = new System.Drawing.Point(18, 82);
            this.lbForCi.Name = "lbForCi";
            this.lbForCi.Size = new System.Drawing.Size(34, 13);
            this.lbForCi.TabIndex = 1;
            this.lbForCi.Text = "For Ci";
            // 
            // lbForAij
            // 
            this.lbForAij.AutoSize = true;
            this.lbForAij.Location = new System.Drawing.Point(18, 32);
            this.lbForAij.Name = "lbForAij";
            this.lbForAij.Size = new System.Drawing.Size(36, 13);
            this.lbForAij.TabIndex = 1;
            this.lbForAij.Text = "For Aij";
            // 
            // btnModelOK
            // 
            this.btnModelOK.Location = new System.Drawing.Point(160, 310);
            this.btnModelOK.Name = "btnModelOK";
            this.btnModelOK.Size = new System.Drawing.Size(111, 23);
            this.btnModelOK.TabIndex = 4;
            this.btnModelOK.Text = "OK";
            this.btnModelOK.UseVisualStyleBackColor = true;
            this.btnModelOK.Click += new System.EventHandler(this.btnModelOK_Click);
            // 
            // btnModelCancel
            // 
            this.btnModelCancel.Location = new System.Drawing.Point(303, 310);
            this.btnModelCancel.Name = "btnModelCancel";
            this.btnModelCancel.Size = new System.Drawing.Size(111, 23);
            this.btnModelCancel.TabIndex = 5;
            this.btnModelCancel.Text = "Cancel";
            this.btnModelCancel.UseVisualStyleBackColor = true;
            this.btnModelCancel.Click += new System.EventHandler(this.btnModelCancel_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(433, 310);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(111, 23);
            this.btnDefault.TabIndex = 6;
            this.btnDefault.Text = "Default Setting";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // Form_ModelSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 364);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnModelCancel);
            this.Controls.Add(this.btnModelOK);
            this.Controls.Add(this.gbParameter);
            this.Controls.Add(this.gbModel);
            this.Controls.Add(this.gbNetworkInfo);
            this.Name = "Form_ModelSetting";
            this.Text = "Form_ModelSetting";
            this.Load += new System.EventHandler(this.Form_ModelSetting_Load);
            this.gbNetworkInfo.ResumeLayout(false);
            this.gbNetworkInfo.PerformLayout();
            this.gbModel.ResumeLayout(false);
            this.gbModel.PerformLayout();
            this.gbParameter.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbValuSetting.ResumeLayout(false);
            this.gbValuSetting.PerformLayout();
            this.gbForAij.ResumeLayout(false);
            this.gbForAij.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNetworkInfo;
        private System.Windows.Forms.GroupBox gbModel;
        private System.Windows.Forms.GroupBox gbParameter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbValuSetting;
        private System.Windows.Forms.GroupBox gbForAij;
        private System.Windows.Forms.ComboBox cbCi;
        private System.Windows.Forms.ComboBox cbAij;
        private System.Windows.Forms.Label lbForCi;
        private System.Windows.Forms.Label lbForAij;
        private System.Windows.Forms.Button btnModelOK;
        private System.Windows.Forms.Button btnModelCancel;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TextBox txtNetworkNum;
        private System.Windows.Forms.Label lbelNetwork;
        private System.Windows.Forms.TextBox txtLinkNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNodeNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHazard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMin;
        private System.Windows.Forms.ComboBox cbMax;
        private System.Windows.Forms.CheckBox cbIOServiceModel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbIOModelEnable;
        private System.Windows.Forms.Label lblIOModel;
        private System.Windows.Forms.Button btnHazard;
    }
}