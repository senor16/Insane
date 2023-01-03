namespace BCEngine;
using Microsoft.Xna.Framework.Graphics;

public class Hero : Sprite{
    public int Energy;

    public Hero(Texture2D pTexture) : base(pTexture)
    {
        Energy=100;
    }

    public override void TouchedBy(IActor pBy){
        if(pBy is Meteor){
            Energy-=10;
        }
    }
}