using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter_Movement : MonoBehaviour
{

  public float hunterMoveSpeed = 4f;
  private int stage = 2;

  public Rigidbody2D hunterRb;
  public Animator hunterAnimator;

  Vector2 hunterMovement;


    // Update is called once per frame
    void Update()
    {
      hunterMovement.x = 0;
      hunterMovement.y = 0;

      hunterAnimator.SetFloat("Horizontal", hunterMovement.x);
      hunterAnimator.SetFloat("Vertical", hunterMovement.y);
      hunterAnimator.SetFloat("Speed", hunterMovement.sqrMagnitude);
      hunterAnimator.SetInteger("Stage", stage);

    }

    void FixedUpdate()
    {
      hunterRb.MovePosition(hunterRb.position + hunterMovement.normalized * hunterMoveSpeed * Time.fixedDeltaTime);
    }
}
