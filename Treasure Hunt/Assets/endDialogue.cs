using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endDialogue : MonoBehaviour
{
    public GameObject dialogueBox3;
    public Text dialogueText;
    public string dialogue;
    public bool playerInRange3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (playerInRange3)
        {
                dialogueBox3.SetActive(true);
                dialogueText.text = dialogue;
            
        }
        if (playerInRange3 == false)
        {
            dialogueBox3.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange3 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange3 = false;
        }
    }
}
