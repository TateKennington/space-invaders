using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        Engine game;

        public Form1()
        {
            InitializeComponent();
            game = new Engine(this.CreateGraphics());
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Tick();
            game.Render();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.KeyHandler(e.KeyCode);
        }
    }
}
