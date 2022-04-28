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

        public int flip;

        public int landingFrames;
        public int flightFrames;

        public int sizeWidth;
        public int sizeHeight;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public Image spriteSheet;

        public Player(int posX, int posY, int flightFrames, int landingFrames, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.landingFrames = landingFrames;
            this.flightFrames = flightFrames;
            this.spriteSheet = spriteSheet;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = flightFrames;
            sizeWidth = 86;
            sizeHeight = 100;
        }

        public void Move(int dirX, int dirY)
        {
            posX += dirX;
            posY += dirY;
        }
    }
 }
