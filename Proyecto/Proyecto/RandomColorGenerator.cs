using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Proyecto
{
    public class RandomColorGenerator
    {
        Random r = new Random(DateTime.Now.Millisecond);

        public Color RandomColor()
        {
            byte red = (byte)r.Next(0, 255);
            byte green = (byte)r.Next(0, 255);
            byte blue = (byte)r.Next(0, 255);

            return new Color(red, green, blue);
        }
    }
}
