using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Drop : GameObject
    {
        public Drop(int width, int height, int startingX, int startingY) 
            : base(width, height, startingX, startingY)
        {
        }

        public void MoveDown(int distance)
        {
            y += distance;
        }

        public virtual bool IntersectsWith(GameObject other)
        {
            return Bounds.IntersectsWith(other.Bounds);
        }

        public bool HasDroppedOffTheBottom(Size boardSize)
        {
            return y >= boardSize.Height;
        }
    }
}
