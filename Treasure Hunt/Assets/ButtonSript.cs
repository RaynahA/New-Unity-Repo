using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSript : MonoBehaviour
{

    [SerializeField]
    GameObject ObjectToDestroy;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
       {
           Destroy(ObjectToDestroy);   
       }
        
    }
}
