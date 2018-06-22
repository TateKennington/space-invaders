using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class EnemyShip : GameObject
    {

        public bool CanFire { get; set; }

        /**
        Default constructor.
        */
        public EnemyShip() : base()
        {
            ObjectType = eType.Enemy;
            CanFire = false;
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
            ObjectType = eType.Enemy;
            CanFire = false;
        }

        public override void Tick(Engine sender)
        {
            if(CanFire && Engine.rand.Next(100) == 0)sender.SpawnBomb(Transform.X, Transform.Y + Transform.Height);
        }
    }
}
