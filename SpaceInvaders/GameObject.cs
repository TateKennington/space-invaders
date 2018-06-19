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

        public GameObject(bool _alive = false)
        {
            Transform = new Rectangle(0, 0, 0, 0);
            alive = _alive;
        }

        public GameObject(int x, int y, int width, int height, bool _alive = false)
        {
            Transform = new Rectangle(x, y, width, height);
            alive = _alive;
        }

        public virtual void Tick() { }

        public void Render(Graphics g)
        {
            if (!alive) return;

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
