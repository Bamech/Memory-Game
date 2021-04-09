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

        public void sequence ()
        {
            p1.Enabled = false;
            p2.Enabled = false;
            p3.Enabled = false;
            p4.Enabled = false;
            p5.Enabled = false;
            
             
            label1.Text = "Game starts in 3";
            Thread.Sleep(1000);
            label1.Text = "Game starts in 2";
            Thread.Sleep(1000);
            label1.Text = "Game starts in 1";
            Thread.Sleep(1000);

            label1.Text = "Remember the sequences";
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
                Thread.Sleep(1200);
                p1a.Visible = false;
                p2a.Visible = false;
                p3a.Visible = false;
                p4a.Visible = false;
                p5a.Visible = false;
                Thread.Sleep(100);
            }
            p1.Enabled = true;
            p2.Enabled = true;
            p3.Enabled = true;
            p4.Enabled = true;
            p5.Enabled = true;
            label1.Text = "Repeat the sequences";
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
                gameInProgress = true;
                SoundPlayer startSound = new SoundPlayer("snd/start.wav");
                startSound.Play();
                sequence();                             
                label1.Text = "test";
            }
        }
    }
}
