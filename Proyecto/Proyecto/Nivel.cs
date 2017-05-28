using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Proyecto
{
     public class Nivel
    {
        Panda panda;
        Fondo fondo;
        Coins coins;
        Pisos pisos;
        Cazadores cazadores;
        SpriteFont arial;
        SpriteFont fuentepanda;
        SpriteBatch sb;
        ContentManager Content;
        Poderes poderes;
        Poder[] corazones;
        public int vidas,a;
        public bool gameover = false, menu=false, escape=false,arriba=false,abajo=false, llave=false,jetpackactivado=false,riverplay;
        public Color color, color2;
        public int timer, timer2, timer3;
        public int numero = -1, indice=2;
        public SoundEffect soundfailure;
        public SoundEffect soundfondo,ganar;
        public SoundEffectInstance instance;
        public SoundEffectInstance instancefail, insganar;
        public SoundEffect river;
        int cantfondos, cantidadplataf, cantidadcazadoresder, cantidadcazadoresizq, cantidadpinches, cantidadmonedas, cantidadvidas, cantidadinvisible, cantvuelo, cantvelocidad, cantnubes, cantmove, cantcazadorarri;
        Vector2[] posicionfondos, posicionplataf, posicioncazadoresder, posicioncazadoresizq, posicionpinches, posvida, posinvisible, posvuelo, posvelocidad, posnubes, posmove, poscazadorarri;
        Vector2 posicionpanda, posllave, pospandamuj;
        Poder pandamuj;
        Poder cartel;
        Poder[] carteles;

        MouseState mouse = Mouse.GetState();
        Texture2D mouseTexture;
        Rectangle mouseRectangle;
        Point punta;

        private bool primera = true;

        public Nivel(ContentManager cm, SpriteBatch sb, Vector2[] posicionmonedas, int cantidadmonedas, Vector2 pandaPosition, int cantidadfondos, Vector2[] posicionfondos, int cantidadplataf, Vector2[] posicionplataf, int cantidadpinches, Vector2[] posicionpinches, int cantidadcazadoresder, int cantidadcazadoresizq, Vector2[] posicioncazadoresizq, Vector2[] posicioncazadoresder, int cantvidas, int cantidadinvisible, Vector2[] poscorazones, Vector2[] posinvisible, Vector2 posllave, Vector2[] posvuelo, int cantvuelo, int cantnubes, Vector2[]posnubes, int cantmove,Vector2[] posmove, int cantidadcazadoresarri, Vector2[] posicioncazadoresarri)
        {
            //Creo objetos del nivel
            this.sb = sb;
            this.Content = cm;
            panda = new Panda(pandaPosition, this.Content);
            fondo = new Fondo(cantidadfondos, posicionfondos, this.Content, Convert.ToString(Game1.nivel));
            coins = new Coins(this.Content, cantidadmonedas, posicionmonedas);
            pisos = new Pisos(this.Content, cantidadplataf, posicionplataf, posicionfondos, cantidadpinches, posicionpinches, Convert.ToString(Game1.nivel), Convert.ToString(Game1.nivel), posnubes, cantnubes, cantmove, posmove);
            cazadores = new Cazadores(this.Content, cantidadcazadoresder, cantidadcazadoresizq, posicioncazadoresizq, posicioncazadoresder, cantidadcazadoresarri, posicioncazadoresarri);
            poderes = new Poderes(this.Content, cantvidas, cantidadinvisible, poscorazones, posinvisible, posllave,posvuelo,cantvuelo);
            poderes.llave.trasparente = true;

            this.cantfondos = cantidadfondos;
            this.cantidadplataf = cantidadplataf;
            this.cantidadcazadoresder = cantidadcazadoresder;
            this.cantidadcazadoresizq = cantidadcazadoresizq;
            this.cantidadpinches = cantidadpinches;
            this.posicionfondos = posicionfondos;
            this.posicionplataf = posicionplataf;
            this.posicionpanda = pandaPosition;
            this.posicioncazadoresder = posicioncazadoresder;
            this.posicioncazadoresizq = posicioncazadoresizq;
            this.posicionpinches = posicionpinches;
            this.cantidadmonedas = cantidadmonedas;
            this.cantidadvidas = cantvidas;
            this.cantidadinvisible = cantidadinvisible;
            this.posvida = poscorazones;
            this.posinvisible = posinvisible;
            this.posllave = posllave;
            this.posvuelo = posvuelo;
            this.cantvuelo = cantvuelo;
            this.posnubes = posnubes;
            this.cantnubes = cantnubes;
            this.cantmove = cantmove;
            this.posmove = posmove;
            this.poscazadorarri = posicioncazadoresarri;
            this.cantcazadorarri = cantidadcazadoresarri;
            if (Game1.nivel == 3)
            {
                pandamuj = new Poder(new Vector2(5555, 530), this.Content, "pandamuj1", false);
                pandamuj.dibujar = false;
                cartel = new Poder(new Vector2(15110, 520), this.Content, "cartel", false);
                cartel.dibujar = false;
            }
            else if (Game1.nivel == 1)
            {
                carteles = new Poder[7];
                carteles[0] = new Poder(new Vector2(150, 300), this.Content, "Carteles/" + Convert.ToString(1), false);
                carteles[0].dibujar = true;
                carteles[1] = new Poder(new Vector2(800, 50), this.Content, "Carteles/" + Convert.ToString(2), false);
                carteles[1].dibujar = true;
                carteles[2] = new Poder(new Vector2(2500, 50), this.Content, "Carteles/" + Convert.ToString(3), false);
                carteles[2].dibujar = true;
                carteles[3] = new Poder(new Vector2(4500, 25), this.Content, "Carteles/" + Convert.ToString(4), false);
                carteles[3].dibujar = true;
                carteles[4] = new Poder(new Vector2(6175, 50), this.Content, "Carteles/" + Convert.ToString(5), false);
                carteles[4].dibujar = true;
                carteles[5] = new Poder(new Vector2(3000, 50), this.Content, "Carteles/" + Convert.ToString(6), false);
                carteles[5].dibujar = true;
                carteles[6] = new Poder(new Vector2(9000, 50), this.Content, "Carteles/" + Convert.ToString(7), false);
                carteles[6].dibujar = true;

            }    
                vidas = 3;

        }
        public void Load(ContentManager Content)
        {
            arial = Content.Load<SpriteFont>("Menu Principal/fuentes/Calibri");
            fuentepanda = Content.Load<SpriteFont>("Menu Principal/fuentes/Calibri");
            mouseTexture = Content.Load<Texture2D>("Menu Principal/Mouse");
            soundfailure = Content.Load<SoundEffect>("Sonidos/Failure");
            soundfondo = Content.Load<SoundEffect>("Sonidos/Fondo");
            ganar = Content.Load<SoundEffect>("Sonidos/Salvar");
            river = Content.Load<SoundEffect>("Sonidos/River");
            mouseRectangle = new Rectangle(mouse.X, mouse.Y, mouseTexture.Width, mouseTexture.Height);
            punta = new Point(mouse.X, mouse.Y);
            if (primera)
            {
                instance = soundfondo.CreateInstance();//
                instance.IsLooped = true;
                instance.Volume = 0.09f;
                instance.Play();//
            }
            instancefail = soundfailure.CreateInstance();
            instancefail.Play();
            instancefail.Pause();
            insganar = ganar.CreateInstance();
            insganar.Play();
            insganar.Pause();

        }
        public void Update()
        {
            if (panda.randomm && riverplay)
            {
                river.Play();
                riverplay = false;
            }
            else if (panda.randomm==false)
                riverplay = true;
            if (menu == false)
            {
                if (gameover == false)
                    instance.Resume();
                else
                    instancefail.Play();

                panda.Update(fondo, coins, pisos, cazadores, ref vidas, poderes, cantidadmonedas);
                fondo.Update(panda);
                coins.Update(panda);
                pisos.Update(panda);
                cazadores.Update(panda);
                poderes.Update(panda);
                jetpackactivado = false;
                if (Game1.nivel == 1)
                {
                    for (int i = 0; i < 7; i++)
                        carteles[i].Update(panda);
                }
                else if (Game1.nivel==3)
                {
                    pandamuj.Update(panda);
                    cartel.Update(panda);
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Escape) && escape == true)
                    escape = false;
                else if (Keyboard.GetState().IsKeyDown(Keys.Escape)&&escape==false)
                    menu = true;

                if (0 > vidas)
                    vidas = 0;
                //creo las vidas
                corazones = new Poder[vidas];
                for (int i = 0; i < vidas; i++)
                {
                    corazones[i] = new Poder(new Vector2(55 * i + 10, 10), Content, "Corazon", true);
                }
                if (cantidadmonedas == coins.puntaje)
                    poderes.llave.trasparente = false;

                if (Game1.nivel == 3)
                {
                    if (poderes.llave.dibujar == false)
                    {
                        llave = true;
                        pandamuj.dibujar = true;
                        cartel.dibujar = true;
                    }

                    if (pandamuj.dibujar == true && panda.bb.Intersects(pandamuj.bb))
                    {
                        if (pandamuj.vector.X > panda.vector.X - panda.textura.Width - 50)
                        {
                            insganar.Play();
                            pospandamuj = pandamuj.vector;
                            pandamuj = pandamuj = new Poder(pospandamuj, this.Content, "pandamuj2", false);
                            timer3++;
                        }
                    }
                    if (timer3 > 0)
                    {
                        timer3++;
                        if (timer3 == 100)
                            Game1.cambionivel = true;
                    }
                }
                if (vidas == 0 && gameover == false)
                {
                    timer2++;
                    instance.Pause();
                }
                if (timer2 == 20)
                    gameover = true;

                if (gameover == true)
                {
                    timer++;
                    if (timer % 6 == 0)
                    {
                        if (3 > numero)
                        {
                            numero++;
                            switch (numero)
                            {
                                case 0:
                                    color = Color.Black * 0.45f;
                                    break;
                                case 1:
                                    color = Color.Black * 0.70f;
                                    break;
                                case 2:
                                    color = Color.Black * 0.85f;
                                    break;
                                case 3:
                                    color = Color.Black;
                                    break;
                            }
                        }
                        else
                        {
                            gameover = false;
                            foreach (Cazador cazador in cazadores.cazadores)
                            {
                                foreach (Bala balas in cazador.balas)
                                    balas.dibujar = false;
                            }
                            foreach (Coin coin in coins.coins)
                            {
                                if (coin.dibujar == true)
                                {
                                    coin.vector2.X = coin.posoriginal.X;
                                    coin.vector2.Y = coin.posoriginal.Y;
                                }
                            }
                            panda = new Panda(posicionpanda, Content);
                            posicionfondos[0].Y = 0;
                            posicionfondos[1].Y = 0;
                            fondo = new Fondo(cantfondos, posicionfondos, Content, Convert.ToString(Game1.nivel));
                            pisos = new Pisos(Content, cantidadplataf, posicionplataf, new Vector2[] { new Vector2(0, 0), new Vector2(1024, 0) }, cantidadpinches, posicionpinches, Convert.ToString(Game1.nivel), Convert.ToString(Game1.nivel), posnubes, cantnubes, cantmove, posmove);
                            cazadores = new Cazadores(Content, cantidadcazadoresder, cantidadcazadoresizq, posicioncazadoresizq, posicioncazadoresder,cantcazadorarri,poscazadorarri);
                            poderes = new Poderes(this.Content, cantidadvidas, cantidadinvisible, posvida, posinvisible, posllave, posvuelo, cantvuelo);

                            if (Game1.nivel == 1)
                            {
                                carteles[0] = new Poder(new Vector2(150, 300), this.Content, "Carteles/" + Convert.ToString(1), false);
                                carteles[0].dibujar = true;
                                carteles[1] = new Poder(new Vector2(800, 50), this.Content, "Carteles/" + Convert.ToString(2), false);
                                carteles[1].dibujar = true;
                                carteles[2] = new Poder(new Vector2(2500, 50), this.Content, "Carteles/" + Convert.ToString(3), false);
                                carteles[2].dibujar = true;
                                carteles[3] = new Poder(new Vector2(4500, 25), this.Content, "Carteles/" + Convert.ToString(4), false);
                                carteles[3].dibujar = true;
                                carteles[4] = new Poder(new Vector2(6175, 50), this.Content, "Carteles/" + Convert.ToString(5), false);
                                carteles[4].dibujar = true;
                                carteles[5] = new Poder(new Vector2(3000, 50), this.Content, "Carteles/" + Convert.ToString(6), false);
                                carteles[5].dibujar = true;
                                carteles[6] = new Poder(new Vector2(9000, 50), this.Content, "Carteles/" + Convert.ToString(7), false);
                                carteles[6].dibujar = true;
                            }
                            else if (Game1.nivel == 3)
                            {
                                pandamuj = new Poder(new Vector2(1550, 530), this.Content, "pandamuj1", false);
                                cartel = new Poder(new Vector2(9130, 520), this.Content, "cartel", false);
                                cartel.dibujar = false;
                                pandamuj.dibujar = false;
                                poderes.llave.dibujar = true;
                                poderes.llave.trasparente = true;
                                

                            }
                            vidas = 3;
                            panda.perdiovida = false;
                            numero = -1;
                            timer2 = 0;
                        }
                    }
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.U))
                {
                    vidas = 12;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.C) && Keyboard.GetState().IsKeyDown(Keys.O) && Keyboard.GetState().IsKeyDown(Keys.I) && Keyboard.GetState().IsKeyDown(Keys.N))
                {
                    foreach (Coin coin in coins.coins)
                    {
                        if (coin.dibujar)
                        {
                            coin.dibujar = false;
                            coins.puntaje += 1;
                        }
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.J) && Keyboard.GetState().IsKeyDown(Keys.E) && Keyboard.GetState().IsKeyDown(Keys.T)&&jetpackactivado==false)
                {
                    jetpackactivado = true;
                    if (!panda.jetpack)
                    {
                        panda.jetpack = true;
                        panda.jetpacktime = 30000000;
                    }
                    else
                    {
                        panda.jetpack = false;
                        panda.jetpacktime = 300;
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D)&& Keyboard.GetState().IsKeyDown(Keys.I)) 
                    vidas = 0;

                instance.Pause();
                mouse = Mouse.GetState();
                if (Keyboard.GetState().IsKeyUp(Keys.Escape) && escape == false)
                    escape = true;
                else if (Keyboard.GetState().IsKeyDown(Keys.Escape) && escape==true)
                {
                    menu = false;
                    gameover = false;
                    indice = 2;
                }
                if(Keyboard.GetState().IsKeyDown(Keys.Up)&&arriba)
                {
                    if (indice == 2)
                        indice--;

                    arriba = false;
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.Up))
                    arriba = true;
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && abajo)
                {
                    if (indice == 1)
                        indice++;

                    abajo = false;
                }
                else if (Keyboard.GetState().IsKeyUp(Keys.Down))
                    abajo = true;
                if (indice == 1 && Keyboard.GetState().IsKeyDown(Keys.Enter) || (mouse.LeftButton == ButtonState.Pressed && Text("Ir al menu", new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2 - 30, Game1.Instance.GraphicsDevice.Viewport.Height / 2 - 30), 1) == Color.Black))
                {
                    Game1.saliojuego = true;
                    Game1.enter = true;
                    Mouse.SetPosition(500, 100);
                    Game1.nivel = 0;
                    instance.Stop();
                    indice = 2;
                }
                else if(indice == 2 && (Keyboard.GetState().IsKeyDown(Keys.Enter) || mouse.LeftButton == ButtonState.Pressed && Text("Continuar Juego", new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2-60, Game1.Instance.GraphicsDevice.Viewport.Height / 2 + 30),2)==Color.Black))
                {
                    menu = false;
                    gameover = false;
                    indice = 2;
                }
                mouseRectangle.X = mouse.X;
                mouseRectangle.Y = mouse.Y;
                punta.X = mouse.X;
                punta.Y = mouse.Y;
            }
        }
            
        public  void Draw(SpriteBatch sb)
        {
            fondo.Draw(sb, gameover, color,panda);
            pisos.Draw(sb, gameover,color);
            coins.Draw(sb, gameover,color);
            cazadores.Draw(sb, gameover,color);
            poderes.Draw(sb, gameover, color);

            if (Game1.nivel == 1)
            {
                for (int i = 0; i < 7; i++)
                    carteles[i].Draw(sb, gameover, color);       
            }
            else if (Game1.nivel == 3)
            {
                pandamuj.Draw(sb, gameover, color);
                cartel.Draw(sb, gameover, color);
                sb.DrawString(arial, "Monedas: " + Convert.ToString(coins.puntaje) + "/" + Convert.ToString(cantidadmonedas), new Vector2(800, 10), Color.MidnightBlue);
            }
            foreach (Poder corazon in corazones)
                corazon.Draw(sb, gameover, color);
            panda.Draw(sb, gameover,color);
            if (Game1.nivel==1||Game1.nivel==2)
            sb.DrawString(arial, "Monedas: " + Convert.ToString(coins.puntaje) + "/" + Convert.ToString(cantidadmonedas), new Vector2(800, 10), Color.White);

            if (menu)
            { 
                gameover=true;
                color= Color.White*0.4f;
                sb.DrawString(fuentepanda, "Ir al menu", new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2 -30, Game1.Instance.GraphicsDevice.Viewport.Height / 2-30), Text("Ir al menu",new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2 -30, Game1.Instance.GraphicsDevice.Viewport.Height / 2-30), 1));
                sb.DrawString(fuentepanda, "Continuar juego", new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2-60, Game1.Instance.GraphicsDevice.Viewport.Height / 2 + 30), Text("Continuar Juego", new Vector2(Game1.Instance.GraphicsDevice.Viewport.Width / 2-60, Game1.Instance.GraphicsDevice.Viewport.Height / 2 + 30),2));
                sb.Draw(mouseTexture, mouseRectangle, Color.White);
            }
        }
        Color Text(string name, Vector2 vector, int indice)
        {
            Rectangle r1 = new Rectangle((int)vector.X,(int)vector.Y, (int)fuentepanda.MeasureString(name).X, (int)fuentepanda.MeasureString(name).Y);
            if (r1.Contains(punta))
            {
                this.indice = indice;
                return Color.Black;
            }
            else if (this.indice==indice)
                return Color.Black;
            else
                return Color.White;
        }
        
    }
}
