using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Engine
    {
        Graphics g;
        int t;

        public Engine()
        {
            t = 0;
        }

        public void SetGraphics(Graphics _g)
        {
            g = _g;
        }

        public void Tick()
        {

        }

        public void Render()
        {
            g.Clear(Color.Black);
        }
    }
}
