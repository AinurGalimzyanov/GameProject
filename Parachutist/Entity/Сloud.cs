using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parachutist.Entity
{
    public class Cloud
    {
        public int x;
        public int y;
        public int srcX;

        public int sizeH;
        public int sizeW;

        public Image cloudSheet;

        public Cloud(int x, int y)
        {
            this.x = x;
            this.y = y;
            cloudSheet = Properties.Resources.cloudSheet;
            sizeH = 100;
            sizeW = 140;
            ChooseRandomPic();
        }

        public void ChooseRandomPic()
        {
            Random r = new Random();
            int rnd = r.Next(0, 3);
            switch (rnd)
            {
                case 0:
                    srcX = 0;
                    break;
                case 1:
                    srcX = 214;
                    break;
                case 2:
                    srcX = 433;
                    break;
            }
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(cloudSheet, new Rectangle(new Point(x, y), new Size(sizeW, sizeH)), srcX, 0, 229, 156, GraphicsUnit.Pixel);
        }
    }
}
