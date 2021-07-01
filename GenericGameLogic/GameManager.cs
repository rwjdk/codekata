using System;
using System.Collections.Generic;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace GenericGameLogic
{
    public class GameManager
    {
        public ContentManager Content { get; }
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        private int _currentStateIndex;
        private readonly List<GameState> _states;

        public GameManager(GraphicsDeviceManager graphicsDeviceManager, ContentManager content)
        {
            Content = content;
            _graphicsDeviceManager = graphicsDeviceManager;
            _states = new List<GameState>();
            _currentStateIndex = 0;
        }
        public int ScreenWidth => _graphicsDeviceManager.PreferredBackBufferWidth;
        public int ScreenHeight => _graphicsDeviceManager.PreferredBackBufferHeight;
        public float VerticalScreenCenter => ScreenWidth / 2f;
        public float HorizontalScreenCenter => ScreenHeight / 2f;
        
        public void AddState(GameState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            _states.Add(state);
        }

        public GameState CurrentState()
        {
            if (_states.Count == 0)
            {
                throw new ApplicationException("No GameStates added so can't retrieve current");
            }

            return _states[_currentStateIndex];
        }

        public GameState MoveFirst()
        {
            _currentStateIndex = 0;
            return CurrentState();
        }

        public GameState MoveNext()
        {
            if (_currentStateIndex == _states.Count - 1)
            {
                throw new ApplicationException("No more states exist (Already at last state)");
            }

            _currentStateIndex++;
            return CurrentState();
        }
        
        public GameState MovePrevious()
        {
            if (_currentStateIndex == 0)
            {
                throw new ApplicationException("Already at first state. Can't move further back");
            }

            _currentStateIndex--;
            return CurrentState();
        }
    }
}