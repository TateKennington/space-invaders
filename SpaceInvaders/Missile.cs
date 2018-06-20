using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    /**
    Projectiles fired by the player
    */
    class Missile : GameObject
    {
        /**
        Constructors
        */
        public Missile() : base(){}
        public Missile(int x, int y, int width, int height) : base(x, y, width, height){}

        public override void OnCollide(GameObject other)
        {
            if (other.getObjectType() == eType.Enemy)
            {
                other.SetAlive(false);
                SetAlive(false);
            }
        }

        //Updates the missiles state by one step
        public override void Tick()
        {
            if (!IsAlive()) return;

            //Move up
            Move(0, -30);

            //Set the missile to dead if it's off screen
            if (Transform.Y < -100)
            {
                SetAlive(false);
            }
        }
    }
}
