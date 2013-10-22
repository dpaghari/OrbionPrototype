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
    class Cursor : Obj
    {
        MouseState mouse;

        public Cursor(Vector2 pos)
            : base(pos)
        {
            position = pos;
            spriteName = "cursor";
        }

        public override void Update()
        {
            mouse = Mouse.GetState();
            position = new Vector2(mouse.X, mouse.Y);
            base.Update();
        }
    }
}
