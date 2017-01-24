using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : ScrollingFloor {

    public bool fromLeftToRight;

    private BounceFromSideToSide bounce;

    private new void Awake ()
    {
        base.Awake();

        bounce = gameObject.GetComponent<BounceFromSideToSide>();
    }
	// Use this for initialization
	private new void Start () {
        base.Start();

        if (fromLeftToRight)
        {
            transform.position = new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y, gameObject.transform.position.z);
            bounce.FlipDirection(true);
        }

        else
        {
            transform.position = new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y, gameObject.transform.position.z);
            bounce.FlipDirection(false);
        }
	}
	
	// Update is called once per frame
	private new void Update () {
        base.Update();

        if (transform.position.z <= endPosition.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }

    public void Die ()
    {
        //TODO

        Destroy(gameObject);
    }

}
