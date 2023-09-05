using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections.Generic;

namespace Space_Invaders
{
  
    public partial class Form1 : Form
    {

        PictureBox[] stars;
        int backgroundspeed;
        Random rnd;
        public PictureBox[] buttons;
        Image[] menuLogo;
        public List<Character> characters { get; set; }
        //public Character[] characters;
        public bool gamesON { get; private set; } = false;
        private PrivateFontCollection privateFontCollection = new PrivateFontCollection();
        Font customFont;

        public Form1()
        {
            InitializeComponent();
            privateFontCollection.AddFontFile("ninja-gaiden-nes.ttf");
            customFont = new Font(privateFontCollection.Families[0], 12, FontStyle.Regular);
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {           
            stars = new PictureBox[10];
            rnd = new Random();
           
            this.initBG();
            gameMenu();




        }

        private void gameMenu()
        {
            this.Controls.Add(this.gameLogoIcon);
            this.Controls.Add(this.newGameIcon);
            this.Controls.Add(this.loadGameIcon);
            this.Controls.Add(this.scoreboardIcon);
            this.Controls.Add(this.exitIcon);
            gameLogoIcon.Visible = true;
            newGameIcon.Visible = true;
            loadGameIcon.Visible = true;
            scoreboardIcon.Visible = true;
            exitIcon.Visible = true;


        }

        private void hidellbuttons()
        {
            gameLogoIcon.Visible = false;
            newGameIcon.Visible = false;
            loadGameIcon.Visible = false;
            scoreboardIcon.Visible = false;
            exitIcon.Visible = false;
            scoreboard_in.Visible = false;
        }



        private void newGame_Click(object sender, EventArgs e)
        {
            hidellbuttons();
            gamesON = true;
            game();
        }

        private void loadGame_Click(object sender, EventArgs e)
        {
            hidellbuttons();
        }

        private void scoreboard_Click(object sender, EventArgs e)
        {
            scoreboard();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void game()
        {
            characters = new List<Character>(8);
            bool alldead = false;
            Timer collisonTimer = new Timer();
            collisonTimer.Interval = 1;
            collisonTimer.Tick += collisonTimer_Tick;
            Playbale_Character playableCharacter = new Playbale_Character(this,"arthur", characters);
            characters.Add(playableCharacter);
            this.Controls.Add(score);
            score_int.Font = customFont;
            this.Controls.Add(this.score_int);

            for (int i = 0; i < 8; i++)
                spawnEnemy( i);

            collisonTimer.Enabled = true;
            playableCharacter.Player.Focus();
            this.KeyPreview = true;

        }

       private void collisonTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                characters[i].collison();
                Playbale_Character temp = (Playbale_Character)characters[0];
                score_int.Text = temp.getScore().ToString();              
            }      
        }
         


        private void scoreboard()
        {
            hidellbuttons();
            this.Controls.Add(this.scoreboard_in);
            scoreboard_in.Enabled = true;
            scoreboard_in.Visible = true;
            Label []ranking = new Label[10];

            for(int i = 0; i<50;i+=50)
                for(int j = 0; j<5;j++)
                {
                    ranking[j] = new Label();
                    ranking[j].Location = new Point(100, 180+j*20);
                    ranking[j].Size = new System.Drawing.Size(35, 13);
                    ranking[j].Text = j.ToString();
                    this.Controls.Add(ranking[j]);
                }

        }
        private void initBG()
        {
            backgroundspeed = 4;

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 580), rnd.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]);
            }
        }

        private void movingBG_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }





        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                hidellbuttons();
                for (int i = 0; i < characters.Count; i++)
                {
                    characters[i].stopTimers();
                    characters[i].Player.Visible = false;
                    characters[i].finishShooting();
                }
                gameMenu();
            }

           
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
          
        }



   

      

       
        private void gameMenu(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

        }


        private void spawnEnemy( int i)
        {
            Random random = new Random();

            // Determine a random spawn position
            int spawnX = random.Next(0, 600);
            int spawnY = random.Next(-50, -20 );

            // Create a new enemy with the chosen spawn position
            Regular newEnemy = new Regular(this, new Point(spawnX, spawnY),characters);

            // Check for collisions with existing enemies
            while (CheckForCollisions(newEnemy))
            {
                spawnX = random.Next(30, 500);
                spawnY = random.Next(-50, -20);
                newEnemy.location = new Point(spawnX, spawnY);
            }
           
            // Add the new enemy to the list
            characters.Add(newEnemy);
         }
        
        private bool CheckForCollisions(NPC newEnemy)
        {
            for (int i = 1; i < characters.Count; i++)
            {
                // You can define a collision radius or distance here
                int collisionRadius = 20; // Adjust as needed

                // Calculate the distance between the new enemy and existing enemy
                double distance = Math.Sqrt(
                    Math.Pow(newEnemy.location.X - characters[i].location.X, 2) +
                    Math.Pow(newEnemy.location.Y - characters[i].location.Y, 2)
                );

                // If the distance is less than the sum of their radii, they collide
                if (distance < collisionRadius * 2)
                {
                    return true; // Collision detected
                }
            }
            return false; // No collision detected

        }

        private void game(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

        }

        private void scoreboard_Click(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

        }
    }


}


