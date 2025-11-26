// Include the namespaces (code libraries) you need below.
using team5_a4_noodle_jump;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Player player = new Player();
        BGM bgm = new BGM();
        Texture2D background = Graphics.LoadTexture("../../../assets/graphics/backgroundnoodle.png");

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 600);
            Window.SetTitle("Noodle Jump!");
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            //draws the background and then the player
            //swaps back and forth between scales so the background and player will scale properly
            Graphics.Scale = 1;
            Graphics.Draw(background, 0, 0);
            Graphics.Scale = 0.2f;
            player.Update(player.playerSprite);

            bgm.BGMPlay();
        }
    }

}
