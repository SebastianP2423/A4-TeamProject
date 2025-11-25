using System;
using System.Numerics;


    namespace MohawkGame2D
    {
        public class Platform
        {
            public Vector2 Position;
            public Vector2 Size;
            public Vector2 Velocity = Vector2.Zero;

            // Variables for the moving platforms
            public bool IsMoving = false;
            public float MoveSpeed = 2f;
            public float MoveDistance = 60f;
            private float moveTimer = 0f;

            // Scrolling
            public float ScrollSpeed = -100f;

            // Variables for the breakable platforms
            public bool IsBreakable = false;      // set externally
            public bool IsBroken = false;         // becomes true after the player lands on it
            public float BreakDuration = 0.4f;    // timer before platform breaks or disapears
            private float breakTimer = 0f;

            private Vector2 startPos;

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
                // Handle break timer
                if (IsBroken)
                {
                    breakTimer += deltaTime;
                    if (breakTimer >= BreakDuration)
                    {
                        // Move platform far offscreen to "delete" it
                        Position = new Vector2(-9999, -9999);
                    }
                }

                // Scroll up
                Position += new Vector2(0, ScrollSpeed * deltaTime);
                startPos += new Vector2(0, ScrollSpeed * deltaTime);

                // Horizontal moving platform
                if (IsMoving)
                {
                    moveTimer += deltaTime * MoveSpeed;
                    float xOffset = (float)Math.Sin(moveTimer) * MoveDistance;
                    Position = new Vector2(startPos.X + xOffset, Position.Y);
                }

                // External velocity
                Position += Velocity * deltaTime;
            }

            public void Draw()
            {
                if (IsBreakable)
                {
                    if (IsBroken)
                    {
                        // Cracked platform color (placeholder)
                        Draw.FillColor = Color.Gray;
                        Draw.LineColor = Color.Black;
                    }
                    else
                    {
                        // Placeholder platform colors 
                        Draw.FillColor = Color.Yellow;
                        Draw.LineColor = Color.Red;
                    }
                }
                else
                {
                    // Normal or moving platform
                    Draw.FillColor = IsMoving ? Color.Green : Color.Red;
                    Draw.LineColor = Draw.FillColor;
                }

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

                bool landed = horizontallyAligned && movingDown && crossingTop;

                // If the player lands on a breakable platform it breaks 
                if (IsBreakable && landed)
                {
                    IsBroken = true;
                    breakTimer = 0f;
                }

                return landed && !IsBroken;
            }
        }
    }







