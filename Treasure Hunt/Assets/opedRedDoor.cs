using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opedRedDoor : MonoBehaviour
{
    public GameObject RedKey;
    public GameObject redDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameObject.Find("Red Key") == null)
            {
                Destroy(redDoor);
            }
        }
    }
}
