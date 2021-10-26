using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMove : MonoBehaviour
{
    private const float Move_speed = 7f;

    private enum State
    {
        Normal,
        Rolling,
    }
    private Rigidbody2D rb;
    private Vector3 moveDir;
    private Vector2 lastMoveDir;
    private Vector3 rollDir;
    private float rollSpeed;
    public Animator myAnimator;
    private State state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;
        rb.rotation = 0;
    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                float moveX = 0f;
                float moveY = 0f;


                if (Input.GetKey(KeyCode.UpArrow))
                {
                    moveY = +1f;
                    //rb.rotation = 0;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    moveY = -1f;
                    //rb.rotation = 180;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    moveX = -1f;
                   // rb.rotation = 90;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    moveX = +1f;
                    //rb.rotation = 270;
                }

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    rollDir = moveDir;
                    rollSpeed = 30f;
                    state = State.Rolling;
                }

                if ((moveX == 0 && moveY == 0) & moveDir.x != 0 || moveDir.y != 0)
                {
                    lastMoveDir = moveDir;
                }
                
                moveDir = new Vector3(moveX, moveY).normalized;
                //myAnimator.SetFloat("moveX", rb.velocity.x);
                //myAnimator.SetFloat("moveY", rb.velocity.y);
                //myAnimator.SetFloat("Speed", Mathf.Abs(moveX));
                Animate();
                break;
            case State.Rolling:
                float rollSpeedDropMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 20f;
                if(rollSpeed < rollSpeedMinimum)
                {
                    state = State.Normal;
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:

                rb.velocity = moveDir * Move_speed;
                break;
            case State.Rolling:
                rb.velocity = rollDir * rollSpeed;
                break;
        }    
    }

    void Animate()
    {
        myAnimator.SetFloat("moveX", moveDir.x);
        myAnimator.SetFloat("moveY", moveDir.y);
        myAnimator.SetFloat("moveMagnitude", moveDir.magnitude);
        myAnimator.SetFloat("lastMoveX", lastMoveDir.x);
        myAnimator.SetFloat("lastMoveY", lastMoveDir.y);
    }
}