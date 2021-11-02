using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    public Transform target;
    public float chaseradius;
    public float attackRadius;
    public Transform homePosition;
    public Animator myAnimator;
    private float Speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseradius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
           // Speed = moveSpeed;
            //Speed = 0;
        }
        

        Animate();
        //Debug.Log(target.position);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

    void Animate()
    {
        myAnimator.SetFloat("EnemySpeed", moveSpeed);
    }
}
