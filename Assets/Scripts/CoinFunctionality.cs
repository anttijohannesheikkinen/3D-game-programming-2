using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFunctionality : MonoBehaviour {

    public ParticleSystem particlesPrefab;
    public GameStateGameIn gameStateGameIn;
    public Score score;

    private void Awake ()
    {
        score = FindObjectOfType<Score>();

        if (score == null)
        {
            Debug.LogError("CoinFunctionality couldn't find score counter.");
        }
    }

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
        score.CoinCollected();
        Destroy(gameObject);
    }
}

