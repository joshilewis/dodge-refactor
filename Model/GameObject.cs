using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class GameObject
    {
        protected readonly Size size;
        protected int x;
        protected int y;

        protected GameObject(Size size, int startingX, int startingY)
        {
            this.size = size;
            x = startingX;
            y = startingY;
        }

        protected GameObject(int width, int height, int startingX, int startingY)
        {
            size = new Size(width, height);
            x = startingX;
            y = startingY;
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(x, y, size.Width, size.Width);
            }
        } 

    }

}
