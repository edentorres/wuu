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
   public class Poderes
    {
        public Poder[] vidas;
        public Poder[] invisible;
        public Poder[] vuelo;
        public Poder llave;
       public ContentManager cm;

       public Poderes(ContentManager cm, int cantidadvidas, int cantidadinvisible, Vector2[] posvidas, Vector2[] posinvisible, Vector2 posllave, Vector2[] posvuelo, int cantidadvuelo)
       {
           this.cm = cm;
           vidas = new Poder[cantidadvidas];
           for (int i = 0; i < cantidadvidas; i++)
               this.vidas[i] = new Poder(posvidas[i], this.cm, "Poderes/Vida", false);

           invisible = new Poder[cantidadinvisible];
           for (int i = 0; i < cantidadinvisible; i++)
               this.invisible[i] = new Poder(posinvisible[i], this.cm, "Poderes/Invisible", false);

           if (Game1.nivel==1||Game1.nivel==2)
           llave = new Poder(posllave, this.cm, "Poderes/Bandera", false);
           else
           llave = new Poder(posllave, this.cm, "Poderes/Llave", false);

           vuelo = new Poder[cantidadvuelo];
           for (int i = 0; i < cantidadvuelo; i++)
               vuelo[i] = new Poder(posvuelo[i], cm, "Poderes/Vuelo", false);

       }
       public void Draw(SpriteBatch sb, bool gameover, Color color)
       {
           foreach (Poder vida in vidas)
               vida.Draw(sb, gameover, color);
           foreach (Poder invisibles in invisible)
               invisibles.Draw(sb, gameover, color);
           foreach (Poder vuel in vuelo)
               vuel.Draw(sb, gameover, color);

           llave.Draw(sb, gameover, color);
       }
       public void Update(Panda panda)
       {
           foreach (Poder vida in vidas)
               vida.Update(panda);
           foreach (Poder invisibles in invisible)
               invisibles.Update(panda);
           foreach (Poder vuel in vuelo)
               vuel.Update(panda);

           llave.Update(panda);
       }
    }
}
