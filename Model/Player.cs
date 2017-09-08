using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player : GameObject
    {
        private const int Distance = 5;

        public Player(int width, int height, int startingX, int startingY) 
            : base(width, height, startingX, startingY)
        {
        }

        public void MoveLeft()
        {
            x -= Distance;
        }

        public void MoveRight()
        {
            x += Distance;
        }

    }
}
