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
    class Tent : Obj
    {
        public Tent(Vector2 pos) : 
            base(pos)
        {
            position = pos;
            spriteName = "tent";

        }

        public override void Update()
        {
            if (position.X < 0 || position.Y < 0 || position.X > Game1.room.Width || position.Y > Game1.room.Height)
            {
                alive = false;
            }

            base.Update();
        }

      
    }
}
