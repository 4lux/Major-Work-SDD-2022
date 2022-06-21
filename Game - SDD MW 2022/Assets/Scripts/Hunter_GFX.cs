using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Hunter_GFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator hunterAnimator;

    // Update is called once per frame
    void Update()
    {
        hunterAnimator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
        hunterAnimator.SetFloat("Vertical", aiPath.desiredVelocity.y);
    }
}
