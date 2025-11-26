using MohawkGame2D;
using System.Numerics;

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

        public Texture2D playerSprite = Graphics.LoadTexture("../../../assets/graphics/character.png");

        public void Update(Texture2D squareSprite)
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

            Graphics.Draw(squareSprite, position);

            //draw score and make score go up if player is going up
            if (yVelocity < 0f)
            {
                playerScore++;
            }
            Text.Color = Color.White;
            Text.Draw($"{playerScore}", 0, 0);


            //code for when platforms are merged in
            /*
            if (platformCollided == true && velocity > 0))
            {
                yVelocity *= -1; yVelocity -= 2;
            }
            */
        }
    }
}
