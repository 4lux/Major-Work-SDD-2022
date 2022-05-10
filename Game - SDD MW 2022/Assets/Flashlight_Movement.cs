using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Movement : MonoBehaviour
{
    public GameObject myPlayer;

    private void FixedUpdate()
    {
        Vector3 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        ///lookDir.normalized();

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

/*



rb.rotation = angle;

rb.MovePosition(rb.Player);*/
