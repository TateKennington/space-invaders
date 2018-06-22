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
        public Mothership(int x, int y, int width, int height, bool _alive = true) : base(x, y, width, height, _alive){}

        /**
        Keyboard input handler.
        k: the input keycode
        */
        public void KeyHandler(Keys k, Engine sender)
        {
            //Move left
            if(k == Keys.Left)
            {
                Move(-1* Math.Min(20,Transform.X), 0);
            }

            //Move Right
            if(k == Keys.Right)
            {
                Move(Math.Min(20, Engine.Width-(Transform.X+Transform.Width)), 0);
            }

            //Fire
            if(k == Keys.Up)
            {
                Fire(sender);
            }
        }

        /**
        Spawns a missile from the resource pool above the mothership.
        */
        void Fire(Engine sender)
        {
            sender.SpawnMissile(Transform.X, Transform.Y - 100);
        }
    }
}
