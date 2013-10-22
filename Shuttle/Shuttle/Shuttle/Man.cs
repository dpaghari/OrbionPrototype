using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Shuttle
{
    class Man : Obj
    {
        KeyboardState keyboard;                         //initialize keyboard
        KeyboardState prevKeyboard;

        MouseState mouse;                               //initialize mouse
        
        float spd;                                      //speed of character movement
        float bSpd = 15;
        float gravity = 0.08f;
        float acceleration = 0;

        const int maxAmmo = 5;                          //maximum ammo
        int ammo = 5;                                   //current ammo amount
        int rate = 20;                                  //firerate
        int firingTimer = 0;
        int reloadTimer = 0;
        int reloadTime = 60 * 2;
        bool reloading = false;
        bool building = false;                          // build mode on / off
        bool inProximity = false;

        public static Man man;

        public Man(Vector2 pos)                         // constructor for man
            : base(pos)
        {
            position = pos;
            spd = 2;
            spriteName = "man";
            man = this;
        }

        public override void Update()   
        {
            if (!alive) return;

            keyboard = Keyboard.GetState();                             // get input
            mouse = Mouse.GetState();
            
            /*
            if (!collision(new Vector2(0, -spd), new Wall(new Vector2(0, 0))))
            {
                acceleration += gravity;
                this.position.Y += acceleration;
            }
            else
            {
                acceleration = 0;
                
                this.position.Y =  1;
                  
            }
            */

            if (keyboard.IsKeyDown(Keys.W) && !collision(new Vector2(0, -spd), new Wall(new Vector2(0, 0))))                              // move up
            {
                position.Y -= spd;
                building = false;
                acceleration = 0;
            }
            if (keyboard.IsKeyDown(Keys.A)&& !collision(new Vector2(-spd, 0), new Wall(new Vector2(0, 0))))                             // move left
            {
                position.X -= spd;
                building = false;
            }
            if (keyboard.IsKeyDown(Keys.S)&& !collision(new Vector2(0, spd), new Wall(new Vector2(0, 0))))                             // move down
            {
                position.Y += spd;
                building = false;
            }
            if (keyboard.IsKeyDown(Keys.D)&& !collision(new Vector2(spd, 0), new Wall(new Vector2(0, 0))))                             // move right
            {
                position.X += spd;
                building = false;
            }
            firingTimer++;
            if (mouse.LeftButton == ButtonState.Pressed)                // if left clicking shoot a bullet
            {
                CheckShooting();
            }
            if (keyboard.IsKeyDown(Keys.B))                             // build mode
            {
                building = true;
            }
            if (building == true && keyboard.IsKeyDown(Keys.L))         // build a laboratory
            {
                buildLab();
                building = false;

            }
            if (building == true && keyboard.IsKeyDown(Keys.T))         // build a tent
            {
                buildTent();
                building = false;

            }
            if (building == true && keyboard.IsKeyDown(Keys.G))         // build a generator
            {
                buildGenerator();
                building = false;

            }
            if (building == true && keyboard.IsKeyDown(Keys.U))         // build a turret
            {
                buildTurret();
                building = false;

            }
            if (keyboard.IsKeyDown(Keys.R))                             // reload
            {
                reloading = true;
            }

            CheckProximity();                                           // check if there are nearby structures 
            CheckReload();

            rotation = point_direction(position.X, position.Y, mouse.X, mouse.Y);       // set direction of player and mouses
            prevKeyboard = keyboard;

            base.Update();
        }

        private void CheckProximity()                                          // function for checking if character is near structures
        {
            foreach (Obj o in Items.objList){
                if ((o.GetType() == typeof(Lab) || o.GetType() == typeof(Tent) || o.GetType() == typeof(Generator))  && o.alive)
                {
                    if (point_distance(position.X, position.Y, o.position.X, o.position.Y) < 20)
                    {
                        inProximity = true;
                        break;

                    }
                    else
                    {
                        inProximity = false;
                        
                    }
                }
            }
            
        }
        private void buildTurret()                                                // function for building a generator
        {
            foreach (Obj o in Items.objList)
            {
                if (o.GetType() == typeof(Turret) && !o.alive)
                {
                    o.position = position;
                    o.alive = true;
                    break;
                }
            }

        }
        private void buildGenerator()                                                // function for building a generator
        {
            foreach (Obj o in Items.objList)
            {
                if (o.GetType() == typeof(Generator) && !o.alive)
                {
                    o.position = position;
                    o.alive = true;
                    break;
                }
            }

        }
        private void buildLab()                                                // function for building a lab
        {
            foreach (Obj o in Items.objList)
            {
                if (o.GetType() == typeof(Lab) && !o.alive)
                {
                    o.position = position;
                    o.alive = true;
                    break;
                }
            }
           
        }
        private void buildTent()                                                // function for building a tent
        {
            foreach (Obj o in Items.objList)
            {
                if (o.GetType() == typeof(Tent) && !o.alive)
                {
                    o.position = position;
                    o.alive = true;
                    break;
                }

            }
        }
        private void CheckShooting() 
        {
            if (firingTimer > rate && ammo > 0)                                 // spaces out bullets so you don't spam
            {
                firingTimer = 0;
                Shoot();
            }
        }

        private void CheckReload()                                              // reload function
        {
            if (reloading)
                reloadTimer++;

            if (reloadTimer > reloadTime)
            {
                ammo = maxAmmo;
                reloadTimer = 0;
                reloading = false;
            }
        }

        private void Shoot()                                                    // shoot function
        {
            ammo--;

            foreach (Obj o in Items.objList)
            {
                if (o.GetType() == typeof(Bullet) && !o.alive)
                {
                    o.position = position;
                    o.rotation = rotation;
                    o.speed = bSpd;
                    o.updateArea();
                    o.alive = true;
                    break;
                }
            }
        }

        private float point_direction(float x, float y, float x2, float y2)         // returns the angle of direction between two objects
        {
            float diffx = x - x2;
            float diffy = y - y2;
            float adj = diffx;
            float opp = diffy;
            float tan = opp / adj;
            float res = MathHelper.ToDegrees((float)Math.Atan2(opp, adj));
            res = (res - 180) % 360;
            if (res < 0) { res += 360; }
            return res;
        }
        private double point_distance(double x, double y, double x2, double y2)     // returns distance between two objects
        {
            double diffx = x - x2;
            double diffy = y - y2;
            double dist = Math.Sqrt(Math.Pow(diffx, 2) + Math.Pow(diffy, 2));
            return dist;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Game1.font, "Ammo: " + ammo, Vector2.Zero, Color.White);
            if (inProximity == true)
            {
                spriteBatch.DrawString(Game1.font, "Lol", new Vector2(position.X, position.Y - 100), Color.White);
            }
            if (reloading)
            {
                spriteBatch.DrawString(Game1.font, "Reloading...", new Vector2(position.X - 50, position.Y - 60), Color.White);
            }
            
            base.Draw(spriteBatch);
        }
    }
}
