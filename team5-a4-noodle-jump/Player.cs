using MohawkGame2D;
using System.Numerics;

namespace team5_a4_noodle_jump
{
    internal class Player
    {
        //position of player
        Vector2 position = new Vector2(200, 400);
        float yVelocity = 0f;
        float gravity = 10f;
        float gravityForce = 0f;
        float fallingTime = Time.DeltaTime;

        public float playerScore = 0f;

        public Texture2D playerSprite = Graphics.LoadTexture("../../../assets/graphics/character.png");

        public void Update(Texture2D squareSprite)
        {
            //x position follows mouse
            position.X = Input.GetMouseX() - (squareSprite.Width / 5 / 2);

            //this is the stuff that makes gravity work
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
        }

        public void Bounce()
        {
            yVelocity *= -1; yVelocity -= 2; fallingTime = 0;
        }

    }
}
