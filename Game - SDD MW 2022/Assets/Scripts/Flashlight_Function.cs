using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight_Function : MonoBehaviour
{
    [SerializeField] private AudioSource click;             //Creates a field for the sound component to be connected
    public UnityEngine.Rendering.Universal.Light2D fl;      //fl is the flashlight's state (on or off)
    public PolygonCollider2D flBox;                         //f1Box is made the collider of the light
    private bool status = true;                       
    public Battery_Health script;

    void Start()
    {
      flashVariables(true);
    }


    void Update()
    {
      if(!Pause_Menu.isPaused)
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
    }

    void flashSwitch()
    {
      if ((status == true) && (Input.GetMouseButtonDown(0)))
      {
          click.Play();
          flashVariables(false);
      }
      else if ((status == false) && (Input.GetMouseButtonDown(0)))
      {
          click.Play();
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
