using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject Door;
    public string keyName;
    public AudioSource doorSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameObject.Find(keyName) == null)
            {
                doorSound.Play();
                Destroy(Door);
            }
        }
    }
}
