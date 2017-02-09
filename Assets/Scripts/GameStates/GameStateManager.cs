using UnityEngine;
using UnityEngine.SceneManagement;
using StateType = GameStateBase.StateType;

public class GameStateManager : MonoBehaviour {

    public GameObject gameState;
    public bool waitingForLoad;
    public StateType newState;

    private void Awake ()
    {
        GameObject devModeCheck = GameObject.Find("DevModeCheck");

        if (devModeCheck == null)
        {
            SetState(StateType.SplashScreenIn);
        }

        else
        {
            DevModeCheck dmc = devModeCheck.GetComponent<DevModeCheck>();
            ChangeState(dmc.stateType, dmc.sceneName);
        }
    }

    public void ChangeState(StateType state, string levelName = "")
    {
        Destroy(gameState);

        if (levelName != "")
        {
            waitingForLoad = true;
            newState = state;
            SceneManager.LoadScene(levelName);
        }

        else
        {
            SetState(state);
        }
    }

    private void SetState (StateType state)
    {
        gameState = new GameObject();
        DontDestroyOnLoad(gameState);

        switch (state)
        {
            default:
                Debug.Log("Change state called with unknown game state.");
                break;

            case StateType.SplashScreenIn:
                gameState.AddComponent<GameStateSplashScreenIn>();
                gameState.name = "Game State: Splash Screen";
                break;

            case StateType.MainMenuIn:
                gameState.AddComponent<GameStateMainMenuIn>();
                gameState.name = "Game State: Main Menu";
                break;

            case StateType.GameIn:
                gameState.AddComponent<GameStateGameIn>();
                gameState.name = "Game State: Game";
                break;
        }

        newState = StateType.Null;
        waitingForLoad = false;
    }

    private void OnEnable ()
    {
        SceneManager.sceneLoaded += LevelWasLoaded;
    }

    private void OnDisable ()
    {
        SceneManager.sceneLoaded -= LevelWasLoaded;
    }

    private void LevelWasLoaded (Scene scene, LoadSceneMode loadSceneMode)
    {
        if (waitingForLoad)
        {
            SetState(newState);
        }
    }
}
