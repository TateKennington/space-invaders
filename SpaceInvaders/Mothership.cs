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

        public Mothership(int x, int y, int width, int height, Missile[] _missiles, bool _alive = true) : base(x, y, width, height, _alive)
        {
            missiles = _missiles;
        }

        public void KeyHandler(Keys k)
        {
            if(k == Keys.Left)
            {
                Move(-1* Math.Min(20,Transform.X), 0);
            }
            if(k == Keys.Right)
            {
                Move(Math.Min(20, 3840-(Transform.X+Transform.Width)), 0);
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
