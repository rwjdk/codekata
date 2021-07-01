using GenericGameLogic;
using GenericGameLogic.Extensions;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MyFirstGame.Model
{
    public class GameOverGameState : GameState
    {
        public static PlayerSprite Winner { get; set; }
        private bool _winnerSongPlayed;
        private readonly Song _mrTWin;
        private readonly Song _chuckNorrisWin;
        private readonly SpriteFont _font;

        public GameOverGameState(GameManager gameManager) : base(gameManager)
        {
            _mrTWin = gameManager.Content.Load<Song>("MrTWin");
            _chuckNorrisWin = gameManager.Content.Load<Song>("ChuckNorrisWin");
            _font = gameManager.Content.LoadSpriteFont("Font");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (PreviousKeyboardState.IsKeyDown(Keys.Enter) && CurrentKeyboardState.IsKeyUp(Keys.Enter))
            {
                Reset();
            }
        }

        private void Reset()
        {
            Winner = null;
            _winnerSongPlayed = false;
            var mainGameState = (MainGameState)GameManager.MovePrevious();
            mainGameState.Reset();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Winner != null)
            {
                spriteBatch.DrawString(_font, Winner.Name + " is the winner!", new Vector2(25, GameManager.HorizontalScreenCenter), Color.Red);
                spriteBatch.DrawString(_font, "(Press 'Enter' to Restart)", new Vector2(25, GameManager.HorizontalScreenCenter + 70), Color.Red);
                if (!_winnerSongPlayed)
                {
                    _winnerSongPlayed = true;
                    MediaPlayer.Play(Winner.IsChuckNorris ? _chuckNorrisWin : _mrTWin);
                }
            }
        }
    }
}