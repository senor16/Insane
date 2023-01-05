using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace BCEngine;

public class Sprite : IActor
{
    public Vector2 Position { get; set; }

    public Rectangle BoundingBox { get; set; }

    public Texture2D Texture { get; set; }
    public List<Anim> ListAnim { get; set; }
    public Anim currentAnim { get; set; }
    public float vx { get; set; }
    public float vy { get; set; }
    public bool ToRemove { get; set; }

    public SpriteEffects effect { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Sprite()
    {
        Texture = null;
        ListAnim = new List<Anim>();
        currentAnim = null;
        ToRemove = false;
        effect = SpriteEffects.None;
    }

    public void addAnim(Anim pAnim)
    {
        ListAnim.Add(pAnim);
    }
    public void Move(float pX, float pY)
    {
        Position = new Vector2(Position.X + pX, Position.Y + pY);
    }

    public virtual void Update(GameTime gameTime)
    {
        if (currentAnim != null)
        {
            currentAnim.Update();
            // if (Width != currentAnim.frames[currentAnim.currentFrame].Width)
            //     Width = currentAnim.frames[currentAnim.currentFrame].Width;

            // if (Height != currentAnim.frames[currentAnim.currentFrame].Height)
            //     Height = currentAnim.frames[currentAnim.currentFrame].Height;

        }
        else if (Texture!= null)
        {
            Width = Texture.Width;
            Height = Texture.Height;
        }
        Move(vx, vy);
        BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

    }

    public virtual void Draw(SpriteBatch pSpriteBatch, SpriteRender pSpriteRenderer)
    {
        pSpriteBatch.Begin();
        if (Texture!= null)
            pSpriteBatch.Draw(Texture, Position, Color.White);
        else if(currentAnim != null)
        {
            pSpriteRenderer.Draw(currentAnim.frames[currentAnim.currentFrame], Position, Color.White,0,1,effect);            
            // pSpriteBatch.Draw(, Position, null, Color.White, 0, Vector2.Zero, 1.0f, effect, 0);
        }
        pSpriteBatch.End();
    }

    public void playAnim(string pName)
    {
        if (currentAnim==null || (currentAnim!=null && currentAnim.name != pName))
        {
            foreach (Anim anim in ListAnim)
            {
                if (anim.name == pName)
                {
                    currentAnim = anim;
                    anim.reset();
                }
            }
        }
    }

    public virtual void TouchedBy(IActor pBy)
    {

    }
}