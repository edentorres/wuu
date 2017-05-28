using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Proyecto
{
    public class Coin
    {
        public Texture2D textura;
        public Vector2 vector2;
        public Vector2 posoriginal;
        public ContentManager cm;
        public BoundingBox bb;
        public bool dibujar = true;
        public int contador=1;
        public int timer=1;
        public int saltar=-5;
        public int contador2;
        public SoundEffect soundcoin;
        

        public Coin(Vector2 posicion, ContentManager cm)//,int contador)
        {
            this.vector2 = posicion;
            this.posoriginal = posicion;
            soundcoin = cm.Load<SoundEffect>("Sonidos/Coin");
            //this.contador = contador;
            this.cm = cm;
            for (int i = 4; i > 0; i--)
                this.textura = cm.Load<Texture2D>("Monedas/" + Convert.ToString(i));

            bb = new BoundingBox(new Vector3(vector2, 0), new Vector3(vector2.X + textura.Width, vector2.Y + textura.Height, 0));
        }
        public void Draw(SpriteBatch sb, bool gameover, Color color)
        {
            if (dibujar == true)
            { 
                if (gameover==false)
                sb.Draw(textura, vector2, Color.White);
                else
                sb.Draw(textura, vector2, color);
            }
        }
        public void Load()
        {
           timer++;
            if (timer % 8 == 0)
            {
                contador++;
                if (contador == 5)
                    contador = 1;
                this.textura = cm.Load<Texture2D>("Monedas/" + Convert.ToString(contador));
            }
        }
        public void Update(Panda panda)
        {
            if (dibujar == true)
            {
                if (panda.subir == true && panda.vector.Y < 50 && panda.a == true)
                    vector2.Y -= panda.jumpspeed;

                else if (panda.subir3 == true)
                    vector2.Y = posoriginal.Y;

                Load();
                contador2++;
                if (saltar != 6)
                {
                    if (contador2 % 8 == 0)
                    {
                        vector2.Y += saltar;
                        saltar++;
                    }
                }
                else
                    saltar = -5;

                bb = new BoundingBox(new Vector3(vector2, 0), new Vector3(vector2.X + textura.Width, vector2.Y + textura.Height, 0));

                        if (panda.moverresta)
                        {
                            vector2.X -= 5;
                        }

                        if (panda.mover)
                        {
                            vector2.X += 5;
                        }
            }
        }
    }
}
