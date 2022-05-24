using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Function : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D fl;
    private bool status = true;
    void Update()
    {
        if (status == true){
          if (Input.GetMouseButtonDown(0))
          {
            fl.enabled = false;
            status = false;
          }
        }
        else if (status == false) {
          if (Input.GetMouseButtonDown(0))
          {
            fl.enabled = true;
            status = true;
          }
        }


    }
}
