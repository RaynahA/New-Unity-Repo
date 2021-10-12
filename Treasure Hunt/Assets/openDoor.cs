using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject BlueKey;
    public GameObject blueDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameObject.Find("Key 1") == null)
            {
                Destroy(blueDoor);
            }
        }
    }
}
