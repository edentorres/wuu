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
    public class Fondo
    {
        public Texture2D[] fondo;
        public BoundingBox bb;
        public Texture2D[] cielo;
        public Vector2[] vector;
        public Vector2[] vecielo;
        public ContentManager cm;
        public int cantidad,contador;
        public bool ultfondo = false, primerfondo = false;

        public Fondo(int cantidad, Vector2[]posicion, ContentManager cm, string fondo)
        {
            this.cantidad = cantidad;
            this.fondo = new Texture2D[2];
            this.cielo = new Texture2D[4];
            vector = new Vector2[2];
            vecielo= new Vector2[4];
            for (int i = 0; i < 2; i++)
            {
                
                vector[i] = posicion[i];
                this.fondo[i] = cm.Load<Texture2D>("Fondo/"+fondo);
            }

            for (int i = 0; i < 4; i++)
                this.cielo[i] = cm.Load<Texture2D>("Fondo/cielos/" + fondo);

            vecielo[0] = new Vector2(0, -780);
            vecielo[1] = new Vector2(posicion[1].X, -780);
            vecielo[2] = new Vector2(0, -1560);
            vecielo[3] = new Vector2(posicion[1].X, -1560);

        }
        public void Draw(SpriteBatch sb, bool gameover, Color color, Panda panda)
        {
            if (gameover == false)
            {                if (panda.randomm)
                {
                    RandomColorGenerator r = new RandomColorGenerator();
                    if (1220 > panda.randomtimer)
                    {
                        panda.randomtimer++;
                        Color mycolor = r.RandomColor();
                        for (int i = 0; i < 4; i++)
                            sb.Draw(cielo[i], vecielo[i], mycolor);

                        for (int i = 0; i < 2; i++)
                            sb.Draw(fondo[i], vector[i], mycolor);
                    }
                    else
                    {
                        panda.randomm = false;
                        panda.randomtimer = 0;
                    }
                }
                else
                {
                for (int i = 0; i < 4; i++)
                    sb.Draw(cielo[i], vecielo[i], Color.White);

                for (int i = 0; i < 2; i++)
                    sb.Draw(fondo[i], vector[i], Color.White);
                }
            }
            else
            {
                    for (int i = 0; i < 4; i++)
                        sb.Draw(cielo[i], vecielo[i], color);

                    for (int i = 0; i < 2; i++)
                        sb.Draw(fondo[i], vector[i], color);
            }
        }

        public void Update(Panda panda)
        {
            if (panda.subir3==true)
            {
                vecielo[0].Y = -fondo[0].Height;
                vecielo[1].Y = -fondo[0].Height;
                vecielo[2].Y = -fondo[0].Height*2;
                vecielo[3].Y = -fondo[0].Height*2;
                vector[0].Y = 0;
                vector[1].Y = 0;
            }
            else if (panda.subir == true && panda.vector.Y < 50 && panda.a == true)
            {
                /*for (int i = 0; i < 4; i++)
                    vecielo[i].Y -= panda.jumpspeed;*/
                vecielo[0].Y = vector[0].Y - panda.jumpspeed - fondo[0].Height;
                vecielo[1].Y = vector[0].Y - panda.jumpspeed - fondo[0].Height;
                for (int i = 0; i < 2; i++)
                   vector[i].Y -= panda.jumpspeed;
                
            }
            /*if (0 <= vecielo[3].Y && Keyboard.GetState().IsKeyUp(Keys.Up))
            {
                for (int i = 0; i < 4; i++)
                    vecielo[i].Y += 50;

                for (int i = 0; i < 2; i++)
                    vector[i].Y += 50;
            }*/

            if (contador != -1)
                primerfondo = true;
            else
                primerfondo = false;
            
            if (contador < cantidad - 1)
                ultfondo = true;
            else
                ultfondo= false;

            if (panda.moverresta)
            {
                        for (int i = 0; i < 2; i++)
                            vector[i].X -= 5;
                        for (int i = 0; i < 4; i++)
                            vecielo[i].X -= 5;
                    
                    for (int a = 0; a < 2 && cantidad - 1 != contador; a++)
                    {
                        if (vector[a].X + fondo[a].Width < 0)
                        {
                            int b = a + 1;
                            if (b == 2) b = 0;
                            vector[a].X = vector[b].X + fondo[a].Width;
                            vecielo[a].X = vecielo[b].X + cielo[a].Width;
                            vecielo[a+2].X = vecielo[b+2].X + cielo[a].Width;
                            contador++;
                            break;

                        }
                    
                    }
            }
            if (panda.mover)
            {
                        for (int i = 0; i < 2; i++)
                            vector[i].X += 5;
                        for (int i = 0; i < 4; i++)
                            vecielo[i].X += 5;
                        for (int a = 0; a < 2 && contador != -1; a++)
                        {
                            if (vector[a].X > fondo[a].Width)
                            {
                                int b = a + 1;
                                if (b == 2) b = 0;                                    
                                vector[a].X =vector[b].X -fondo[a].Width;
                                vecielo[a].X = vecielo[b].X - cielo[a].Width;
                                vecielo[a + 2].X = vecielo[b + 2].X - cielo[a].Width;
                                contador--;
                                break;
                            }
                        }
                    }

            /*for (int a = 0; a < 2; a++)
            {
                if (vecielo[a].X > 1024)
                {
                    int b, c, d;
                    switch (a)
                    {
                        case 0:
                            b = 2;
                            c = 1;
                            d = 3;
                            
                    vecielo[a].X = vecielo[b].X - cielo[a].Width;
                    vecielo[c].X = vecielo[d].X - cielo[a].Width;

                            break;
                        case 1:
                            b = 3;
                            c = 0;
                            d = 2;
                    vecielo[a].X = vecielo[b].X - cielo[a].Width;
                    vecielo[c].X = vecielo[d].X - cielo[a].Width;
                            break;
                    }

                    break;
                }
            }
            for (int a = 0; a < 2; a++)
            {
                if (vecielo[a].X + 1024 < 0)
                {
                    int b, c, d;
                    switch (a)
                    {
                        case 0:
                            b = 2;
                            c = 1;
                            d = 3;
                            vecielo[a].X = vecielo[b].X + cielo[a].Width;
                            vecielo[c].X = vecielo[d].X + cielo[a].Width;
                            break;
                        case 1:
                            b = 3;
                            c = 0;
                            d = 2;
                            vecielo[a].X = vecielo[b].X + cielo[a].Width;
                            vecielo[c].X = vecielo[d].X + cielo[a].Width;
                            break;
                    }
                    break;
                }
            }*/
        }
    }  
}
