using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BCEngine;

public class MainGame : Game
{
    GraphicsDeviceManager graphics;
    public SpriteBatch spriteBatch;
    public GameState gameState;

    public MainGame()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;        
        gameState = new BCEngine.GameState(this);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        IsMouseVisible=true;        
        gameState.changeScene(GameState.SceneType.Gameplay);
        base.Initialize();
        
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        AssetManager.Load(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        if(gameState.currentScene!=null){
            gameState.currentScene.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        if(gameState.currentScene!=null){
            gameState.currentScene.Draw(gameTime);
        }        

        base.Draw(gameTime);
    }
}
