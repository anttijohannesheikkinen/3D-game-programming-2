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

    protected new void Start ()
    {
        stateName = "MainMenuIn";


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
                break;

            case FadeOutEffectPhase.FadingIn:
                break;

            case FadeOutEffectPhase.Idle:

                if (Input.anyKey)
                {
                    StartFadeOut(3.0f);
                    fadeOutEffectPhase = FadeOutEffectPhase.FadingOut;
                    Debug.Log("User pressed 'any key'");
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

    private void GoToGame()
    {
        Debug.Log("Main Menu screen script told to transition to Game");
        gameStateManager.ChangeState(GameStateBase.StateType.GameIn, "Level1");
    }
}
