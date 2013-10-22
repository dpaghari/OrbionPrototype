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
    class Enemy : Obj
    {
        int health;
        float spd = 2;

        public static Enemy enemy;
          public Enemy(Vector2 pos) : 
            base(pos)
        {
            speed = spd;
            position = pos;
            spriteName = "enemy";
            enemy = this;

        }
          public override void Update()
          {
              rotation = point_direction(position.X, position.Y, Man.man.position.X, Man.man.position.Y);
              base.Update();
          }
          public override void pushTo(float pix, float dir)
          {
              float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
              float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
              newX *= pix;
              newY *= pix;
              if(!collision(new Vector2(newX, newY), new Wall(Vector2.Zero)))
              {
              base.pushTo(pix, dir);
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

    }
}
