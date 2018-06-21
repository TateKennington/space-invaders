using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    /**
    Projectiles fired by the enemies
    */
    class Bomb : GameObject
    {
        /**
        Constructors
        */
        public Bomb() : base(){ }
        public Bomb(int x, int y, int width, int height) : base(x, y, width, height){ }

        public override void OnCollide(GameObject other)
        {
            if (other.ObjectType == eType.Mothership)
            {
                other.Alive = false;
                Alive = false;
            }
        }

        //Updates the missiles state by one step
        public override void Tick(Engine sender)
        {
            if (!Alive) return;

            //Move Down
            Move(0, 30);

            //Set the bomb to dead if it's off screen
            if (Transform.Y > 2160)
            {
                Alive = false;
            }
        }
    }
}
