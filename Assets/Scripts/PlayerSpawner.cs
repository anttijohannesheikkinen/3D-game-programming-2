using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = gameObject.transform.position;
	}

    void SpawnAgain ()
    {
        gameObject.transform.position = startPosition;
    }
	
	void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("BottomPlane"))
        {
            SpawnAgain();
        }
    }
}
