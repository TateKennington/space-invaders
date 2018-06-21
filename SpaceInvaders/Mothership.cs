using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    /**
    The player character.
    */
    class Mothership : GameObject
    {
        Missile[] missiles; //References to missiles in the resource pool

        /**
        Default constructor.
        */
        public Mothership() : base() { }

        /**
        Mothership constructer.
        x: X position of the mothership in screen space.
        y: Y position of the mothership in screen space.
        width: Width of the mothership in pixels.
        height: Height of the mothership in pixels.
        _missiles: List of references to pooled missiles.
        _alive: Whether the ship is initially alive(default) or dead.
        */
        public Mothership(int x, int y, int width, int height, Missile[] _missiles, bool _alive = true) : base(x, y, width, height, _alive)
        {
            missiles = _missiles;
        }

        /**
        Keyboard input handler.
        k: the input keycode
        */
        public void KeyHandler(Keys k)
        {
            //Move left
            if(k == Keys.Left)
            {
                Move(-1* Math.Min(20,Transform.X), 0);
            }

            //Move Right
            if(k == Keys.Right)
            {
                Move(Math.Min(20, 3840-(Transform.X+Transform.Width)), 0);
            }

            //Fire
            if(k == Keys.Up)
            {
                Fire();
            }
        }

        /**
        Spawns a missile from the resource pool above the mothership.
        */
        void Fire()
        {
            //Consider each missile in the pool
            foreach(Missile missile in missiles)
            {
                //If it is no longer alive claim it
                if (!missile.Alive)
                {
                    missile.Alive =true;
                    missile.SetPosition(Transform.X, Transform.Y - 100);
                    break;
                }
            }
        }
    }
}
