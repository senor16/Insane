using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TexturePackerLoader;

namespace BCEngine
{
    public class SceneGameplay : Scene
    {
        private KeyboardState oldKBState;
        private GamePadState oldPadState;
        private Song music;
        private SoundEffect sfxExplode;
        private PlayerInput playerInput;
        private Rectangle World;
        private SpriteSheetLoader spriteSheetLoader;
        private SpriteSheet heroSpriteSheet;

        private Hero MyHero;

        private Texture2D Background;



        public SceneGameplay(MainGame pGame) : base(pGame)
        {

        }

        public override void Load()
        {

            World.Width = 1000;
            World.Height = mainGame.Screen.Height;

            // Input state
            oldKBState = Keyboard.GetState();
            oldPadState = GamePad.GetState(PlayerIndex.One);
            playerInput = new PlayerInput();

            spriteSheetLoader = new SpriteSheetLoader(mainGame.Content, mainGame.GraphicsDevice);
            heroSpriteSheet = spriteSheetLoader.Load("Robot 1.png");

            // Hero
            // Anim Idle
            Anim HeroIdle = new Anim("idle", 10, true);
            for (int i = 0; i < 9; i++)
            {
                HeroIdle.addFrame(heroSpriteSheet.Sprite("R1_Idle/idle_00" + i));
            }

            // Anim Run
            Anim HeroRun = new Anim("run", 10, true);
            for (int i = 0; i < 12; i++)
            {
                if (i < 10)
                {
                    HeroRun.addFrame(heroSpriteSheet.Sprite("R1_Run/Run_00" + i));
                }
                else
                {
                    HeroRun.addFrame(heroSpriteSheet.Sprite("R1_Run/Run_0" + i));
                }
            }


            MyHero = new Hero();

            MyHero.Height = 150;

            MyHero.addAnim(HeroIdle);
            MyHero.addAnim(HeroRun);
            MyHero.playAnim("run");
            MyHero.Position = new Vector2(40, mainGame.Screen.Height - MyHero.Height - 20);
            Debug.WriteLine(MyHero.Position);
            listActor.Add(MyHero);

            // Meteors
            // AssetManager.LoadTexture2D(mainGame.Content, "meteor");
            // for (int i = 0; i < 10; i++)
            // {
            //     Meteor m = new Meteor(AssetManager.GetTexture2D("meteor"));
            //     m.Position = new Vector2(Util.GetInt(1, mainGame.Screen.Width - m.Texture.Width), Util.GetInt(1, mainGame.Screen.Height - m.Texture.Height));
            //     listActor.Add(m);
            // }

            // Music
            // AssetManager.LoadSong(mainGame.Content,"techno");
            // music = AssetManager.GetSong("techno");
            // MediaPlayer.Play(music);
            // MediaPlayer.IsRepeating=true;

            // Sfx
            // AssetManager.LoadSoundEffect(mainGame.Content,"explode");
            // sfxExplode = AssetManager.GetSoundEffect("explode");

            // Background
            AssetManager.LoadTexture2D(mainGame.Content, "War2");
            Background = AssetManager.GetTexture2D("War2");


            base.Load();
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            // Debug.WriteLine("Updating Scene Gameplay..."); 

            // Mouse
            // MouseState mouseState = Mouse.GetState();
            // Debug.WriteLine(mouseState.X+", "+mouseState.Y+", "+mouseState.LeftButton);



            /**
                Controlls
            */
            playerInput.reset();
            // Pad
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                GamePadState newPadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickLeft) || newPadState.IsButtonDown(Buttons.DPadLeft))
                    playerInput.Left = true;
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickDown) || newPadState.IsButtonDown(Buttons.DPadDown))
                    playerInput.Down = true;
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickRight) || newPadState.IsButtonDown(Buttons.DPadRight))
                    playerInput.Right = true;
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickUp) || newPadState.IsButtonDown(Buttons.DPadUp))
                    playerInput.Up = true;


                if (newPadState.IsButtonDown(Buttons.A))
                    playerInput.A = true;

                if (newPadState.IsButtonDown(Buttons.B) && !oldPadState.IsButtonDown(Buttons.B))
                    playerInput.B = true;

                oldPadState = newPadState;
            }

            //  Keyboard        
            KeyboardState newKBState = Keyboard.GetState();
            if ((newKBState.IsKeyDown(Keys.Left) || newKBState.IsKeyDown(Keys.A)))
                playerInput.Left = true;
            if ((newKBState.IsKeyDown(Keys.Down) || newKBState.IsKeyDown(Keys.S)))
                playerInput.Down = true;
            if ((newKBState.IsKeyDown(Keys.Right) || newKBState.IsKeyDown(Keys.D)))
                playerInput.Right = true;
            if ((newKBState.IsKeyDown(Keys.Up) || newKBState.IsKeyDown(Keys.W)))
                playerInput.Up = true;

            if (newKBState.IsKeyDown(Keys.Space) && !oldKBState.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("Space on the menu");
                mainGame.gameState.changeScene(GameState.SceneType.Menu);
            }

            if (newKBState.IsKeyDown(Keys.I))
            {
                Debug.WriteLine("Fire !");
            }

            // Handle inputs
            // if (playerInput.Up && MyHero.Position.Y > 0)
            // {
            //     MyHero.Move(3 * 0, 3 * -1);
            // }
            // if (playerInput.Down && MyHero.Position.Y < World.Height - MyHero.Height)
            // {
            //     MyHero.Move(3 * 0, 3 * 1);
            // }
            // if (playerInput.Left && MyHero.Position.X > 0)
            // {
            //     MyHero.Move(3 * -1, 3 * 0);
            //     MyHero.effect = SpriteEffects.FlipHorizontally;
            // }
            // if (playerInput.Right && MyHero.Position.X < World.Width - MyHero.Width)
            // {
            //     MyHero.Move(3 * 1, 3 * 0);
            //     MyHero.effect = SpriteEffects.None;
            // }
            if (playerInput.A)
            {

            }
            if (playerInput.B)
            {

            }
            if (playerInput.X)
            {

            }
            if (playerInput.Y)
            {

            }




            // /**
            //     Meteors
            // */
            // foreach (IActor Actor in listActor)
            // {
            //     if (Actor is Meteor m)
            //     {
            //         if (m.Position.X < 0)
            //         {
            //             m.Position = new Vector2(0, m.Position.Y);
            //             m.vx = -m.vx;
            //         }
            //         if (m.Position.X > mainGame.Screen.Width - m.Texture.Width)
            //         {
            //             m.Position = new Vector2(mainGame.Screen.Width - m.Texture.Width, m.Position.Y);
            //             m.vx = -m.vx;
            //         }
            //         if (m.Position.Y < 0)
            //         {
            //             m.Position = new Vector2(m.Position.X, 0);
            //             m.vy = -m.vy;

            //         }

            //         if (m.Position.Y > mainGame.Screen.Height - m.Texture.Height)
            //         {
            //             m.Position = new Vector2(m.Position.X, mainGame.Screen.Height - m.Texture.Height);
            //             m.vy = -m.vy;
            //         }
            //         if (Util.CollideByBox(m, MyHero))
            //         {
            //             MyHero.TouchedBy(m);
            //             m.TouchedBy(MyHero);
            //             m.ToRemove = true;
            //             // sfxExplode.Play();
            //         }
            //     }
            // }

            listActor.RemoveAll(item => item.ToRemove == true);

            /**
                Ship
            */
            // if (MyHero.Energy <= 0)
            // {
            //     MediaPlayer.Stop();
            //     mainGame.gameState.changeScene(GameState.SceneType.Gameover);
            // }

            oldKBState = newKBState;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Gameplay...");
            mainGame.spriteBatch.Begin();
            mainGame.spriteBatch.Draw(Background, Vector2.Zero, Color.White);


            // mainGame.spriteBatch.DrawString(AssetManager.MainFont, "Ship Energy : " + MyHero.Energy, new Vector2(20, 50), Color.Wheat);
            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "This is the Gameplay", new Vector2(100, 10), Color.Red);

            mainGame.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}