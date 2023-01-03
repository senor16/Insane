
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine{
    public interface IActor{
        Vector2 Position{get;}
        Rectangle BoundingBox {get;} 

        bool ToRemove {get;set;}

        void Update(GameTime gameTime);
        void Draw(SpriteBatch pSpriteBatch);

        void TouchedBy(IActor pBy);
        
    }
}