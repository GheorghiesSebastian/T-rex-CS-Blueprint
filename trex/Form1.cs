using System.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Input;

namespace trex
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int count = 0;
        int ti1 = 0;
        int jumpCount;
        int jumpLimit = 10;
        int countTimer2 = 0;
        bool TriggerFall = false;
        int Start;


        Random respawn = new Random();

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            ++count;
            if (count % 100 == 0)
            {
                ++ti1;
                textBox1.Text = "Score : " + ti1;
            }
            Obstacle.Location = new Point(Obstacle.Location.X - 2, Obstacle.Location.Y);
            if (Obstacle.Location.X - 2 <= 0)
            {
                Obstacle.Location = new Point(respawn.Next(1300, 1600), Obstacle.Location.Y);
            }

        }
        private void Jump(object sender, EventArgs e)
        {
            

        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        public async void keyup(object sender, KeyEventArgs e)
        {
            while (pictureBox2.Location.Y > 230)
            {
                await Task.Delay(10);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 3);
            }
            while (pictureBox2.Location.Y < 405)
            {
                await Task.Delay(10);
                pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 3);
            }
        }
        private async Task Wait()
        {
            await Task.Delay(100);
        }
    }
}
