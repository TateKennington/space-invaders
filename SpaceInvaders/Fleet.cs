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
        EnemyShip[][] EnemyShips;

        public Fleet(int _x, int _y, int _Rows, int _Columns) : base()
        {
            alive = true;
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

        public override void Tick()
        {
            foreach (EnemyShip[] row in EnemyShips)
            {
                foreach (EnemyShip enemyShip in row)
                {
                    enemyShip.Move(20,0);
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
