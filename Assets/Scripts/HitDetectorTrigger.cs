using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorTrigger : MonoBehaviour {

    private PlayerSpawner spawner;

    void Awake ()
    {
        spawner = GetComponentInParent<PlayerSpawner>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !spawner.dead)
        {
            spawner.Die();
        }
    }
}
