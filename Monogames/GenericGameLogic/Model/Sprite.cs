using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace GenericGameLogic.Model
{
    public class Sprite : Component
    {
        public GameState GameState { get; }
        public Texture2D Texture { get; }
        public Vector2 Position;
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        public float DirectionSpeed;

        public Sprite(GameState gameState, Texture2D texture)
        {
            GameState = gameState;
            Texture = texture;
            DirectionSpeed = 1;
        }

        public override void Update(GameTime gameTime)
        {
            //Empty
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }

        public int Width => Texture.Width;

        public int Height => Texture.Height;

        public float Left => Position.X;

        public float Right => Position.X + Width;

        public float Top => Position.Y;

        public float Bottom => Position.Y + Height;

        public float VerticalCenter => Width / 2f;

        public float HorizontalCenter => Height / 2f;

        public void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public void SetPosition(ComponentPosition componentPosition, int xAdjustment = 0, int yAdjustment = 0)
        {
            var gameManager = GameState.GameManager;
            switch (componentPosition)
            {
                case ComponentPosition.Center:
                    Position = new Vector2(gameManager.VerticalScreenCenter - VerticalCenter + xAdjustment, gameManager.HorizontalScreenCenter - HorizontalCenter + yAdjustment);
                    break;
                case ComponentPosition.TopCenter:
                    Position = new Vector2(gameManager.VerticalScreenCenter - VerticalCenter + xAdjustment, 0 + yAdjustment);
                    break;
                case ComponentPosition.BottomCenter:
                    Position = new Vector2(gameManager.VerticalScreenCenter - VerticalCenter + xAdjustment, gameManager.ScreenHeight - Height + yAdjustment);
                    break;
                case ComponentPosition.CenterLeft:
                    Position = new Vector2(0 + xAdjustment, gameManager.HorizontalScreenCenter - HorizontalCenter + yAdjustment);
                    break;
                case ComponentPosition.CenterRight:
                    Position = new Vector2(gameManager.ScreenWidth - Width + xAdjustment, gameManager.HorizontalScreenCenter - HorizontalCenter + yAdjustment);
                    break;
                case ComponentPosition.TopLeft:
                    Position = new Vector2(0 + xAdjustment, 0 + yAdjustment);
                    break;
                case ComponentPosition.TopRight:
                    Position = new Vector2(gameManager.ScreenWidth - Width + xAdjustment, 0 + yAdjustment);
                    break;
                case ComponentPosition.BottomLeft:
                    Position = new Vector2(0 + xAdjustment, gameManager.ScreenHeight - Height + yAdjustment);
                    break;
                case ComponentPosition.BottomRight:
                    Position = new Vector2(gameManager.ScreenWidth - Width + xAdjustment, gameManager.ScreenHeight - Height + yAdjustment);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(componentPosition), componentPosition, null);
            }
        }
    }
}