using Parachutist.Entity;
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
        public Image dwarfSheet;
        public Image gladiatorSheet;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {

            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Dwarf.png"));

            Player player = new Player(100, 100, Hero.flightFrames, Hero.landingFrames, dwarfSheet);
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(dwarfSheet, new Point(100, 100));
        }
    }
}
