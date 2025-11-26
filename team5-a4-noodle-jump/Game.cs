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
        Texture2D background;
        BGM bgm = new BGM();

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 600);
            Window.SetTitle("Noodle Jump!");
            background = Graphics.LoadTexture("../../../assets/graphics/backgroundnoodle.png");
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Graphics.Scale = 1;
            Graphics.Draw(background, 0, 0);
            Graphics.Scale = 0.2f;
            player.Update(player.playerSprite);
            bgm.BGMPlay();
        }
    }

}
