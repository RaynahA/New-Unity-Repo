using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoin : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectSound.Play();
            ScoringSystem.theScore += 50;
            Destroy(gameObject);
        }
       
    }
}
