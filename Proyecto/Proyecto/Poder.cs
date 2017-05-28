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
    public class Poder
    {
        public Texture2D textura;
        public Vector2 vector;
        public Vector2 posoriginal;
        public ContentManager cm;
        public BoundingBox bb;
        public bool dibujar = true, trasparente=false;
        bool esvida;
        public Poder(Vector2 posicion, ContentManager cm, string poder, bool vida)
        {
            this.vector = posicion;
            this.posoriginal = posicion;
            this.cm = cm;
            this.textura = cm.Load<Texture2D>(poder);
            esvida = vida;
            bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
        
        }
        public void Draw(SpriteBatch sb, bool gameover, Color color)
        {
            if (dibujar == true)
            {
                if (gameover == false && trasparente==false)
                    sb.Draw(textura, vector, Color.White);
                else if (trasparente==true)
                    sb.Draw(textura, vector, Color.White*0.25f);
                else
                    sb.Draw(textura, vector, color);
            }
        }
        public void Update(Panda panda)
        {
            if (esvida==false)
            {
                if (panda.subir == true && panda.vector.Y < 50 && panda.a == true)
                    vector.Y -= panda.jumpspeed;
                else if (panda.subir3 == true)
                    vector.Y = posoriginal.Y;
                        
                if (panda.moverresta)
                    vector.X -= 5;
                if (panda.mover)
                    vector.X += 5;

                bb = new BoundingBox(new Vector3(vector, 0), new Vector3(vector.X + textura.Width, vector.Y + textura.Height, 0));
            }
        }
    }
}
