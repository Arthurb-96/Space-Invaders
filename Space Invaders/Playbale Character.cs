using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WMPLib;


namespace Space_Invaders
{

    public class Playbale_Character : Character
    {

        public bool _isExist { get; private set; }
        protected PictureBox[] munition;
        protected string _name;
        private List<Character> enemys;
        private static int score { get; set; } = 0;
        private Form form;

        public Playbale_Character(Form form1, string name, List<Character> characters)
        {
            form = form1;
            enemys = characters;
            this.initCharImg(form);
            _isExist = true;
            _HP = 3;
            _playerSpeed = 4;
            this.initMunition(form);
            _name = name;
            initTimers();
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
            
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
       
                if (e.KeyCode == Keys.Left)
                {
                timers[0].Enabled = true;

                }
                else if (e.KeyCode == Keys.Right)
                {
                  timers[1].Enabled = true;
                }
                else if (e.KeyCode == Keys.Up)
                {
                timers[2].Enabled = true;
                 }
                else if (e.KeyCode == Keys.Down)
                {
                timers[3].Enabled = true;
                }
                else if (e.KeyCode == Keys.Space)
                {
                timers[4].Enabled = true;
                
                }
         }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {

            for (int i = 0; i < 4; i++)
                timers[i].Stop();

            if (e.KeyCode == Keys.Space)
            {

                timers[4].Stop();
                this.finishShooting();
            }
        }

        private void initCharImg(Form form)
        {
           
            Player = new PictureBox();
            Player.Width = Player.Height = 50;
            Image image = Image.FromFile("D:\\Arthur\\VS\\C#\\Space Invaders\\Space Invaders\\bin\\Debug\\asserts\\player.png");
            shooting = new WindowsMediaPlayer();
            shooting.URL = "songs\\pew pew.mp3";
            shooting.settings.setMode("loop", true);
            shooting.settings.volume = 3;
            shooting.controls.stop();
            explosion = new WindowsMediaPlayer();
            explosion.URL = "songs\\boom.mp3";
            explosion.settings.setMode("loop", false);
            explosion.controls.stop();
            explosion.settings.volume = 30;
            Player.Location = new Point(231, 386);
            Player.SizeMode = PictureBoxSizeMode.Zoom;
            Player.BackgroundImageLayout = ImageLayout.None;
            Player.BackColor = Color.Transparent;        
            Player.Image = image;
            
            Player.BorderStyle = BorderStyle.None;

            

            
            form.Controls.Add(Player);
        }

       private void initTimers()
        {
            timers = new Timer[5];

            for (int i = 0; i < 5; i++)
            {
                timers[i] = new Timer();
                timers[i].Interval = 5;
            }

            timers[0].Tick += mLeft_Tick;
            timers[1].Tick += mRight_Tick;
            timers[2].Tick += mUp_Tick;
            timers[3].Tick += mDown_Tick;
            timers[4].Tick += shoot_Tick;

        }

        private void initMunition(Form form)
        {
            _munitionSpeed = 20;
            munition = new PictureBox[3];
            Image image = Image.FromFile("D:\\Arthur\\VS\\munition.png");

            for (int i = 0; i < munition.Length; i++)
            {
                munition[i] = new PictureBox();
                munition[i].Size = new Size(8, 8);
                munition[i].Image = image;
                munition[i].SizeMode = PictureBoxSizeMode.Zoom;
                munition[i].BorderStyle = BorderStyle.None;
                form.Controls.Add(munition[i]);
            }
        }

     
        public void mLeft_Tick(object sender, EventArgs e)
        {
            
            if (Player.Left > 10)
            {
                Player.Left -= _playerSpeed;

            }
        }

        public void mRight_Tick(object sender, EventArgs e)
        {

            if (Player.Right < 580)
            {
                Player.Left += _playerSpeed;
              
            }
        }


        public void mUp_Tick(object sender, EventArgs e)
        {

            if (Player.Top > 10)
            {
                Player.Top -= _playerSpeed;
            }
        }


        public void mDown_Tick(object sender, EventArgs e)
        {
            
            if (Player.Top < 400)
            {
                Player.Top += _playerSpeed;
            }
        }


      
        public void shoot_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < munition.Length; i++)
                if (munition[i].Top > 0)
                {
                    munition[i].Visible = true;
                    munition[i].Top -= _munitionSpeed;
                }
                else
                {
                    munition[i].Visible = false;
                    munition[i].Location = new Point(Player.Location.X+22, Player.Location.Y + 20);

                }
            shooting.controls.play();
            



        }

        public override void finishShooting()
        {
            
            bool munitionsStillVisible =true;
           
            while (munitionsStillVisible)
            {
                munitionsStillVisible = false;
                for (int i = 0; i < munition.Length; i++)
                {
                    if (munition[i].Top > 0)
                    {
                        munition[i].Top -= _munitionSpeed;
                        munitionsStillVisible = true;
                    }
                }
            }
            shooting.controls.stop();
        }

        public override void collison()
        {
            for (int i = 1; i < enemys.Count; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (munition[j].Bounds.IntersectsWith(enemys[i].Player.Bounds))
                    {

                        enemys[i].location = new Point(-60, -60);
                        enemys[i].stopTimers();
                        enemys[i].finishShooting();
                        enemys[i].Player.Visible = false;
                        enemys[i].stopTimers();
                        score += 10;                        

                    }
                }
               
            
           
        }
         
        public void cabum()
        {

            explosion.controls.play();
        }

        public int getScore()
        {
            return score;
        }
     }



    
}

