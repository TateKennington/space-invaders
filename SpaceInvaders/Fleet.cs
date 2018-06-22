using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    /**
    Game object for managing multiple enemy ships.
    */
    class Fleet : GameObject
    {
        int x;
        int y;
        int Rows;
        int Columns;
        int Direction;
        EnemyShip[][] EnemyShips;

        public Fleet(int _x, int _y, int _Rows, int _Columns) : base()
        {
            Direction = 1;
            Alive = true;
            ObjectType = eType.Enemy;
            x = _x;
            y = _y;
            Rows = _Rows;
            Columns = _Columns;
            EnemyShips = new EnemyShip[Columns][];
            for(int i = 0; i<Columns; i++)
            {
                EnemyShips[i] = new EnemyShip[Rows];
                for(int j = 0; j<Rows; j++)
                {
                    EnemyShips[i][j] = new EnemyShip(x + 200 * i, y + 200 * j, 100, 100);
                }
            }
            for(int i = 0; i<Columns; i++)
            {
                EnemyShips[i][Rows-1].CanFire = true;
            }
        }

        public List<GameObject> GetShips()
        {
            List<GameObject> res = new List<GameObject>();
            foreach (EnemyShip[] row in EnemyShips)
            {
                foreach (EnemyShip enemyShip in row)
                {
                    res.Add(enemyShip);
                }
            }
            return res;
        }

        public override void Tick(Engine sender)
        {
            int left = 4000, right = 0;
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (EnemyShips[i][j].Alive)
                    {
                        left = Math.Min(left, x + i * 200);
                        right = Math.Max(right, x + i * 200 + 100);
                    }
                }
            }
            if (left<0 || right > 3840) Direction *= -1;
            foreach (EnemyShip[] row in EnemyShips)
            {
                foreach (EnemyShip enemyShip in row)
                {
                    enemyShip.Move(Direction*20,0);
                }
            }
            x += Direction*20;

            //Set the lowest living ships to fire
            for(int i = 0; i<Columns; i++)
            {
                for(int j = Rows-1; j>=0; j--)
                {
                    if (EnemyShips[i][j].Alive)
                    {
                        EnemyShips[i][j].CanFire = true;
                        break;
                    }
                    else
                    {
                        EnemyShips[i][j].CanFire = false;
                    }
                }
            }
        }

        //public override void Render(Graphics g)
        //{
        //    foreach (EnemyShip[] row in EnemyShips)
        //    {
        //        foreach (EnemyShip enemyShip in row)
        //        {
        //            enemyShip.Render(g);
        //        }
        //    }
        //}

        //public override bool Collides(GameObject other)
        //{
        //    foreach (EnemyShip[] row in EnemyShips)
        //    {
        //        foreach (EnemyShip enemyShip in row)
        //        {
        //            if (enemyShip.Collides(other)) return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
