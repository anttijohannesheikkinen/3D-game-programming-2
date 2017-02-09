using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour {

    public delegate void FadedIn();
    public event FadedIn FadeInHasHappened;

    public delegate void FadedOut();
    public event FadedOut FadeOutHasHappened;

    private float effectStartTime;
    private float ratio;
    private float effectLength;
    private Image image;
    private Color color1;
    private Color color2;
    private Color fromColor;
    private Color targetColor;

    private enum FadeState
    {
        
        FadingIn,
        Idle,
        FadingOut
    }

    private FadeState fadeState = FadeState.Idle;

    private void Awake ()
    {
        image = GetComponent<Image>();
        color1 = image.color;
        color2 = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

	public void StartFadeEffect (float lenghtOfEffect, bool fadeIn)
    {
        effectStartTime = Time.time;
        effectLength = lenghtOfEffect;
        ratio = 0;

        if (fadeIn)
        {
            fadeState = FadeState.FadingIn;
        }

        else
        {
            fadeState = FadeState.FadingOut;
        }

        if (fadeIn)
        {
            fromColor = color1;
            targetColor = color2;
        }

        else
        {
            fromColor = color2;
            targetColor = color1;
        }
	}

    private void LerpColors ()
    {
        ratio = (Time.time - effectStartTime) / effectLength;

        if (ratio < 1.0f)
        {
            image.color = Color.Lerp(fromColor, targetColor, ratio);
        }

        else
        {
            image.color = targetColor;
            fadeState = FadeState.Idle;

            if (image.color == color2)
            {
                if (FadeInHasHappened != null)
                {
                    Debug.Log("FiredAnEvent: FadeIn happened.");
                    FadeInHasHappened();
                }
            }

            else
            {
                if (FadeOutHasHappened != null)
                {
                    Debug.Log("FiredAnEvent: FadeOut happened.");
                    FadeOutHasHappened();
                }
            }
        }
    }
	

	void Update ()
    {
		switch (fadeState)
        {
            case FadeState.FadingIn:
                LerpColors();
                break;

            case FadeState.Idle:

                break;

            case FadeState.FadingOut:
                LerpColors();
                break;
        }
	}
}
