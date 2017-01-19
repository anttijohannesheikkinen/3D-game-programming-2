using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = gameObject.transform.position;
	}

    public void Die ()
    {
        SpawnAgain();
    }

    void SpawnAgain ()
    {
        gameObject.transform.position = startPosition;
    }
	
	void Update () {

        if (gameObject.transform.position.z < -5.0f || gameObject.transform.position.y < -10.0f)
        {

            SpawnAgain();
        }
    }  
}
