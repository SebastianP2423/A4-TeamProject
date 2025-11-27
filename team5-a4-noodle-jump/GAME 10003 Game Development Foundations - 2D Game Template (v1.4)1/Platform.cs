using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Platform
    {
        public const float DefaultWidth = 80f;
        public const float DefaultHeight = 20f;

         public Vector2 Position;
        public Vector2 Size;

        public Vector2 Velocity = Vector2.Zero;

        // Moving platforms here 
        public bool IsMoving = false;
        public float MoveSpeed = 50f;
        public float MoveDistance = 50f;

        private float moveTimer = 0f;
        private Vector2 moveOrigin;

        // Scrolling speed here
        public float ScrollSpeed = -100f;

        // Breakable platforms here
        public bool IsBroken = false;
        public float BreakDuration = 0.4f;
        private float breakTimer = 0f;

        public Platform()
        {
            Position = new Vector2(160, 450);
            Size = new Vector2(DefaultWidth, DefaultHeight);
            moveOrigin = Position;
        }

        public Platform(float x, float y)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(DefaultWidth, DefaultHeight);
            moveOrigin = Position;
        }

        public Platform(float x, float y, float width, float height)
        {
            Position = new Vector2(x, y);
            Size = new Vector2(width, height);
            moveOrigin = Position;
        }

        public float Left => Position.X;
        public float Right => Position.X + Size.X;
        public float Top => Position.Y;
        public float Bottom => Position.Y + Size.Y;

        public void Update(float deltaTime)
        {
            // So that broken platforms fall
            if (IsBroken)
            {
                breakTimer += deltaTime;
                if (breakTimer >= BreakDuration)
                {
                    // Platforms go off screen to disapear
                    Position = new Vector2(-9999, -9999);
                    return;
                }
            }

            // Camera scrolling so they keep moving up
            Vector2 scroll = new Vector2(0, ScrollSpeed * deltaTime);
            Position += scroll;
            moveOrigin += scroll;

            // Moving platform oscillation
            if (IsMoving)
            {
                moveTimer += deltaTime * MoveSpeed;
                float xOffset = (float)Math.Sin(moveTimer) * MoveDistance;
                Position = new Vector2(moveOrigin.X + xOffset, Position.Y);
            }

            // Any external velocity applied just in case
            Position += Velocity * deltaTime;
        }

        public void Draw()
        {
            // Green = moving | Red = normal
            Draw.FillColor = IsMoving ? Color.Green : Color.Red;
            Draw.LineColor = Color.Black;
            Draw.LineSize = 2;

            Draw.Rectangle(Position, Size);
        }
            // Player landing on platform (logic)
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
