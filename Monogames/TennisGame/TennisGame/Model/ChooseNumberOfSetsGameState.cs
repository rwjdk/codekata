using GenericGameLogic;
using GenericGameLogic.Extensions;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tennis.Logic.Interface;
using TennisGame.Control;

namespace TennisGame.Model
{
    public class ChooseNumberOfSetsGameState : GameState
    {
        private readonly IAppController _appController;
        private readonly GuiController _guiController;
        private readonly SpriteFont _font;

        public ChooseNumberOfSetsGameState(GameManager gameManager, IAppController appController, GuiController guiController) : base(gameManager)
        {
            _appController = appController;
            _guiController = guiController;
            var title = AddSprite(gameManager.Content.LoadTexture2D("title"));
            title.SetPosition(ComponentPosition.Center);
            _font = gameManager.Content.LoadSpriteFont("font");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (_appController.IsNumberOfSetsNotDefined())
            {
                _appController.AskForNumberOfSets();
            }
            else
            {
                _appController.StartMatch();
                GameManager.MoveNext();
            }

            if (CurrentKeyboardState.IsKeyDown(Keys.D1))
            {
                _guiController.NumberOfSetSelected = 1;
            }

            if (CurrentKeyboardState.IsKeyDown(Keys.D3))
            {
                _guiController.NumberOfSetSelected = 3;
            }

            if (CurrentKeyboardState.IsKeyDown(Keys.D5))
            {
                _guiController.NumberOfSetSelected = 5;
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            var text = "Please enter \"1\", \"3\" or \"5\" to choose number of sets";
            var textWidth = _font.MeasureString(text);
            var position = new Vector2(GameManager.VerticalScreenCenter - textWidth.X / 2f, 100);
            spriteBatch.DrawString(_font, text, position, Color.White);
        }
    }
}