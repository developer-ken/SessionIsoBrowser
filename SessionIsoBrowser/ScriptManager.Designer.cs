
namespace SessionIsoBrowser
{
    partial class ScriptManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptManager));
            this.noticePad = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userScriptBox = new System.Windows.Forms.RichTextBox();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "打开存储目录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userScriptBox
            // 
            this.userScriptBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userScriptBox.Location = new System.Drawing.Point(4, 34);
            this.userScriptBox.Name = "userScriptBox";
            this.userScriptBox.Size = new System.Drawing.Size(792, 411);
            this.userScriptBox.TabIndex = 3;
            this.userScriptBox.Text = "";
            // 
            // ScriptManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userScriptBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noticePad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScriptManager";
            this.Text = "Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserScriptManager_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noticePad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox userScriptBox;
    }
}