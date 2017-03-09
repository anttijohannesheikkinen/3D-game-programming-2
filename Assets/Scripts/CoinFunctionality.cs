using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFunctionality : MonoBehaviour {

    public ParticleSystem particlesPrefab;
    public GameStateGameIn gameStateGameIn;

    private void Start ()
    {
        gameStateGameIn = FindObjectOfType<GameStateGameIn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyCoin();
        }
    }

    public void DestroyCoin()
    {

        ParticleSystem particles = Instantiate(particlesPrefab, transform.position, Quaternion.identity);
        gameStateGameIn.CoinCollected();
        Destroy(gameObject);
    }
}

