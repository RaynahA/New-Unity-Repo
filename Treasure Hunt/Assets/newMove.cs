using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newMove : MonoBehaviour
{
    private const float Move_speed = 7f;
    public AudioSource dashSound;
    public shooting shoot;



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
    //private LastMove lastMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;
        rb.rotation = 0;
        GetComponent<mobileHealthController>();
        //playerHealth = mobileHealthController.GetComponent<playerHealth>();

    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "LevelOne")
        {
            Destroy(shoot);
        }
    }

    private void Update() //create new enum for last move direction, get that in fireball script
    {
        
        switch (state)
        {
            case State.Normal:

                float moveX = 0f;
                float moveY = 0f;
                
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    moveY = +1f;
                    shoot.firePoint.transform.localPosition = moveDir;                  
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    moveY = -1f;
                    shoot.firePoint.transform.localPosition = moveDir;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    moveX = -1f;
                    shoot.firePoint.transform.localPosition = moveDir;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    moveX = +1f;
                    shoot.firePoint.transform.localPosition = moveDir;
                }

                shoot.firePointDirection = lastMoveDir * 0.5f;



                if (Input.GetKeyDown(KeyCode.Z))
                {
                    rollDir = moveDir;
                    rollSpeed = 30f;
                    state = State.Rolling;
                    dashSound.Play();
                }

                if ((moveX == 0 && moveY == 0) & moveDir.x != 0 || moveDir.y != 0)
                {
                    lastMoveDir = moveDir;
                    shoot.firePoint.transform.localPosition = lastMoveDir;
                }

                moveDir = new Vector3(moveX, moveY).normalized;
               
                Animate();

                break;
            case State.Rolling:
                float rollSpeedDropMultiplier = 5f;
                rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

                float rollSpeedMinimum = 20f;
                if (rollSpeed < rollSpeedMinimum)
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