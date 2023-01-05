
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace BCEngine{
    public interface IActor{
        Vector2 Position{get;}
        Rectangle BoundingBox {get;} 

        bool ToRemove {get;set;}

        void Update(GameTime gameTime);
        void Draw(SpriteBatch pSpriteBatch, SpriteRender pSpriteRenderer);

        void TouchedBy(IActor pBy);
        
    }
}