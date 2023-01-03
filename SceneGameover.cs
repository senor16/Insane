using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace BCEngine
{
     public class SceneGameover : Scene
    {
        public SceneGameover(MainGame pGame) : base(pGame)
        {
        }


        public override void Load()
        {
            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            // Debug.WriteLine("Updating Scene Gameover...");
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Gameover...");
            mainGame.spriteBatch.Begin();
            
            mainGame.spriteBatch.DrawString(AssetManager.MainFont,"Game Over",new Vector2(100,50),Color.Red);
            
            mainGame.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}