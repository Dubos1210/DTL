using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace dtl
{
    public partial class Form1 : Form
    {

        public Bitmap image;
        public string path = "0.wav";
        void play()
        {
            //SoundPlayer Sound = new SoundPlayer(Application.StartupPath +@"\"+path);

            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = Application.StartupPath + @"\" + path;
            try
            {
                //Sound.Play();
                player.Play();
            }
            catch (System.IO.FileNotFoundException ex)
            {
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = e.KeyChar.ToString();
            path = e.KeyChar.ToString() + ".wav";
            pictureBox1.Visible = true;
            try
            {
                pictureBox1.Image = image;
                image = new Bitmap(e.KeyChar.ToString() + ".png", true);
                pictureBox1.Image = image;
            }
            catch (System.ArgumentException ex)
            {
                label1.Text = "Error";
                pictureBox1.Visible = false;
            }

            Thread thr = new Thread(play);
            thr.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            label1.Text = "No Key";
            pictureBox1.Visible = false;
        }
    }
}
