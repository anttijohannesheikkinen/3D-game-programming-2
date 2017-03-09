using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMainMenuIn : GameStateBase {

    private float timerStartTime;

    private enum MenuState
    {
        FadeIn,
        Idle,
        FadeOut
    }

    private MenuState menuState = MenuState.FadeIn;
    private bool okToGoToGame;

    protected new void Start ()
    {
        stateName = "MainMenuIn";
        okToGoToGame = false;

        timerStartTime = Time.time;
        base.Start();
    }

	protected new void Update ()
    {

        if (!performFadeOutEffects)
        {
            GoToGame();
        }

        else
        {
            PerformTransitionEffects();
        }
    }

    private void PerformTransitionEffects()
    {
        switch (fadeOutEffectPhase)
        {
            case FadeOutEffectPhase.WaitingToFadeIn:
                StartFadeIn(1.5f);
                timerStartTime = Time.time;
                fadeOutEffectPhase = FadeOutEffectPhase.FadingIn;
                Debug.Log("Main Menu waiting to fade in");
                okToGoToGame = false;
                break;

            case FadeOutEffectPhase.FadingIn:
                break;

            case FadeOutEffectPhase.Idle:

                if (okToGoToGame)
                {
                    StartFadeOut(3.0f);
                    fadeOutEffectPhase = FadeOutEffectPhase.FadingOut;
                    Debug.Log("User started the game");
                }
                break;

            case FadeOutEffectPhase.FadingOut:
                break;

            case FadeOutEffectPhase.FadedOut:
                Debug.Log("Main Menu faded out");
                GoToGame();
                break;
        }
    }

    public void OkToGoToGame ()
    {
        okToGoToGame = true;
    }

    private void GoToGame()
    {
        Debug.Log("Main Menu screen script told to transition to Game");
        gameStateManager.ChangeState(GameStateBase.StateType.GameIn, "Level1");
    }
}
