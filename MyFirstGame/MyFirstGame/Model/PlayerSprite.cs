using System;
using System.Linq;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MyFirstGame.Model
{
    public class PlayerSprite : Sprite
    {
        public string Name { get; }
        public bool IsChuckNorris { get; }
        private bool _chuckAlwaysWinsMode;
        private readonly Song _chuckAlwaysWinSong;
        private readonly DirectionalInputMethod _inputMethod;
        private readonly PlayerStartPosition _startPosition;

        public PlayerSprite(GameState gameState, string name, Texture2D texture, DirectionalInputMethod inputMethod, PlayerStartPosition startPosition, bool isChuckNorris) : base(gameState, texture)
        {
            _startPosition = startPosition;
            _inputMethod = inputMethod;
            Name = name;
            IsChuckNorris = isChuckNorris;
            DirectionSpeed = 3;
            SetStartPosition(startPosition);
            _chuckAlwaysWinSong = gameState.GameManager.Content.Load<Song>("ChuckNorrisWinMode");
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.End) && IsChuckNorris && !_chuckAlwaysWinsMode)
            {
                MediaPlayer.Play(_chuckAlwaysWinSong);
                _chuckAlwaysWinsMode = true;
            }
            var nextCalculatedPosition = _inputMethod.CalculatedNextPostion(this, BoundingRules.NeedToStayWithinGameScreen);

            if (IsWall(nextCalculatedPosition) && !_chuckAlwaysWinsMode)
            {
                return;
            }

            SetPosition(nextCalculatedPosition);
            if (Rectangle.Intersects(MainGameState.Goal.Rectangle))
            {
                GameOverGameState.Winner = this;
                GameState.GameManager.MoveNext();
            }
        }

        private bool IsWall(Vector2 nextCalculatedPosition)
        {
            var rectangle = new Rectangle(
                (int)(nextCalculatedPosition.X + VerticalCenter),
                (int)(nextCalculatedPosition.Y + HorizontalCenter),
                (int)(Width - VerticalCenter),
                (int)(Height - HorizontalCenter));
            Color[] rawData = new Color[rectangle.Width * rectangle.Height];
            GameState.Background.Texture.GetData(0, rectangle, rawData, 0, rectangle.Width * rectangle.Height);

            if (rawData.All(background => background.R != 0 || background.G != 0 || background.B != 0))
            {
                return false;
            }

            return true;
        }

        private void SetStartPosition(PlayerStartPosition startPosition)
        {
            switch (startPosition)
            {
                case PlayerStartPosition.Player1:
                    SetPosition(new Vector2(240, 240));
                    break;
                case PlayerStartPosition.Player2:
                    SetPosition(new Vector2(740, 240));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(startPosition), startPosition, null);
            }
        }

        public void Reset()
        {
            _chuckAlwaysWinsMode = false;
            SetStartPosition(_startPosition);
        }
    }
}