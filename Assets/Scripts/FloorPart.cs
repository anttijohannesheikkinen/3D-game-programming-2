using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPart : ScrollingFloor {

    Vector3 offset = new Vector3(0, 0, 5);
    public bool initial;

    private new void Awake ()
    {
        base.Awake();
    }

	// Use this for initialization
	private new void Start () {
        base.Start();

        if (!initial)
        {

            transform.position = new Vector3(floorManager.PreviousFloorTile.transform.position.x,
                                             floorManager.PreviousFloorTile.transform.position.y,
                                             floorManager.PreviousFloorTile.transform.position.z + floorManager.floorLength);
        }
    }
	
	// Update is called once per frame
	private new void Update () {

        base.Update();

        if (transform.position.z <= endPosition.z)
        {
            floorManager.FloorDestroyed();
            Destroy(gameObject);
        }
    }
}
