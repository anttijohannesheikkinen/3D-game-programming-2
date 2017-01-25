using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPart : ScrollingFloor {

    Vector3 offset = new Vector3(0, 0, 5);

    private new void Awake ()
    {
        base.Awake();
    }

	// Use this for initialization
	private new void Start () {
        base.Start();

    }
	
	// Update is called once per frame
	private new void Update () {

        base.Update();

        if (transform.position.z <= endPosition.z)
        {
            floorManager.FloorDestroyed(transform.position.z - endPosition.z);
            Destroy(gameObject);
        }
    }
}
