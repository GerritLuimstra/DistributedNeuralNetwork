namespace P2PNNClient
{
    partial class Form2
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
            this.button2 = new System.Windows.Forms.Button();
            this.downloadLocation = new System.Windows.Forms.Label();
            this.downloadChange = new System.Windows.Forms.Button();
            this.downloadShow = new System.Windows.Forms.Button();
            this.website = new System.Windows.Forms.Label();
            this.token = new System.Windows.Forms.Label();
            this.tokenInput = new System.Windows.Forms.TextBox();
            this.websiteInput = new System.Windows.Forms.TextBox();
            this.debugBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // downloadLocation
            // 
            this.downloadLocation.AutoSize = true;
            this.downloadLocation.Location = new System.Drawing.Point(13, 18);
            this.downloadLocation.Name = "downloadLocation";
            this.downloadLocation.Size = new System.Drawing.Size(95, 13);
            this.downloadLocation.TabIndex = 4;
            this.downloadLocation.Text = "Download location";
            // 
            // downloadChange
            // 
            this.downloadChange.Location = new System.Drawing.Point(114, 13);
            this.downloadChange.Name = "downloadChange";
            this.downloadChange.Size = new System.Drawing.Size(75, 23);
            this.downloadChange.TabIndex = 5;
            this.downloadChange.Text = "Change";
            this.downloadChange.UseVisualStyleBackColor = true;
            this.downloadChange.Click += new System.EventHandler(this.downloadChange_Click);
            // 
            // downloadShow
            // 
            this.downloadShow.Location = new System.Drawing.Point(247, 13);
            this.downloadShow.Name = "downloadShow";
            this.downloadShow.Size = new System.Drawing.Size(75, 23);
            this.downloadShow.TabIndex = 6;
            this.downloadShow.Text = "Show";
            this.downloadShow.UseVisualStyleBackColor = true;
            this.downloadShow.Click += new System.EventHandler(this.downloadShow_Click);
            // 
            // website
            // 
            this.website.AutoSize = true;
            this.website.Location = new System.Drawing.Point(13, 54);
            this.website.Name = "website";
            this.website.Size = new System.Drawing.Size(46, 13);
            this.website.TabIndex = 7;
            this.website.Text = "Website";
            // 
            // token
            // 
            this.token.AutoSize = true;
            this.token.Location = new System.Drawing.Point(13, 88);
            this.token.Name = "token";
            this.token.Size = new System.Drawing.Size(53, 13);
            this.token.TabIndex = 10;
            this.token.Text = "Set token";
            // 
            // tokenInput
            // 
            this.tokenInput.Location = new System.Drawing.Point(114, 87);
            this.tokenInput.Name = "tokenInput";
            this.tokenInput.Size = new System.Drawing.Size(208, 20);
            this.tokenInput.TabIndex = 11;
            // 
            // websiteInput
            // 
            this.websiteInput.Location = new System.Drawing.Point(114, 51);
            this.websiteInput.Name = "websiteInput";
            this.websiteInput.Size = new System.Drawing.Size(208, 20);
            this.websiteInput.TabIndex = 13;
            // 
            // debugBtn
            // 
            this.debugBtn.Location = new System.Drawing.Point(16, 132);
            this.debugBtn.Name = "debugBtn";
            this.debugBtn.Size = new System.Drawing.Size(75, 23);
            this.debugBtn.TabIndex = 14;
            this.debugBtn.Text = "Debug";
            this.debugBtn.UseVisualStyleBackColor = true;
            this.debugBtn.Click += new System.EventHandler(this.debugBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 169);
            this.Controls.Add(this.debugBtn);
            this.Controls.Add(this.websiteInput);
            this.Controls.Add(this.tokenInput);
            this.Controls.Add(this.token);
            this.Controls.Add(this.website);
            this.Controls.Add(this.downloadShow);
            this.Controls.Add(this.downloadChange);
            this.Controls.Add(this.downloadLocation);
            this.Controls.Add(this.button2);
            this.Name = "Form2";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label downloadLocation;
        private System.Windows.Forms.Button downloadChange;
        private System.Windows.Forms.Button downloadShow;
        private System.Windows.Forms.Label website;
        private System.Windows.Forms.Label token;
        private System.Windows.Forms.TextBox tokenInput;
        private System.Windows.Forms.TextBox websiteInput;
        private System.Windows.Forms.Button debugBtn;
    }
}