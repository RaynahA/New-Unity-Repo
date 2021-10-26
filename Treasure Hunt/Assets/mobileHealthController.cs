using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mobileHealthController : MonoBehaviour
{
    public float playerHealth;
    [SerializeField]
    private Text livesText;

    public void UpdateHealth()
    {
        livesText.text = playerHealth.ToString("0");
    }
}
