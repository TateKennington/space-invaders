using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Missile : GameObject
    {
        public Missile() : base(){}

        public Missile(int x, int y, int width, int height) : base(x, y, width, height){}

        public override void Tick()
        {
            Move(0, -30);
            if (Transform.Y < -100)
            {
                SetAlive(false);
            }
        }
    }
}
