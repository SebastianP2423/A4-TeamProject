using MohawkGame2D;
using System.Numerics;

namespace team5_a4_noodle_jump
{
    internal class Player
    {
        //position of player
        public Vector2 position = new Vector2(200, 400);
        public float yVelocity = 0f;
        float gravity = 10f;
        float gravityForce = 0f;
        float fallingTime = Time.DeltaTime;

        public float playerScore = 0f;

        public static Texture2D playerSprite = Graphics.LoadTexture("../../../assets/graphics/character.png");
        public Vector2 playerSpriteSize = new Vector2(playerSprite.Width, playerSprite.Height);

        public void Update()
        {
            //x position follows mouse
            position.X = Input.GetMouseX() - (playerSprite.Width / 5 / 2);

            //this is the stuff that makes gravity work
            fallingTime = Time.DeltaTime;
            gravityForce = gravity * fallingTime;
            yVelocity += gravityForce;
            position.Y += yVelocity;

            Graphics.Draw(playerSprite, position);

            //draw score and make score go up if player is going up
            if (yVelocity < 0f)
            {
                playerScore++;
            }
            Text.Color = Color.White;
            Text.Draw($"Score: {playerScore}", 0, 0);
        }

        public void Bounce()
        {
            yVelocity *= -1; yVelocity -= 5; fallingTime = 0;
        }

    }
}
