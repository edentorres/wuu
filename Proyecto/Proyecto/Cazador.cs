using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Proyecto
{
    public class Cazador
    {
        public Texture2D textura;
        public Texture2D cazadorarriba;
        public BoundingBox bb;
        public Vector2 vector;
        public Vector2 posoriginal;
        public Vector2 vectorbala;
        public ContentManager cm;
        public SpriteEffects effect;
        public SoundEffect soundbala;
        public Bala[] balas;
        public Random rd=new Random();
        public bool disparo = false, dibujar=true, trasparente=true;
        public int timer, timer1, timer2, timer3, timer4;
        public int puntaje;

        public Cazador(Vector2 posicion, ContentManager cm, SpriteEffects effect)
        {
            this.vector = posicion;
            this.posoriginal = posicion;
            this.cm = cm;
            this.cazadorarriba = cm.Load<Texture2D>("Cazador/3");
            this.textura = cm.Load<Texture2D>("Cazador/1");
            soundbala =cm.Load<SoundEffect>("Sonidos/Shoot");
            bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
            balas = new Bala[5];
            this.effect=effect;
            if (effect==SpriteEffects.None)
                vectorbala= new Vector2(vector.X-40, vector.Y+110);
            else if (effect == SpriteEffects.FlipHorizontally)
                vectorbala = new Vector2(vector.X + 245, vector.Y + 110);
            else
                vectorbala = new Vector2(vector.X +30, vector.Y+30);
            for (int i = 0; i < 5; i++)
                balas[i]= new Bala(vectorbala,this.cm);
        }
        public void Draw(SpriteBatch sb,bool gameover, Color color)
        {
            if (gameover == false)
            {
                if (dibujar == true)
                {
                    if (effect == SpriteEffects.FlipVertically)
                        sb.Draw(this.cazadorarriba, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                    else
                    {
                        sb.Draw(this.textura, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, effect, 0f);
                        Load();
                    }

                    foreach (Bala bala in balas)
                    {
                        if (bala.dibujar == false && timer1 == 0)
                                timer1 = rd.Next(300, 630);
                        else
                        {
                            if (timer1 != 0 && bala.dibujar == false)
                            {
                                if (timer != timer1)
                                    timer++;
                                else
                                {
                                    if (effect == SpriteEffects.None)
                                        bala.vector.X = this.vector.X - 40;
                                    else if (effect == SpriteEffects.FlipHorizontally)
                                        bala.vector.X = this.vector.X + 245;
                                    else
                                    {
                                        bala.vector.Y = this.vector.Y -30;
                                        bala.vector.X = this.vector.X + 50;
                                    }
                                    bala.dibujar = true;
                                    disparo = true;
                                    Load();
                                    timer1 = 0;
                                    timer = 0;
                                }
                            }
                        }
                        bala.Draw(sb, effect, gameover, color);
                    }
                }
                else 
                {
                    if (timer3 > 280 && timer3 % 5 == 0 && trasparente==true)
                    {
                        if (effect == SpriteEffects.FlipVertically)
                        {
                            sb.Draw(this.cazadorarriba, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                            trasparente = false;
                        }
                        else
                        {
                            sb.Draw(this.textura, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, effect, 0f);
                            trasparente = false;
                        }
                    }
                    else if (trasparente == false)
                    {
                        if (effect == SpriteEffects.FlipVertically)
                            sb.Draw(this.cazadorarriba, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                        else
                            sb.Draw(this.textura, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, effect, 0f);

                            timer4++;
                        if (timer4 == 5)
                        {
                            timer4 = 0;
                            trasparente = true;
                        }
                    }
                    else 
                    {
                        if (effect == SpriteEffects.FlipVertically)
                            sb.Draw(this.cazadorarriba, vector, null, Color.White*0.60f, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                        else
                            sb.Draw(this.textura, vector, null, Color.White * 0.60f, 0f, Vector2.Zero, 1.0f, effect, 0f);
                    }
                    foreach (Bala bala in balas)
                        bala.Draw(sb, effect, gameover, color);
                }
            }
            else
            {
                if (effect == SpriteEffects.FlipVertically)
                    sb.Draw(this.cazadorarriba, vector, null, color, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                else
                    sb.Draw(this.textura, vector, null, color, 0f, Vector2.Zero, 1.0f, effect, 0f);
                foreach (Bala bala in balas)
                    bala.Draw(sb, effect, gameover, color);
            }
        }
        public void Update(Panda panda)
        {
            bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));

            foreach (Bala bala in balas)
                bala.Update(panda);

            if (panda.moverresta)
                vector.X -= 5;
            if (panda.mover)
                vector.X += 5; 

            if (dibujar == false)
            {
                timer3++;
                if (timer3 == 350)
                {
                    timer3 = 0;
                    dibujar = true;
                }
            }
            if (panda.subir == true && panda.vector.Y < 50 && panda.a == true)
                vector.Y -= panda.jumpspeed;
            else if (panda.subir3 == true)
                vector.Y = posoriginal.Y;
        }
        public void Load()
        {
            if (disparo == true)
            {
                if (effect == SpriteEffects.None || effect == SpriteEffects.FlipHorizontally)
                {
                    this.textura = cm.Load<Texture2D>("Cazador/2");
                    timer2++;
                    if (timer2 == 10)
                    {
                        this.textura = cm.Load<Texture2D>("Cazador/1");
                        disparo = false;
                        timer2 = 0;
                        if (vector.X >= 1100 || -80 >= vector.X)
                        {
                        }
                        else
                            soundbala.Play();
                    }
                }
                else
                {
                    if (vector.X >= 1100 || -80 >= vector.X)
                    {
                    }
                    else
                    {
                        disparo = false;
                        soundbala.Play();
                    }
                }
            }
        }
    }
}
