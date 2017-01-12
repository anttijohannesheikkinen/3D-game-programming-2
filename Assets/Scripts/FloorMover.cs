using UnityEngine;
using System.Collections;

public class FloorMover : MonoBehaviour {



    public Vector3 startPosition;
    public Vector3 endPosition;
    public float duration;

    public FloorManager floorManager;


    private float totalTime;
    private float startTime;
    private float ratio;

    private Transform ownTransform;

	// Use this for initialization
	void Awake () {
        ownTransform = gameObject.GetComponent<Transform>();

	}

    void Start ()
    {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        float ratio = (Time.time - startTime ) / duration;

        if (ratio >= 1.0f) {
            floorManager.FloorDestroyed();
            Destroy(gameObject);
        }

        ownTransform.position = Vector3.Lerp(startPosition, endPosition, ratio);

    }
}
