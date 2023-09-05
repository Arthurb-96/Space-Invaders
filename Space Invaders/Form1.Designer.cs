using System.Drawing.Text;
using System.Drawing;

namespace Space_Invaders
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.movingBG = new System.Windows.Forms.Timer(this.components);
            this.scoreboard_in = new System.Windows.Forms.PictureBox();
            this.exitIcon = new System.Windows.Forms.PictureBox();
            this.scoreboardIcon = new System.Windows.Forms.PictureBox();
            this.loadGameIcon = new System.Windows.Forms.PictureBox();
            this.gameLogoIcon = new System.Windows.Forms.PictureBox();
            this.newGameIcon = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.PictureBox();
            this.score_int = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scoreboard_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreboardIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadGameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameLogoIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.score)).BeginInit();
            this.SuspendLayout();
            // 
            // movingBG
            // 
            this.movingBG.Enabled = true;
            this.movingBG.Interval = 10;
            this.movingBG.Tick += new System.EventHandler(this.movingBG_Tick);
            // 
            // scoreboard_in
            // 
            this.scoreboard_in.BackColor = System.Drawing.Color.Transparent;
            this.scoreboard_in.Enabled = false;
            this.scoreboard_in.Image = global::Space_Invaders.Properties.Resources.scoreboard_in;
            this.scoreboard_in.Location = new System.Drawing.Point(102, 36);
            this.scoreboard_in.Name = "scoreboard_in";
            this.scoreboard_in.Size = new System.Drawing.Size(384, 109);
            this.scoreboard_in.TabIndex = 0;
            this.scoreboard_in.TabStop = false;
            this.scoreboard_in.Visible = false;
            this.scoreboard_in.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.scoreboard_Click);
            this.scoreboard_in.Click += new System.EventHandler(this.scoreboard_Click);
            // 
            // exitIcon
            // 
            this.exitIcon.Image = global::Space_Invaders.Properties.Resources.EXIT;
            this.exitIcon.Location = new System.Drawing.Point(235, 404);
            this.exitIcon.Name = "exitIcon";
            this.exitIcon.Size = new System.Drawing.Size(96, 23);
            this.exitIcon.TabIndex = 4;
            this.exitIcon.TabStop = false;
            this.exitIcon.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.gameMenu);
            this.exitIcon.Click += new System.EventHandler(this.exit_Click);
            // 
            // scoreboardIcon
            // 
            this.scoreboardIcon.Image = global::Space_Invaders.Properties.Resources.SCOREBOARD;
            this.scoreboardIcon.Location = new System.Drawing.Point(169, 332);
            this.scoreboardIcon.Name = "scoreboardIcon";
            this.scoreboardIcon.Size = new System.Drawing.Size(241, 24);
            this.scoreboardIcon.TabIndex = 3;
            this.scoreboardIcon.TabStop = false;
            this.scoreboardIcon.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.gameMenu);
            this.scoreboardIcon.Click += new System.EventHandler(this.scoreboard_Click);
            // 
            // loadGameIcon
            // 
            this.loadGameIcon.Image = global::Space_Invaders.Properties.Resources.LOADGAME;
            this.loadGameIcon.Location = new System.Drawing.Point(180, 290);
            this.loadGameIcon.Name = "loadGameIcon";
            this.loadGameIcon.Size = new System.Drawing.Size(215, 25);
            this.loadGameIcon.TabIndex = 2;
            this.loadGameIcon.TabStop = false;
            this.loadGameIcon.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.gameMenu);
            this.loadGameIcon.Click += new System.EventHandler(this.loadGame_Click);
            // 
            // gameLogoIcon
            // 
            this.gameLogoIcon.Image = global::Space_Invaders.Properties.Resources.SPACEINVADERS;
            this.gameLogoIcon.Location = new System.Drawing.Point(126, 53);
            this.gameLogoIcon.Name = "gameLogoIcon";
            this.gameLogoIcon.Size = new System.Drawing.Size(320, 81);
            this.gameLogoIcon.TabIndex = 1;
            this.gameLogoIcon.TabStop = false;
            this.gameLogoIcon.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.gameMenu);
            // 
            // newGameIcon
            // 
            this.newGameIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.newGameIcon.BackColor = System.Drawing.Color.Transparent;
            this.newGameIcon.Image = global::Space_Invaders.Properties.Resources.NEWGAME;
            this.newGameIcon.Location = new System.Drawing.Point(194, 245);
            this.newGameIcon.Name = "newGameIcon";
            this.newGameIcon.Size = new System.Drawing.Size(191, 25);
            this.newGameIcon.TabIndex = 0;
            this.newGameIcon.TabStop = false;
            this.newGameIcon.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.gameMenu);
            this.newGameIcon.Click += new System.EventHandler(this.newGame_Click);
            // 
            // score
            // 
            this.score.BackColor = System.Drawing.Color.Transparent;
            this.score.Image = global::Space_Invaders.Properties.Resources.SCORE4;
            this.score.Location = new System.Drawing.Point(23, 13);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(78, 17);
            this.score.TabIndex = 0;
            this.score.TabStop = false;
            this.score.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.game);
            // 
            // score_int
            // 
            this.score_int.AutoSize = true;
            this.score_int.ForeColor = System.Drawing.Color.Yellow;
            this.score_int.Location = new System.Drawing.Point(120, 10);
            this.score_int.Name = "score_int";
            this.score_int.Size = new System.Drawing.Size(13, 13);
            this.score_int.TabIndex = 0;
            this.score_int.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 500);
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.scoreboard_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreboardIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadGameIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameLogoIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGameIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.score)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer movingBG;
        private System.Windows.Forms.PictureBox newGameIcon;
        private System.Windows.Forms.PictureBox gameLogoIcon;
        private System.Windows.Forms.PictureBox loadGameIcon;
        private System.Windows.Forms.PictureBox scoreboardIcon;
        private System.Windows.Forms.PictureBox exitIcon;
        private System.Windows.Forms.PictureBox scoreboard_in;
        private System.Windows.Forms.PictureBox score;
        private System.Windows.Forms.Label score_int;
    }
}

