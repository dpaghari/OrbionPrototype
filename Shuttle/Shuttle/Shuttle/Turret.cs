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
    class Turret : Obj
    {
         public Turret(Vector2 pos) : 
            base(pos)
        {
            
            position = pos;
            spriteName = "turret";

        }
          public override void Update()
          {
              rotation = point_direction(position.X, position.Y, Enemy.enemy.position.X, Enemy.enemy.position.Y);
              base.Update();
          }
         float point_direction(float x, float y, float x2, float y2)         // returns the angle of direction between two objects
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
    }
}
