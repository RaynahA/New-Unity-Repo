using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public Vector2 firePointDirection = new Vector2();

    public float bulletForce = 20f;

    public Transform playerBody;


    // Update is called once per frame
    //get current direction and fire w/ raycast
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointDirection  * bulletForce, ForceMode2D.Impulse);
        //rb.rotation = 90;
        //rb.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 90f);
        //rb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}