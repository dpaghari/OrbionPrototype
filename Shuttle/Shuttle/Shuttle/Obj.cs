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
    class Obj
    {
        public Vector2 position;
        public float rotation = 0.0f;
        public Texture2D spriteIndex;
        public string spriteName = "block";
        public float speed = 0.0f;
        public float scale = 1.0f;
        public Rectangle area;
        public bool alive = true;
        public bool solid = false;

        public Obj(Vector2 pos)
        {
            position = pos;
        }

        public Obj()
        {
        }
        public virtual void Update()
        {
            if (!alive) return;

            updateArea();
            pushTo(speed, rotation);
        }
        public virtual void LoadContent(ContentManager content)
        {
            spriteIndex = content.Load<Texture2D>("sprites\\" + this.spriteName);
            area = new Rectangle(0, 0, spriteIndex.Width, spriteIndex.Height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            if (!alive) return;
            
            Vector2 center = new Vector2(spriteIndex.Width / 2, spriteIndex.Height / 2);

            spriteBatch.Draw(spriteIndex, position, null, Color.White, MathHelper.ToRadians(rotation), center, scale, SpriteEffects.None, 0);
        }

        public virtual void pushTo(float pix, float dir)
        {
            float newX = (float)Math.Cos(MathHelper.ToRadians(dir));
            float newY = (float)Math.Sin(MathHelper.ToRadians(dir));
            position.X += pix * (float)newX;
            position.Y += pix * (float)newY;
        }

        public void updateArea()
        {
            area.X = (int)position.X - (spriteIndex.Width / 2);
            area.Y = (int)position.Y - (spriteIndex.Height / 2);

        }
        public bool collision(Vector2 pos, Obj obj)
        {
            Rectangle newArea = new Rectangle(area.X, area.Y, area.Width, area.Height);
            newArea.X += (int)pos.X;
            newArea.Y += (int)pos.Y;
            foreach (Obj o in Items.objList)
            {
                if (((o.GetType() == obj.GetType())&& o.solid))
                {
                    if(o.area.Intersects(newArea))
                    {
                    return true;
                    }
                }
            }
            return false;
        }
    }
}
