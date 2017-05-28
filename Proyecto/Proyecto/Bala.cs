using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Proyecto
{
    public class Bala
    {
        public Texture2D textura;
        public Texture2D balaarriba;
        public Vector2 vector;
        public Vector2 posoriginal;
        public ContentManager cm;
        public BoundingBox bb;
        public bool dibujar = false;
        public SpriteEffects effect;
        public int b;
        public Bala(Vector2 posicion, ContentManager cm)
        {
            this.vector = posicion;
            this.posoriginal = posicion;
            this.cm = cm;
            this.textura = cm.Load<Texture2D>("Dardo");
            this.balaarriba = cm.Load<Texture2D>("Dardo2");
            bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
        }
        public void Draw(SpriteBatch sb, SpriteEffects effect, bool gameover, Color color)
        {
            this.effect = effect;
            if (dibujar == true)
            {
                if (gameover == true)
                {
                    if (effect == SpriteEffects.FlipVertically)
                        sb.Draw(this.balaarriba, vector, null, color, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                    else
                        sb.Draw(this.textura, vector, null, color, 0f, Vector2.Zero, 1.0f, effect, 0f);
                }
                else
                {
                    if (effect == SpriteEffects.FlipVertically)
                        sb.Draw(this.balaarriba, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                    else
                        sb.Draw(this.textura, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, effect, 0f);
                }
            }
        }
        public void Update(Panda panda)
        {
            if (panda.subir == true && panda.vector.Y < 50 && panda.a == true)
                vector.Y -= panda.jumpspeed;
            else if (panda.subir3 == true && effect != SpriteEffects.FlipVertically)
                vector.Y = posoriginal.Y;
            if ((vector.X >= 1100 || -80 >= vector.X) || (vector.Y <= -150) || 900 <= vector.Y)
                dibujar = false;
            if (dibujar == true)
            {
                if (effect == SpriteEffects.FlipVertically)
                {
                        vector.Y -= 4f;

                    if (panda.moverresta)
                        vector.X -= 5;
                    if (panda.mover)
                        vector.X += 5;
                }
                else
                {
                    if (effect == SpriteEffects.FlipHorizontally)
                        b = 1;
                    else if (effect == SpriteEffects.None)
                        b = -1;
                    if (panda.moverresta)
                    {
                        if (b == 1) 
                            vector.X += 1.3f * b;
                        else
                            vector.X += 9.2f * b;
                    }
                    else if (panda.mover)
                    {
                        if(b==1)
                            vector.X += 9.2f * b;
                        else
                            vector.X += 1.3f * b;
                    }
                    else
                        vector.X += 4.5f * b;
                }
                bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
            }
        }
    }
}

