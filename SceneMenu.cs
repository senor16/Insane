using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace BCEngine
{
    public class SceneMenu : Scene
    {

        private Button btnPlay;
        Rectangle Screen;
        private Song music;
        public SceneMenu(MainGame pGame) : base(pGame)
        {            
        }

        public void onClickPlay(Button pSender)
        {
            MediaPlayer.Stop();
            mainGame.gameState.changeScene(GameState.SceneType.Gameplay);
        }

        public override void Load()
        {
            Screen = mainGame.Window.ClientBounds;
            AssetManager.LoadTexture2D(mainGame.Content,"button");
            btnPlay = new Button(AssetManager.GetTexture2D("button"));
            btnPlay.Position = new Vector2(Screen.Width/2-btnPlay.Texture.Width/2,Screen.Height/2-btnPlay.Texture.Height/2);
            btnPlay.onClick = onClickPlay;
            listActor.Add(btnPlay);

            // Music
            AssetManager.LoadSong(mainGame.Content,"cool");
            music = AssetManager.GetSong("cool");
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating=true;
            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            // Debug.WriteLine("Updating Scene Menu...");
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Menu...");
            mainGame.spriteBatch.Begin();

            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "This is the Menu", new Vector2(1, 1), Color.Blue);

            mainGame.spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}