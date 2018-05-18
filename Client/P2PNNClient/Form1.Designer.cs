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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.ConnToServerTXT = new System.Windows.Forms.Label();
            this.tokenCheck = new System.Windows.Forms.Label();
            this.downloadCheck = new System.Windows.Forms.Label();
            this.launchNNTXT = new System.Windows.Forms.Label();
            this.launchNN = new System.Windows.Forms.Button();
            this.nnProgressTXT = new System.Windows.Forms.Label();
            this.uploadMatricesTXT = new System.Windows.Forms.Label();
            this.uploadMatrices = new System.Windows.Forms.Button();
            this.uploadStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(486, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "217.122.28.164";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input IP here:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ping";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection was ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "NOT CONNECTED";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(670, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Automatic connection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(673, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "TEST";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(489, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Raw token";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(783, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(783, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(783, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "label9";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(783, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Download dataset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(783, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(783, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "label11";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(706, 415);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsBtn.TabIndex = 15;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(486, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "label12";
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
            // downloadCheck
            // 
            this.downloadCheck.AutoSize = true;
            this.downloadCheck.Location = new System.Drawing.Point(16, 66);
            this.downloadCheck.Name = "downloadCheck";
            this.downloadCheck.Size = new System.Drawing.Size(70, 13);
            this.downloadCheck.TabIndex = 19;
            this.downloadCheck.Text = "Download ... ";
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
            // launchNN
            // 
            this.launchNN.Location = new System.Drawing.Point(176, 84);
            this.launchNN.Name = "launchNN";
            this.launchNN.Size = new System.Drawing.Size(75, 23);
            this.launchNN.TabIndex = 21;
            this.launchNN.Text = "Launch";
            this.launchNN.UseVisualStyleBackColor = true;
            this.launchNN.Click += new System.EventHandler(this.launchNN_Click);
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
            // uploadMatrices
            // 
            this.uploadMatrices.Location = new System.Drawing.Point(176, 130);
            this.uploadMatrices.Name = "uploadMatrices";
            this.uploadMatrices.Size = new System.Drawing.Size(75, 23);
            this.uploadMatrices.TabIndex = 24;
            this.uploadMatrices.Text = "Upload";
            this.uploadMatrices.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 450);
            this.Controls.Add(this.uploadStatus);
            this.Controls.Add(this.uploadMatrices);
            this.Controls.Add(this.uploadMatricesTXT);
            this.Controls.Add(this.nnProgressTXT);
            this.Controls.Add(this.launchNN);
            this.Controls.Add(this.launchNNTXT);
            this.Controls.Add(this.downloadCheck);
            this.Controls.Add(this.tokenCheck);
            this.Controls.Add(this.ConnToServerTXT);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client app α 0.10";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button settingsBtn;
        public System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label ConnToServerTXT;
        private System.Windows.Forms.Label tokenCheck;
        private System.Windows.Forms.Label downloadCheck;
        private System.Windows.Forms.Label launchNNTXT;
        private System.Windows.Forms.Button launchNN;
        private System.Windows.Forms.Label nnProgressTXT;
        private System.Windows.Forms.Label uploadMatricesTXT;
        private System.Windows.Forms.Button uploadMatrices;
        private System.Windows.Forms.Label uploadStatus;
        private System.Windows.Forms.Timer timer1;
    }
}

