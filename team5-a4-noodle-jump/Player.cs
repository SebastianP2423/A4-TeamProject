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
        int squareSize = 30;
        Vector2 position = new Vector2(200, 400);
        float yVelocity = 0f;
        float gravity = 10f;
        float gravityForce = 0f;
        public void Update()
        {
            position.X = Input.GetMouseX() - squareSize / 2;

            if (position.Y + squareSize * 1.1f <= 600)
            {
                
            }
            gravityForce = gravity * Time.DeltaTime;
            yVelocity += gravityForce;
            position.Y += yVelocity;

            Draw.Square(position, squareSize);

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                yVelocity *= -1; yVelocity -= 2;
            }
        }
    }
}
