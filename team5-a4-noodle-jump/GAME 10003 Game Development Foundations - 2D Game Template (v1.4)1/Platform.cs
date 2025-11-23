using System.Numerics;

public class Platform;

namespace MohawkGame2D
{
        public class Platform // Platfroms do not scroll like the game yet
        {
            public Vector2 Position;
            public Vector2 Size;
            public Vector2 Velocity = Vector2.Zero;

            public Platform(float x, float y, float width, float height)
            {
                Position = new Vector2(x, y);
                Size = new Vector2(width, height);
            }

            public float Left => Position.X;
            public float Right => Position.X + Size.X;
            public float Top => Position.Y;
            public float Bottom => Position.Y + Size.Y;

            public void Update(float deltaTime)
            {
                Position += Velocity * deltaTime;
            }

            public void Draw()
            {
                // colours for the platforms whch only need to be called 
                Draw.FillColor = Color.Red;
                Draw.LineColor = Color.Red;
                Draw.LineSize  = 2;

                Draw.Rectangle(Position, Size);
            }

            public bool CheckLanding(Vector2 playerPos, Vector2 playerSize, Vector2 playerVelocity)
            {
                float pLeft = playerPos.X;
                float pRight = playerPos.X + playerSize.X;
                float pBottom = playerPos.Y + playerSize.Y;

                bool horizontallyAligned =
                    pRight > Left &&
                    pLeft < Right;

                bool movingDown = playerVelocity.Y > 0;

                bool crossingTop =
                    pBottom <= Top &&
                    pBottom + playerVelocity.Y >= Top;

                return horizontallyAligned && movingDown && crossingTop;
            }
        }
    }




