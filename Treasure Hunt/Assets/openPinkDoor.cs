using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPinkDoor : MonoBehaviour
{
    public GameObject PinkKey;
    public GameObject pinkDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameObject.Find("Key X") == null)
            {
                Destroy(pinkDoor);
            }
        }
    }
}
