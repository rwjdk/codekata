using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GenericGameLogic.Model
{
    public abstract class GameState
    {
        public GameManager GameManager { get; }
        public List<Sprite> Sprites { get; }
        public Sprite Background { get; private set; }
        protected KeyboardState PreviousKeyboardState { get; set; }
        protected KeyboardState CurrentKeyboardState { get; set; }

        protected GameState(GameManager gameManager)
        {
            Sprites = new List<Sprite>();
            GameManager = gameManager;
        }

        protected void AddSprite(Sprite sprite)
        {
            Sprites.Add(sprite);
        }

        protected Sprite AddSprite(Texture2D texture)
        {
            var sprite = new Sprite(this,texture);
            Sprites.Add(sprite);
            return sprite;
        }

        protected void AddBackground(Texture2D texture)
        {
            var sprite = new Sprite(this, texture);
            Sprites.Add(sprite);
            Background = sprite;
        }

        public virtual void Update(GameTime gameTime)
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
            foreach (var sprite in Sprites)
            {
                sprite.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in Sprites)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
        }
    }
}