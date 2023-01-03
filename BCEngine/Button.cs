using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BCEngine
{
    public delegate void OnClick(Button pSender);

    public class Button : Sprite
    {
        public bool isHover { get; private set; }
        private MouseState oldMouseState;
        public OnClick onClick {get;set;}
        public Button(Texture2D pTexture) : base(pTexture)
        {
            isHover = false;
            oldMouseState = Mouse.GetState();
        }

        public override void Update(GameTime gameTime)
        {
            Point mousePos = Mouse.GetState().Position;
            MouseState newMouseState = Mouse.GetState();

            if (BoundingBox.Contains(mousePos))
            {
                if (!isHover)
                {
                    isHover = true;
                    Debug.WriteLine("Button is now on Hover");
                }
            }
            else
            {
                isHover = false;
            }

            if (isHover
            && newMouseState.LeftButton == ButtonState.Pressed
            && oldMouseState.LeftButton != ButtonState.Pressed)
            {
                Debug.WriteLine("Button is clicked");
                if (onClick != null)
                    onClick(this);
            }

            oldMouseState = newMouseState;
            base.Update(gameTime);
        }
    }
}