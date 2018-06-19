﻿using System;
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
        Graphics g; // Form rendering context 
        Bitmap backBuffer; //Backbuffer image
        Graphics backBufferGraphics; //Backbuffer rendering context
        List<GameObject> gameObjects; //List of all gameobjects
        Mothership mship; //Player character

        /**
        Constructor for the engine.
        _g: The context to render to.
        */
        public Engine(Graphics _g)
        {
            g = _g;
            backBuffer = new Bitmap(3840, 2160);
            backBufferGraphics = Graphics.FromImage(backBuffer);
            gameObjects = new List<GameObject>();

            //Initialize the pool of missiles
            Missile[] missiles = new Missile[15];
            for(int i = 0; i<15; i++)
            {
                missiles[i] = new Missile(0,0,100,100);
                gameObjects.Add(missiles[i]);
            }

            //Create the player character
            mship = new Mothership(2000,1800,100,100,missiles);
            gameObjects.Add(mship);
        }

        /**
        Advances the games state by one step.
        */
        public void Tick()
        {
            //Update each game object
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.Tick();
            }
        }

        /**
        Process keyboard input.
        k: The keycode of the input key.
        */
        public void KeyHandler(Keys k)
        {
            //Pass the event information to the mothership
            mship.KeyHandler(k);
        }

        /**
        Render and display the current game state
        */
        public void Render()
        {
            //Clear the backbuffer
            backBufferGraphics.Clear(Color.Black);

            //Draw each gameobject
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Render(backBufferGraphics);
            }

            //Draw the backbuffer to the front buffer
            g.DrawImage(backBuffer, 0, 0, 1024, 576);
        }
    }
}
