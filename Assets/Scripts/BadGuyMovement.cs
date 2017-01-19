using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyMovement : MonoBehaviour {

    public float lerpTime;

    public Vector3 startposition;
    public Vector3 endPosition;

    private float lerpStartTime;
    private float lerpRatio;
    private bool fromStartToEnd;

	// Use this for initialization
	void Start () {

        startposition = new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
        endPosition = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);

        lerpStartTime = Time.time;

        fromStartToEnd = true;
    }
	
	// Update is called once per frame
	void Update () {

        lerpRatio = (Time.time - lerpStartTime) / lerpTime;


        if (fromStartToEnd)

        {
            gameObject.transform.position = Vector3.Lerp(startposition, endPosition, Easing.EaseInOut(lerpRatio, EasingType.Cubic, EasingType.Cubic));
        }

        else
        {
            gameObject.transform.position = Vector3.Lerp(endPosition, startposition, Easing.EaseInOut(lerpRatio, EasingType.Cubic, EasingType.Cubic));
        }

        if (lerpRatio >= 1.0f)
        {
            fromStartToEnd = !fromStartToEnd;
            lerpStartTime = Time.time;
        }
    }
}
