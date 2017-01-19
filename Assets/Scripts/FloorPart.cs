using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPart : ScrollingFloor {

    void Awake ()
    {
        OnAwake();
    }

	// Use this for initialization
	void Start () {
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {

        if (ownTransform.position.z <= endPosition.z)
        {
            floorManager.FloorDestroyed(ownTransform.position.z - endPosition.z);
            Destroy(gameObject);
        }

        ownTransform.Translate(direction * speed * Time.deltaTime);
    }
}
