namespace P2PNNClient
{
    partial class Debug
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
            this.ShowDloadLocationBtn = new System.Windows.Forms.Button();
            this.WebsiteBtn = new System.Windows.Forms.Button();
            this.TokenBtn = new System.Windows.Forms.Button();
            this.RawJsonBtn = new System.Windows.Forms.Button();
            this.OpenDloadLocationBtn = new System.Windows.Forms.Button();
            this.TestErrorBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowDloadLocationBtn
            // 
            this.ShowDloadLocationBtn.Location = new System.Drawing.Point(13, 11);
            this.ShowDloadLocationBtn.Name = "ShowDloadLocationBtn";
            this.ShowDloadLocationBtn.Size = new System.Drawing.Size(123, 23);
            this.ShowDloadLocationBtn.TabIndex = 0;
            this.ShowDloadLocationBtn.Text = "Show Dload Location";
            this.ShowDloadLocationBtn.UseVisualStyleBackColor = true;
            this.ShowDloadLocationBtn.Click += new System.EventHandler(this.ShowDloadLocationBtn_Click);
            // 
            // WebsiteBtn
            // 
            this.WebsiteBtn.Location = new System.Drawing.Point(142, 11);
            this.WebsiteBtn.Name = "WebsiteBtn";
            this.WebsiteBtn.Size = new System.Drawing.Size(75, 23);
            this.WebsiteBtn.TabIndex = 1;
            this.WebsiteBtn.Text = "Website";
            this.WebsiteBtn.UseVisualStyleBackColor = true;
            this.WebsiteBtn.Click += new System.EventHandler(this.WebsiteBtn_Click);
            // 
            // TokenBtn
            // 
            this.TokenBtn.Location = new System.Drawing.Point(223, 11);
            this.TokenBtn.Name = "TokenBtn";
            this.TokenBtn.Size = new System.Drawing.Size(75, 23);
            this.TokenBtn.TabIndex = 2;
            this.TokenBtn.Text = "Token";
            this.TokenBtn.UseVisualStyleBackColor = true;
            this.TokenBtn.Click += new System.EventHandler(this.TokenBtn_Click);
            // 
            // RawJsonBtn
            // 
            this.RawJsonBtn.Location = new System.Drawing.Point(223, 42);
            this.RawJsonBtn.Name = "RawJsonBtn";
            this.RawJsonBtn.Size = new System.Drawing.Size(75, 23);
            this.RawJsonBtn.TabIndex = 3;
            this.RawJsonBtn.Text = "Raw Json";
            this.RawJsonBtn.UseVisualStyleBackColor = true;
            this.RawJsonBtn.Click += new System.EventHandler(this.RawJsonBtn_Click);
            // 
            // OpenDloadLocationBtn
            // 
            this.OpenDloadLocationBtn.Location = new System.Drawing.Point(13, 42);
            this.OpenDloadLocationBtn.Name = "OpenDloadLocationBtn";
            this.OpenDloadLocationBtn.Size = new System.Drawing.Size(123, 23);
            this.OpenDloadLocationBtn.TabIndex = 4;
            this.OpenDloadLocationBtn.Text = "Open Dload Location";
            this.OpenDloadLocationBtn.UseVisualStyleBackColor = true;
            this.OpenDloadLocationBtn.Click += new System.EventHandler(this.OpenDloadLocationBtn_Click);
            // 
            // TestErrorBtn
            // 
            this.TestErrorBtn.Location = new System.Drawing.Point(142, 42);
            this.TestErrorBtn.Name = "TestErrorBtn";
            this.TestErrorBtn.Size = new System.Drawing.Size(75, 23);
            this.TestErrorBtn.TabIndex = 5;
            this.TestErrorBtn.Text = "Test Error";
            this.TestErrorBtn.UseVisualStyleBackColor = true;
            this.TestErrorBtn.Click += new System.EventHandler(this.TestErrorBtn_Click);
            // 
            // Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 77);
            this.Controls.Add(this.TestErrorBtn);
            this.Controls.Add(this.OpenDloadLocationBtn);
            this.Controls.Add(this.RawJsonBtn);
            this.Controls.Add(this.TokenBtn);
            this.Controls.Add(this.WebsiteBtn);
            this.Controls.Add(this.ShowDloadLocationBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Debug";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Debug";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowDloadLocationBtn;
        private System.Windows.Forms.Button WebsiteBtn;
        private System.Windows.Forms.Button TokenBtn;
        private System.Windows.Forms.Button RawJsonBtn;
        private System.Windows.Forms.Button OpenDloadLocationBtn;
        private System.Windows.Forms.Button TestErrorBtn;
    }
}