using GenericGameLogic;
using GenericGameLogic.Extensions;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TennisGame.Model
{
    public class GameOverGameState : GameState
    {
        public static TennisPlayer Winner;
        private readonly SpriteFont _font;

        public GameOverGameState(GameManager gameManager) : base(gameManager)
        {
            _font = gameManager.Content.LoadSpriteFont("font");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            var text = "Winner is " + Winner.PlayerNumber;
            var textWidth = _font.MeasureString(text);
            var position = new Vector2(GameManager.VerticalScreenCenter - textWidth.X / 2f, 250);
            spriteBatch.DrawString(_font, text, position, Color.White);

            spriteBatch.Draw(Winner.Texture, new Vector2(GameManager.VerticalScreenCenter, GameManager.HorizontalScreenCenter), Color.White);
        }
    }
}