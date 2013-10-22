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
    class Wall : Obj
    {
         public Wall(Vector2 pos) : 
            base(pos)
        {
            solid = true;
            position = pos;
            spriteName = "wall";

        }
    }
}
