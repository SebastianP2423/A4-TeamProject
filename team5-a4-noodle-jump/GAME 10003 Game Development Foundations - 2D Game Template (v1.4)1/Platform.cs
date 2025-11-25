using System;
using System.Numerics;


namespace MohawkGame2D
    {
        public class Platform
        {
            public Vector2 Position;
            public Vector2 Size;
            public Vector2 Velocity = Vector2.Zero;

            // Actual moving platfform functions 
            public bool IsMoving = false;
            public float MoveSpeed = 50f;       // how fast thy move
            public float MoveDistance = 50f;    // how far their movement is

            private float moveTimer = 0f;
            private Vector2 startPos;

            // Scrolling for platforms like the actual game
            public float ScrollSpeed = -100f; 

            public Platform(float x, float y, float width, float height)
            {
                Position = new Vector2(x, y);
                Size = new Vector2(width, height);

                startPos = Position; 
            }

            public float Left => Position.X;
            public float Right => Position.X + Size.X;
            public float Top => Position.Y;
            public float Bottom => Position.Y + Size.Y;

            public void Update(float deltaTime)
            {
                //Horizontal movement
                if (IsMoving)
                {
                    moveTimer += deltaTime * MoveSpeed;
                    float xOffset = (float)Math.Sin(moveTimer) * MoveDistance;
                    Position = new Vector2(startPos.X + xOffset, Position.Y);
                }

                // Scroll upward feature
                Position += new Vector2(0, ScrollSpeed * deltaTime);

                // Just in case something else needs to set velocity
                Position += Velocity * deltaTime;
            }

            public void Draw()
            {
                Draw.FillColor = IsMoving ? Color.Green : Color.Red;
                Draw.LineColor = Draw.FillColor;
                Draw.LineSize = 2;

                Draw.Rectangle(Position, Size);
            }

            public bool CheckLanding(Vector2 playerPos, Vector2 playerSize, Vector2 playerVelocity)
            {
                float pLeft = playerPos.X;
                float pRight = playerPos.X + playerSize.X;
                float pBottom = playerPos.Y + playerSize.Y;

                bool horizontallyAligned = pRight > Left && pLeft < Right;
                bool movingDown = playerVelocity.Y > 0;
                bool crossingTop =
                    pBottom <= Top &&
                    pBottom + playerVelocity.Y >= Top;

                return horizontallyAligned && movingDown && crossingTop;
            }
        }
    }






