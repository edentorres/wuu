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
    public class menuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public int CantElementos;
        public int element_active = 0;
        private string[] elements;
        private Color selected_color;
        private Color unselected_color;
        private Vector2 free_position;
        private SpriteFont font;
        private int separation;
        public int PantallaAncho;
        private Boolean key_Up_press;
        private Boolean key_Down_press;
        public Rectangle[] opciones;

        public menuComponent( Game game, int Num_elements, Color selected_c, Color unselected_c, Vector2 _free_position, SpriteFont _font, int _separation, int ancho)
            : base(game)
        {
            CantElementos = Num_elements;
            element_active = 0;
            elements = new string[CantElementos];
            selected_color = selected_c;
            unselected_color = unselected_c;
            free_position = _free_position;
            font = _font;
            separation = _separation;
            opciones = new Rectangle[CantElementos];
            PantallaAncho = ancho;
        }

        public void AddElement(int element_number, string element_name)
        {
            if ((element_number > -1) && (element_number < CantElementos))
            {
                elements[element_number] = element_name;
                opciones[element_number] = new Rectangle( (int) (PantallaAncho / 3 - font.MeasureString(elements[element_number].ToString()).X / 2) , (int) (free_position.Y + (separation * element_number)), (int) font.MeasureString(elements[element_number].ToString()).X, (int) font.MeasureString(elements[element_number].ToString()).Y);
            }
        }

        public int Element_active()
        {
            return element_active + 1;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        private void next_item()
        {
            if (element_active < CantElementos - 1)
            {
                element_active++;
            }
            else
            {
                element_active = 0;
            }
        }

        private void previus_item()
        {
            if (element_active > 0)
            {
                element_active--;
            }
            else
            {
                element_active = CantElementos - 1;
            }
        }

        public void Press_keys(KeyboardState keys)
        {
            if (keys.IsKeyDown(Keys.Up) && key_Up_press)
            {
                this.previus_item();
                key_Up_press = false;
            }
            else
            {
                if (keys.IsKeyUp(Keys.Up))
                {
                    key_Up_press = true;
                }
            }

            if (keys.IsKeyDown(Keys.Down) && key_Down_press)
            {
                this.next_item();
                key_Down_press = false;
            }
            else
            {
                if (keys.IsKeyUp(Keys.Down))
                {
                    key_Down_press = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < CantElementos; i++)
            {
                if (element_active == i)
                {
                    spriteBatch.DrawString(font, elements[i].ToString(),
                                           new Vector2(PantallaAncho / 3 - font.MeasureString(elements[i].ToString()).X/2,
                                           free_position.Y + (separation * i)),
                                           selected_color);
                }
                else
                {

                    spriteBatch.DrawString(font, elements[i].ToString(),
                                           new Vector2(PantallaAncho / 3 - font.MeasureString(elements[i].ToString()).X / 2,
                                           free_position.Y + (separation * i)),
                                           unselected_color);
                }
            }
        }
    }
}
