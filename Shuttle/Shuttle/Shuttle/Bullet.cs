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
    class Bullet : Obj
    {
         public Bullet(Vector2 pos) : 
            base(pos)
        {
            position = pos;
            spriteName = "block";

        }

        public override void Update()
        {
            if (!alive) return;

            if (collision(Vector2.Zero, new Wall(new Vector2(0, 0))))
            {
                alive = false;
            }
            if (position.X < 0 || position.Y < 0 || position.X > Game1.room.Width || position.Y > Game1.room.Height)
            {
                alive = false;
            }

            base.Update();
        }
    }
}
