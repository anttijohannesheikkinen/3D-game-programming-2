using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFunctionality : MonoBehaviour {

    public ParticleSystem particlesPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }

    public void Die()
    {

        ParticleSystem particles = Instantiate(particlesPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}

