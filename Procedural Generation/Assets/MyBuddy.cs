using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBuddy : MonoBehaviour
{
    public float speed = 1.0f;

    Vector2 nextLocation = new Vector2();
    MyGridSystem gridSystem;
    SpriteRenderer spriteRenderer;

    public bool isActive;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    //Setting grid system and is active to true
    void Start()
    {
        gridSystem = GameObject.FindGameObjectWithTag("GridSystem").GetComponent<MyGridSystem>();
        isActive = true;
        StartCoroutine(MoveToLocation());
    }

    /// <summary>
    /// while isActive is true, move gameobject to a new location
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveToLocation()
    {
        while (isActive)
        {
            float t = 0.0f;
            nextLocation = gridSystem.GetRandomLocation();
            Vector2 startLocation = transform.position;
            //spriteRenderer.color = new Color(Random.Range(0.1f, 1.0f))
            while(t < 1.0f)
            {
                t += Time.deltaTime * speed;
                transform.position = Vector2.Lerp(startLocation, nextLocation, t);
            }
            yield return new WaitForSeconds(1.0f);

        }
    }

}
