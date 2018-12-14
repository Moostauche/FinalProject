using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //creating variables
    public Animator baseAnimation;
    public Rigidbody body;
    public SpriteRenderer shadow;

    public float movespeed = 2;
    public float walkingSpeed = 2;

    Vector3 currentDir;
    bool isFacingLeft;
    protected Vector3 frontVector;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //getting Horizontal and Vertical value
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //storing the Horizontal and Vertical value in a vector
        currentDir = new Vector3(horizontal, 0, vertical);
        currentDir.Normalize();

        //is there an input - horizontal or vertical? If not, stop movement.
        if ((vertical == 0 && horizontal == 0))
        {
            Stop();
        }
        else if ((vertical != 0 || horizontal != 0))
        {
            Walk();
        }

    }

    //When the method Stop() is called above, set the hero velocity to 0 and prevent him from moving
    public void Stop()
    {
        movespeed = 0;
        baseAnimation.SetFloat("Movespeed", movespeed);
    }
    //if the method Walk() is called above, set the hero velocity to the value of speed
    public void Walk()
    {
        movespeed = walkingSpeed;
        baseAnimation.SetFloat("Movespeed", movespeed);
    }

    //positioning the rigidBody according to the movement of the hero
    void FixedUpdate()
    {
        Vector3 moveVector = currentDir * movespeed;
        body.MovePosition(transform.position + moveVector * Time.fixedDeltaTime);
        baseAnimation.SetFloat("Movespeed", moveVector.magnitude);
    
    //Check if the hero is facing left or right
     if (moveVector != Vector3.zero) {
            if (moveVector.x != 0) {
                isFacingLeft = moveVector.x< 0;
            }
                FlipSprite(isFacingLeft);
        }
    }

    //if the hero moves to the left flip the sprite, otherwise he is moving right and no action is needed
    public void FlipSprite(bool isFacingLeft)
    {
        if (isFacingLeft) {
            frontVector = new Vector3(-1, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        } else {
            frontVector = new Vector3(1, 0, 0);
            transform.localScale = new Vector3(1, 1, 1); }

    }


    }
