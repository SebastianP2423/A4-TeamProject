using System.Collections.Generic;
using System.Numerics;
using team5_a4_noodle_jump;

namespace MohawkGame2D
{
    public class Game
    {
        Player player = new Player();
        BGM bgm = new BGM();
        Texture2D background = Graphics.LoadTexture("../../../assets/graphics/backgroundnoodle.png");

        // Platform list for storage 
        List<Platform> platforms = new List<Platform>();

        public void Setup()
        {
            Window.SetSize(400, 600);
            Window.SetTitle("Noodle Jump!");

            // Creates starter platforms for when game first starts
            platforms.Add(new Platform(150, 500, Platform.DefaultWidth, Platform.DefaultHeight));
            platforms.Add(new Platform(70, 350, Platform.DefaultWidth, Platform.DefaultHeight));
            platforms.Add(new Platform(220, 200, Platform.DefaultWidth, Platform.DefaultHeight));

            // Example moving platform
            platforms[1].IsMoving = true;
        }

        public void Update()
        {
            Graphics.Scale = 1;
            Graphics.Draw(background, 0, 0);

            foreach (Platform p in platforms)
            {
                p.Update(Time.DeltaTime);
                p.PlatformDraw();
            }

            // Platform deletion off screen 
            platforms.RemoveAll(p => p.Position.Y > 700);

            // Draws plus updates player 
            Graphics.Scale = 0.2f;
            player.Update(player.playerSprite);

            bgm.BGMPlay();
        }
    }
}
