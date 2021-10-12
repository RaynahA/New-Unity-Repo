using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue2 : MonoBehaviour
{
    public GameObject dialogueBox2;
    public Text dialogueText;
    public string dialogue;
    public bool playerInRange2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange2)
        {
            if (dialogueBox2.activeInHierarchy)
            {
                dialogueBox2.SetActive(false);
            }
            else
            {
                dialogueBox2.SetActive(true);
                dialogueText.text = dialogue;
            }
        }
        if (playerInRange2 == false)
        {
            dialogueBox2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange2 = false;
        }
    }
}
