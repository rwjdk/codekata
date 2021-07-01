using System;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tennis.Logic.Model;

namespace TennisGame.Model
{
    public class TennisPlayer : Sprite
    {
        private readonly DirectionalInputMethod _inputMethod;
        public Player PlayerNumber { get; }
        public bool Serving;

        public TennisPlayer(GameState gameState, Texture2D texture, DirectionalInputMethod inputMethod, Player playerNumber) : base(gameState, texture)
        {
            PlayerNumber = playerNumber;
            _inputMethod = inputMethod;
            SetStartPosition();
            DirectionSpeed = 5;
            Serving = false;
        }

        public void SetStartPosition()
        {
            switch (PlayerNumber)
            {
                case Player.Player1:
                    SetPosition(ComponentPosition.CenterLeft, 50, 120);
                    break;
                case Player.Player2:
                    SetPosition(ComponentPosition.CenterRight, -50, -120);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(PlayerNumber), PlayerNumber, null);
            }
        }

        public override void Update(GameTime gameTime)
        {
            var nextPostion = _inputMethod.CalculatedNextPostion(this, BoundingRules.NeedToStayWithinGameScreen);
            if (PlayerIsOnWrongSideOfNet(nextPostion)) { return; }
            if (PlayerInServeModeAndToFarOnOwnSide(nextPostion)) { return;}
            SetPosition(nextPostion);
        }

        private bool PlayerInServeModeAndToFarOnOwnSide(Vector2 nextPostion)
        {
            if (!Serving)
            {
                return false;
            }
            switch (PlayerNumber)
            {
                case Player.Player1:
                    if (nextPostion.X > 100)
                    {
                        return true;
                    }
                    break;
                case Player.Player2:
                    if (nextPostion.X < GameState.GameManager.ScreenWidth - 100)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private bool PlayerIsOnWrongSideOfNet(Vector2 nextPostion)
        {
            switch (PlayerNumber)
            {
                case Player.Player1:
                    if (nextPostion.X > GameState.GameManager.VerticalScreenCenter - 60) // -60 because the net is schewed right on the background due to the shadow
                    {
                        return true;
                    }
                    break;
                case Player.Player2:
                    if (nextPostion.X < GameState.GameManager.VerticalScreenCenter - 10) // -10 because the net is schewed right on the background due to the shadowdddds
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}