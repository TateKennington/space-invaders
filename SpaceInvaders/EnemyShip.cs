using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class EnemyShip : GameObject
    {
        /**
        Default constructor.
        */
        public EnemyShip() : base()
        {
            ObjectType = 0;
        }

        /**
        Enemyship constructer.
        x: X position of the enemyship in screen space.
        y: Y position of the enemyship in screen space.
        width: Width of the enemyship in pixels.
        height: Height of the enemyship in pixels.
        _alive: Whether the ship is initially alive(default) or dead.
        */
        public EnemyShip(int x, int y, int width, int height, bool _alive = true) : base(x, y, width, height, _alive)
        {
            ObjectType = 0;
        }
    }
}
