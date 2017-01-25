using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFunctionality : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }

    public void Die()
    {
        //TODO

        Destroy(gameObject);
    }
}

