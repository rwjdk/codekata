using System;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tennis.Logic.Model;

namespace TennisGame.Model
{
    public class Ball : Sprite
    {
        public bool InPlay { get; set; }
        public bool Bounced { get; set; }
        public float AngleChange { get; set; }
        public int HitSpeed = 5;
        private Random _random;

        public Ball(GameState gameState, Texture2D texture) : base(gameState, texture)
        {
            _random = new Random();
            InPlay = false;
            Bounced = false;
            DirectionSpeed = 0;
        }

        public void PlayBall(TennisPlayer player)
        {
            player.Serving = false;
            InPlay = true;
            switch (player.PlayerNumber)
            {
                case Player.Player1:
                    DirectionSpeed = HitSpeed;
                    AngleChange = GenerateRandomAngle();
                    break;
                case Player.Player2:
                    DirectionSpeed = -HitSpeed;
                    AngleChange = GenerateRandomAngle();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(player), player, null);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            SetPosition(GetBallPosition());
        }

        private Vector2 GetBallPosition()
        {
            return new Vector2(Position.X + DirectionSpeed, Position.Y + AngleChange);
        }

        public bool IsHitByPlayer(TennisPlayer player)
        {
            return Rectangle.Intersects(player.Rectangle);
        }

        public float GenerateRandomAngle()
        {
            if (Position.Y > GameState.GameManager.HorizontalScreenCenter)
            {
                //Top half
                return _random.Next(-25, 0) / 10f;
            }

            //Bottom half
            return _random.Next(0, 25) / 10f;
        }
    }
}