﻿using UnityEngine;
using System.Collections;

public class FloorMover : MonoBehaviour {

    public FloorManager floorManager;

    public Vector3 startPosition;
    public Vector3 endPosition;


    //Lerp-based movement
    public float duration;
    private float totalTime;
    private float startTime;
    private float ratio;

    private Transform ownTransform;

    // Velocity bsaed movement
    private Vector3 direction;
    public float speed;

    // Use this for initialization
    void Awake () {
        ownTransform = gameObject.GetComponent<Transform>();
        floorManager = GameObject.Find("FloorManager").GetComponent<FloorManager>();
	}

    void Start ()
    {
        //startTime = Time.time;
        direction = (endPosition - startPosition).normalized;
        ownTransform.position = startPosition;
    }
	
	// Update is called once per frame
	void Update () {

        //float ratio = (Time.time - startTime ) / duration;

        //if (ratio >= 1.0f)
        //{
        //    floorManager.FloorDestroyed();
        //    Destroy(gameObject);
        //}

        //ownTransform.position = Vector3.Lerp(startPosition, endPosition, ratio);

        if (ownTransform.position.z < endPosition.z)
        {
            floorManager.FloorDestroyed();
            Destroy(gameObject);
        }

        ownTransform.Translate(direction * speed * Time.deltaTime);
    }
}
