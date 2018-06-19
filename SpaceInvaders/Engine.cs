using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Engine
    {
        Graphics g;
        Bitmap backBuffer = new Bitmap(3840,2160);
        Graphics backBufferGraphics;
        List<GameObject> gameObjects = new List<GameObject>();
        Mothership mship = new Mothership(0,1800,100,100);

        public Engine( Graphics _g)
        {
            g = _g;
            gameObjects.Add(mship);
            backBufferGraphics = Graphics.FromImage(backBuffer);
        }

        public void SetGraphics(Graphics _g)
        {
            g = _g;
        }

        public void Tick()
        {
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Tick();
            }
        }

        public void KeyHandler(Keys k)
        {
            mship.KeyHandler(k);
        }

        public void Render()
        {
            backBufferGraphics.Clear(Color.Black);
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Render(backBufferGraphics);
            }
            g.DrawImage(backBuffer, 0, 0, 1024, 576);
        }
    }
}
