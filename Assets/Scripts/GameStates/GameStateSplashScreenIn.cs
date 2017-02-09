using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSplashScreenIn : GameStateBase {

    private float timerStartTime;
    private float lengthOfSplashScreen;

	protected new void Start ()
    {
        fadeEffect = FindObjectOfType<FadeEffect>();

        if (fadeEffect == null)
        {
            timerStartTime = Time.time;
        }

        stateName = "SplashScreenIn";
        stateType = StateType.SplashScreenIn;
        base.Start();
	}
	
	protected new void Update () {

        if (!performFadeOutEffects)
        {
            if (Time.time - timerStartTime > 2.0f)
            {
                GoToMainMenu();
            }
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
                StartFadeIn(2.0f);
                timerStartTime = Time.time;
                fadeOutEffectPhase = FadeOutEffectPhase.FadingIn;
                Debug.Log("SplashScreen waiting to fade in");
                break;

            case FadeOutEffectPhase.FadingIn:
                break;

            case FadeOutEffectPhase.Idle:

                if ((Time.time - timerStartTime) > lengthOfSplashScreen)
                {
                    StartFadeOut(2.0f);
                    fadeOutEffectPhase = FadeOutEffectPhase.FadingOut;
                    Debug.Log("SplashScreen finished idling");
                }
                break;

            case FadeOutEffectPhase.FadingOut:
                break;

            case FadeOutEffectPhase.FadedOut:
                Debug.Log("SplashScreen faded out");
                GoToMainMenu();
                break;
        }
    }

    private void GoToMainMenu()
    {
        Debug.Log("Splash screen script told to transition to Main Menu");
        gameStateManager.ChangeState(StateType.MainMenuIn, "MainMenu");
    }
}
