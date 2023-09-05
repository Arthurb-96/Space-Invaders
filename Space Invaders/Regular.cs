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
    public class Regular : NPC
    {
        private WindowsMediaPlayer enemysong;
        private PictureBox munition;
        private List<Character> enemys;
        private Form form;
        private List<Character> characters;
        public Regular(Form form1,Point cordinates, List<Character> enemys)
        {

            //enemysong = new WindowsMediaPlayer();
            //enemysong.URL = "songs\\lehem_havita (mp3cut.net).mp3";
            //enemysong.controls.play();
            //enemysong.settings.setMode("loop", true);
            //enemysong.settings.volume = 7;
            characters = enemys;
            form = form1;
            Random rnd = new Random();
            _HP = _currentHP = 4;
            _playerSpeed = 4;
            Player = new PictureBox();
            Player.Visible = false;
            Player.Width = Player.Height = 80;
            Image image = Image.FromFile("D:\\Arthur\\VS\\C#\\Space Invaders\\Space Invaders\\bin\\Debug\\asserts\\havita.png");
            
            Player.Location = location= cordinates;
            Player.SizeMode = PictureBoxSizeMode.Zoom;

            Player.Image = image;
            Player.BorderStyle = BorderStyle.None;
           // Player.Location = new Point(rnd.Next(0, 480), -50);
            initMunition(form);
            
            form.Controls.Add(Player);
            initTimers();
            



        }

        private void initTimers()
        {
            timers = new Timer[2];
            timers[0] = new Timer();
            timers[0].Interval = 100;
            timers[0].Tick += moveEnemy_Tick;
            timers[0].Enabled = true;
            timers[1] = new Timer();
            timers[1].Interval = 20;
            timers[1].Tick += shoot_Tick;
            timers[1].Enabled = true;
           

        }

        public void stopTimers()
        {
            timers[0].Enabled = false;
            timers[1].Enabled = false;
        }



        private void initMunition(Form form)
        {
            _munitionSpeed = 7;
            munition = new PictureBox();
            munition.Size = new Size(2, 25);
            munition.Visible = false;
            munition.BackColor = Color.Yellow;
            munition.Location = new Point(Player.Location.X + 50, Player.Location.Y - 20);
            form.Controls.Add(munition);

        }


        public void moveEnemy_Tick(object sender, EventArgs e)
        {
            Player.Visible = true;
            Player.Top += _playerSpeed;
            if (Player.Top > 480)
            {
                Player.Location = new Point(Player.Location.X, -150);
            }
        }

        public void dead()
        {
            Player.Dispose();
            enemysong.controls.stop();

            //need to delete the object and not the picture box
        }

        public void shoot_Tick(object sender, EventArgs e)
        {
          
            if (munition.Top < 500)
             {
               munition.Visible = true;
               munition.Top += _munitionSpeed;
             }
             else
             {
                    munition.Visible = false;
                    munition.Location = new Point(Player.Location.X + 50, Player.Location.Y + 60);
             }
        
        }

        public override void finishShooting()
        {
            bool munitionsStillVisible = true;
           
            while (munitionsStillVisible)
            {
                munitionsStillVisible = false;


                if (munition.Top < 500)
                {
                    munition.Top += _munitionSpeed;
                    munitionsStillVisible = true;
                }

            }

        }

        public override  void collison()
        {


            if (munition.Bounds.IntersectsWith(characters[0].Player.Bounds))
            {
                this.munition.Visible = false;
                form.Controls.Remove(characters[0].Player);
                characters[0].finishShooting();
                characters[0].Player.Visible = false;
                characters[0].Player.Location = new Point(-20, 0);

                
            }
           
        }


    }
}


