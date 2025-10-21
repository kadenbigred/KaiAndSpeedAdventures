using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private int gravityVal = 0;
        int xmove = -10;
        int xbound = Screen.PrimaryScreen.Bounds.Width;
        int ybound = Screen.PrimaryScreen.Bounds.Height;
        string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "kai.png");

        public Form2()
        {
            InitializeComponent();

            //Make window
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(xbound/2, ybound/2);
            this.Height = 300;
            this.Width = 300;
            this.DoubleBuffered = true;

            //Add image
            PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = imgPath;
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1.Size = new Size(300,260);
            this.Controls.Add(pb1);

            //Window title
            this.Text = "Kai and Speed Adventures";

            //Pin window
            this.TopMost = true;

            //Make window bounce around screen
            var moveTimer = new Timer();
            moveTimer.Interval = 15; // 100 ms
            moveTimer.Tick += (s, e) =>
            {
                gravity();
            };
            moveTimer.Start();
        }

        private void gravity()
        {
            gravityVal += 2;
            int gravMax = 30;

            //If it hits the bottom, bounce
            if (this.Location.Y >= ybound - this.Height)
            {
                gravityVal = -gravityVal;
            }

            //Dont let it get above the max height
            if (gravityVal >= gravMax)
            {
                gravityVal = gravMax;
            }
            else if (gravityVal <= -gravMax)
            {
                gravityVal = -gravMax;
            }

            //If it hits the sides of the screen, bounce the other way
            if (this.Location.X + this.Width >= xbound)
            {
                xmove = -xmove;
            }
            else if (this.Location.X <= 0)
            {
                xmove = -xmove;
            }

            //Apply gravity to window location
            this.Location = new Point(this.Location.X + xmove, this.Location.Y + gravityVal);
        }

    }
}
