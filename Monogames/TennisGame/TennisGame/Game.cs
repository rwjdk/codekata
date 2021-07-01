using GenericGameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using TennisGame.Control;
using TennisGame.Model;

namespace TennisGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private readonly GameManager _gameManager;
        SpriteBatch _spriteBatch;
        private TerminationController _iTerminationController;

        public Game()
        {
            var graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 997,
                PreferredBackBufferHeight = 700
            };
            Content.RootDirectory = "Content";
            _gameManager = new GameManager(graphics, Content);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Setup of all the Tennis Logic
            var numberOfSetsController = new NumberOfSetsController();
            var gameRulesController = new GameRulesController();
            var setRulesController = new SetRulesController();
            var matchRulesController = new MatchRulesController();
            var gameScoreController = new GameScoreController(gameRulesController);
            var matchController = new MatchController(gameScoreController, setRulesController, matchRulesController);
            var guiController = new GuiController();
            _iTerminationController = new TerminationController(this);
            var appController = new AppController(numberOfSetsController, matchController, guiController, _iTerminationController);

            //Setup of the game states
            _gameManager.AddState(new ChooseNumberOfSetsGameState(_gameManager, appController, guiController));
            _gameManager.AddState(new MainGameState(_gameManager, appController));
            _gameManager.AddState(new GameOverGameState(_gameManager));
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _iTerminationController.TerminateApp();
            }

            _gameManager.CurrentState().Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(153, 177, 101));

            _spriteBatch.Begin();

            _gameManager.CurrentState().Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}