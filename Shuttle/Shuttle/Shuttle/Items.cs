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
    class Items
    {
        public static List<Obj> objList = new List<Obj>();

        public static void Initialize()
        {

            for (int i = 0; i < 5; i++)
            {
                Obj b = new Bullet(new Vector2(0, 0));
                b.alive = false;
                objList.Add(b);

            }

            for (int i = 0; i < 10; i++)
            {
                objList.Add(new Wall(new Vector2(100 + (i * 32), 800)));                    // create blocks that are a block width apart  

            }
                Obj t = new Turret(new Vector2(0, 0));                                      // add turret to world
                Obj o = new Tent(new Vector2(0, 0));                                        // add tent to world
                Obj l = new Lab(new Vector2(0, 0));                                         // add lab to world
                Obj g = new Generator(new Vector2(0, 0));                                   // add generator to world
                l.alive = false;
                g.alive = false;
                o.alive = false;
                t.alive = false;

                objList.Add(t);                             
                objList.Add(o);
                objList.Add(l);
                objList.Add(g);
            


            objList.Add(new Man(new Vector2(50, 50)));                                      // add man to world
            objList.Add(new Enemy(new Vector2(400, 400)));                                  // add an enemy to world
            objList.Add(new Cursor(new Vector2(0, 0)));                                     // add cursor to world

            
        }

        public static void Reset()
        {
            foreach (Obj o in objList)
            {
                o.alive = false;
            }
            foreach (Obj l in objList)
            {
                l.alive = false;
            }
            foreach (Obj g in objList)
            {
                g.alive = false;
            }
        }
    }
}
