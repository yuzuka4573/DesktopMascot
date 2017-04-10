namespace Desktop_Mascot
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.終了xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画像変更eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最前面表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.画像追加aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了xToolStripMenuItem,
            this.画像変更eToolStripMenuItem,
            this.最前面表示ToolStripMenuItem,
            this.画像追加aToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 終了xToolStripMenuItem
            // 
            this.終了xToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 終了xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画像変更eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最前面表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 画像追加aToolStripMenuItem;
    }
}

