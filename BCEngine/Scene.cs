
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace BCEngine
{
    public abstract class Scene
    {

        protected MainGame mainGame;
        protected List<IActor> listActor ;

        public Scene(MainGame pGame)
        {
            mainGame = pGame;
            listActor = new List<IActor>();

        }
        public virtual void Load()
        {

        }
        public virtual void Update(GameTime gameTime)
        {
            // Debug.WriteLine("Updating Scene...");
            foreach(IActor actor in listActor){
                actor.Update(gameTime);
            }

        }
        public virtual void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene...");
            foreach(IActor actor in listActor){
                actor.Draw(mainGame.spriteBatch,mainGame.spriteRender);
            }

        }
        public virtual void Unload()
        {

        }
    }
}