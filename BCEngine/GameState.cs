namespace BCEngine;

public class GameState
{

    public enum SceneType
    {
        Menu,
        Gameplay,
        Gameover
    }

    protected MainGame mainGame;
    public Scene currentScene { get; set; }
    public GameState(MainGame pGame)
    {
        mainGame = pGame;
    }

    public void changeScene(SceneType pSceneType)
    {
        if (currentScene != null)
        {
            currentScene.Unload();
            currentScene = null;
        }
        switch (pSceneType)
        {
            case SceneType.Menu:
                currentScene = new SceneMenu(mainGame);
                break;
            case SceneType.Gameplay:
                currentScene = new SceneGameplay(mainGame);
                break;
            case SceneType.Gameover:
                currentScene = new SceneGameover(mainGame);
                break;
            default:
                break;
        }
        if (currentScene!=null)
        currentScene.Load();
    }

}