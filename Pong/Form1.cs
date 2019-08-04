using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        bool playerup;
        bool playerdown;
        int speed = 5;
        int ballx = 5;
        int bally = 5;
        int score = 0;
        int cpuPoint = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                playerdown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                playerdown = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                playerdown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                playerup = false;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            playerScore.Text = " " + score;
            cpuLabel.Text = " " + cpuPoint;

            ball.Top -= bally;
            ball.Left -= ballx;

            cpu.Top += speed;

            if (score < 5)
            {
                if (cpu.Top < 0|| cpu.Top > 455)
                {
                    speed = -speed;
                }
            }
            else
            {
                cpu.Top = ball.Top + 30;
            }

            if (ball.Left < 0)
            {
                ball.Left = 434; 
                ballx = -ballx; 
                ballx -= 2; 
                cpuPoint++; 
            }

            if (ball.Left + ball.Width > ClientSize.Width)
            {
              
                ball.Left = 434;
                ballx = -ballx; 
                ballx += 2; 
                score++; 
            }

            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(player.Bounds) || ball.Bounds.IntersectsWith(cpu.Bounds))
            {
                
                ballx = -ballx;
            }

            if (playerup == true && player.Top > 0)
            {
          
                player.Top -= 8;
            }
            if (playerdown == true && player.Top < 455)
            {
           
                player.Top += 8;
            }
            if (score > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You win this game");
            }

            if (cpuPoint > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("CPU wins, you lose");
            }
        }


    }
}
