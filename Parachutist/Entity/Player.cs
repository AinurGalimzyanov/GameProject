using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parachutist.Entity
{
    public class Player
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool isMoving;

        public int sizeWidth;
        public int sizeHeight;

        public Image playerImg;
        public Image spriteImg;

        public int score = 0;

        public Player(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            sizeWidth = 85;
            sizeHeight = 125;
            score = 0;
            playerImg = Properties.Resources.Parachutist;
            spriteImg = Properties.Resources.ParachutistEnd;
        }

        public void Move()
        {
            posX += dirX;
            posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(playerImg, posX, posY, sizeWidth, sizeHeight);
        }

        public void PlayAnimationEnd(Graphics g)
        {
            g.DrawImage(spriteImg, posX, posY, sizeWidth * 4, sizeHeight * 3);
        }
    }
}
