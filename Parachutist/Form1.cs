﻿using Parachutist.Entity;
using Parachutist.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parachutist
{
    public partial class Form1 : Form
    {
        
        public Image playerImg;
        public Player player;
        public Cloud[] cloudArray = new Cloud[5];
        public Bird[] birdArray = new Bird[5];

        bool gameOver;
        bool collide = false;
        Random randNum = new Random();
        private int score;
        private int speed;
        private int money = 0;
        private bool start = false;
        private bool infoBool = false;
        private bool armorBool = false;
        public Button menu;
        public Button startGame;
        public Button restartGame;
        public Button exit;
        public Button shop;
        public Button back;
        public Label moneyLable;
        public PictureBox moneyImg;
        public PictureBox gameOverImg;
        public Label gameOverMoney;
        public Button info;
        public PictureBox infoImg;
        public Button hp;
        public Button armor;
        private int count = 0;
        private int timerCount = 340;
        private Label timerLabel;
        private Label record;
        private int maxScore = 0;

        public Form1()
        {
            InitializeComponent();
            
            this.Width = 600;
            this.Height = 870;
            this.DoubleBuffered = true;
            this.StartPosition = 0;
            this.KeyPreview = true;
            
            txtScore.BackColor = Color.Transparent;

            menu = new Button 
            { 
                Location = new Point(healthBar.Right + 9, 20), 
                Size = new Size(30, 30),
                Image = Properties.Resources.pause,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            menu.Click += new EventHandler(Menu_Click);
            menu.FlatAppearance.BorderSize = 0;
            menu.FlatAppearance.MouseOverBackColor = Color.Transparent;
            menu.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Controls.Add(menu);

            hp = new Button 
            { 
                Location = new Point(85, 200), 
                Size = new Size(170, 175),
                Image = Properties.Resources.hp3,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            hp.Click += new EventHandler(Hp_Click);
            hp.FlatAppearance.BorderSize = 5;
            hp.FlatAppearance.BorderColor = Color.Blue;
            hp.FlatAppearance.MouseOverBackColor = Color.Transparent;
            hp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Controls.Add(hp);

            armor = new Button 
            { 
                Location = new Point(330, 200), 
                Size = new Size(170, 175),
                Image = Properties.Resources.armorButton2,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            armor.Click += new EventHandler(Armor_Click);
            armor.FlatAppearance.BorderSize = 5;
            armor.FlatAppearance.BorderColor = Color.Blue;
            armor.FlatAppearance.MouseOverBackColor = Color.Transparent;
            armor.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Controls.Add(armor);

            info = new Button 
            { 
                Location = new Point(healthBar.Right + 9, 16),
                Size = new Size(30, 34),
                Image = Properties.Resources.info,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent
            };
            info.Click += new EventHandler(Info_Click);
            info.FlatAppearance.BorderSize = 0;
            info.FlatAppearance.MouseOverBackColor = Color.Transparent;
            info.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Controls.Add(info);

            startGame = new Button
            {
                Location = new Point(this.Width / 2 - 85, 250),
                Text = "Play",
                ForeColor = Color.White,
                Font = new Font("MV Boli", 24, FontStyle.Bold),
                Size = new Size(170, 50),
                FlatStyle = FlatStyle.Flat
            };
            startGame.Click += new EventHandler(Start_Click);
            startGame.FlatAppearance.BorderSize = 0;
            Controls.Add(startGame);

            shop = new Button
            {
                Location = new Point(startGame.Location.X, startGame.Bottom + 3),
                Text = "Shop",
                ForeColor = Color.White,
                Font = new Font("MV Boli", 24, FontStyle.Bold),
                Size = new Size(170, 50),
                FlatStyle = FlatStyle.Flat
            };
            shop.Click += new EventHandler(Shop_Click);
            shop.FlatAppearance.BorderSize = 0;
            Controls.Add(shop);

            restartGame = new Button
            {
                Location = new Point(startGame.Location.X, shop.Bottom + 3),
                Text = "Restart",
                Font = new Font("MV Boli", 24, FontStyle.Bold),
                Size = new Size(170, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            restartGame.Click += new EventHandler(Restart_Click);
            restartGame.FlatAppearance.BorderSize = 0;
            Controls.Add(restartGame);

            exit = new Button
            {
                Location = new Point(startGame.Location.X, restartGame.Bottom + 3),
                Text = "Exit",
                Font = new Font("MV Boli", 24, FontStyle.Bold),
                Size = new Size(170, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            exit.Click += new EventHandler(Exit_Click);
            exit.FlatAppearance.BorderSize = 0;
            Controls.Add(exit);

            moneyImg = new PictureBox()
            {
                Location = new Point(txtScore.Location.X, txtScore.Location.Y - 5),
                Size = new Size(42, 42),
                Image = Properties.Resources.money,
                BackColor = Color.Transparent
            };
            Controls.Add(moneyImg);

            gameOverImg = new PictureBox()
            {
                Location = new Point(this.Width / 2 - 150, 65),
                Size = new Size(300, 200),
                Image = Properties.Resources.gameOver,
                BackColor = Color.Transparent
            };
            Controls.Add(gameOverImg);

            infoImg = new PictureBox()
            {
                Location = new Point(0, 80),
                Size = new Size(800, 1000),
                Image = Properties.Resources.infoImg,
                BackColor = Color.Transparent
            };
            Controls.Add(infoImg);

            moneyLable = new Label()
            {
                Location = new Point(moneyImg.Right, txtScore.Location.Y),
                BackColor = Color.Transparent,
                Text = "" + money,
                Font = new Font("Myanmar Text", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            Controls.Add(moneyLable);

            record = new Label()
            {
                Size = new Size(this.Width, 70),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Location = new Point(0, 700),
                BackColor = Color.Transparent,
                Font = new Font("Myanmar Text", 24, FontStyle.Bold),
                ForeColor = Color.Black
            };
            Controls.Add(record);

            gameOverMoney = new Label()
            {
                Size = new Size(this.Width, 70),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Location = new Point(0, 270),
                BackColor = Color.Blue,
                Font = new Font("MV Boli", 30, FontStyle.Bold),
                ForeColor = Color.Black
            };
            Controls.Add(gameOverMoney);

            timerLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(270, txtScore.Location.Y),
                BackColor = Color.Transparent,
                Font = new Font("MV Boli", 28, FontStyle.Bold),
                ForeColor = Color.Black
            };
            Controls.Add(timerLabel);

            RestartGame();

            gameOverImg.Hide();
            txtScore.Hide();
            healthBar.Hide();
            menu.Hide();
            restartGame.Hide();
            exit.Hide();
            shop.Hide();
            moneyLable.Hide();
            moneyImg.Hide();
            gameOverMoney.Hide();
            infoImg.Hide();
            hp.Hide();
            armor.Hide();
            timerLabel.Hide();
            record.Hide();
        }

       

        public void Init()
        {
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            timer1.Start();

            Invalidate();
        }

        private void RestartGame()
        {
            score = 0;
            speed = 10;
            player = new Player(240, 100);

            for (int i = 0; i < cloudArray.Length; i++)
            {
                var x1 = randNum.Next(0, 500);
                var y1 = randNum.Next(800, 1500);
                cloudArray[i] = new Cloud(x1, y1);
            }

            for (var i = 0; i < birdArray.Length; i++)
            {
                var x1 = randNum.Next(0, 500);
                var y1 = randNum.Next(800, 1500);
                birdArray[i] = new Bird(x1, y1);
            }
            timer1.Start();
        }

        public void Update(object sender, EventArgs e)
        {
            if (player.playerHealth > 0)
            {
                score += speed;
                if (collide)
                {
                    speed = 10;
                    collide = false;
                }

                if (score % 1000 >= 0 && score % 1000 <= 9)
                    speed += 2;

                healthBar.Value = player.playerHealth;
                MoveBird();
                MoveCloud();
            }
            else
            {
                money += (int)Math.Round(score * 0.1);
                moneyLable.Text = "" + money;
                gameOverMoney.Text = "Money: +" + (int)Math.Round(score * 0.1);
                if (score > maxScore) maxScore = score;
                record.Text = "Record: " + maxScore;
                gameOver = true;
                gameOverMoney.Show();
                gameOverImg.Show();
                record.Show();
                timer1.Stop();
            }

            txtScore.Text = "" + score + "m";

            if (armorBool)
            {
                if (player.isMoving)
                {
                    if (player.posX > 48) player.posX -= 15;
                    if (player.posX + player.sizeWidth < 560 - 48) player.posX += 15;
                    player.Move();
                }
                timerLabel.Show();
                if (timerCount % 34 == 0)
                    timerLabel.Text = "" + (timerCount / 34);
                timerCount -= 1;
                count += 1;
                if (count == 340)
                {
                    armorBool = false;
                    count = 0;
                    timerCount = 340;
                    timerLabel.Hide();
                }
            }
            else
            {
                if (player.isMoving)
                {
                    if (player.posX > 0) player.posX -= 15;
                    if (player.posX + player.sizeWidth < 560) player.posX += 15;
                    player.Move();
                }
            }
            Invalidate();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
            }

            player.isMoving = false;

            if (e.KeyCode == Keys.Enter && gameOver)
            {
                gameOverMoney.Hide();
                gameOverImg.Hide();
                record.Hide();
                gameOver = false;
                RestartGame();
            }
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    player.isMoving = true;
                    player.dirX = -15;
                    break;
                case Keys.D:
                    player.isMoving = true;
                    player.dirX = 15;
                    break;
            }
        }

        public void MoveCloud()
        {
            for (int i = 0; i < cloudArray.Length; i++)
            {
                cloudArray[i].y -= speed;
                if (cloudArray[i].y < -150)
                    cloudArray[i] = new Cloud(randNum.Next(0, 500), randNum.Next(800, 1300));
            }
        }

        public void MoveBird()
        {
            for (int i = 0; i < birdArray.Length; i++)
            {
                if (!armorBool && Collide(player, birdArray[i]))
                {
                    player.playerHealth -= 3;
                    continue;
                }
                birdArray[i].y -= speed;
                if (birdArray[i].y < -100)
                    birdArray[i] = new Bird(randNum.Next(0, 500), randNum.Next(800, 1300));
            }
        }

        private bool Collide(Player player, Bird bird)
        {
            var r1 = new Rectangle(player.posX, player.posY, 73, 102);
            var r2 = new Rectangle(bird.x + 10, bird.y, 60, 50);
            if (r1.IntersectsWith(r2))
            {
                collide = true;
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var i in cloudArray)
                i.DrawSprite(g);
            if (start)
                if (!gameOver)
                {
                    foreach (var i in birdArray)
                        i.DrawSprite(g);

                    if (armorBool)
                        player.PlayAnimationEnd(g);
                    else
                        player.PlayAnimation(g);
                }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            start = false;
            shop.Show();
            if (!gameOver)
            {
                startGame.Show();
                startGame.Text = "Continue";
                startGame.Font = new Font("MV Boli", 24, FontStyle.Bold);
            }
            txtScore.Hide();
            infoImg.Hide();
            healthBar.Hide();
            menu.Hide();
            timer1.Tick -= Update;
            KeyDown -= new KeyEventHandler(OnPress);
            KeyUp -= new KeyEventHandler(OnKeyUp);
            restartGame.Show();
            exit.Show();
            moneyLable.Show();
            moneyImg.Show();
            record.Show();
            info.Show();
            hp.Hide();
            armor.Hide();
            if (gameOver)
            {
                shop.Hide();
                restartGame.Location = new Point(shop.Location.X, 370);
                restartGame.ForeColor = Color.Black;
                exit.Location = new Point(shop.Location.X, restartGame.Bottom + 3);
                exit.ForeColor = Color.Black;
            }
            if (infoBool)
            {
                gameOverImg.Show();
                record.Show();
                gameOverMoney.Show();
                infoBool = false;
            }
            Invalidate();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            start = true;
            startGame.Hide();
            record.Hide();
            shop.Hide();
            Init();
            txtScore.Show();
            menu.Show();
            healthBar.Show();
            restartGame.Hide();
            infoImg.Hide();
            exit.Hide();
            moneyLable.Hide();
            moneyImg.Hide();
            info.Hide();
            menu.Image = Properties.Resources.pause;
            hp.Hide();
            armor.Hide();
        }

        private void Hp_Click(object sender, EventArgs e)
        {
            if (money >= 10000)
            {
                if (player.playerHealth + 33 < 100)
                {
                    player.playerHealth += 33;
                    money -= 10000;
                    moneyLable.Text = "" + money;
                }
                else
                {
                    player.playerHealth = 100;
                    money -= 10000;
                    moneyLable.Text = "" + money;
                }
            }
        }

        private void Armor_Click(object sender, EventArgs e)
        {
            if (money >= 15000)
            {
                armorBool = true;
                money -= 15000;
                moneyLable.Text = "" + money;
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            info.Hide();
            menu.Show();
            restartGame.Hide();
            startGame.Hide();
            exit.Hide();
            shop.Hide();
            moneyLable.Hide();
            moneyImg.Hide();
            infoImg.Show();
            hp.Hide();
            armor.Hide();
            gameOverImg.Hide();
            record.Hide();
            gameOverMoney.Hide();
            if (gameOver)
            {
                infoBool = true;
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                shop.Location = new Point(startGame.Location.X, startGame.Bottom + 3);
                shop.ForeColor = Color.White;
                restartGame.Location = new Point(startGame.Location.X, shop.Bottom + 3);
                restartGame.ForeColor = Color.White;
                exit.Location = new Point(startGame.Location.X, restartGame.Bottom + 3);
                exit.ForeColor = Color.White;
            }
            hp.Hide();
            armor.Hide();
            start = true;
            gameOver = false;
            Init();
            gameOverMoney.Hide();
            gameOverImg.Hide();
            record.Hide();
            txtScore.Show();
            exit.Hide();
            shop.Hide();
            healthBar.Show();
            restartGame.Hide();
            startGame.Hide();
            RestartGame();
            menu.Show();
            moneyLable.Hide();
            moneyImg.Hide();
            info.Hide();
            menu.Image = Properties.Resources.pause;
        }

        private void Shop_Click(object sender, EventArgs e)
        {
            hp.Show();
            armor.Show();
            gameOverMoney.Hide();
            gameOverImg.Hide();
            record.Hide();
            txtScore.Hide();
            healthBar.Hide();
            restartGame.Hide();
            startGame.Hide();
            exit.Hide();
            shop.Hide();
            menu.Show();
            moneyLable.Show();
            moneyImg.Show();
            menu.Image = Properties.Resources.menu;
            info.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
