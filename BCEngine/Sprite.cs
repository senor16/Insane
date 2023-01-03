using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine;

public class Sprite : IActor
{
    public Vector2 Position { get; set; }

    public Rectangle BoundingBox { get; set; }

    public Texture2D Texture;
    public float vx { get; set; }
    public float vy { get; set; }
    public bool ToRemove { get ; set ; }

    public Sprite(Texture2D pTexture)
    {
        Texture = pTexture;
        ToRemove=false;
    }

    public void Move(float pX, float pY)
    {
        Position = new Vector2(Position.X + pX, Position.Y + pY);
    }

    public virtual void Update(GameTime gameTime)
    {
        Move(vx,vy);
        BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
    }

    public virtual void Draw(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Begin();
        pSpriteBatch.Draw(Texture, Position, Color.White);
        pSpriteBatch.End();
    }

    public virtual void TouchedBy(IActor pBy)
    {
        
    }
}