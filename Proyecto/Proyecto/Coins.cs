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
    public class Coins
    {
        public Coin[] coins;
        public Vector2[] vector;
        public ContentManager cm;
        public SpriteBatch sb;
        public int puntaje;//,contador=1;
       
        public Coins(ContentManager cm, int cantidad, Vector2[] vector2)
        {
            this.cm = cm;
            coins = new Coin[cantidad];
           for (int i = 0; i < cantidad; i++)
            {
                this.coins[i] = new Coin(vector2[i], cm);//,contador);
                /*contador++;
                if (contador > 4)
                {
                   contador = 1;
                }*/ 
            }
        }
        public void Draw(SpriteBatch sb,bool gameover, Color color)
        {
            foreach (Coin coin in coins)
                coin.Draw(sb, gameover, color);
        }
        public void Update(Panda panda)
        {
            foreach (Coin coin in coins)
            {
                if (coin.dibujar == true)
                    coin.Update(panda);               
            }
        }


    }
}
