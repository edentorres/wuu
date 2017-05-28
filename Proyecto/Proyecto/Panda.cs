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
    public class Panda
    {
        public Texture2D textura;
        public BoundingBox bb;
        public Vector2 vector;
        public ContentManager cm;
        public int timer = 0, timer2, timer3, tiempojetpack,tiempovelocidad, jetpacktime, randomtimer;
        public SpriteEffects effect;
        public SoundEffect soundjump;
        public SoundEffect soundhurt;
        public SoundEffect soundcaza;
        public SoundEffect soundpower;
        public bool jumping = false, fall = true, perdiovida = false, gameover = false, secondjump = false, keyup = false, trasparente=true, subir=false, subir2=true, subir3=false, a=false, jetpack=false, camina=false,cae=false,mover=false,moverresta=false,pisomove=false, randomm=false;
        int contador = 1;
        public float startY, jumpspeed = 0, speed = 16, multi = 0;
        Vector2 v2 = new Vector2(-100000, -100000);

        public Panda(Vector2 posicion, ContentManager cm)
        {
            for (int i = 9; i > 0; i--)
                this.textura = cm.Load<Texture2D>("Panda/" + Convert.ToString(i)); //cargo las imagenes
            this.vector = posicion;
            this.cm = cm;
            soundjump = cm.Load<SoundEffect>("Sonidos/Jump");
            soundhurt = cm.Load<SoundEffect>("Sonidos/Hurt");
            soundcaza = cm.Load<SoundEffect>("Sonidos/cazador");
            soundpower = cm.Load<SoundEffect>("Sonidos/power");
            jetpacktime = 300;
            bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0)); //creo el boundingBox
        }
        public void Colision(Pisos pisos, Fondo fondo)
        {
            if (jumping == false)
            {
                foreach (Piso piso in pisos.plataformas)
                {
                    if (bb.Intersects(piso.bb) && vector.Y + textura.Height - 65 < piso.vector.Y && ((effect == SpriteEffects.None && vector.X + textura.Width - 20 < piso.vector.X + piso.textura.Width + 75) || effect == SpriteEffects.FlipHorizontally && piso.vector.X - 40 < vector.X + textura.Width))
                    {
                        fall = true;
                        vector.Y = piso.vector.Y - textura.Height;
                        break;
                    }
                    else
                        fall = false;
                }
                foreach (Piso piso in pisos.move)
                {
                    if (bb.Intersects(piso.bb) && vector.Y + textura.Height - 45 < piso.vector.Y && ((effect == SpriteEffects.None && vector.X + textura.Width < piso.vector.X + piso.textura.Width + 75) || effect == SpriteEffects.FlipHorizontally && piso.vector.X < vector.X + textura.Width))
                    {
                        fall = true;
                        vector.Y = piso.vector.Y - textura.Height;

                        break;
                    }
                    else
                    {
                        fall = false;
                    }
                }
                foreach (Piso piso in pisos.nubes)
                {
                    if (piso.trasparente==false && bb.Intersects(piso.bb) && vector.Y + textura.Height - 45 < piso.vector.Y && ((effect == SpriteEffects.None && vector.X + textura.Width - 20 < piso.vector.X + piso.textura.Width + 75) || effect == SpriteEffects.FlipHorizontally && piso.vector.X - 40 < vector.X + textura.Width))
                    {
                        if (piso.timer2 == 30)
                        {
                            piso.trasparente = true;
                            fall = false;
                        }
                        else
                        {
                            fall = true;
                            vector.Y = piso.vector.Y - textura.Height;
                            piso.timer2++;
                        }
                        break;
                    }
                    else
                    {
                        piso.timer2 = 0;
                        fall = false;
                    }
                }
                foreach (Piso pis in pisos.piso)
                {
                        if (bb.Intersects(pis.bb))
                        {
                            fall = true;
                            vector.Y = pis.vector.Y - textura.Height;
                            break;
                        }
                }
            }
            if (jetpack)
            {
                foreach (Piso piso in pisos.nubes)
                {
                    if (piso.trasparente == false && bb.Intersects(piso.bb) && vector.Y + textura.Height - 45 < piso.vector.Y && ((effect == SpriteEffects.None && vector.X + textura.Width - 20 < piso.vector.X + piso.textura.Width + 75) || effect == SpriteEffects.FlipHorizontally && piso.vector.X - 40 < vector.X + textura.Width))
                    {
                        if (piso.timer2 == 30)
                            piso.trasparente = true;
                        else
                            piso.timer2++;
                        break;
                    }
                    else
                        piso.timer2 = 0;
                }
            }
        }
        public void Fall(Pisos pisos, Fondo fondo)//frena la caida
        {
            if (jumping == true)
                fall = true;

            foreach (Piso piso in pisos.plataformas)
            {
                if (bb.Intersects(piso.bb) && vector.X > piso.vector.X - textura.Width && vector.Y + textura.Height - 65 < piso.vector.Y)
                {
                        fall = true;
                        subir3 = false;
                        vector.Y = piso.vector.Y - textura.Height;
                        speed = 16;
                        camina = true;
                        multi = 0;
                        break;
                }
            }
            foreach (Piso pis in pisos.piso)
            {
                if (bb.Intersects(pis.bb))
                {
                    fall = true;
                    subir = false;
                    subir3 = false;
                    speed = 16;
                    vector.Y = pis.vector.Y - textura.Height;
                    camina = true;
                    multi = 0;
                    break;
                }
            }
           foreach (Piso pis in pisos.nubes)
            {
                if (bb.Intersects(pis.bb) && pis.trasparente == false && vector.Y + textura.Height - 45 < pis.vector.Y)
                {
                    fall = true;
                    subir = false;
                    subir3 = false;
                    speed = 16;
                    vector.Y = pis.vector.Y - textura.Height;
                    camina = true;
                    multi = 0;
                    break;
                }
            }
            foreach (Piso pis in pisos.move)
            {
                if (bb.Intersects(pis.bb) && vector.Y + textura.Height - 65 < pis.vector.Y)
                {
                    fall = true;
                    subir3 = false;
                    speed = 16;
                    vector.Y = pis.vector.Y - textura.Height;
                    camina = true;
                    multi = 0;
                    break;
                }
            }
            if (fall == false)
            {
                if (fondo.vector[0].Y <= 10)
                {
                    vector.Y += 16;
                    speed += 5;
                    jumpspeed = 0;
                    //fondo.vector[0].Y = 0;
                    subir2 = true;
                    subir = false;
                    subir3 = true;
                    camina = false;
                    multi = 0;
                }
                else if (fondo.vector[0].Y > 10 )
                {
                    jumpspeed = 16;
                    subir = true;
                    subir3 = false;
                }
            }
        }
        public void Jetpack(Fondo fondo)
        {
            jumpspeed = -8;
            jumping = true;
            startY = vector.Y;
            secondjump = false;
            keyup = false;
            subir = true;
            subir3 = false;
        }
        public void Load(Pisos pisos)
        {
            if (jumping == false)
            {
                if (!jetpack && timer%5==0)
                {
                        contador++;
                        if (contador == 9)
                            contador = 1;
                        this.textura = cm.Load<Texture2D>("Panda/" + Convert.ToString(contador));//cambia las imagenes del panda
                }
            }
            if (jetpack)//cambia las imagenes en el jetpack
            {
                    if (camina)
                    {
                        if (timer % 5 == 0)
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.Left))
                            {
                                contador++;
                                if (contador > 3) contador = 2;
                                else if (contador==1) contador = 2;
                                this.textura = cm.Load<Texture2D>("Panda/Jetpack/" + Convert.ToString(contador));
                            }
                            else
                            {
                                contador++;
                                if (contador > 2) contador = 1;
                                //else if (contador == 2) contador++;
                                this.textura = cm.Load<Texture2D>("Panda/Jetpack/" + Convert.ToString(contador));
                            }
                            }
                            return;
                        }

                if (timer % 8 == 0)
                {
                    contador++;
                    if (contador > 2) contador = 1;
                    this.textura = cm.Load<Texture2D>("Panda/Jetpack/"+Convert.ToString(contador));
                }
            }
        }
        public void Moveleft(Pisos pisos, Fondo fondo)
        {
            if (vector.X - 5 >= 0)
            {
                vector.X -= 5;
                effect = SpriteEffects.FlipHorizontally;
                if(!jetpack)
                Load(pisos);
                Colision(pisos, fondo);
            }
        }
        public void Moveright(Pisos pisos, Fondo fondo)
        {
            if (vector.X + 5 + textura.Width <= Game1.Instance.GraphicsDevice.DisplayMode.Width)
            {
                vector.X += 5;
                effect = SpriteEffects.None;
                if(!jetpack)
                Load(pisos);
                Colision(pisos, fondo);
            }
        }
        public void Startjump()//valores cuando empieza un salto
        {
            jumping = true;
            jumpspeed = -16;
            startY = vector.Y;
            secondjump = false;
            keyup = false;
            subir = true;
            subir3 = false;
            this.textura = cm.Load<Texture2D>("Panda/9");
            soundjump.Play();
        }
        public void Jump(Pisos pisos, Fondo fondo)
        {
            /*if (jetpack)
            {
                if (jumpspeed > -8)
                jumpspeed-=4;
            }*/

            if (jumping == true)
            {
                fall = true;
                    if (vector.Y < 50)
                    {
                        if (subir == true)
                        {
                            a = true;
                            if (fondo.vecielo[1].Y < 0)
                            {
                                a = true;
                            }
                            else
                            {
                                a = false;
                                if (0 <= fondo.vecielo[1].Y && Keyboard.GetState().IsKeyUp(Keys.Up))
                                {
                                    a = true;
                                    fondo.vecielo[1].Y = -10;
                                    fondo.vecielo[0].Y = -10;
                                    
                                }
                            }
                            if (jumpspeed < 0)
                            {
                                jumpspeed += 1;
                                subir = true;
                                subir2 = false;
                            }
                            else if (jumpspeed >= 0)
                            {
                                jumpspeed += 1;
                                subir2 = false;
                            }

                            if (jumpspeed > 0 && fondo.vector[0].Y <= 0)
                            {
                                subir2 = true;
                                subir = false;
                            }
                        }
                    }
                    
                    if (subir2 == true && fondo.vector[0].Y <= 0)
                    {
                        vector.Y += jumpspeed;
                        jumpspeed += 1;
                        subir3 = false;
                    }
                if (jumpspeed > 0)
                {

                    foreach (Piso piso in pisos.plataformas)
                    {
                        if (bb.Intersects(piso.bb) &&vector.X > piso.vector.X - textura.Width && (vector.Y) + textura.Height - 65 < piso.vector.Y) 
                        {
                                jumping = false;
                                subir = false;
                                jumpspeed = -16;
                                secondjump = false;
                                keyup = false;
                                subir3 = false;
                                vector.Y = piso.vector.Y - textura.Height;
                                break;
                        }
                    }
                    foreach (Piso piso in pisos.move)
                    {
                        if (bb.Intersects(piso.bb)&&vector.X > piso.vector.X - textura.Width && (vector.Y) + textura.Height - 65 < piso.vector.Y)
                        {
                                jumping = false;
                                subir = false;
                                jumpspeed = -16;
                                secondjump = false;
                                keyup = false;
                                subir3 = false;
                                vector.Y = piso.vector.Y - textura.Height;
                                break;
                        }
                    }
                    foreach (Piso piso in pisos.nubes)
                    {
                        if (bb.Intersects(piso.bb)&&piso.trasparente==false && vector.X > piso.vector.X - textura.Width && (vector.Y) + textura.Height - 65 < piso.vector.Y)
                        {
                                jumping = false;
                                subir = false;
                                jumpspeed = -16;
                                secondjump = false;
                                keyup = false;
                                subir3 = false;
                                vector.Y = piso.vector.Y - textura.Height;
                                break;
                        }
                    }
                    foreach (Piso pis in pisos.piso)
                    {
                        if (bb.Intersects(pis.bb)&&vector.Y + textura.Height > pis.vector.Y)
                        {
                                jumping = false;
                                subir = false;
                                jumpspeed = -16;
                                secondjump = false;
                                keyup = false;
                                subir3 = false;
                                vector.Y = pis.vector.Y - textura.Height;
                                break;
                        }
                    }
                }
            }
        }
        public void Update(Fondo fondo, Coins coins, Pisos pisos, Cazadores cazadores, ref int vidas, Poderes poderes, int cantidadmonedas)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.F) && Keyboard.GetState().IsKeyDown(Keys.E))
                randomm = true;
            mover = false;
            moverresta = false;
            pisomove = false;
            if (40 > vector.Y)
                vector.Y++;
            if (vidas != 0)
            {
                if (fall == false)
                    a = true;
                else
                    a = false;
                if (jetpack)
                {
                    tiempojetpack++;
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        multi = 0;
                        camina = false;

                            Jetpack(fondo);                           
                            Jump(pisos, fondo);
                           
                    }
                    else
                    {
                        Jetpack(fondo);
                        jumpspeed = 8+multi;
                        multi+=0.25f;
                        subir2 = true;
                        Jump(pisos, fondo);
                        camina = false;
                        Fall(pisos, fondo);
                    }

                    if (tiempojetpack == jetpacktime)
                    {
                        jetpack = false;
                        jetpacktime = 300;
                    }
                    Load(pisos);
                }
                else
                {
                    if (jumping == true && Keyboard.GetState().IsKeyDown(Keys.Up) && secondjump == false && keyup == true)
                    {
                        secondjump = true;
                        jumpspeed -= 11;
                        soundjump.Play();

                    }
                    if (jumping == true)
                    {
                        Jump(pisos, fondo);
                        if (Keyboard.GetState().IsKeyUp(Keys.Up) && secondjump == false)
                            keyup = true;
                    }
                    else
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                            Startjump();
                        else
                            this.textura = cm.Load<Texture2D>("Panda/" + Convert.ToString(contador));
                    }
                }
                timer++;
                Colision(pisos,fondo);
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (vector.X >= 550 && fondo.ultfondo == true&& pisomove==false)
                    {
                        if(!jetpack)
                        Load(pisos);
                        Colision(pisos, fondo);
                        moverresta = true;
                    }
                    else
                        Moveright(pisos, fondo);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (350 >= vector.X && fondo.primerfondo == true &&pisomove==false)
                    {
                        if (!jetpack)
                        Load(pisos);
                        Colision(pisos, fondo);
                        mover = true;
                    }
                    else
                        Moveleft(pisos, fondo);
                }

                foreach (Coin cn in coins.coins)
                {
                    if (cn.dibujar == true)
                    {
                        if (bb.Intersects(cn.bb))
                        {
                            if (vector.Y + textura.Height - 40 < cn.vector2.Y + 60 && (vector.X + textura.Width > cn.vector2.X + cn.textura.Width && effect == SpriteEffects.None) || cn.vector2.X > vector.X && effect == SpriteEffects.FlipHorizontally)
                            {
                                cn.dibujar = false;
                                coins.puntaje += 1;
                                cn.soundcoin.Play();
                            }
                        }
                    }
                }
                if (bb.Intersects(poderes.llave.bb) && coins.puntaje == cantidadmonedas &&poderes.llave.dibujar==true)
                {
                    if ((vector.X + textura.Width > poderes.llave.vector.X + poderes.llave.textura.Width && effect == SpriteEffects.None) || poderes.llave.vector.X+ poderes.llave.textura.Width-50 > vector.X && effect == SpriteEffects.FlipHorizontally)
                    {
                        if (Game1.nivel == 3)
                            poderes.llave.dibujar = false;
                        else
                        {
                            Game1.cambionivel = true;
                            poderes.llave.dibujar = false;
                        }

                        soundpower.Play();
                    }
                }
                foreach (Poder vida in poderes.vidas)
                {
                    if (vida.dibujar == true)
                    {
                        if (bb.Intersects(vida.bb) && vector.Y + textura.Height - 40 < vida.vector.Y + 60 && Game1.nivel == 3 || bb.Intersects(vida.bb) &&(Game1.nivel==2||Game1.nivel==1))
                        {
                            if ((vector.X + textura.Width > vida.vector.X + vida.textura.Width && effect == SpriteEffects.None) || vida.vector.X > vector.X && effect == SpriteEffects.FlipHorizontally)
                            {
                                vidas++;
                                vida.dibujar = false;
                                soundpower.Play();
                            }
                        }
                    }
                }
                foreach (Poder invi in poderes.invisible)
                {
                    if (invi.dibujar == true)
                    {
                        if (bb.Intersects(invi.bb))
                        {
                            if (vector.Y + textura.Height - 40 < invi.vector.Y + 60 && (vector.X + textura.Width > invi.vector.X + invi.textura.Width && effect == SpriteEffects.None) || (invi.vector.X > vector.X && effect == SpriteEffects.FlipHorizontally))
                            {
                                perdiovida = true;
                                timer2 -= 250;
                                invi.dibujar = false;
                                soundpower.Play();
                            }
                        }
                    }
                }

            foreach (Poder poder in poderes.vuelo)
            {
                if (bb.Intersects(poder.bb)&& poder.dibujar==true)
                {
                    jetpack = true;
                    tiempojetpack = 0;
                    poder.dibujar = false;
                    soundpower.Play();
                }
            }
            foreach (Cazador cazador in cazadores.cazadores)
            {
                if (cazador.dibujar == true)
                {
                    if (bb.Intersects(cazador.bb) && cazador.vector.Y > vector.Y + textura.Height - 50)
                    {
                        cazador.dibujar = false;
                        soundcaza.Play();
                    }
                }
            }
            if (perdiovida == false)
            {
                foreach (Cazador cazador in cazadores.cazadores)
                {
                    foreach (Bala bala in cazador.balas)
                    {
                        if (vector.X >= 1200 || -100 >= vector.X)
                        {
                        }
                        else
                        {
                            if (bala.dibujar == true && bb.Intersects(bala.bb))
                            {
                                if ((cazador.effect == SpriteEffects.None && vector.X + textura.Width - 40 >= bala.vector.X) || cazador.effect == SpriteEffects.FlipHorizontally && bala.vector.X >= vector.X - 10 || cazador.effect == SpriteEffects.FlipVertically && vector.X + textura.Width - 30 >= bala.vector.X && bala.vector.Y + 10 >= vector.Y)
                                {
                                    if (bala.vector.Y > vector.Y)
                                    {
                                        bala.dibujar = false;
                                        if (randomm == false)
                                        {
                                            vidas -= 1;
                                            perdiovida = true;
                                        }
                                        bala.bb = bb = new BoundingBox(new Vector3(v2, 0), new Vector3(v2.X + textura.Width, v2.Y + textura.Height, 0));
                                        soundhurt.Play();
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (Piso pinche in pisos.pinches)
                {
                    if (bb.Intersects(pinche.bb))
                    {
                            if ((vector.X + 50 > pinche.vector.X && effect == SpriteEffects.None) || pinche.vector.X + pinche.textura.Width > vector.X + 50 && effect == SpriteEffects.FlipHorizontally)
                            {
                                if (randomm == false)
                                {
                                    vidas -= 1;
                                    perdiovida = true;
                                    jumping = true;
                                    jumpspeed = -16;
                                    Jump(pisos, fondo);
                                    soundhurt.Play();
                                }
                                
                            }
                    }
                }
            }  
                if (fall == false)
                {
                    Fall(pisos, fondo);
                }
                bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
            }
    }
        public void Draw(SpriteBatch sb, bool gameover, Color color)
        {
            if (gameover == false)
            {
                if(perdiovida==false)
                    sb.Draw(this.textura, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, effect, 0f);
                else if (perdiovida)
                {
                    timer2++;
                    if (timer2 > 75 && timer2 % 5 == 0 && trasparente == true)
                    {
                        sb.Draw(this.textura, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, effect, 0f);
                        trasparente = false;
                    }
                   else if (trasparente == true)
                    {
                        sb.Draw(this.textura, vector, null, Color.White * 0.65f, 0f, Vector2.Zero, 1.0f, effect, 0f);
                    }
                    
                    else if (trasparente == false)
                    {
                        sb.Draw(this.textura, vector, null, Color.White, 0f, Vector2.Zero, 1.0f, effect, 0f);
                        timer3++;
                        if (timer3 == 5)
                        {
                            timer3 = 0;
                            trasparente = true;
                        }
                    }
                    if (timer2 == 150)
                    {
                        perdiovida = false;
                        timer2 = 0;
                    }
                }
            }
            else
            {
                sb.Draw(this.textura, vector, null, color, 0f, Vector2.Zero, 1.0f, effect, 0f);
            }
        }
    }
}
