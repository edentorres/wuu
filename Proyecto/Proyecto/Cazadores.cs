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
    public class Cazadores
    {
        public Cazador[] cazadores;
        public ContentManager cm;
        public SpriteBatch sb;
        public Cazadores(ContentManager cm, int cantidadder, int cantidadizq, Vector2[] vectorizq, Vector2[] vectorder, int cantarriba, Vector2[] vectorarri)
        {
            this.cm = cm;
            cazadores = new Cazador[cantidadizq+cantidadder+cantarriba];
            for (int i = 0; i < cantidadizq; i++)
                this.cazadores[i] = new Cazador(vectorizq[i], this.cm, SpriteEffects.None);
            for (int i = cantidadizq; i < cantidadder+cantidadizq; i++)
                this.cazadores[i] = new Cazador(vectorder[i-cantidadizq], this.cm, SpriteEffects.FlipHorizontally);
            int a = 0;
            for (int i = cantidadizq+cantidadder; i < cantidadder + cantidadizq+ cantarriba; i++)
            {
                this.cazadores[i] = new Cazador(vectorarri[a], this.cm, SpriteEffects.FlipVertically);
                a++;
            }
        }
        public void Draw(SpriteBatch sb, bool gameover, Color color)
        {
            foreach (Cazador cazador in cazadores)
                cazador.Draw(sb, gameover,color);
        }
        public void Update(Panda panda)
        {
            foreach (Cazador cazador in cazadores)
                cazador.Update(panda);
        }
    }
}
