using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GenericGameLogic.Model
{
    public class DirectionalInputMethod
    {
        public Keys Up { get; }
        public Keys Down { get; }
        public Keys Left { get; }
        public Keys Right { get; }

        public DirectionalInputMethod(Keys up, Keys down, Keys left, Keys right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }

        public bool IsUpKeyPressed => Keyboard.GetState().IsKeyDown(Up);
        public bool IsDownKeyPressed => Keyboard.GetState().IsKeyDown(Down);
        public bool IsLeftKeyPressed => Keyboard.GetState().IsKeyDown(Left);
        public bool IsRightKeyPressed => Keyboard.GetState().IsKeyDown(Right);

        public Vector2 CalculatedNextPostion(Sprite sprite, BoundingRules rules = BoundingRules.None)
        {
            var oldPosition = sprite.Position;
            Vector2 next = oldPosition;
            if (IsUpKeyPressed)
            {
                next.Y = sprite.Position.Y - sprite.DirectionSpeed;
            }

            if (IsDownKeyPressed)
            {
                next.Y = sprite.Position.Y + sprite.DirectionSpeed;
            }

            if (IsLeftKeyPressed)
            {
                next.X = sprite.Position.X - sprite.DirectionSpeed;
            }

            if (IsRightKeyPressed)
            {
                next.X = sprite.Position.X + sprite.DirectionSpeed;
            }

            if (rules.HasFlag(BoundingRules.NeedToStayWithinGameScreen))
            {
                var gameManager = sprite.GameState.GameManager;
                next.X = MathHelper.Clamp(next.X, 0, gameManager.ScreenWidth - sprite.Width);
                next.Y = MathHelper.Clamp(next.Y, 0, gameManager.ScreenHeight - sprite.Height);
            }

            if (rules.HasFlag(BoundingRules.CanNotTouchOtherSpritesOnGameScreen))
            {
                foreach (Sprite otherSprite in sprite.GameState.Sprites)
                {
                    if (otherSprite == sprite.GameState.Background)
                    {
                        continue; //Allowed to touch background
                    }

                    if (otherSprite == sprite)
                    {
                        continue; //Allowed to "touch" itself :-)
                    }

                    var nextRectangle = new Rectangle((int)next.X, (int)next.Y, sprite.Width, sprite.Height);
                    if (otherSprite.Rectangle.Intersects(nextRectangle))
                    {
                        return sprite.Position; //Return old position as next position is not allowed
                    }
                }
            }

            return next;
        }

        public static DirectionalInputMethod ArrowKeys => new DirectionalInputMethod(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
        // ReSharper disable once InconsistentNaming
        public static DirectionalInputMethod WSAD => new DirectionalInputMethod(Keys.W, Keys.S, Keys.A, Keys.D);
    }
}