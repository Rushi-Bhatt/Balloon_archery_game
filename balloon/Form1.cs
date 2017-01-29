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
using System.Media;

namespace balloon
{
    public partial class Form1 : Form
    {
        int arrow_alive = 0, allow = 1,arrow=0,score=0;
        public Form1()
        {
            InitializeComponent();
        }
        const string addr = "C:\\Users\\Harshin\\Desktop\\Balloon_game\\";


        SoundPlayer My_JukeBox1 = new SoundPlayer(@"" + addr + "blast.wav");
        SoundPlayer My_JukeBox2 = new SoundPlayer(@"" + addr + "release.wav");

        Thread th1, th2,th3;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            th2 = new Thread(bal_mov);
            th2.IsBackground = true;
            th2.Start();
            

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (arrow_alive == 0)
            {
                My_JukeBox2.Play();
                pictureBox2.Show();
                th1 = new Thread(arrow_mov);
                th1.IsBackground = true;
                th1.Start();
            }
           // My_JukeBox2.Stop();
        }

        void arrow_mov()
        {
            arrow++;
           
            //hide_arrow();
            th3 = new Thread(hide_arrow);
            th3.IsBackground = true;
            th3.Start();
            int i = 750;
            pictureBox2.Invoke(new System.Action(() => pictureBox2.Location = new Point(pictureBox1.Location.X + 50, pictureBox1.Location.Y+75)));
            arrow_alive=1;
            while (i != 0)
            {
                pictureBox2.Invoke(new System.Action(() => pictureBox2.Location = new Point(pictureBox2.Location.X + 1, pictureBox2.Location.Y)));
               // Thread.Sleep(2);
                Application.DoEvents();
                //Thread.Sleep(2);
                i--;          
            }
            arrow_alive = 0;
            allow = 1;
            pictureBox2.Invoke(new System.Action(() => pictureBox2.Location = new Point(pictureBox2.Location.X - 750, pictureBox2.Location.Y)));
            pictureBox2.Invoke(new System.Action(() => pictureBox2.Hide()));
            if (arrow == 20)
            {
                restart();
            }
        }

        void hide_arrow()
        {
            switch (arrow)
            {
                case 1: pictureBox6.Invoke(new System.Action(() => pictureBox6.Hide()));
                    break;

                case 2: pictureBox7.Invoke(new System.Action(() => pictureBox7.Hide()));
                    break;

                case 3: pictureBox8.Invoke(new System.Action(() => pictureBox8.Hide()));
                    break;

                case 4: pictureBox9.Invoke(new System.Action(() => pictureBox9.Hide()));
                    break;

                case 5: pictureBox10.Invoke(new System.Action(() => pictureBox10.Hide()));
                    break;

                case 6: pictureBox11.Invoke(new System.Action(() => pictureBox11.Hide()));
                    break;

                case 7: pictureBox12.Invoke(new System.Action(() => pictureBox12.Hide()));
                    break;

                case 8: pictureBox13.Invoke(new System.Action(() => pictureBox13.Hide()));
                    break;

                case 9: pictureBox14.Invoke(new System.Action(() => pictureBox14.Hide()));
                    break;

                case 10: pictureBox15.Invoke(new System.Action(() => pictureBox15.Hide()));
                    break;

                case 11: pictureBox16.Invoke(new System.Action(() => pictureBox16.Hide()));
                    break;

                case 12: pictureBox17.Invoke(new System.Action(() => pictureBox17.Hide()));
                    break;

                case 13: pictureBox18.Invoke(new System.Action(() => pictureBox18.Hide()));
                    break;

                case 14: pictureBox19.Invoke(new System.Action(() => pictureBox19.Hide()));
                    break;

                case 15: pictureBox20.Invoke(new System.Action(() => pictureBox20.Hide()));
                    break;

                case 16: pictureBox21.Invoke(new System.Action(() => pictureBox21.Hide()));
                    break;

                case 17: pictureBox22.Invoke(new System.Action(() => pictureBox22.Hide()));
                    break;

                case 18: pictureBox23.Invoke(new System.Action(() => pictureBox23.Hide()));
                    break;

                case 19: pictureBox24.Invoke(new System.Action(() => pictureBox24.Hide()));
                    break;

                case 20: pictureBox25.Invoke(new System.Action(() => pictureBox25.Hide()));
                  
                    break;
            }
        }

        void restart()
        {
            Application.Restart();
        }

        void bal_mov()
        {
            int i = 600;
            while (true)
            {
                pictureBox3.Invoke(new System.Action(() =>pictureBox3.Show()));
                pictureBox5.Invoke(new System.Action(() =>pictureBox5.Hide()));

                pictureBox3.Invoke(new System.Action(() => pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 1)));
                i--;

                Application.DoEvents();
                Thread.Sleep(10);
                if(pictureBox2.Location.X + 100 >= pictureBox3.Location.X && pictureBox2.Location.Y<pictureBox3.Location.Y && allow==1)
                {
                    allow=0;
                }

                if (allow == 1 && (pictureBox2.Location.X + 118) >= pictureBox3.Location.X && pictureBox2.Location.Y >= pictureBox3.Location.Y && pictureBox2.Location.Y <= pictureBox3.Location.Y + 50)
                {
                    My_JukeBox1.Play();
                    score++;
                   // MessageBox.Show(""+score);
                  
                    label2.Invoke(new System.Action(() => label2.Text = score.ToString()));
                    
                    pictureBox5.Invoke(new System.Action(() => pictureBox5.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y)));
                    pictureBox3.Invoke(new System.Action(() => pictureBox3.Hide()));
                    pictureBox5.Invoke(new System.Action(() => pictureBox5.Show()));
                    Thread.Sleep(350);
                    pictureBox3.Invoke(new System.Action(() => pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + (600 - i))));
                    i = 600;
                }

                else if (i == 0)// || (allow==1 && (pictureBox2.Location.X + 118) >= pictureBox3.Location.X && pictureBox2.Location.Y >= pictureBox3.Location.Y && pictureBox2.Location.Y <= pictureBox3.Location.Y + 100)) 
                {
                    pictureBox3.Invoke(new System.Action(() => pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + (600-i))));
                    i = 600;
                }
               

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && pictureBox1.Location.Y < 382)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 10);
            }

            if (e.KeyCode == Keys.Up && pictureBox1.Location.Y > 10)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 10);
            }
        }

        
    }
}
