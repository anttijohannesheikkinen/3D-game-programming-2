using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceFromSideToSide : MonoBehaviour {

    public float lerpTime;
    public bool fromLeftToRight = true;

    public Vector3 startposition;
    public Vector3 endPosition;

    private float lerpStartTime;
    private float lerpRatio;

    private Vector3 position1;
    private Vector3 position2;

	// Use this for initialization
	void Start () {

        startposition = new Vector3(gameObject.transform.position.x + 3, gameObject.transform.position.y, gameObject.transform.position.z);
        endPosition = new Vector3(gameObject.transform.position.x - 3, gameObject.transform.position.y, gameObject.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        lerpRatio = (Time.time - lerpStartTime) / lerpTime;


        Vector3 lerpPosition = Vector3.Lerp(position1, position2, Easing.EaseInOut(lerpRatio, EasingType.Sine, EasingType.Sine));

        gameObject.transform.position = new Vector3(lerpPosition.x, transform.position.y, transform.position.z);

        if (lerpRatio >= 1.0f)
        {
            FlipDirection(!fromLeftToRight);
        }
    }

    public void FlipDirection(bool leftToRight)
    {
        lerpStartTime = Time.time;

        if (leftToRight)
        {
            fromLeftToRight = true;
            position1 = startposition;
            position2 = endPosition;
        }

        else
        {
            fromLeftToRight = false;
            position1 = endPosition;
            position2 = startposition;
        }
    }
}
