using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_game
{
    public partial class Form1 : Form
    {
        SoundPlayer p1Sound = new SoundPlayer("snd/d1.wav");
        SoundPlayer p2Sound = new SoundPlayer("snd/d2.wav");
        SoundPlayer p3Sound = new SoundPlayer("snd/d3.wav");
        SoundPlayer p4Sound = new SoundPlayer("snd/d4.wav");
        SoundPlayer p5Sound = new SoundPlayer("snd/d5.wav");

        int[] numbers = new int[1000];
        bool gameInProgress = false;
        int round = 0;
        int counter = 0;  
        
        public void picturesOff ()
        {
            p1.Enabled = false;
            p2.Enabled = false;
            p3.Enabled = false;
            p4.Enabled = false;
            p5.Enabled = false;
        } 

        public void clickedButtom (int button)
        {
            if (gameInProgress)
            {
                counter++;
                if (numbers[counter - 1] != button)
                {
                    picturesOff();
                    round--;
                    label1.Text = "End game. Your score: " + round.ToString();
                    SoundPlayer endGame = new SoundPlayer("snd/koniec.wav");
                    endGame.Play();
                    gameInProgress = false;
                }

                if (counter == round)
                {
                    label1.Text = "Great!";
                    sequence();
                }
            }
        }

        public void sequence ()
        {
            p1.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p1.bmp");
            p2.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p2.bmp");
            p3.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p3.bmp");
            p4.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p4.bmp");
            p5.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p5.bmp");

            Application.DoEvents();
            Thread.Sleep(1000);

            int secondsToStarts = 1;
            for(int i=secondsToStarts;i>0;i--)
            {
                label1.Text = "Game starts in " + i;
                Application.DoEvents();
                Thread.Sleep(1000);
            }     

            label1.Text = "Remember the sequences";
            Application.DoEvents();
            Thread.Sleep(1000);
            
            round++;
            
            for (int i=0; i<round; i++)
            {
                switch(numbers[i])
                {
                    case 1:
                        {
                            p1Sound.Play();
                            p1a.Visible = true;
                        } break;
                    case 2:
                        {
                            p2Sound.Play();
                            p2a.Visible = true;
                        }
                        break;
                    case 3:
                        {
                            p3Sound.Play();
                            p3a.Visible = true;
                        }
                        break;
                    case 4:
                        {
                            p4Sound.Play();
                            p4a.Visible = true;
                        }
                        break;
                    case 5:
                        {
                            p5Sound.Play();
                            p5a.Visible = true;
                        }
                        break;

                }
                Application.DoEvents();
                Thread.Sleep(1200);
                p1a.Visible = false;
                p2a.Visible = false;
                p3a.Visible = false;
                p4a.Visible = false;
                p5a.Visible = false;
                Application.DoEvents();
                Thread.Sleep(100);
            }
            p1.Enabled = true;
            p2.Enabled = true;
            p3.Enabled = true;
            p4.Enabled = true;
            p5.Enabled = true;
            label1.Text = "Repeat the sequences";
            counter = 0;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void memoryGame_Load(object sender, EventArgs e)
        {
            Random randNum = new Random();
            numbers = Enumerable
                .Repeat(0, 1000)
                .Select(i => randNum.Next(1, 5))
                .ToArray();
        }

        private void label1_Click(object sender, EventArgs e)
        {            
            if(gameInProgress == false)
            {
                picturesOff();
                gameInProgress = true;
                SoundPlayer startSound = new SoundPlayer("snd/start.wav");
                startSound.Play();                
                sequence();                
            }
        }

        private void p1_Click(object sender, EventArgs e)
        {
            clickedButtom(1);
        }

        private void p2_Click(object sender, EventArgs e)
        {
            clickedButtom(2);
        }

        private void p3_Click(object sender, EventArgs e)
        {
            clickedButtom(3);
        }

        private void p4_Click(object sender, EventArgs e)
        {
            clickedButtom(4);
        }

        private void p5_Click(object sender, EventArgs e)
        {
            clickedButtom(5);
        }

        private void p1_MouseDown(object sender, MouseEventArgs e)
        {
            p1.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p1a.bmp");
            p1Sound.Play();         
        }

        private void p1_MouseUp(object sender, MouseEventArgs e)
        {
            p1.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p1.bmp");
        }

        private void p2_MouseDown(object sender, MouseEventArgs e)
        {
            Image image2 = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p2a.bmp");
            p2.Image = image2;
            p2Sound.Play();
        }

        private void p2_MouseUp(object sender, MouseEventArgs e)
        {
            p2.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p2.bmp");
        }

        private void p3_MouseDown(object sender, MouseEventArgs e)
        {
            p3.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p3a.bmp");
            p3Sound.Play();
        }

        private void p3_MouseUp(object sender, MouseEventArgs e)
        {
            p3.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p3.bmp");
        }

        private void p4_MouseDown(object sender, MouseEventArgs e)
        {
            p4.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p4a.bmp");
            p4Sound.Play();
        }

        private void p4_MouseUp(object sender, MouseEventArgs e)
        {
            p4.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p4.bmp");
        }

        private void p5_MouseDown(object sender, MouseEventArgs e)
        {
            p5.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p5a.bmp");
            p5Sound.Play();
        }

        private void p5_MouseUp(object sender, MouseEventArgs e)
        {
            p5.Image = Image.FromFile(@"C:\Users\Dom\Desktop\C# Projekty\Memory game\img\p5.bmp");
        }
    }
}
