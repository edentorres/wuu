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
    public class Piso
    {
        public Texture2D textura;
        public BoundingBox bb;
        public Vector2 vector;
        public ContentManager cm;
        public Vector2 posoriginal ,final;
        public bool trasparente=false,colisiona=false;
        public int timer, timer2, b=1, movio;
        public float pandamueve;

        public Piso(Vector2 posicion, ContentManager cm, string name)
        {
            this.vector = posicion;
            this.posoriginal=this.vector;
            this.cm = cm;
            this.textura = cm.Load<Texture2D>(name);
            bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
        }
        public void Draw(SpriteBatch sb, bool gameover, Color color)
        {
            if (gameover == false)
            {
                if (trasparente == true)
                {
                    sb.Draw(textura, vector, Color.White * 0.3f);
                    timer++;
                    if (timer == 120)
                    {
                        timer = 0;
                        trasparente = false;
                    }
                }
                else
                    sb.Draw(textura, vector, Color.White);
            }
            else
                sb.Draw(textura, vector, color);
        }
        public void Move(Panda panda)
        {
            if (panda.pisomove)
            {

            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (panda.moverresta)
                    {
                        vector.X += 2.5f * b;
                    }

                    else
                    {
                        vector.X += 2.5f * b;
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (panda.mover)
                    {
                        vector.X += 2.5f * b;
                    }
                    else
                    {
                        vector.X += 2.5f * b;
                    }
                }
                else
                {
                    vector.X += 2.9f * b;
                }
            }
        }
        public void Update(Panda panda, bool espiso, Vector2 principio, Vector2 final)
        {
            if (espiso == false)
            {
                if (panda.moverresta)
                    vector.X -= 5;
                if (panda.mover)
                    vector.X += 5; 
            }
            if (panda.subir3 == true)
                vector.Y = posoriginal.Y;
            else if (panda.subir == true && panda.vector.Y < 50 && panda.a == true)
                vector.Y -= panda.jumpspeed;

                    if (espiso==true)
                    {
                       /* if (panda.bb.Intersects(bb)&&panda.vector.Y + panda.textura.Height - 65 < vector.Y)
                        {
                        }
                        else
                        {*/
                            if (panda.moverresta)
                                vector.X -= 5;
                            if (panda.mover)
                                vector.X += 5;
                        //}
                        if (vector.X >= 4400 || -3350 >= vector.X)
                        {
                        }
                        else
                        {
                            Move(panda);
                            if (vector.X-50<=principio.X)
                            {
                                b = 1;
                                Move(panda);
                            }
                            else if (vector.X >=final.X+300)
                            {
                                b = -1;
                                Move(panda);
                            }
                        }
                    }
                    bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
        } 
    }
}
