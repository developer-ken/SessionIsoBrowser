
namespace SessionIsoBrowser
{
    partial class ExtentionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtentionManager));
            this.noticePad = new System.Windows.Forms.Label();
            this.userScriptBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // noticePad
            // 
            this.noticePad.AutoSize = true;
            this.noticePad.Location = new System.Drawing.Point(12, 9);
            this.noticePad.Name = "noticePad";
            this.noticePad.Size = new System.Drawing.Size(219, 15);
            this.noticePad.TabIndex = 0;
            this.noticePad.Text = "* 正在编辑 全局 用户脚本设置";
            // 
            // userScriptBox
            // 
            this.userScriptBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userScriptBox.Location = new System.Drawing.Point(12, 38);
            this.userScriptBox.Multiline = true;
            this.userScriptBox.Name = "userScriptBox";
            this.userScriptBox.Size = new System.Drawing.Size(776, 400);
            this.userScriptBox.TabIndex = 1;
            // 
            // ExtentionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userScriptBox);
            this.Controls.Add(this.noticePad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtentionManager";
            this.Text = "Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserScriptManager_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noticePad;
        private System.Windows.Forms.TextBox userScriptBox;
    }
}