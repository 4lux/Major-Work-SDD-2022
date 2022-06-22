using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Function : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D fl;
    public PolygonCollider2D flBox;
    private bool status = true;
    public Battery_Health script;

    void Start()
    {
      flashVariables(true);
    }


    void Update()
    {
        if (script.flLevel != 3)
        {
          flashSwitch();
        }
        else
        {
          flashVariables(false);
        }

    }

    void flashSwitch()
    {
      if ((status == true) && (Input.GetMouseButtonDown(0)))
      {
          flashVariables(false);
      }
      else if ((status == false) && (Input.GetMouseButtonDown(0)))
      {
          flashVariables(true);
      }
    }

    void flashVariables(bool option)
    {
      fl.enabled = option;
      status = option;
      script.flStatus = option;
      flBox.enabled = option;
    }

}
