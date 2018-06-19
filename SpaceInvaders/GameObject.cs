using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    /**
    Any object in the game engine
    */
    class GameObject
    {
        protected Rectangle Transform; //The objects position and size information
        bool alive; //Life flag

        /**
        Default constructor.
        _alive: Whether or not the object is initially alive or dead(default).
        */
        public GameObject(bool _alive = false)
        {
            Transform = new Rectangle(0, 0, 0, 0);
            alive = _alive;
        }

        /**
        Game Object constructer.
        x: X position of the object in screen space.
        y: Y position of the object in screen space.
        width: Width of the object in pixels.
        height: Height of the object in pixels.
        _alive: Whether the object is initially alive or dead(default).
        */
        public GameObject(int x, int y, int width, int height, bool _alive = false)
        {
            Transform = new Rectangle(x, y, width, height);
            alive = _alive;
        }

        /**
        Updates the gameobject by one step.
        */
        public virtual void Tick() { }

        /**
        Renders the object to a given context.
        g: the context to render to.
        */
        public void Render(Graphics g)
        {
            if (!alive) return;

            g.DrawRectangle(new Pen(Color.White), Transform);
        }

        /**
        Move the object by a discrete number of pixels.
        dx: number of pixels to move in the x direction.
        dy: the number of pixels to move in the y direction.
        */
        public void Move(int dx, int dy)
        {
            Transform.X += dx;
            Transform.Y += dy;
        }

        /**
        Returns the objects life flag.
        */
        public bool IsAlive()
        {
            return alive;
        }
        
        /**
        Sets the objects life flag.
        */
        public void SetAlive(bool _alive)
        {
            alive = _alive;
        }

        /**
        Sets the objects position.
        x: The objects new x position in screen space.
        y: the objects new y position in screen space.
        */
        public void SetPosition(int x, int y)
        {
            Transform.X = x;
            Transform.Y = y;
        }
    }
}
