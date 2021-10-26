using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobileDamageController : MonoBehaviour
{
    [SerializeField]
    private float spikeDamage;
    [SerializeField]
    private mobileHealthController healthController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        healthController.playerHealth = healthController.playerHealth - spikeDamage;
        healthController.UpdateHealth();
        this.gameObject.SetActive(false);
    }
}
