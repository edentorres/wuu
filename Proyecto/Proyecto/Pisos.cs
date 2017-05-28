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
public class Pisos
    {
        public Piso[] plataformas;
        public Piso[] piso;
        public Piso[] pinches;
        public Piso[] nubes;
        public Piso[] move;
        public ContentManager cm;
        public SpriteBatch sb;
        public bool espiso;

        public Pisos(ContentManager cm, int cantidadplataformas, Vector2[] posplataf, Vector2[] pospisos, int cantidadpinches, Vector2[]pospinches, string plataforma, string piso,Vector2[] posnubes, int cantnubes, int cantmove, Vector2[] posmove)
        {
            this.cm = cm;
            plataformas = new Piso[cantidadplataformas];
            for (int i = 0; i < cantidadplataformas; i++)
                this.plataformas[i] = new Piso(posplataf[i], cm, "Plataforma/"+piso);

            this.piso = new Piso[2];
            for (int i = 0; i < 2; i++)
            {
                pospisos[i].Y = 769 - 40;
                if (Game1.nivel == 5)
                    pospisos[i].Y = 769 - 260;
                this.piso[i] = new Piso(pospisos[i], cm, "Pisos/"+piso);
            }
            pinches = new Piso[cantidadpinches];
            for (int i = 0; i < cantidadpinches; i++)
                this.pinches[i] = new Piso(pospinches[i], cm, "Pinche");

            nubes = new Piso[cantnubes];
            for (int i = 0; i < cantnubes; i++)
                this.nubes[i] = new Piso(posnubes[i], cm, "Nubes/"+piso);
                       move = new Piso[cantmove];
            for (int i = 0; i < cantmove; i++)
                this.move[i] = new Piso(posmove[i], cm, "Move");
        }
        public void Draw(SpriteBatch sb, bool gameover, Color color)
        {
            foreach (Piso plataf in plataformas)
                plataf.Draw(sb,gameover,color);
            foreach (Piso pis in piso)
                pis.Draw(sb,gameover,color);
            foreach (Piso pinche in pinches)
                pinche.Draw(sb, gameover, color);
            foreach (Piso nube in nubes)
                nube.Draw(sb, gameover, color);
            foreach (Piso moves in move)
                moves.Draw(sb, gameover, color);
        }
        public void Update(Panda panda)
        {
            foreach (Piso plataf in plataformas)
                plataf.Update(panda,false, Vector2.Zero, Vector2.Zero);
            foreach (Piso pis in piso)
                pis.Update(panda, false, Vector2.Zero, Vector2.Zero);
            foreach (Piso pinche in pinches)
                pinche.Update(panda, false, Vector2.Zero, Vector2.Zero);
            foreach (Piso nube in nubes)
                nube.Update(panda, false, Vector2.Zero, Vector2.Zero);
           
            switch(Game1.nivel)
            {
                case 2:
                    move[0].Update(panda, true, pinches[1].vector, pinches[2].vector);
                    move[1].Update(panda, true, pinches[3].vector, pinches[4].vector);
                    break;
                case 3:
                    move[0].Update(panda, true, pinches[2].vector, pinches[3].vector);
                    move[1].Update(panda, true, pinches[4].vector, pinches[5].vector);
                    move[2].Update(panda, true, plataformas[15].vector + new Vector2(400, 0), plataformas[15].vector + new Vector2(2000, 0));
                    break;

            }

            for (int a = 0; a < 2; a++)
            {
                if (piso[a].vector.X > 1024)
                {
                    int b = a + 1;
                    if (b == 2) b = 0;
                    piso[a].vector.X = piso[b].vector.X - piso[a].textura.Width;
                    break;
                }
            }
            for (int a = 0; a < 2; a++)
            {
                if (piso[a].vector.X + piso[a].textura.Width < 0)
                {
                    int b = a + 1;
                    if (b == 2) b = 0;
                    piso[a].vector.X = piso[b].vector.X + piso[a].textura.Width;
                    break;
                }
            }
            
        }
     
    }
}
