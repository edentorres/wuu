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
    /// <summary>
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Nivel nivel1;
        Nivel nivel2;
        Nivel nivel3;
        Nivel nivel4;
        Nivel nivel5;

        SoundEffect soundcymball;
        SoundEffectInstance instancefondo;
        SoundEffect soundfondo;
        int timer,nivelact=0;
        public static int nivel = 0;
        public static bool escape = false, saliojuego = false, enter = false, cambionivel=false, flechaup, primera=true;
        public int cantfondos;
        public int cantidadplataf;
        public int cantidadpinches;
        public int cantidadmonedas;
        public int cantidadcazadoresizq;
        public int cantidadcazadoresder;
        public int cantidadcazadorarri;
        int cantidadvidas;
        int cantidadinvisible;
        int cantvuelo;
        int cantnubes;
        int cantmove;
        Vector2 posicionpanda;
        Vector2 posllave;
        Vector2[] posicionpinches;
        Vector2[] posicioncazadoresizq;
        Vector2[] posicioncazadorarri;
        Vector2[] posicioncazadoresder;
        Vector2[] posicionplataf;
        Vector2[] posicionfondos;
        Vector2[] posicionmonedas;
        Vector2[] posvidas;
        Vector2[] posinvisible;
        Vector2[] posvuelo;
        Vector2[] posnubes;
        Vector2[] posmove;

        menuComponent menu_principal;

        SpriteFont fontinstrucciones;
        Texture2D fondo;


        MouseState mouse = Mouse.GetState();
        Texture2D mouseTexture;
        Rectangle mouseRectangle;
        Point punta;
        Rectangle volver;

        Rectangle Masvolumen, Menosvolumen;

        double UltimoClick = 0;
        int EstadoInstrucciones = 1, Volumen=9;
        Texture2D TextInstrucciones, Textflechader, Textflechaizq;
        Rectangle Recinstrucciones, Recflechader, Recflechaizq;

        Rectangle r1, r2, r3;
        Texture2D t1, t2, t3;  
        

        enum GameMode
        {
            Menu,
            Juego,
            Niveles,
            Instrucciones,
            HighScore,
            Opciones
        }

        GameMode gamemode;
        

        public static Game1 Instance;

        public Game1()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            SoundEffect.MasterVolume = 0.5f;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            if (nivel == 0)
            {
                Mouse.SetPosition(500, 200);
                menu_principal = new menuComponent(this, 5, Color.Green, Color.Black, new Vector2(300, 420), Content.Load<SpriteFont>("Menu principal/fuentes/Calibri"), 40, GraphicsDevice.Viewport.Width);
                menu_principal.AddElement(0, "Nuevo juego");
                menu_principal.AddElement(1, "Seleccionar nivel");
                menu_principal.AddElement(2, "Instrucciones");
                menu_principal.AddElement(3, "Opciones");
                menu_principal.AddElement(4, "Salir");

                Menosvolumen = new Rectangle(GraphicsDevice.Viewport.Width / 2 - Content.Load<Texture2D>("Menu Principal/Volumen/" + Volumen).Width / 2 + 140, GraphicsDevice.Viewport.Height / 2 - Content.Load<Texture2D>("Menu Principal/Volumen/" + Volumen).Height / 2 + 245, 72, 70);
                Masvolumen = new Rectangle(GraphicsDevice.Viewport.Width / 2 - Content.Load<Texture2D>("Menu Principal/Volumen/" + Volumen).Width / 2 + 425, GraphicsDevice.Viewport.Height / 2 - Content.Load<Texture2D>("Menu Principal/Volumen/" + Volumen).Height / 2 + 245, 70, 70);

                gamemode = GameMode.Menu;
            }
            else if (nivel == 1)
            {
                //cosas que cambiar
                // corazones arriba de carteles
                //cazadores
                //terminar niveles
                //termine bien
                //
                //
                //
                cantfondos = 6;
                cantidadcazadoresder = 2;
                cantidadcazadoresizq = 3;
                cantidadcazadorarri = 0;
                cantidadinvisible = 1;
                cantidadmonedas = 30;
                cantidadpinches = 8;
                cantidadplataf = 6;
                cantidadvidas = 1;
                cantvuelo = 1;
                cantnubes = 18;
                cantmove = 0;

                posicionplataf = new Vector2[cantidadplataf];
                posicionplataf[0] = new Vector2(900, 600);
                posicionplataf[1] = new Vector2(1400, 350);
                //posicionplataf[2] = new Vector2(1700, 50);
                posicionplataf[2] = new Vector2(1900, 500);
                posicionplataf[3] = new Vector2(5800, 450);
                posicionplataf[4] = new Vector2(2600, 600);
                posicionplataf[5] = new Vector2(5100, 450);
                //posicionplataf[6] = new Vector2(3500, 400);
                /*posicionplataf[7] = new Vector2(175, 250);
                posicionplataf[8] = new Vector2(190, 500);*/



                posicionpinches = new Vector2[cantidadpinches];
                posicionpinches[0] = new Vector2(1850, 700);
                posicionpinches[1] = new Vector2(2400, 700);
                posicionpinches[2] = new Vector2(8700, 700);
                posicionpinches[3] = new Vector2(9100, 700);
                posicionpinches[4] = new Vector2(5300, 700);
                posicionpinches[5] = new Vector2(8300, 700);
                posicionpinches[6] = new Vector2(3300, 700);
                posicionpinches[7] = new Vector2(3900, 700);


                posicionfondos = new Vector2[2];
                posicionfondos[0] = new Vector2(0, 0);
                posicionfondos[1] = new Vector2(2048, 0);

                posicionmonedas = new Vector2[cantidadmonedas];
                posicionmonedas[1] = new Vector2(1075, 550);
                posicionmonedas[2] = new Vector2(1575, 270);
                posicionmonedas[3] = new Vector2(2075, 420);
                posicionmonedas[4] = new Vector2(2775, 420);
                posicionmonedas[5] = new Vector2(1700, 70);
                posicionmonedas[6] = new Vector2(2250, 170);
                posicionmonedas[7] = new Vector2(3400, 300);
                posicionmonedas[8] = new Vector2(4075, 100);
                posicionmonedas[9] = new Vector2(4275, 300);
                posicionmonedas[10] = new Vector2(6300, 300);
                posicionmonedas[11] = new Vector2(4800, 120);
                posicionmonedas[12] = new Vector2(4800, 345);
                posicionmonedas[13] = new Vector2(4800, 620);
                posicionmonedas[14] = new Vector2(5250, 370);
                posicionmonedas[15] = new Vector2(2025, -70);
                posicionmonedas[16] = new Vector2(6300, 400);
                posicionmonedas[17] = new Vector2(5600, 30);
                posicionmonedas[18] = new Vector2(5900, 620);
                posicionmonedas[19] = new Vector2(7350, 620);
                posicionmonedas[20] = new Vector2(7150, 620);
                posicionmonedas[21] = new Vector2(7825, 70);
                posicionmonedas[22] = new Vector2(8600, 45);
                posicionmonedas[23] = new Vector2(8950, 45);
                posicionmonedas[24] = new Vector2(8900, 320);
                posicionmonedas[25] = new Vector2(8400, 320);
                posicionmonedas[26] = new Vector2(9400, 320);
                posicionmonedas[27] = new Vector2(9500, 45);
                posicionmonedas[28] = new Vector2(3500, 220);
                posicionmonedas[29] = new Vector2(3600, -220);

                //posmove = new Vector2[cantmove];
                //posmove[0] = new Vector2(3500, 300);
                //posmove[1] = new Vector2(4000, 400);

                posicioncazadoresizq = new Vector2[cantidadcazadoresizq];
                posicioncazadoresizq[0] = new Vector2(4900, 480);
                posicioncazadoresizq[1] = new Vector2(6000, 200);
                posicioncazadoresizq[2] = new Vector2(7500, 480);
                /*posicioncazadoresizq[3] = new Vector2(7500, 520);*/

                posicioncazadoresder = new Vector2[cantidadcazadoresder];
                posicioncazadoresder[0] = new Vector2(6800, 480);
                posicioncazadoresder[1] = new Vector2(7800, 480);

                posnubes = new Vector2[cantnubes];
                posnubes[0] = new Vector2(2150, 250);
                posnubes[1] = new Vector2(3900, 200);
                posnubes[2] = new Vector2(4125, 400);
                posnubes[3] = new Vector2(5500, 200);
                posnubes[4] = new Vector2(1900, 10);
                posnubes[5] = new Vector2(6800, 400);
                posnubes[6] = new Vector2(7700, 200);
                posnubes[7] = new Vector2(1550, 150);
                posnubes[8] = new Vector2(7800, 400);
                posnubes[9] = new Vector2(7900, 600);
                posnubes[10] = new Vector2(8100, 100);
                posnubes[11] = new Vector2(8500, 100);
                posnubes[12] = new Vector2(8900, 100);
                posnubes[13] = new Vector2(8800, 400);
                posnubes[14] = new Vector2(8300, 400);
                posnubes[15] = new Vector2(9300, 400);
                posnubes[16] = new Vector2(9400, 100);
                posnubes[17] = new Vector2(4325, 600);


                posicionpanda = new Vector2(0, 530);



                posvidas = new Vector2[cantidadvidas];
                posvidas[0] = new Vector2(5850, 375);

                posinvisible = new Vector2[cantidadinvisible];
                posinvisible[0] = new Vector2(6925, 300);

                posvuelo = new Vector2[cantvuelo];
                posvuelo[0] = new Vector2(3150, 500);

                posllave = new Vector2(9900, 600);
                nivel1 = new Nivel(this.Content, this.spriteBatch, posicionmonedas, cantidadmonedas, posicionpanda, cantfondos, posicionfondos, cantidadplataf, posicionplataf, cantidadpinches, posicionpinches, cantidadcazadoresder, cantidadcazadoresizq, posicioncazadoresizq, posicioncazadoresder, cantidadvidas, cantidadinvisible, posvidas, posinvisible, posllave, posvuelo, cantvuelo, cantnubes, posnubes, cantmove, posmove, cantidadcazadorarri, posicioncazadorarri);

                
            }
            else if (nivel == 2)
            {

                cantfondos = 10;
                cantidadcazadoresder = 2;
                cantidadcazadoresizq = 5;
                cantidadcazadorarri = 1;
                cantidadinvisible = 2;
                cantidadmonedas = 30;
                cantidadpinches = 9;
                cantidadplataf = 16;
                cantidadvidas = 2;
                cantvuelo = 1;
                cantnubes = 17;
                cantmove = 2;

                posicionplataf = new Vector2[cantidadplataf];
                posicionplataf[0] = new Vector2(440, 500);
                posicionplataf[1] = new Vector2(890, 350);
                posicionplataf[2] = new Vector2(3400, 500);//
                posicionplataf[3] = new Vector2(4260, 150);
                posicionplataf[4] = new Vector2(5000, 150);
                posicionplataf[5] = new Vector2(6500, 600);
                posicionplataf[6] = new Vector2(7100, 470);
                posicionplataf[7] = new Vector2(6480, 340);
                posicionplataf[8] = new Vector2(7145, 210);
                posicionplataf[9] = new Vector2(7600, 400);
                posicionplataf[10] = new Vector2(8750, 350);
                posicionplataf[11] = new Vector2(7700, 130);
                posicionplataf[12] = new Vector2(6600, 20);
                posicionplataf[13] = new Vector2(8150, 500);
                posicionplataf[14] = new Vector2(8200, 200);
                posicionplataf[15] = new Vector2(5950, 500);//

                posnubes = new Vector2[cantnubes];
                posnubes[0] = new Vector2(2500, 500);
                posnubes[1] = new Vector2(1960, 400);
                posnubes[2] = new Vector2(2000, 600);
                posnubes[3] = new Vector2(2540, 300);
                posnubes[4] = new Vector2(2080, 200);
                posnubes[5] = new Vector2(2515, 100);
                posnubes[6] = new Vector2(9000, -50);
                posnubes[7] = new Vector2(9400, 500);
                posnubes[8] = new Vector2(9900, 400);
                posnubes[9] = new Vector2(9360, 300);
                posnubes[10] = new Vector2(9920, 200);
                posnubes[11] = new Vector2(9470, 100);
                posnubes[12] = new Vector2(9910, 0);
                posnubes[13] = new Vector2(1350, 80);
                posnubes[14] = new Vector2(950, 0);
                posnubes[15] = new Vector2(500, 0);
                posnubes[16] = new Vector2(100, 0);

                posmove = new Vector2[cantmove];
                posmove[0] = new Vector2(3700, 350);
                posmove[1] = new Vector2(4200, 350);

                posicionpinches = new Vector2[cantidadpinches];
                posicionpinches[0] = new Vector2(400, 700);
                posicionpinches[1] = new Vector2(3700, 700);
                posicionpinches[2] = new Vector2(4240, 700);
                posicionpinches[3] = new Vector2(4780, 700);
                posicionpinches[4] = new Vector2(5320, 700);
                posicionpinches[5] = new Vector2(7000, 700);
                posicionpinches[6] = new Vector2(7540, 700);
                posicionpinches[7] = new Vector2(8080, 700);
                posicionpinches[8] = new Vector2(8620, 700);

                posicionfondos = new Vector2[2];
                posicionfondos[0] = new Vector2(0, 0);
                posicionfondos[1] = new Vector2(1024, 0);

                posicionmonedas = new Vector2[cantidadmonedas];
                posicionmonedas[0] = new Vector2(2550, 440);
                posicionmonedas[1] = new Vector2(500, 450);
                posicionmonedas[2] = new Vector2(750, 450);
                posicionmonedas[3] = new Vector2(2150, 540);
                posicionmonedas[4] = new Vector2(2600, 240);
                posicionmonedas[5] = new Vector2(4300, 80);
                posicionmonedas[6] = new Vector2(4550, 80);
                posicionmonedas[7] = new Vector2(5050, 80);
                posicionmonedas[8] = new Vector2(5300, 80);
                posicionmonedas[9] = new Vector2(2250, 140);
                posicionmonedas[10] = new Vector2(200, -70);
                posicionmonedas[11] = new Vector2(250, 680);
                posicionmonedas[12] = new Vector2(1600, 680);
                posicionmonedas[13] = new Vector2(1800, 680);
                posicionmonedas[14] = new Vector2(3230, 680);
                posicionmonedas[15] = new Vector2(3550, 680);
                posicionmonedas[16] = new Vector2(6700, -55);
                posicionmonedas[17] = new Vector2(7300, 420);
                posicionmonedas[18] = new Vector2(6700, 540);
                posicionmonedas[19] = new Vector2(6050, 440);
                posicionmonedas[20] = new Vector2(7680, 340);
                posicionmonedas[21] = new Vector2(7880, 340);
                posicionmonedas[22] = new Vector2(8250, 140);
                posicionmonedas[23] = new Vector2(8450, 140);
                posicionmonedas[24] = new Vector2(8350, 440);
                posicionmonedas[25] = new Vector2(6870, -55);
                posicionmonedas[26] = new Vector2(9300, 680);
                posicionmonedas[27] = new Vector2(9500, 240);
                posicionmonedas[28] = new Vector2(10100, -50);
                posicionmonedas[29] = new Vector2(10050, 340);

                posicionpanda = new Vector2(0, 530);

                posicioncazadoresder = new Vector2[cantidadcazadoresder];
                posicioncazadoresder[0] = new Vector2(7200, -35);
                posicioncazadoresder[1] = new Vector2(6750, 95);

                posicioncazadoresizq = new Vector2[cantidadcazadoresizq];
                posicioncazadoresizq[0] = new Vector2(900, 480);
                posicioncazadoresizq[1] = new Vector2(2900, 480);
                posicioncazadoresizq[2] = new Vector2(10090, 480);
                posicioncazadoresizq[3] = new Vector2(8850, 110);
                posicioncazadoresizq[4] = new Vector2(6450, 95);

                posicioncazadorarri = new Vector2[cantidadcazadorarri];
                posicioncazadorarri[0] = new Vector2(1300, 480);

                posvidas = new Vector2[cantidadvidas];
                posvidas[0] = new Vector2(4420, 70);
                posvidas[1] = new Vector2(5180, 70);

                posinvisible = new Vector2[cantidadinvisible];
                posinvisible[0] = new Vector2(2630, 40);
                posinvisible[1] = new Vector2(7890, 65);

                posvuelo = new Vector2[cantvuelo];
                posvuelo[0] = new Vector2(150, 640);

                posllave = new Vector2(9130, -250);
                nivel2 = new Nivel(this.Content, this.spriteBatch, posicionmonedas, cantidadmonedas, posicionpanda, cantfondos, posicionfondos, cantidadplataf, posicionplataf, cantidadpinches, posicionpinches, cantidadcazadoresder, cantidadcazadoresizq, posicioncazadoresizq, posicioncazadoresder, cantidadvidas, cantidadinvisible, posvidas, posinvisible, posllave, posvuelo, cantvuelo, cantnubes, posnubes, cantmove, posmove, cantidadcazadorarri, posicioncazadorarri);
            }
            else if (nivel == 3)
            {
                cantfondos = 16;
                cantidadcazadoresder = 3;
                cantidadcazadoresizq = 4;
                cantidadcazadorarri = 5;
                cantidadinvisible = 2;
                cantidadmonedas = 30;
                cantidadpinches = 19;
                cantidadplataf = 19;
                cantidadvidas = 2;
                cantvuelo = 2;
                cantnubes = 24;
                cantmove = 3;

                posicionplataf = new Vector2[cantidadplataf];
                posicionplataf[0] = new Vector2(400, 565);
                posicionplataf[1] = new Vector2(860, 350);
                posicionplataf[2] = new Vector2(560, 135);//
                posicionplataf[3] = new Vector2(2040, 350);
                posicionplataf[4] = new Vector2(2040, 565);
                posicionplataf[5] = new Vector2(4650, 350);
                posicionplataf[6] = new Vector2(5075, 565);
                posicionplataf[7] = new Vector2(6450, 400);
                posicionplataf[8] = new Vector2(5925, 565);
                posicionplataf[9] = new Vector2(6950, 200);
                posicionplataf[10] = new Vector2(7900, -150);
                posicionplataf[11] = new Vector2(8600, -150);
                posicionplataf[12] = new Vector2(9200, 75);
                posicionplataf[13] = new Vector2(8700, 300);
                posicionplataf[14] = new Vector2(9300, 565);
                posicionplataf[15] = new Vector2(9800, 300);
                posicionplataf[16] = new Vector2(12500, 400);
                posicionplataf[17] = new Vector2(13000, 100);
                posicionplataf[18] = new Vector2(12600, -200);

                posnubes = new Vector2[cantnubes];
                posnubes[0] = new Vector2(50, 350);
                posnubes[1] = new Vector2(50, 135);
                posnubes[2] = new Vector2(1550, 350);
                posnubes[3] = new Vector2(3370, 200);
                posnubes[4] = new Vector2(5100, 150);
                posnubes[5] = new Vector2(5500, -50);
                posnubes[6] = new Vector2(5100, -250);
                posnubes[7] = new Vector2(4800, -270);
                posnubes[8] = new Vector2(4500, -290);
                posnubes[9] = new Vector2(4200, -290);
                posnubes[10] = new Vector2(3900, -290);
                posnubes[11] = new Vector2(3600, -290);
                posnubes[12] = new Vector2(5850, -250);
                posnubes[13] = new Vector2(6150, -150);
                posnubes[14] = new Vector2(6450, -50);
                posnubes[15] = new Vector2(7500, 0);
                posnubes[16] = new Vector2(10600, 100);
                posnubes[17] = new Vector2(11100, -75);
                posnubes[18] = new Vector2(10700, -250);
                posnubes[19] = new Vector2(11000, -250);
                posnubes[20] = new Vector2(11300, -250);
                posnubes[21] = new Vector2(13600, 100);
                posnubes[22] = new Vector2(14100, 100);
                posnubes[23] = new Vector2(14600, 100);

                posmove = new Vector2[cantmove];
                posmove[0] = new Vector2(3700, 350);
                posmove[1] = new Vector2(4200, 350);
                posmove[2] = new Vector2(10300, 300);

                posicionpinches = new Vector2[cantidadpinches];
                posicionpinches[0] = new Vector2(1000, 700);
                posicionpinches[1] = new Vector2(1540, 700);
                posicionpinches[2] = new Vector2(2440, 700);
                posicionpinches[3] = new Vector2(2980, 700);
                posicionpinches[4] = new Vector2(3520, 700);
                posicionpinches[5] = new Vector2(4060, 700);
                posicionpinches[6] = new Vector2(5900, 700);
                posicionpinches[7] = new Vector2(6440, 700);
                posicionpinches[8] = new Vector2(6980, 700);
                posicionpinches[9] = new Vector2(7664, 700);
                posicionpinches[10] = new Vector2(8204, 700);
                posicionpinches[11] = new Vector2(8744, 700);
                posicionpinches[12] = new Vector2(10344, 700);
                posicionpinches[13] = new Vector2(10884, 700);
                posicionpinches[14] = new Vector2(11424, 700);
                posicionpinches[15] = new Vector2(11964, 700);
                posicionpinches[16] = new Vector2(13490, 700);//13600
                posicionpinches[17] = new Vector2(14030, 700);
                posicionpinches[18] = new Vector2(14570, 700);//14900
                //15110
                posicionfondos = new Vector2[2];
                posicionfondos[0] = new Vector2(0, 0);
                posicionfondos[1] = new Vector2(1024, 0);

                posicionmonedas = new Vector2[cantidadmonedas];
                posicionmonedas[0] = new Vector2(175, 30);
                posicionmonedas[1] = new Vector2(710, 30);
                posicionmonedas[2] = new Vector2(1675, 245);
                posicionmonedas[3] = new Vector2(3495, 105);
                posicionmonedas[4] = new Vector2(4925, -400);
                posicionmonedas[5] = new Vector2(4025, -400);
                posicionmonedas[6] = new Vector2(4625, -400);
                posicionmonedas[7] = new Vector2(6575, -150);
                posicionmonedas[8] = new Vector2(2215, 250);
                posicionmonedas[9] = new Vector2(5225, -350);
                posicionmonedas[10] = new Vector2(5975, -350);
                posicionmonedas[11] = new Vector2(7246, -108);
                posicionmonedas[12] = new Vector2(7625, -208);
                posicionmonedas[13] = new Vector2(8075, -300);
                posicionmonedas[14] = new Vector2(8775, -300);
                posicionmonedas[15] = new Vector2(9375, -75);
                posicionmonedas[16] = new Vector2(8500, 600);
                posicionmonedas[17] = new Vector2(8200, 600);
                posicionmonedas[18] = new Vector2(9975, 150);
                posicionmonedas[19] = new Vector2(10450, 150);
                posicionmonedas[20] = new Vector2(12350, 150);
                posicionmonedas[21] = new Vector2(11500, 150);
                posicionmonedas[22] = new Vector2(10900, -400);
                posicionmonedas[23] = new Vector2(11125, -400);
                posicionmonedas[24] = new Vector2(11425, -400);
                posicionmonedas[25] = new Vector2(12700, -350);
                posicionmonedas[26] = new Vector2(12850, -350);
                posicionmonedas[27] = new Vector2(13725, -50);
                posicionmonedas[28] = new Vector2(14725, -50);
                posicionmonedas[29] = new Vector2(14225, 300);

                for (int i = 0; i < 10; i++)
                {
                    posicionmonedas[i].Y += 30;
                }
                for (int i = 12; i < cantidadmonedas; i++)
                {
                    posicionmonedas[i].Y += 80;
                }

                posicionpanda = new Vector2(0, 530);

                posicioncazadoresder = new Vector2[cantidadcazadoresder];
                posicioncazadoresder[0] = new Vector2(3730, -498);
                posicioncazadoresder[1] = new Vector2(6450, 192);
                posicioncazadoresder[2] = new Vector2(10700, -458);

                for (int i = 0; i < cantidadcazadoresder; i++)
                {
                    posicioncazadoresder[i].Y -= 40;
                }

                posicioncazadoresizq = new Vector2[cantidadcazadoresizq];
                posicioncazadoresizq[0] = new Vector2(530, -73);
                posicioncazadoresizq[1] = new Vector2(7184, -8);
                posicioncazadoresizq[2] = new Vector2(9556, 357);
                posicioncazadoresizq[3] = new Vector2(13175, -108);

                for (int i = 0; i < cantidadcazadoresizq; i++)
                {
                    posicioncazadoresizq[i].Y -= 40;
                }

                posicioncazadorarri = new Vector2[cantidadcazadorarri];
                posicioncazadorarri[0] = new Vector2(830, 520);
                posicioncazadorarri[1] = new Vector2(4625, 520);
                posicioncazadorarri[2] = new Vector2(4875, 520);
                posicioncazadorarri[3] = new Vector2(7520, 520);
                posicioncazadorarri[4] = new Vector2(10200, 520);

                for (int i = 0; i < cantidadcazadorarri; i++)
                {
                    posicioncazadorarri[i].Y -= 40;
                }

                posvidas = new Vector2[cantidadvidas];
                posvidas[0] = new Vector2(4325, -400);
                posvidas[1] = new Vector2(8420, -330);

                posinvisible = new Vector2[cantidadinvisible];
                posinvisible[0] = new Vector2(3500, -400);
                posinvisible[1] = new Vector2(8870, 150);

                posvuelo = new Vector2[cantvuelo];
                posvuelo[0] = new Vector2(6850, -225);
                posvuelo[1] = new Vector2(13340, 0);

                posllave = new Vector2(15210, 600);
                nivel3 = new Nivel(this.Content, this.spriteBatch, posicionmonedas, cantidadmonedas, posicionpanda, cantfondos, posicionfondos, cantidadplataf, posicionplataf, cantidadpinches, posicionpinches, cantidadcazadoresder, cantidadcazadoresizq, posicioncazadoresizq, posicioncazadoresder, cantidadvidas, cantidadinvisible, posvidas, posinvisible, posllave, posvuelo, cantvuelo, cantnubes, posnubes, cantmove, posmove, cantidadcazadorarri, posicioncazadorarri);

            }
            else if (nivel == 4)
            {             

            }
            else if (nivel == 5)
            {
                
            }
            else if (nivel == 6)
            {

            }
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadFondo()
        {
            timer++;
            if (timer < 250)
                fondo = Content.Load<Texture2D>("Menu Principal/fondo 1");
            else
            {
                fondo = Content.Load<Texture2D>("Menu Principal/fondo 2");
                if (timer > 258)
                    timer = 0;
            }
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (nivel == 0)
            {
                if (primera)
                {
                    soundfondo = Content.Load<SoundEffect>("Sonidos/Menu");
                    instancefondo = soundfondo.CreateInstance();
                    instancefondo.IsLooped = true;
                    instancefondo.Volume = 0.5f;
                    primera = false;
                }

                instancefondo.Play();
                soundcymball = Content.Load<SoundEffect>("Sonidos/Cymball");
                mouseTexture = Content.Load<Texture2D>("Menu Principal/Mouse");
                mouseRectangle = new Rectangle(mouse.X, mouse.Y, mouseTexture.Width, mouseTexture.Height);
                punta = new Point(mouse.X, mouse.Y);
                fontinstrucciones = Content.Load<SpriteFont>("Menu principal/fuentes/Calibri");
                volver = new Rectangle(900, 700, (int)fontinstrucciones.MeasureString("Volver").X, (int)fontinstrucciones.MeasureString("Volver").Y);


                t1 = Content.Load<Texture2D>("Menu Principal/Nivel/1");
                t2 = Content.Load<Texture2D>("Menu Principal/Nivel/2");
                t3 = Content.Load<Texture2D>("Menu Principal/Nivel/3");
                r1 = new Rectangle(GraphicsDevice.Viewport.Width / 6 - t1.Width / 2, GraphicsDevice.Viewport.Height / 2 - t1.Height / 2, t1.Width, t1.Height);
                r2 = new Rectangle(GraphicsDevice.Viewport.Width / 2 - t2.Width / 2, GraphicsDevice.Viewport.Height / 2 - t2.Height / 2, t2.Width, t2.Height);
                r3 = new Rectangle((GraphicsDevice.Viewport.Width / 6) * 5 - t3.Width / 2, GraphicsDevice.Viewport.Height / 2 - t3.Height / 2, t3.Width, t3.Height);

                TextInstrucciones = Content.Load<Texture2D>("Menu Principal/Instrucciones/1");
                Textflechader = Content.Load<Texture2D>("Menu Principal/Instrucciones/Siguiente");
                Textflechaizq = Content.Load<Texture2D>("Menu Principal/Instrucciones/Anterior");
                Recinstrucciones = new Rectangle(0, 0, TextInstrucciones.Width, TextInstrucciones.Height);
                Recflechaizq = new Rectangle(50, GraphicsDevice.Viewport.Height / 2 - Textflechaizq.Height / 2 + 50, Textflechaizq.Width, Textflechaizq.Height);
                Recflechader = new Rectangle(874, GraphicsDevice.Viewport.Height / 2 - Textflechader.Height / 2 + 50, Textflechader.Width, Textflechader.Height);

                menu_principal.PantallaAncho = GraphicsDevice.Viewport.Width;
            }
            else if (nivel == 1)
            {
                instancefondo.Pause();
                nivel1.Load(Content);

                
            }
            else if (nivel == 2)
            {
               //nstancefondo.Pause();
                nivel2.Load(Content);
            }
            else if (nivel == 3)
            {
                instancefondo.Pause();
               nivel3.Load(Content);
            }
            else if (nivel == 4)
            {
                instancefondo.Pause();
                fondo = Content.Load<Texture2D>("Ganaste");
            }
            else if (nivel == 5)
            {
                instancefondo.Stop();
                nivel5.Load(Content);
            }
            else if (nivel == 6)
            {

            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// //GUIDO WAS HERE... XD LOL... SI EDEN SE ENTERA ME VA A MATAR... :DsdgSAGDUJFERIUSWQWSABHKDLHUFUIVEGRIHORGBOUBOIYEFAOSEORWÑ
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (cambionivel)
            {
                cambionivel = false;
                nivel++;
                Initialize();
                LoadContent();
            }
            
            if (nivel == 0)
            {
                LoadFondo();
                UltimoClick += gameTime.ElapsedGameTime.Milliseconds;
                mouse = Mouse.GetState();
                if (saliojuego == true)
                {
                    LoadContent();
                    Initialize();
                    saliojuego = false;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Enter))
                    enter = false;
                if (Keyboard.GetState().IsKeyUp(Keys.Escape) && escape == false)
                    escape = true;
                else if (Keyboard.GetState().IsKeyDown(Keys.Escape) && escape == true)
                    this.Exit();
                if (gamemode == GameMode.Menu)
                {
                    nivelact = 0;
                    if (enter == false && (Keyboard.GetState().IsKeyDown(Keys.Enter) && menu_principal.Element_active() == 1) || (mouse.LeftButton == ButtonState.Pressed && menu_principal.opciones[0].Contains(punta)))
                    {
                        soundcymball.Play();
                        gamemode = GameMode.Juego;
                        nivel = 3;
                        Initialize();
                        LoadContent();
                        Update(gameTime);
                        Draw(gameTime);
                        escape = false;
                        //instancefondo.Stop();
                    }
                    else
                    {
                        if ((Keyboard.GetState().IsKeyDown(Keys.Enter) && menu_principal.Element_active() == 2) || (mouse.LeftButton == ButtonState.Pressed && menu_principal.opciones[1].Contains(punta)))
                        {
                            gamemode = GameMode.Niveles;
                            UltimoClick = 0;
                        }
                        else
                        {
                            if ((Keyboard.GetState().IsKeyDown(Keys.Enter) && menu_principal.Element_active() == 3) || (mouse.LeftButton == ButtonState.Pressed && menu_principal.opciones[2].Contains(punta)))
                            {
                                gamemode = GameMode.Instrucciones;
                                EstadoInstrucciones = 1;
                                TextInstrucciones = Content.Load<Texture2D>("Menu Principal/Instrucciones/1");
                                UltimoClick = 0;
                            }
                            else
                            {
                                if ((Keyboard.GetState().IsKeyDown(Keys.Enter) && menu_principal.Element_active() == 4) || (mouse.LeftButton == ButtonState.Pressed && menu_principal.opciones[3].Contains(punta)))
                                {
                                    gamemode = GameMode.Opciones;
                                    UltimoClick = 0;
                                }
                                else
                                {
                                    if ((Keyboard.GetState().IsKeyDown(Keys.Enter) && menu_principal.Element_active() == 5) || (mouse.LeftButton == ButtonState.Pressed && menu_principal.opciones[4].Contains(punta)))
                                        this.Exit();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (gamemode != GameMode.Juego)
                    {
                        if (volver.Contains(punta))
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.Enter) || mouse.LeftButton == ButtonState.Pressed)
                            {
                                UltimoClick = 0;
                                gamemode = GameMode.Menu;
                            }
                        }
                        if (gamemode == GameMode.Niveles)
                        {
                            if ((mouse.LeftButton == ButtonState.Pressed && r1.Contains(punta) && UltimoClick > 300) || (Keyboard.GetState().IsKeyDown(Keys.Enter) && nivelact == 1))
                            {
                                instancefondo.Stop();
                                soundcymball.Play();
                                gamemode = GameMode.Juego;
                                nivel = 1;
                                Initialize();
                                LoadContent();
                                Update(gameTime);
                                Draw(gameTime);
                                escape = false;
                                nivelact = 0;
                            }
                            else
                            {
                                if ((mouse.LeftButton == ButtonState.Pressed && r2.Contains(punta) && UltimoClick > 300)||(Keyboard.GetState().IsKeyDown(Keys.Enter)&&nivelact==2))
                                {
                                    instancefondo.Stop();
                                    soundcymball.Play();
                                    gamemode = GameMode.Juego;
                                    nivel = 2;
                                    Initialize();
                                    LoadContent();
                                    Update(gameTime);
                                    Draw(gameTime);
                                    escape = false;
                                    nivelact = 0;
                                }


                                else
                                {
                                    if ((mouse.LeftButton == ButtonState.Pressed && r3.Contains(punta) && UltimoClick > 300) || (Keyboard.GetState().IsKeyDown(Keys.Enter) && nivelact == 3))
                                    {
                                        instancefondo.Stop();
                                        soundcymball.Play();
                                        gamemode = GameMode.Juego;
                                        nivel = 3;
                                        Initialize();
                                        LoadContent();
                                        Update(gameTime);
                                        Draw(gameTime);
                                        escape = false;
                                        nivelact = 0;
                                    }
                                }
                            }
                        }
                        if (gamemode == GameMode.Opciones)
                        {
                            if (Mouse.GetState().LeftButton == ButtonState.Pressed && UltimoClick > 200)
                            {
                                UltimoClick = 0;
                                if (Masvolumen.Contains(punta) && Volumen < 9)
                                {
                                    Volumen++;
                                    SoundEffect.MasterVolume = 0.1f * (Volumen);
                                }
                                if (Menosvolumen.Contains(punta) && Volumen > 0)
                                {
                                    Volumen--;
                                    SoundEffect.MasterVolume = 0.1f * (Volumen);
                                }
                            }
                        }
                        if (gamemode == GameMode.Instrucciones)
                        {
                            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            {
                                if (EstadoInstrucciones == 1 && Recflechader.Contains(punta))
                                {
                                    EstadoInstrucciones = 2;
                                    TextInstrucciones = Content.Load<Texture2D>("Menu Principal/Instrucciones/2");
                                }
                                else
                                {
                                    if (EstadoInstrucciones == 2 && Recflechaizq.Contains(punta))
                                    {
                                        EstadoInstrucciones = 1;
                                        TextInstrucciones = Content.Load<Texture2D>("Menu Principal/Instrucciones/1");
                                    }
                                }
                            }
                        }
                    }
                }

                menu_principal.Press_keys(Keyboard.GetState());

                mouseRectangle.X = mouse.X;
                mouseRectangle.Y = mouse.Y;
                punta.X = mouse.X;
                punta.Y = mouse.Y;

                for (int i = 0; i < menu_principal.CantElementos; i++)
                {
                    if (menu_principal.opciones[i].Contains(punta))
                        menu_principal.element_active = i;
                }
            }
            
            else if (nivel == 1)
                nivel1.Update();   
            else if (nivel == 2)
                nivel2.Update();
            else if (nivel == 3)
                nivel3.Update();
            else if (nivel == 5)
                nivel5.Update();
            else if (nivel == 4)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    instancefondo.Stop();
                    nivel = 0;
                    Initialize();
                    LoadContent();
                }

            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkKhaki);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (nivel == 0)
            {

                if (gamemode == GameMode.Menu)
                {
                    spriteBatch.Draw(fondo, new Vector2(0, 0), Color.White);
                    menu_principal.Draw(spriteBatch);
                }

                if (gamemode == GameMode.Instrucciones)
                {
                    spriteBatch.Draw(TextInstrucciones, Recinstrucciones, Color.White);
                    if (EstadoInstrucciones == 1)
                        spriteBatch.Draw(Textflechader, Recflechader, Color.White);
                    else
                        spriteBatch.Draw(Textflechaizq, Recflechaizq, Color.White);
                }

                if (gamemode == GameMode.Opciones)
                {
                    spriteBatch.Draw(Content.Load<Texture2D>("Menu Principal/FondoGeneral"), new Vector2(0, 0), Color.White);
                    spriteBatch.DrawString(Content.Load<SpriteFont>("Menu Principal/fuentes/Titulo"), "Volumen", new Vector2(GraphicsDevice.Viewport.Width / 2 - Content.Load<SpriteFont>("Menu Principal/fuentes/Titulo").MeasureString("Volumen").X / 2, 100), Color.Black);
                    spriteBatch.Draw(Content.Load<Texture2D>("Menu Principal/Volumen/" + Volumen), new Vector2(GraphicsDevice.Viewport.Width / 2 - Content.Load<Texture2D>("Menu Principal/Volumen/" + Volumen).Width / 2, GraphicsDevice.Viewport.Height / 2 - Content.Load<Texture2D>("Menu Principal/Volumen/" + Volumen).Height / 2), Color.White);
                }
                if (gamemode == GameMode.Niveles)
                {
                    spriteBatch.Draw(Content.Load<Texture2D>("Menu Principal/FondoGeneral"), new Vector2(0, 0), Color.White);
                    spriteBatch.Draw(t1, r1, Color.White);
                    spriteBatch.Draw(t2, r2, Color.White);
                    spriteBatch.Draw(t3, r3, Color.White);

                    if (r1.Contains(punta))
                    {
                        spriteBatch.Draw(t1, r1, Color.DarkKhaki);
                        nivelact = 1;
                    }
                    else if (r2.Contains(punta))
                    {
                        spriteBatch.Draw(t2, r2, Color.DarkKhaki);
                        nivelact = 2;
                    }
                    else if (r3.Contains(punta))
                    {
                        spriteBatch.Draw(t3, r3, Color.DarkKhaki);
                        nivelact = 3;
                    }
                    else
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.Right) && flechaup)
                        {
                            nivelact++;
                            flechaup = false;
                            if (nivelact == 4)
                                nivelact = 1;
                        }
                        else if (Keyboard.GetState().IsKeyDown(Keys.Left) && flechaup)
                        {
                            nivelact--;
                            flechaup = false;
                            if (nivelact <= 0)
                                nivelact = 3;
                        }
                        else if (Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left))
                            flechaup = true;
                        switch (nivelact)
                        {
                            case 1:
                                spriteBatch.Draw(t1, r1, Color.DarkKhaki);
                                break;
                            case 2:
                                spriteBatch.Draw(t2, r2, Color.DarkKhaki);
                                break;
                            case 3:
                                spriteBatch.Draw(t3, r3, Color.DarkKhaki);
                                break;
                        }

                    }

                    spriteBatch.DrawString(Content.Load<SpriteFont>("menu principal/fuentes/Titulo"), "Seleccione un nivel", new Vector2(GraphicsDevice.Viewport.Width / 2 - Content.Load<SpriteFont>("Menu Principal/fuentes/Titulo").MeasureString("Seleccione un nivel").X / 2, 100), Color.Black);

                }
                if (gamemode != GameMode.Menu && gamemode != GameMode.Juego)
                {
                    if (volver.Contains(punta))
                        spriteBatch.DrawString(Content.Load<SpriteFont>("Menu Principal/fuentes/Calibri"), "Volver", new Vector2(900, 700), Color.Green);
                    else
                        spriteBatch.DrawString(Content.Load<SpriteFont>("Menu Principal/fuentes/Calibri"), "Volver", new Vector2(900, 700), Color.Black);
                }

                spriteBatch.Draw(mouseTexture, mouseRectangle, Color.White);

            }
            else if (nivel == 1)
                nivel1.Draw(spriteBatch);
            else if (nivel == 2)
                nivel2.Draw(spriteBatch);
            else if (nivel == 3)
                    nivel3.Draw(spriteBatch);  
            else if (nivel == 5)
                nivel5.Draw(spriteBatch);
            else if (nivel == 4)
                spriteBatch.Draw(fondo, new Vector2(0, 0), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
