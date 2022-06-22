using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Hunter_GFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator hunterAnimator;
    public Page_Counter script;
    public static int stage = 1;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        stageUpdate();

        hunterAnimator.SetFloat("Horizontal", aiPath.desiredVelocity.x);
        hunterAnimator.SetFloat("Vertical", aiPath.desiredVelocity.y);
        hunterAnimator.SetFloat("Speed", aiPath.desiredVelocity.sqrMagnitude);
        hunterAnimator.SetInteger("Stage", stage);
    }

    void stageUpdate()
    {
      if (script.pages <= 3){
        stage = 1;
      }
      else if (script.pages <= 6){
        stage = 2;
        Hunter_Behaviour.ntps = 0;
      }
      else {
        stage = 3;
        Hunter_Behaviour.ntps = 0;
      }
    }

}
