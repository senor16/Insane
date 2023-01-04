using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine;

public class Sprite : IActor
{
    public Vector2 Position { get; set; }

    public Rectangle BoundingBox { get; set; }

    public Texture2D Texture { get; set; }
    public List<Anim> ListAnim { get; set; }
    public Anim currentAnim {get;set;}
    public float vx { get; set; }
    public float vy { get; set; }
    public bool ToRemove { get; set; }

    public Sprite()
    {
        Texture = null;
        ListAnim = new List<Anim>();
        currentAnim=null;
        ToRemove = false;
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
        if (currentAnim!=null)
            currentAnim.Update();   
        Move(vx, vy);
        BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
    }

    public virtual void Draw(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Begin();
        if (currentAnim==null)
            pSpriteBatch.Draw(Texture, Position, Color.White);
        else{
            pSpriteBatch.Draw(currentAnim.frames[currentAnim.currentFrame],Position,Color.White);
        }
        pSpriteBatch.End();
    }

    public virtual void TouchedBy(IActor pBy)
    {

    }
}