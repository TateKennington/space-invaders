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
        Missile[] missiles;

        public Mothership() : base() { }

        public Mothership(int x, int y, int width, int height, Missile[] _missiles) : base(x, y, width, height)
        {
            missiles = _missiles;
        }

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
            if(k == Keys.Up)
            {
                Fire();
            }
        }

        void Fire()
        {
            foreach(Missile missile in missiles)
            {
                if (!missile.IsAlive())
                {
                    missile.SetAlive(true);
                    missile.SetPosition(Transform.X, Transform.Y - 100);
                    break;
                }
            }
        }
    }
}
