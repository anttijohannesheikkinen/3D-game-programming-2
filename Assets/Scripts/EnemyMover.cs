using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : ScrollingFloor {

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

        ownTransform.Translate(direction * speed * Time.deltaTime);
    }

}
