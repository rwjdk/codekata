using System;
using GenericGameLogic;
using GenericGameLogic.Extensions;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tennis.Logic.Control;
using Tennis.Logic.Interface;
using Tennis.Logic.Model;

namespace TennisGame.Model
{
    public class MainGameState : GameState
    {
        private readonly IAppController _appController;
        private readonly TennisPlayer _player1;
        private readonly TennisPlayer _player2;
        private readonly SpriteFont _font;
        private readonly Ball _ball;
        private readonly GameScoreFormatter _gameScoreFormatter;

        public MainGameState(GameManager gameManager, IAppController appController) : base(gameManager)
        {
            _appController = appController;
            _gameScoreFormatter = new GameScoreFormatter();
            AddBackground(gameManager.Content.LoadTexture2D("tennisCourt"));
            _player1 = new TennisPlayer(this, gameManager.Content.LoadTexture2D("player1"), DirectionalInputMethod.WSAD, Player.Player1);
            _player2 = new TennisPlayer(this, gameManager.Content.LoadTexture2D("player2"), DirectionalInputMethod.ArrowKeys, Player.Player2);
            _ball = new Ball(this, gameManager.Content.LoadTexture2D("tennisBall"));
            AddSprite(_player1);
            AddSprite(_player2);
            AddSprite(_ball);
            _font = gameManager.Content.LoadSpriteFont("font");
            //Setup of events
            appController.GameStatusChanged += GameStatusChanged;
            appController.MatchIsOver += MatchIsOver;
        }

        private IMatch Match { get; set; }

        private void GameStatusChanged(IMatch match)
        {
            Match = match;
            _player1.Serving = match.CurrentServe == Player.Player1;
            _player2.Serving = match.CurrentServe == Player.Player2;
            _ball.InPlay = false;
            _player1.SetStartPosition();
            _player2.SetStartPosition();
        }

        private void MatchIsOver(IMatch match)
        {
            Match = match;
            if (match.Winner != null)
            {
                GameOverGameState.Winner = match.Winner.Value == Player.Player1 ? _player1 : _player2;
                GameManager.MoveNext();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!_appController.HaveNotYetFoundItsWinner())
            {
                return;
            }

            if (!_ball.InPlay)
            {
                PlaceBallInPlayersHand();
                if (CurrentKeyboardState.IsKeyDown(Keys.Space))
                {
                    switch (Match.CurrentServe)
                    {
                        case Player.Player1:
                            _ball.PlayBall(_player1);
                            break;
                        case Player.Player2:
                            _ball.PlayBall(_player2);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                //For "easy" debugging you can give points with key F1 and key F2
                if (CurrentKeyboardState.IsKeyDown(Keys.F1) && PreviousKeyboardState.IsKeyUp(Keys.F1))
                {
                    _appController.SetWinnerOfNextGame(Player.Player1);
                }

                if (CurrentKeyboardState.IsKeyDown(Keys.F2) && PreviousKeyboardState.IsKeyUp(Keys.F2))
                {
                    _appController.SetWinnerOfNextGame(Player.Player2);
                }
            }
            else
            {
                //Ball in play
                if (_ball.IsHitByPlayer(_player1))
                {
                    _ball.DirectionSpeed = _ball.HitSpeed;
                    _ball.AngleChange = _ball.GenerateRandomAngle();

                }
                else if (_ball.IsHitByPlayer(_player2))
                {
                    _ball.DirectionSpeed = -_ball.HitSpeed;
                    _ball.AngleChange = _ball.GenerateRandomAngle();
                }

                if (!(_ball.Position.X > GameManager.VerticalScreenCenter))
                {
                    if (_ball.Bottom < 55 || _ball.Top > 643)
                    {
                        //Ball is out - Point go to this side player
                        _appController.SetWinnerOfNextGame(Player.Player1);
                    }   

                    //Ball on player 1's area - Check if it is past player
                    if (_ball.Left < _player1.Left)
                    {
                        //Player 2 won point
                        _appController.SetWinnerOfNextGame(Player.Player2);
                    }
                }
                else
                {
                    if (_ball.Bottom < 55 || _ball.Top > 643)
                    {
                        //Ball is out - Point go to this side player
                        _appController.SetWinnerOfNextGame(Player.Player2);
                    }   

                    //Ball on player 2's area - Check if it is past player
                    if (_ball.Position.X > _player2.Right)
                    {
                        //Player 1 won point
                        _appController.SetWinnerOfNextGame(Player.Player1);
                    }
                }
            }
        }

        private void PlaceBallInPlayersHand()
        {
            switch (Match.CurrentServe)
            {
                case Player.Player1:
                    _ball.SetPosition(_player1.Right - 25, _player1.Top + 25);
                    break;
                case Player.Player2:
                    _ball.SetPosition(_player2.Left + 10, _player2.Top + 25);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            var currentGame = Match.CurrentGame;
            var player1Score = currentGame.GetGameScore().GetScoreForPlayer(Player.Player1);
            var player2Score = currentGame.GetGameScore().GetScoreForPlayer(Player.Player2);
            var currentSet = Match.CurrentSet;
            var player1Games = currentSet.GetWonGamesForPlayer(Player.Player1);
            var player2Games = currentSet.GetWonGamesForPlayer(Player.Player2);
            spriteBatch.DrawString(_font, $"Set: {Match.CurrentSetNumber} - Games: {player1Games} : {player2Games} - Current Game: {_gameScoreFormatter.FormatPoint(player1Score)} : {_gameScoreFormatter.FormatPoint(player2Score)} - {Match.CurrentServe} to server", new Vector2(10, 10), Color.White);
        }
    }
}