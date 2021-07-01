using GenericGameLogic;
using GenericGameLogic.Extensions;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyFirstGame.Model
{
    public class TitleGameState : GameState
    {
        private readonly SpriteFont _font;

        public TitleGameState(GameManager gameManager) : base(gameManager)
        {
            AddSplashImage(gameManager.Content.LoadTexture2D("chuckVsMrT"));
            _font = gameManager.Content.LoadSpriteFont("Font");
        }

        private void AddSplashImage(Texture2D texture)
        {
            var sprite = new Sprite(this, texture);
            sprite.SetPosition(ComponentPosition.Center);
            Sprites.Add(sprite);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (PreviousKeyboardState.IsKeyDown(Keys.Space) && CurrentKeyboardState.IsKeyUp(Keys.Space))
            {
                GameManager.MoveNext();
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, "Chuck Norris vs Mr. T", new Vector2(330, 5), Color.White);
            spriteBatch.DrawString(_font, "(Press 'spacebar' to begin)", new Vector2(280, 450), Color.White);
            base.Draw(gameTime, spriteBatch);
        }
    }
}