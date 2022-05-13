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

        public Image spriteImg;

        public int score = 0;

        public Player(int posX, int posY, Image spriteImg)
        {
            this.posX = posX;
            this.posY = posY;
            this.spriteImg = spriteImg;
            sizeWidth = 80;
            sizeHeight = 100;
            score = 0;
        }

        public void Move()
        {
            posX += dirX;
            posY += dirY;
        }



        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(spriteImg, new Point(posX, posY));
        }
    }
 }
