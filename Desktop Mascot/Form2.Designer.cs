namespace Desktop_Mascot
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.終了xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画像変更eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最前面表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画像追加aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画像削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了xToolStripMenuItem,
            this.画像削除ToolStripMenuItem,
            this.画像変更eToolStripMenuItem,
            this.最前面表示ToolStripMenuItem,
            this.画像追加aToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 136);
            // 
            // 終了xToolStripMenuItem
            // 
            this.終了xToolStripMenuItem.Name = "終了xToolStripMenuItem";
            this.終了xToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.終了xToolStripMenuItem.Text = "終了&x";
            this.終了xToolStripMenuItem.Click += new System.EventHandler(this.終了xToolStripMenuItem_Click);
            // 
            // 画像変更eToolStripMenuItem
            // 
            this.画像変更eToolStripMenuItem.Name = "画像変更eToolStripMenuItem";
            this.画像変更eToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.画像変更eToolStripMenuItem.Text = "画像変更&e";
            this.画像変更eToolStripMenuItem.Click += new System.EventHandler(this.画像変更eToolStripMenuItem_Click);
            // 
            // 最前面表示ToolStripMenuItem
            // 
            this.最前面表示ToolStripMenuItem.Name = "最前面表示ToolStripMenuItem";
            this.最前面表示ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.最前面表示ToolStripMenuItem.Text = "最前面表示";
            this.最前面表示ToolStripMenuItem.Click += new System.EventHandler(this.最前面表示ToolStripMenuItem_Click);
            // 
            // 画像追加aToolStripMenuItem
            // 
            this.画像追加aToolStripMenuItem.Name = "画像追加aToolStripMenuItem";
            this.画像追加aToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.画像追加aToolStripMenuItem.Text = "画像追加&a";
            this.画像追加aToolStripMenuItem.Click += new System.EventHandler(this.画像追加aToolStripMenuItem_Click);
            // 
            // 画像削除ToolStripMenuItem
            // 
            this.画像削除ToolStripMenuItem.Name = "画像削除ToolStripMenuItem";
            this.画像削除ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.画像削除ToolStripMenuItem.Text = "画像削除";
            this.画像削除ToolStripMenuItem.Click += new System.EventHandler(this.画像削除ToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 終了xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画像変更eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最前面表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画像追加aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画像削除ToolStripMenuItem;
    }
}