using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

    private ParticleSystem particles;

	// Use this for initialization
	void Awake () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!particles.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
