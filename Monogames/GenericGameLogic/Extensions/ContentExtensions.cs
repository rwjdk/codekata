using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GenericGameLogic.Extensions
{
    public static class ContentExtensions
    {
        public static Texture2D LoadTexture2D(this ContentManager contentManager, string nameWithoutExtension)
        {
            return contentManager.Load<Texture2D>(nameWithoutExtension);
        }
        
        public static SpriteFont LoadSpriteFont(this ContentManager contentManager, string nameWithoutExtension)
        {
            return contentManager.Load<SpriteFont>(nameWithoutExtension);
        }
    }
}