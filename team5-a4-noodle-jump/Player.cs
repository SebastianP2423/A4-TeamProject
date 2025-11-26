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
        float fallingTime = Time.DeltaTime;
        public float playerScore = 0f;
        public void Update()
        {
            position.X = Input.GetMouseX() - squareSize / 2;

            if (Input.IsKeyboardKeyReleased(KeyboardInput.Space))
            {
                fallingTime = 0;
                gravityForce = 0;
                yVelocity *= -1;
            }
            fallingTime = Time.DeltaTime;
            gravityForce = gravity * fallingTime;
            yVelocity += gravityForce;
            position.Y += yVelocity;

            Draw.Square(position, squareSize);

            if (yVelocity < 0f)
            {
                playerScore++;
            }
            Text.Draw($"{playerScore}", 0, 0);

            /*
            if (platformCollided == true && velocity > 0))
            {
                yVelocity *= -1; yVelocity -= 2;
            }
            */
        }
    }
}
