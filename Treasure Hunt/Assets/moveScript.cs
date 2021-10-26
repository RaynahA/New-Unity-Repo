using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float speed = 10.0f;
    //public SpriteRenderer spriteRenderer;
    private Animator myAnimator;
    // Start is called before the first frame update
    //private bool isDashButtonDown;
    public float cooldownTimer = 0;

    private enum State{
        Normal,
        Rolling,
    }
    [SerializeField]
    private float speed;
    //private Vector3 moveDir;
    private Vector3 rollDir;
    private float rollSpeed;
    private State state;

    private void Awake()
    {
        state = State.Normal;
    }
    void Start()
    {
        //spriteRenderer = this.GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    /*
    void MoveObject()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate((Vector2.left * Time.deltaTime) * speed);
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate((Vector2.up * Time.deltaTime) * speed);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate((Vector2.down * Time.deltaTime) * speed);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }*/

    
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Normal:

                // MoveObject();
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
                myAnimator.SetFloat("moveX", rb.velocity.x);
                myAnimator.SetFloat("moveY", rb.velocity.y);

                cooldownTimer -= Time.deltaTime;
                /*if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    isDashButtonDown = true;
                }*/
                if (Input.GetKeyDown(KeyCode.Z) && cooldownTimer <= 0)
                {
                    rollDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    rollSpeed = 50f;
                    state = State.Rolling;
                    
                }
                break;
            case State.Rolling:
                float rollSpeedDropMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 50f;

                if(rollSpeed < rollSpeedMinimum)
                {
                    state = State.Normal; //try to use cooldown timer
                    cooldownTimer = 1;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (state) 
        {
            case State.Normal:
                /*if (isDashButtonDown)
                {
                    float dashAmount = 800f;
                    rb.MovePosition(transform.position + moveDir * dashAmount);
                    isDashButtonDown = false;
                }*/
                break;
            case State.Rolling:
                rb.velocity = rollDir * rollSpeed;
                break;
        }
    }
}
