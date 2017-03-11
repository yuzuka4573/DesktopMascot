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
    public partial class Form1 : Form
    {
        public string json;
        public string path;
        public bool imgAct = true;
        public bool setFront = false;
        // set json settings
        public class jsons
        {
            public bool act { get; set; }　//is img active? T / F
            public bool tMost { get; set; } // is img set front? T / F
            public string location { get; set; } //imgfile Path String
            public int posX { get; set; } //position X int
            public int posY { get; set; }//position Y int
        }

        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new MouseEventHandler(this.Form1_MouseUp);
            this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);
            this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            this.AllowTransparency = true;
            // first process


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

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            Console.WriteLine("new pos X : " + this.Left + " Y : " + this.Top);
            this.mouseCapture = false;
        }

        private void Form1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (this.mouseCapture == true && this.Capture == false)
            {
                this.mouseCapture = false;
            }
        }

        //Show image
        private void show(string path)
        {
            //clear form border
            this.FormBorderStyle = FormBorderStyle.None;
            //resize form
            size_change(@path);
            //set background image 
            this.BackgroundImage = Image.FromFile(@path);
            // Console.WriteLine("form size : " + this.Width + " / " + this.Height);
        }

        private void showchild(string path,int posx,int posy)
        {
            Form2 f = new Form2();
            f.ShowInTaskbar = false;
            f.Show(this);
            f.path = path;
            f.PosX = posx;
            f.PosY = posy;
            f.showimg(f.path);
            //clear form border
            f.FormBorderStyle = FormBorderStyle.None;

        }


        //resize form
        private void size_change(string path)
        {
            //check image size
            System.Drawing.Bitmap bmpSrc = new System.Drawing.Bitmap(@path);
            int width = bmpSrc.Width;
            int height = bmpSrc.Height;
            // Console.WriteLine("img size : " + width + " / " + height);
            //change form size
            this.Size = new Size(width, height);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            path = @"miniI.png"; //default image path


            //check files
            if (!File.Exists(@"config.json"))
            {
                //not exist
                Console.WriteLine("config.json is not exist!!");
                show(path);
            }
            else
            {
                //exist -> reading
                Console.WriteLine("config.json is exist!!");
                read_json(@"config.json");

            }
        }


        void read_json(string json_path)
        {
            bool lst = true; //check 1st img or not
            //read json file as string
            var text = File.ReadAllText(json_path);
            //collect data in "ByJson"
            var ByJson = JsonConvert.DeserializeObject<List<jsons>>(text);
            //show all
            foreach (var task in ByJson)
            {
                //1st img only
                if (lst == true)
                {
                    show(task.location);
                    lst = false;
                }
                else
                {
                    showchild(task.location,task.posX,task.posY);

                }
            }


        }

        void write_json()
        {
            List<jsons> _data = new List<jsons>();

            _data.Add(new jsons()
            {
                act = imgAct,
                tMost = setFront,
                location = path,
                posX = this.Left,
                posY = this.Top
            });
            string json = JsonConvert.SerializeObject(_data.ToArray());

            //write string to file
            File.WriteAllText(@"config.json", json);
        }

        private void 終了xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //write some info to json file
            write_json();
            //stop
            Environment.Exit(0);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

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
                show(path);
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
    }
}
