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

    private Vector3 position1;
    private Vector3 position2;

	// Use this for initialization
	void Start () {

        startposition = new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
        endPosition = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);

        position1 = startposition;
        position2 = endPosition;

        lerpStartTime = Time.time;

        fromStartToEnd = true;
    }
	
	// Update is called once per frame
	void Update () {

        lerpRatio = (Time.time - lerpStartTime) / lerpTime;

        gameObject.transform.position = Vector3.Lerp(position1, position2, Easing.EaseInOut(lerpRatio, EasingType.Sine, EasingType.Sine));



        if (lerpRatio >= 1.0f)
        {
            fromStartToEnd = !fromStartToEnd;
            lerpStartTime = Time.time;

            if (fromStartToEnd)
            {
                position1 = startposition;
                position2 = endPosition;
            }

            else
            {
                position1 = endPosition;
                position2 = startposition;
            }
        }
    }
}
