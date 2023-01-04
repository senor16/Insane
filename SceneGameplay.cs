using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BCEngine
{
    public class SceneGameplay : Scene
    {
        private KeyboardState oldKBState;
        private GamePadState oldPadState;
        private Song music;
        private SoundEffect sfxExplode;

        private Rectangle World;

        private Hero MyHero;
        private Texture2D Background;



        public SceneGameplay(MainGame pGame) : base(pGame)
        {

        }

        public override void Load()
        {

            World.Width = 100;
            World.Height = mainGame.Screen.Height;

            Debug.WriteLine("w : " + mainGame.Screen.Width + ", h : " + mainGame.Screen.Height);
            // Input state
            oldKBState = Keyboard.GetState();
            oldPadState = GamePad.GetState(PlayerIndex.One);

            // Ship
            // Anims
            Anim HeroIdle = new Anim("idle", 10, true);
            for (int i = 0; i < 9; i++)
            {
                AssetManager.LoadTexture2D(mainGame.Content,"Robot_1/R1_Idle/idle_00"+i);
                HeroIdle.addFrame(AssetManager.GetTexture2D("Robot_1/R1_Idle/idle_00"+i));
            }
            MyHero = new Hero();
            MyHero.addAnim(HeroIdle);
            MyHero.currentAnim = MyHero.ListAnim[0];
            MyHero.Position = new Vector2(40, mainGame.Screen.Height - MyHero.Texture.Height - 20);
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
            // Pad
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                GamePadState newPadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickLeft))
                {
                    MyHero.Move(3 * -1, 3 * 0);
                }
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickDown))
                {
                    MyHero.Move(3 * 0, 3 * 1);
                }
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickRight))
                {
                    MyHero.Move(3 * 1, 3 * 0);
                }
                if (newPadState.IsButtonDown(Buttons.LeftThumbstickUp))
                {
                    MyHero.Move(3 * 0, 3 * -1);
                }


                if (newPadState.IsButtonDown(Buttons.DPadLeft))
                {
                    MyHero.Move(3 * -1, 3 * 0);
                }

                if (newPadState.IsButtonDown(Buttons.DPadDown))
                {
                    MyHero.Move(3 * 0, 3 * 1);
                }

                if (newPadState.IsButtonDown(Buttons.DPadRight))
                {

                    MyHero.Move(3 * 1, 3 * 0);
                }

                if (newPadState.IsButtonDown(Buttons.DPadUp))
                {
                    MyHero.Move(3 * 0, 3 * -1);
                }

                if (newPadState.IsButtonDown(Buttons.A))
                {
                    Debug.WriteLine("Button A is Down");
                }

                if (newPadState.IsButtonDown(Buttons.B) && !oldPadState.IsButtonDown(Buttons.B))
                {
                    Debug.WriteLine("Button B is down");
                }

                oldPadState = newPadState;
            }

            //  Keyboard        
            KeyboardState newKBState = Keyboard.GetState();

            // Move the ship
            if ((newKBState.IsKeyDown(Keys.Left) || newKBState.IsKeyDown(Keys.A)) && MyHero.Position.X > 0)
            {
                MyHero.Move(3 * -1, 3 * 0);
            }
            if ((newKBState.IsKeyDown(Keys.Down) || newKBState.IsKeyDown(Keys.S)) && MyHero.Position.Y < World.Height - MyHero.Texture.Height)
            {
                MyHero.Move(3 * 0, 3 * 1);
            }
            if (newKBState.IsKeyDown(Keys.Right) || newKBState.IsKeyDown(Keys.D))
            {
                MyHero.Move(3 * 1, 3 * 0);
            }
            if ((newKBState.IsKeyDown(Keys.Up) || newKBState.IsKeyDown(Keys.W)) && MyHero.Position.Y > 0)
            {
                MyHero.Move(3 * 0, 3 * -1);
            }

            if (newKBState.IsKeyDown(Keys.Space) && !oldKBState.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("Space on the menu");
                mainGame.gameState.changeScene(GameState.SceneType.Menu);
            }

            if (newKBState.IsKeyDown(Keys.I))
            {
                Debug.WriteLine("Fire !");
            }


            /**
                Meteors
            */
            foreach (IActor Actor in listActor)
            {
                if (Actor is Meteor m)
                {
                    if (m.Position.X < 0)
                    {
                        m.Position = new Vector2(0, m.Position.Y);
                        m.vx = -m.vx;
                    }
                    if (m.Position.X > mainGame.Screen.Width - m.Texture.Width)
                    {
                        m.Position = new Vector2(mainGame.Screen.Width - m.Texture.Width, m.Position.Y);
                        m.vx = -m.vx;
                    }
                    if (m.Position.Y < 0)
                    {
                        m.Position = new Vector2(m.Position.X, 0);
                        m.vy = -m.vy;

                    }

                    if (m.Position.Y > mainGame.Screen.Height - m.Texture.Height)
                    {
                        m.Position = new Vector2(m.Position.X, mainGame.Screen.Height - m.Texture.Height);
                        m.vy = -m.vy;
                    }
                    if (Util.CollideByBox(m, MyHero))
                    {
                        MyHero.TouchedBy(m);
                        m.TouchedBy(MyHero);
                        m.ToRemove = true;
                        // sfxExplode.Play();
                    }
                }
            }

            listActor.RemoveAll(item => item.ToRemove == true);

            /**
                Ship
            */
            if (MyHero.Energy <= 0)
            {
                MediaPlayer.Stop();
                mainGame.gameState.changeScene(GameState.SceneType.Gameover);
            }

            oldKBState = newKBState;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Debug.WriteLine("Drawing Scene Gameplay...");
            mainGame.spriteBatch.Begin();
            mainGame.spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "Ship Energy : " + MyHero.Energy, new Vector2(20, 50), Color.Wheat);
            mainGame.spriteBatch.DrawString(AssetManager.MainFont, "This is the Gameplay", new Vector2(100, 10), Color.Red);

            mainGame.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}