using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    /**
    Handles all the games functionality, rendering, updating, etc.
    */
    class Engine
    {
        public static Random rand = new Random();
        public static int Width = 3840;
        public static int Height = 2160;

        public enum eState
        {
            MainMenu,
            Playing, 
            Win,
            Loss
        }

        Graphics g; // Form rendering context 
        Bitmap backBuffer; //Backbuffer image
        Graphics backBufferGraphics; //Backbuffer rendering context
        List<GameObject> gameObjects; //List of all gameobjects
        Mothership mship; //Player character
        Fleet fleet;
        Missile[] missiles; //References to missiles in the resource pool
        List<Bomb> bombs;
        Menu main;
        bool paused = false;
        eState currentState;

        /**
        Constructor for the engine.
        _g: The context to render to.
        */
        public Engine(Graphics _g)
        {
            g = _g;
            backBuffer = new Bitmap(Width, Height);
            backBufferGraphics = Graphics.FromImage(backBuffer);
            gameObjects = new List<GameObject>();

            //Initialize the pool of missiles
            missiles = new Missile[15];
            for(int i = 0; i<15; i++)
            {
                missiles[i] = new Missile(0,0,100,100);
                gameObjects.Add(missiles[i]);
            }

            bombs = new List<Bomb>();

            //Test fleet
            fleet = new Fleet(0, 0, 5, 5);
            gameObjects.Add(fleet);
            gameObjects.AddRange(fleet.GetShips());


            //Create the player character
            mship = new Mothership(2000,1800,100,100);
            gameObjects.Add(mship);

            currentState = eState.MainMenu;

            main = new Menu();
            main.Add(new GUILabel("Start", 200, 0, 500, 100), new Menu.Action(e => e.SetState(eState.Playing)));
            main.Add(new GUILabel("Quit", 200, 300, 500, 100), new Menu.Action(e => e.Quit()));

        }

        /**
        Advances the games state by one step.
        */
        public void Tick()
        {
            if (currentState == eState.Playing && !paused)
            {
                //Update each game object
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    gameObjects[i].Tick(this);
                }
                CheckCollisions();

                if (!mship.Alive) currentState = eState.Loss;
                if (fleet.IsDead()) currentState = eState.Win;
            }
        }

        /**
        Checks all game objects pairwise for collisions.
        */
        public void CheckCollisions()
        {
            foreach(GameObject g1 in gameObjects)
            {
                foreach(GameObject g2 in gameObjects)
                {
                    if (g1.Equals(g2)) continue;

                    //If the objects are colliding call their collision handlers
                    if (g1.Collides(g2))
                    {
                        g1.OnCollide(g2);
                        g2.OnCollide(g1);
                    }
                }
            }
        }

        /**
        Process keyboard input.
        k: The keycode of the input key.
        */
        public void KeyHandler(Keys k)
        {
            if (currentState == eState.Playing && k == Keys.Space) paused = !paused;

            if (currentState == eState.MainMenu)
            {
                main.KeyHandler(k, this);
            }
            else if (currentState == eState.Playing && !paused)
            {
                //Pass the event information to the mothership
                mship.KeyHandler(k, this);
            }
        }
        /**
        Render and display the current game state
        */
        public void Render()
        {
            //Clear the backbuffer
            backBufferGraphics.Clear(Color.Black);

            if(currentState == eState.MainMenu)
            {
                //backBufferGraphics.DrawString("Press Space to Start", new Font("sans", 100),
                //                               Brushes.White, 0, 0);
                main.Render(backBufferGraphics);
            }

            else if (currentState == eState.Playing)
            {
                //Draw each gameobject
                foreach (GameObject gameObject in gameObjects)
                {
                    gameObject.Render(backBufferGraphics);
                }
                if (paused)
                {
                    backBufferGraphics.DrawString("Paused", new Font("sans", 100), Brushes.White, 0, 0);
                }
            }

            else if (currentState == eState.Win)
            {
                backBufferGraphics.DrawString("You Win", new Font("sans", 100),
                                               Brushes.White, 0, 0);
            }

            else if (currentState == eState.Loss)
            {
                backBufferGraphics.DrawString("You Lose", new Font("sans", 100),
                                               Brushes.White, 0, 0);
            }
            //Draw the backbuffer to the front buffer
            g.DrawImage(backBuffer, 0, 0, 1024, 576);
        }

        public void SpawnBomb(int x, int y)
        {
            foreach(Bomb bomb in bombs)
            {
                if (!bomb.Alive)
                {
                    bomb.Alive = true;
                    bomb.SetPosition(x, y);
                    return;
                }
            }
            Bomb b = new Bomb(x, y, 100, 100);
            bombs.Add(b);
            gameObjects.Add(b);
        }

        public void SpawnMissile(int x, int y)
        {
            //Consider each missile in the pool
            foreach (Missile missile in missiles)
            {
                //If it is no longer alive claim it
                if (!missile.Alive)
                {
                    missile.Alive = true;
                    missile.SetPosition(x, y);
                    break;
                }
            }
        }

        public void SetState(eState newState)
        {
            currentState = newState;
        }

        public void Quit()
        {
            Console.WriteLine("Do quit things");
            //TODO: Implement quitting
        }
    }
}
