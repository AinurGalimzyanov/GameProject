using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parachutist.Entity
{
    public class Bird
    {
        public int x;
        public int y;
        public int srcX;

        public int sizeH;
        public int sizeW;

        public Image birdSheet;

        int frameCount = 0;
        int animationCount = 0;

        public Bird(int x, int y)
        {
            this.x = x;
            this.y = y;
            sizeH = 70;
            sizeW = 90;
            ChooseRandomPic();
        }

        public void ChooseRandomPic()
        {
            Random r = new Random();
            int rnd = r.Next(0, 4);
            switch (rnd)
            {
                case 0:
                    birdSheet = Properties.Resources.birdRockerSheet2;
                    break;
                case 1:
                    birdSheet = Properties.Resources.birdYellowSheet;
                    break;
                case 2:
                    birdSheet = Properties.Resources.birdBlueSheet;
                    break;
                case 3:
                    birdSheet = Properties.Resources.birdGreenSheet;
                    break;
            }
        }

        public void DrawSprite(Graphics g)
        {
            frameCount++;
            if (frameCount <= 10)
                animationCount = 0;
            else if (frameCount > 10 && frameCount <= 20)
                animationCount = 1;
            else if (frameCount > 20)
                frameCount = 0;

            g.DrawImage(birdSheet, new Rectangle(new Point(x, y), new Size(sizeW, sizeH)), 396 * animationCount, 0, 396, 316, GraphicsUnit.Pixel);
        }
    }
}
