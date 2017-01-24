using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    public bool dead;

    private Vector3 startPosition;
    private CharacterController characterController;
    private Vector3 hidePosition;

    private void Awake ()
    {
        characterController = GetComponent<CharacterController>();
        hidePosition = new Vector3(-1000, -1000, -1000);
    }

	// Use this for initialization
	void Start () {
        dead = false;
        startPosition = gameObject.transform.position;
	}

    public void Die ()
    {
        if (!dead) {
            Debug.Log("told to die");
            dead = true;
            transform.position = hidePosition;
            Invoke("SpawnAgain", 1.6f);
        }
    }

    void SpawnAgain ()
    {
        dead = false;
        gameObject.transform.position = startPosition;
    }
	
	void Update () {

        if (!dead && gameObject.transform.position.z < -5.0f || gameObject.transform.position.y < -10.0f)
        {

            Die();
        }
    }  
}
