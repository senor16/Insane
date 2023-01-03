using Microsoft.Xna.Framework.Graphics;

namespace BCEngine
{
    public class Meteor : Sprite
    {
        public Meteor(Texture2D pTexture) : base(pTexture)
        {
            do
            {
                vx = (float)Util.GetInt(-3, 3) / 2;
            } while (vx == 0);
            do
            {
                vy = (float)Util.GetInt(-3, 3) / 2;
            } while (vy == 0);
        }
    }
}