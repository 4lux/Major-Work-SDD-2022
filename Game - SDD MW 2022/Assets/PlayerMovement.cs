using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);

/*
      if (((Input.GetAxisRaw("Horizontal"))^2 + (Input.GetAxisRaw("Vertical"))^2) == 2){
        moveSpeed = 2.12132f;
      }

      else
      {
        moveSpeed = 3f;
      }
*/
    }

    void FixedUpdate()
    {
      rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
