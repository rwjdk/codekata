using System.Linq;
using GenericGameLogic;
using GenericGameLogic.Extensions;
using GenericGameLogic.Model;
using Microsoft.Xna.Framework.Graphics;

namespace MyFirstGame.Model
{
    public class MainGameState : GameState
    {
        internal static Sprite Goal;
        
        public MainGameState(GameManager gameManager) : base(gameManager)
        {
            AddBackground(gameManager.Content.LoadTexture2D("maze"));
            AddGoal(gameManager.Content.LoadTexture2D("goal_small"));
            AddSprite(new PlayerSprite(this, "Chuck Norris", gameManager.Content.LoadTexture2D("chuck_small"), DirectionalInputMethod.ArrowKeys, PlayerStartPosition.Player2, true));
            AddSprite(new PlayerSprite(this, "Mr. T", gameManager.Content.LoadTexture2D("mrT_small"), DirectionalInputMethod.WSAD, PlayerStartPosition.Player1, false));
        }

        private void AddGoal(Texture2D texture)
        {
            Goal = AddSprite(texture);
            Goal.SetPosition(ComponentPosition.Center, yAdjustment: 12);
        }

        public void Reset()
        {
            var players = Sprites.Where(x => x is PlayerSprite).ToList();
            foreach (var sprite in players)
            {
                ((PlayerSprite)sprite).Reset();
            }
        }
    }
}