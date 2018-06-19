using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Mothership : GameObject
    {
        public Mothership() : base() { }

        public Mothership(int x, int y, int width, int height) : base(x, y, width, height) { }

        public void KeyHandler(Keys k)
        {
            if(k == Keys.Left)
            {
                Move(-20, 0);
            }
            if(k == Keys.Right)
            {
                Move(20, 0);
            }
        }
    }
}
