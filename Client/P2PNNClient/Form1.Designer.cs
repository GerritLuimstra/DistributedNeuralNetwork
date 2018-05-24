namespace P2PNNClient
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.settingsBtn = new System.Windows.Forms.Button();
            this.ConnToServerTXT = new System.Windows.Forms.Label();
            this.tokenCheck = new System.Windows.Forms.Label();
            this.downloadCheckTXT = new System.Windows.Forms.Label();
            this.launchNNTXT = new System.Windows.Forms.Label();
            this.launchDNNBtn = new System.Windows.Forms.Button();
            this.nnProgressTXT = new System.Windows.Forms.Label();
            this.uploadMatricesTXT = new System.Windows.Forms.Label();
            this.uploadStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.debugBtn = new System.Windows.Forms.Button();
            this.EasterEgg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(319, 66);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsBtn.TabIndex = 15;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // ConnToServerTXT
            // 
            this.ConnToServerTXT.AutoSize = true;
            this.ConnToServerTXT.Location = new System.Drawing.Point(16, 20);
            this.ConnToServerTXT.Name = "ConnToServerTXT";
            this.ConnToServerTXT.Size = new System.Drawing.Size(120, 13);
            this.ConnToServerTXT.TabIndex = 17;
            this.ConnToServerTXT.Text = "Connection to server ... ";
            // 
            // tokenCheck
            // 
            this.tokenCheck.AutoSize = true;
            this.tokenCheck.Location = new System.Drawing.Point(16, 43);
            this.tokenCheck.Name = "tokenCheck";
            this.tokenCheck.Size = new System.Drawing.Size(86, 13);
            this.tokenCheck.TabIndex = 18;
            this.tokenCheck.Text = "Token check ... ";
            // 
            // downloadCheckTXT
            // 
            this.downloadCheckTXT.AutoSize = true;
            this.downloadCheckTXT.Location = new System.Drawing.Point(16, 66);
            this.downloadCheckTXT.Name = "downloadCheckTXT";
            this.downloadCheckTXT.Size = new System.Drawing.Size(70, 13);
            this.downloadCheckTXT.TabIndex = 19;
            this.downloadCheckTXT.Text = "Download ... ";
            // 
            // launchNNTXT
            // 
            this.launchNNTXT.AutoSize = true;
            this.launchNNTXT.Location = new System.Drawing.Point(16, 89);
            this.launchNNTXT.Name = "launchNNTXT";
            this.launchNNTXT.Size = new System.Drawing.Size(116, 13);
            this.launchNNTXT.TabIndex = 20;
            this.launchNNTXT.Text = "Launch neural network";
            // 
            // launchDNNBtn
            // 
            this.launchDNNBtn.Location = new System.Drawing.Point(319, 20);
            this.launchDNNBtn.Name = "launchDNNBtn";
            this.launchDNNBtn.Size = new System.Drawing.Size(75, 23);
            this.launchDNNBtn.TabIndex = 21;
            this.launchDNNBtn.Text = "Launch";
            this.launchDNNBtn.UseVisualStyleBackColor = true;
            this.launchDNNBtn.Click += new System.EventHandler(this.launchDNNBtn_Click);
            // 
            // nnProgressTXT
            // 
            this.nnProgressTXT.AutoSize = true;
            this.nnProgressTXT.Location = new System.Drawing.Point(16, 112);
            this.nnProgressTXT.Name = "nnProgressTXT";
            this.nnProgressTXT.Size = new System.Drawing.Size(137, 13);
            this.nnProgressTXT.TabIndex = 22;
            this.nnProgressTXT.Text = "Neural network progress ... ";
            // 
            // uploadMatricesTXT
            // 
            this.uploadMatricesTXT.AutoSize = true;
            this.uploadMatricesTXT.Location = new System.Drawing.Point(16, 135);
            this.uploadMatricesTXT.Name = "uploadMatricesTXT";
            this.uploadMatricesTXT.Size = new System.Drawing.Size(83, 13);
            this.uploadMatricesTXT.TabIndex = 23;
            this.uploadMatricesTXT.Text = "Upload matrices";
            // 
            // uploadStatus
            // 
            this.uploadStatus.AutoSize = true;
            this.uploadStatus.Location = new System.Drawing.Point(16, 158);
            this.uploadStatus.Name = "uploadStatus";
            this.uploadStatus.Size = new System.Drawing.Size(56, 13);
            this.uploadStatus.TabIndex = 25;
            this.uploadStatus.Text = "Upload ... ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(319, 112);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(75, 23);
            this.debugBtn.TabIndex = 26;
            this.debugBtn.Text = "Debug";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Click += new System.EventHandler(this.debugBtn_Click);
            // 
            // EasterEgg
            // 
            this.EasterEgg.AutoSize = true;
            this.EasterEgg.Location = new System.Drawing.Point(346, 167);
            this.EasterEgg.Name = "EasterEgg";
            this.EasterEgg.Size = new System.Drawing.Size(48, 13);
            this.EasterEgg.TabIndex = 27;
            this.EasterEgg.Text = "Ver α1.1";
            this.EasterEgg.DoubleClick += new System.EventHandler(this.EasterEgg_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 189);
            this.Controls.Add(this.EasterEgg);
            this.Controls.Add(this.debugBtn);
            this.Controls.Add(this.uploadStatus);
            this.Controls.Add(this.uploadMatricesTXT);
            this.Controls.Add(this.nnProgressTXT);
            this.Controls.Add(this.launchDNNBtn);
            this.Controls.Add(this.launchNNTXT);
            this.Controls.Add(this.downloadCheckTXT);
            this.Controls.Add(this.tokenCheck);
            this.Controls.Add(this.ConnToServerTXT);
            this.Controls.Add(this.settingsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client app α 1.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Label ConnToServerTXT;
        private System.Windows.Forms.Label tokenCheck;
        private System.Windows.Forms.Label downloadCheckTXT;
        private System.Windows.Forms.Label launchNNTXT;
        private System.Windows.Forms.Button launchDNNBtn;
        private System.Windows.Forms.Label nnProgressTXT;
        private System.Windows.Forms.Label uploadMatricesTXT;
        private System.Windows.Forms.Label uploadStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button debugBtn;
        private System.Windows.Forms.Label EasterEgg;
    }
}

