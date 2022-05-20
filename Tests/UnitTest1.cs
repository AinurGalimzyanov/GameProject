using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parachutist.Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private bool win;
        private bool lose;
        private Player player;
        private Bird bird;
        private Button hp;
        private bool armorBool;
        private int score;
        private int speed;
        private bool collide;
        private bool gameOver;


        [TestMethod]
        public void СheckСollision()
        {
            player = new Player(100, 100);
            bird = new Bird(110, 120);
            Assert.AreEqual(true, Collide(player, bird));
        }

        [TestMethod]
        public void PlayerMapLimitsLeft()
        {
            var b = false;
            player = new Player(-10, 100);
            player.isMoving = true;

            if (player.isMoving && player.posX > 0 && player.posX + player.sizeWidth < 560)
                b = true;
            Assert.AreEqual(false, b);
        }

        [TestMethod]
        public void PlayerMapLimitsRight()
        {
            var b = false;
            player = new Player(580, 100);
            player.isMoving = true;

            if (player.isMoving && player.posX > 0 && player.posX + player.sizeWidth < 560)
                b = true;
            Assert.AreEqual(false, b);
        }

        [TestMethod]
        public void ArmorPlayerMapLimitsLeft()
        {
            var b = false;
            player = new Player(-10, 100);
            player.isMoving = true;

            if (player.isMoving && player.posX > 48 && player.posX + player.sizeWidth < 560 - 48)
                b = true;
            Assert.AreEqual(false, b);
        }

        [TestMethod]
        public void ArmorPlayerMapLimitsRight()
        {
            var b = false;
            player = new Player(580, 100);
            player.isMoving = true;
            if (player.isMoving && player.posX > 48 && player.posX + player.sizeWidth < 560 - 48)
                b = true;
            Assert.AreEqual(false, b);
        }

        [TestMethod]
        public void PlayerMoveLeft()
        {
            var b = false;
            player = new Player(100, 100);
            player.dirX = 15;
            player.isMoving = true;
            player.Move();

            if (player.posX == 115 && player.isMoving && player.posX > 0 && player.posX + player.sizeWidth < 560)
                b = true;

            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void PlayerMoveRight()
        {
            var b = false;
            player = new Player(100, 100);
            player.dirX = -15;
            player.isMoving = true;
            player.Move();

            if (player.posX == 85 && player.isMoving && player.posX > 0 && player.posX + player.sizeWidth < 560)
                b = true;

            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void GameOver()
        {
            gameOver = false;
            player = new Player(100, 100);
            bird = new Bird(110, 120);
            player.playerHealth = 1;
            if (Collide(player, bird))
                player.playerHealth -= 1;

            Update();
            Assert.AreEqual(true, gameOver);
        }

        [TestMethod]
        public void HealthDecreases()
        {
            var b = false;
            player = new Player(100, 100);
            bird = new Bird(110, 120);

            if (Collide(player, bird))
                player.playerHealth -= 1;

            if (player.playerHealth < 100)
                b = true;

            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void ChangesSpeed()
        {
            var b = false;
            speed = 10;
            score = 0;
            var beginSpeed = speed;
            for (var i = 0; i < 1000; i++)
            {
                score += speed;

                if (score % 1000 >= 0 && score % 1000 <= 9)
                    speed += 2;
            }

            if (beginSpeed < speed)
            {
                b = true;
            }
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void SpeedReductionAfterCollision()
        {
            collide = true;
            speed = 10;
            score = 0;

            score += speed;

            if (collide)
            {
                speed = 10;
                collide = false;
            }

            if (score % 1000 >= 0 && score % 1000 <= 9)
                speed += 2;
            
            
            Assert.AreEqual(10, speed);
        }

        private bool Collide(Player player, Bird bird)
        {
            var r1 = new Rectangle(player.posX, player.posY, 73, 102);
            var r2 = new Rectangle(bird.x + 10, bird.y, 60, 50);
            if (r1.IntersectsWith(r2))
            {
                return true;
            }
            return false;
        }

        private void Update()
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
            }
            else
            {
                gameOver = true;
            }
        }
    }
}
