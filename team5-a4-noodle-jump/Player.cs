using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace team5_a4_noodle_jump
{
    internal class Player
    {
        Vector2 position = new Vector2(200, 400);
        public void Update()
        {
            position.X = Input.GetMouseX();
            Draw.Square(position, 30);
        }
    }
}
