
namespace SessionIsoBrowser
{
    partial class BrowserWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserWindow));
            this.url = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.browserLayoutPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // url
            // 
            this.url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.url.Location = new System.Drawing.Point(3, 12);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(659, 25);
            this.url.TabIndex = 0;
            this.url.KeyUp += new System.Windows.Forms.KeyEventHandler(this.url_KeyUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(668, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "设为默认并转到";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // browserLayoutPanel
            // 
            this.browserLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserLayoutPanel.Location = new System.Drawing.Point(3, 41);
            this.browserLayoutPanel.Name = "browserLayoutPanel";
            this.browserLayoutPanel.Size = new System.Drawing.Size(799, 406);
            this.browserLayoutPanel.TabIndex = 2;
            this.browserLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.browserLayoutPanel_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(-6, -6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 10);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BrowserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.browserLayoutPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.url);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserWindow";
            this.Text = "BrowserWindow";
            this.Load += new System.EventHandler(this.BrowserWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel browserLayoutPanel;
        private System.Windows.Forms.Button button2;
    }
}