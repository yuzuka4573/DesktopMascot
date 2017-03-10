using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Mascot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(this.Form1_MouseUp);
            this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);

            this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            this.AllowTransparency = true;
        }

        private Point lastMousePosition;
        private bool mouseCapture;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            //マウスの位置を所得
            this.lastMousePosition = Control.MousePosition;
            this.mouseCapture = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseCapture == false)
            {
                return;
            }

            // 最新のマウスの位置を取得
            Point mp = Control.MousePosition;

            // 差分を取得
            int offsetX = mp.X - this.lastMousePosition.X;
            int offsetY = mp.Y - this.lastMousePosition.Y;

            // コントロールを移動
            this.Location = new Point(this.Left + offsetX, this.Top + offsetY);

            this.lastMousePosition = mp;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            this.mouseCapture = false;
        }

        private void Form1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.mouseCapture == true && this.Capture == false)
            {
                this.mouseCapture = false;
            }
        }

        //画像を表示する
        private void show(string path)
        {
            //フォームの境界線をなくす
            this.FormBorderStyle = FormBorderStyle.None;
            //フォームのサイズ変更
            size_change(@path);
            //背景画像を指定する
            this.BackgroundImage = Image.FromFile(@path);
            //黒色の部分を透明化する
            //  this.TransparencyKey = Color.Black;
        }

        //ウィンドウの大きさを画像の大きさに変更
        private void size_change(string path)
        {
            //元画像の縦横サイズを調べる
            System.Drawing.Bitmap bmpSrc = new System.Drawing.Bitmap(@path);
            int width = bmpSrc.Width;
            int height = bmpSrc.Height;
            //ウィンドウのサイズを変更
            this.Size = new Size(width, height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"miniI.png"; //画像のパス
            show(path);
        }
    }
}
