
namespace SessionIsoBrowser
{
    partial class SessionManager
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionManager));
            this.listOfContainer = new System.Windows.Forms.ListView();
            this.ContainerItemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新窗口OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.会话下的窗口WindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示所有ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏所有HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除会话DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.脚本ScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全局用户脚本UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏所有会话窗口HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示所有隐藏的窗口ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.okbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.coName = new System.Windows.Forms.TextBox();
            this.打开插件目录ExtentionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.调试模式打开窗口DebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContainerItemMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listOfContainer
            // 
            this.listOfContainer.ContextMenuStrip = this.ContainerItemMenu;
            this.listOfContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listOfContainer.HideSelection = false;
            this.listOfContainer.Location = new System.Drawing.Point(3, 21);
            this.listOfContainer.Name = "listOfContainer";
            this.listOfContainer.Size = new System.Drawing.Size(770, 326);
            this.listOfContainer.TabIndex = 0;
            this.listOfContainer.UseCompatibleStateImageBehavior = false;
            this.listOfContainer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listOfContainer_MouseDoubleClick);
            // 
            // ContainerItemMenu
            // 
            this.ContainerItemMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContainerItemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sToolStripMenuItem,
            this.全局用户脚本UToolStripMenuItem,
            this.隐藏所有会话窗口HideToolStripMenuItem,
            this.显示所有隐藏的窗口ShowToolStripMenuItem});
            this.ContainerItemMenu.Name = "ContainerItemMenu";
            this.ContainerItemMenu.Size = new System.Drawing.Size(264, 128);
            this.ContainerItemMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContainerItemMenu_Opening);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新窗口OToolStripMenuItem,
            this.会话下的窗口WindowsToolStripMenuItem,
            this.删除会话DeleteToolStripMenuItem,
            this.脚本ScriptToolStripMenuItem,
            this.调试模式打开窗口DebugToolStripMenuItem});
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.sToolStripMenuItem.Text = ">>>>>>>>>(&S)";
            // 
            // 新窗口OToolStripMenuItem
            // 
            this.新窗口OToolStripMenuItem.Name = "新窗口OToolStripMenuItem";
            this.新窗口OToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.新窗口OToolStripMenuItem.Text = "新窗口(&Open)";
            this.新窗口OToolStripMenuItem.Click += new System.EventHandler(this.新窗口OToolStripMenuItem_Click);
            // 
            // 会话下的窗口WindowsToolStripMenuItem
            // 
            this.会话下的窗口WindowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示所有ShowToolStripMenuItem,
            this.隐藏所有HideToolStripMenuItem,
            this.关闭所有CloseToolStripMenuItem});
            this.会话下的窗口WindowsToolStripMenuItem.Name = "会话下的窗口WindowsToolStripMenuItem";
            this.会话下的窗口WindowsToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.会话下的窗口WindowsToolStripMenuItem.Text = "会话下的窗口(&Windows)";
            // 
            // 显示所有ShowToolStripMenuItem
            // 
            this.显示所有ShowToolStripMenuItem.Name = "显示所有ShowToolStripMenuItem";
            this.显示所有ShowToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.显示所有ShowToolStripMenuItem.Text = "显示所有(&Show)";
            this.显示所有ShowToolStripMenuItem.Click += new System.EventHandler(this.显示所有ShowToolStripMenuItem_Click);
            // 
            // 隐藏所有HideToolStripMenuItem
            // 
            this.隐藏所有HideToolStripMenuItem.Name = "隐藏所有HideToolStripMenuItem";
            this.隐藏所有HideToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.隐藏所有HideToolStripMenuItem.Text = "隐藏所有(&Hide)";
            this.隐藏所有HideToolStripMenuItem.Click += new System.EventHandler(this.隐藏所有HideToolStripMenuItem_Click);
            // 
            // 关闭所有CloseToolStripMenuItem
            // 
            this.关闭所有CloseToolStripMenuItem.Name = "关闭所有CloseToolStripMenuItem";
            this.关闭所有CloseToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.关闭所有CloseToolStripMenuItem.Text = "关闭所有(&Close)";
            this.关闭所有CloseToolStripMenuItem.Click += new System.EventHandler(this.关闭所有CloseToolStripMenuItem_Click);
            // 
            // 删除会话DeleteToolStripMenuItem
            // 
            this.删除会话DeleteToolStripMenuItem.Name = "删除会话DeleteToolStripMenuItem";
            this.删除会话DeleteToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.删除会话DeleteToolStripMenuItem.Text = "删除会话(&Delete)";
            this.删除会话DeleteToolStripMenuItem.Click += new System.EventHandler(this.删除会话DeleteToolStripMenuItem_Click);
            // 
            // 脚本ScriptToolStripMenuItem
            // 
            this.脚本ScriptToolStripMenuItem.Name = "脚本ScriptToolStripMenuItem";
            this.脚本ScriptToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.脚本ScriptToolStripMenuItem.Text = "脚本(&Script)";
            this.脚本ScriptToolStripMenuItem.Click += new System.EventHandler(this.用户脚本UserScriptToolStripMenuItem_Click);
            // 
            // 全局用户脚本UToolStripMenuItem
            // 
            this.全局用户脚本UToolStripMenuItem.Name = "全局用户脚本UToolStripMenuItem";
            this.全局用户脚本UToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.全局用户脚本UToolStripMenuItem.Text = "全局脚本(&U)";
            this.全局用户脚本UToolStripMenuItem.Click += new System.EventHandler(this.全局用户脚本UToolStripMenuItem_Click);
            // 
            // 隐藏所有会话窗口HideToolStripMenuItem
            // 
            this.隐藏所有会话窗口HideToolStripMenuItem.Name = "隐藏所有会话窗口HideToolStripMenuItem";
            this.隐藏所有会话窗口HideToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.隐藏所有会话窗口HideToolStripMenuItem.Text = "隐藏所有会话窗口(&Hide)";
            this.隐藏所有会话窗口HideToolStripMenuItem.Click += new System.EventHandler(this.隐藏所有会话窗口HideToolStripMenuItem_Click);
            // 
            // 显示所有隐藏的窗口ShowToolStripMenuItem
            // 
            this.显示所有隐藏的窗口ShowToolStripMenuItem.Name = "显示所有隐藏的窗口ShowToolStripMenuItem";
            this.显示所有隐藏的窗口ShowToolStripMenuItem.Size = new System.Drawing.Size(263, 24);
            this.显示所有隐藏的窗口ShowToolStripMenuItem.Text = "显示所有隐藏的窗口(&Show)";
            this.显示所有隐藏的窗口ShowToolStripMenuItem.Click += new System.EventHandler(this.显示所有隐藏的窗口ShowToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listOfContainer);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cookies 容器";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.okbutton);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.coName);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "新建 Cookies 容器";
            // 
            // okbutton
            // 
            this.okbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okbutton.Location = new System.Drawing.Point(345, 30);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(75, 23);
            this.okbutton.TabIndex = 2;
            this.okbutton.Text = "建立";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "容器名称";
            // 
            // coName
            // 
            this.coName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coName.Location = new System.Drawing.Point(84, 31);
            this.coName.Name = "coName";
            this.coName.Size = new System.Drawing.Size(255, 25);
            this.coName.TabIndex = 0;
            this.coName.Text = "-=三 The Cookie Container 三=-";
            // 
            // 打开插件目录ExtentionsToolStripMenuItem
            // 
            this.打开插件目录ExtentionsToolStripMenuItem.Name = "打开插件目录ExtentionsToolStripMenuItem";
            this.打开插件目录ExtentionsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.打开插件目录ExtentionsToolStripMenuItem.Text = "打开插件目录(&Extentions)";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(453, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(332, 70);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "安全警示：脚本与Userscript(例如油猴加载的脚本)不完全相同，需要兼容层来运行。兼容层未实现安全模型，可能被恶意页面利用来提权。请仅使用可信的脚本、仅访问" +
    "可信的页面。";
            // 
            // 调试模式打开窗口DebugToolStripMenuItem
            // 
            this.调试模式打开窗口DebugToolStripMenuItem.Name = "调试模式打开窗口DebugToolStripMenuItem";
            this.调试模式打开窗口DebugToolStripMenuItem.Size = new System.Drawing.Size(271, 26);
            this.调试模式打开窗口DebugToolStripMenuItem.Text = "调试模式打开窗口(&Debug)";
            this.调试模式打开窗口DebugToolStripMenuItem.Click += new System.EventHandler(this.调试模式打开窗口DebugToolStripMenuItem_Click);
            // 
            // SessionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SessionManager";
            this.Text = "多会话隔离浏览器 - 会话管理";
            this.Load += new System.EventHandler(this.SessionManager_Load);
            this.ContainerItemMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listOfContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox coName;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.ContextMenuStrip ContainerItemMenu;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新窗口OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 会话下的窗口WindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示所有ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除会话DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开插件目录ExtentionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全局用户脚本UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 脚本ScriptToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem 隐藏所有HideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏所有会话窗口HideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示所有隐藏的窗口ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调试模式打开窗口DebugToolStripMenuItem;
    }
}

