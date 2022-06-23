using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;                            // Sets an adjustable speed for the character

    public Rigidbody2D rb;                                  //Declaring the rigidbody as rb
    public Animator animator;                               //Declargin the animator controller as animator

    Vector2 movement;                                       //Declaring the movement vector

    // Update is called once per frame
    void Update()
    {
      movement.x = Input.GetAxisRaw("Horizontal");          //These two lines take inputs from WASD/Arrow keys and turn
      movement.y = Input.GetAxisRaw("Vertical");            //them into vectors

      animator.SetFloat("Horizontal", movement.x);          //Changing Variables in the animator controller
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {                                                                                           //Calculates the movement of the rigidbody by using
      rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);     //the initial position, movement direction/speed and
    }                                                                                           //the time based off the system rather than frames
}
