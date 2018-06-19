using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameObject
    {
        protected Rectangle Transform;
        bool alive;

        public GameObject()
        {
            Transform = new Rectangle(0, 0, 0, 0);
            alive = false;
        }

        public GameObject(int x, int y, int width, int height)
        {
            Transform = new Rectangle(x, y, width, height);
            alive = false;
        }

        public virtual void Tick() { }

        public void Render(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.White), Transform);
        }

        public void Move(int dx, int dy)
        {
            Transform.X += dx;
            Transform.Y += dy;
        }

        public bool IsAlive()
        {
            return alive;
        }
        
        public void SetAlive(bool _alive)
        {
            alive = _alive;
        }

        public void SetPosition(int x, int y)
        {
            Transform.X = x;
            Transform.Y = y;
        }
    }
}
