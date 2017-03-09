using UnityEngine;

public class GameStateBase : MonoBehaviour {

    public enum StateType
    {
        Null = 0,
        SplashScreenIn = 1,
        MainMenuIn = 2,
        GameIn = 3,
        GameOver = 4
    }

    public enum FadeOutEffectPhase
    {
        WaitingToFadeIn = 0,
        FadingIn = 1,
        Idle = 2,
        FadingOut = 3,
        FadedOut = 4
    }

    protected GameStateManager gameStateManager;
    protected GameGlobals gameGlobals;
    protected string stateName = "GameStateBase";
    protected StateType stateType;

    protected FadeEffect fadeEffect;
    protected bool performFadeOutEffects = true;
    protected FadeOutEffectPhase fadeOutEffectPhase;

    protected virtual void Start ()
    {
        Debug.Log("Enter GameState: " + stateName);

        gameGlobals = GameGlobals.Instance;

        if (gameGlobals == null)
        {
            Debug.LogError("State: " + stateName + " couldn't find GameGlobals. " + gameObject);
        }

        gameStateManager = gameGlobals.GameStateManager;

        if (gameStateManager == null)
        {
            Debug.LogError("State: " + stateName + " couldn't find GameStateManager. " + gameObject);
        }

        fadeEffect = FindObjectOfType<FadeEffect>();

        if (fadeEffect == null)
        {
            performFadeOutEffects = false;
        }

        else
        {
            performFadeOutEffects = true;
        }
    }
	
	protected virtual void Update () {
		
	}

    protected virtual void LateUpdate()
    {

    }

    protected virtual void OnDisable()
    {
        Debug.Log("Exit GameState: " + stateName);

        if (fadeEffect != null)
        {
            fadeEffect.FadeOutHasHappened -= new FadeEffect.FadedOut(FinishedFadeOut);
            fadeEffect.FadeInHasHappened -= new FadeEffect.FadedIn(FinishedFadeIn);
        }
    }

    protected void FinishedFadeOut()
    {
        if (fadeEffect != null)
        {
            fadeOutEffectPhase = FadeOutEffectPhase.FadedOut;
            fadeEffect.FadeOutHasHappened -= new FadeEffect.FadedOut(FinishedFadeOut);
            Debug.Log(stateName + " screen got the message that fade OUT was finished.");
        }
    }

    protected void FinishedFadeIn()
    {
        if (fadeEffect != null)
        {
            fadeOutEffectPhase = FadeOutEffectPhase.Idle;
            fadeEffect.FadeInHasHappened -= new FadeEffect.FadedIn(FinishedFadeIn);
            Debug.Log(stateName + " screen got the message that fade IN was finished.");
        }
    }

    protected void StartFadeOut(float lenght)
    {
        if (fadeEffect != null)
        {
            fadeEffect.FadeOutHasHappened += new FadeEffect.FadedOut(FinishedFadeOut);
            fadeEffect.StartFadeEffect(lenght, false);
        }
    }

    protected void StartFadeIn(float lenght)
    {
        if (fadeEffect != null)
        {
            fadeEffect.FadeInHasHappened += new FadeEffect.FadedIn(FinishedFadeIn);
            fadeEffect.StartFadeEffect(lenght, true);
        }
    }
}
