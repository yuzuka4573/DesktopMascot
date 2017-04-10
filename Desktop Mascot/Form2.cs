using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Desktop_Mascot
{

    public partial class Form2 : Form
    {
        public string json;
        public string path;
        public bool imgAct = true;
        public bool setFront = false;
        public int PosX;
        public int PosY;
        public int ID;
        public Form1 form1;
        

        public class jsons
        {
            public bool act { get; set; }　//is img active? T / F
            public bool tMost { get; set; } // is img set front? T / F
            public string location { get; set; } //imgfile Path String
            public int posX { get; set; } //position X int
            public int posY { get; set; }//position Y int
        }



        public Form2()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(this.Form2_MouseMove);
            this.MouseUp += new MouseEventHandler(this.Form2_MouseUp);
            this.MouseDown += new MouseEventHandler(this.Form2_MouseDown);
            this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            this.AllowTransparency = true;
        }

        private Point lastMousePosition;
        private bool mouseCapture;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            //get mouse pos
            this.lastMousePosition = Control.MousePosition;
            this.mouseCapture = true;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseCapture == false)
            {
                return;
            }

            // get latest mouse pos
            Point mp = Control.MousePosition;

            // get difference
            int offsetX = mp.X - this.lastMousePosition.X;
            int offsetY = mp.Y - this.lastMousePosition.Y;

            int posX = this.Left + offsetX;
            int posY = this.Top + offsetY;
            //check position
            posX = checkpos(posX);
            posY = checkpos(posY);
            // move control
            this.Location = new Point(posX, posY);
            this.lastMousePosition = mp;
        }

        private int checkpos(int num)
        {
            if (num < 0) return 0;
            else return num;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Console.WriteLine("new pos X : " + this.Left + " Y : " + this.Top);
            this.mouseCapture = false;
        }

        private void Form2_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.mouseCapture == true && this.Capture == false)
            {
                this.mouseCapture = false;
            }
        }

        //Show image
        public void showimg(string path)
        {
            //clear form border
            this.FormBorderStyle = FormBorderStyle.None;
            //resize form
            size_change(@path);
            //set background image 
            this.BackgroundImage = Image.FromFile(@path);
            this.Location = new Point(PosX, PosY);
            //    Console.WriteLine("form size : " + this.Width + " / " + this.Height);
        }

        public void show(string path)
        {
            //clear form border
            this.FormBorderStyle = FormBorderStyle.None;
            //resize form
            size_change(@path);
            //set background image 
            this.BackgroundImage = Image.FromFile(@path);
        }

        //resize form
        private void size_change(string path)
        {
            //check image size
            System.Drawing.Bitmap bmpSrc = new System.Drawing.Bitmap(@path);
            int width = bmpSrc.Width;
            int height = bmpSrc.Height;
            //    Console.WriteLine("img size : " + width + " / " + height);
            //change form size
            this.Size = new Size(width, height);

        }


        void write_json()
        {

            form1.formdatas[ID, 0] = imgAct.ToString(); //act
            form1.formdatas[ID, 1] = setFront.ToString(); //tMost
            form1.formdatas[ID, 2] = path; //location
            form1.formdatas[ID, 3] = this.Left.ToString(); //posx
            form1.formdatas[ID, 4] = this.Top.ToString(); //posy

            //this function is sending value to form1

        }

        private void 終了xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // kill program
            Environment.Exit(0);
        }

        private void 画像変更eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Dialog open");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "画像ファイル(*.jpg;*.jpeg;*.png;*gif)|*.jpg;*.jpeg;*.png;*gif|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開く画像ファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                Console.WriteLine(ofd.FileName);
                Console.WriteLine("img Refreshed...");
                showimg(path);
            }
        }

        private void 最前面表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (最前面表示ToolStripMenuItem.Checked == true)
            {
                this.TopMost = false;
                setFront = false;
                最前面表示ToolStripMenuItem.Checked = false;
            }
            else if (最前面表示ToolStripMenuItem.Checked == false)
            {
                this.TopMost = true;
                setFront = true;
                最前面表示ToolStripMenuItem.Checked = true;
            }
        }

        private void 画像追加aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Dialog open");
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "画像ファイル(*.jpg;*.jpeg;*.png;*gif)|*.jpg;*.jpeg;*.png;*gif|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開く画像ファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                Console.WriteLine(ofd.FileName);
                Console.WriteLine("img Refreshed...");
                Form2 f = new Form2();
                f.ShowInTaskbar = false;
                f.Show(this);
                f.path = ofd.FileName;
                f.showimg(f.path);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //write some info to json file
            write_json();
        }

        private void 画像削除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //form delete ( Owner is still alive )
            Dispose();
        }
    }
}
