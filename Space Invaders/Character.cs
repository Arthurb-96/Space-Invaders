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
    public class Character
    {
        public PictureBox Player;
        protected Timer [] timers;
        protected WindowsMediaPlayer explosion;
        protected WindowsMediaPlayer shooting;
        protected int _HP;
        protected int _currentHP;
        public int _attack;
        protected int _speed;

       
        
        public Point location { get; set; }
        // protected PictureBox[] munition;
        public int _playerSpeed { get; set ; }
        protected int _munitionSpeed { get; set; }

        public void stopTimers()
        {
            for (int i = 0; i < timers.Length; i++)
                timers[i].Enabled = false;
        }

        public virtual void finishShooting() { }
        public virtual void collison() { }


    }


}
