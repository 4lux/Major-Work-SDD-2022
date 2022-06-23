using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Health : MonoBehaviour
{
    public Animator batteryAnimator;   //gets the location of the animation controller and nicks it "batteryAnimator"

    public bool flStatus;              //Status of the flashligh (is it off or on)
    public int flLevel;                //The amount of battery the flashlight has (lower number = more power left)
    private float timeStart;           //Timer for the battery


    // Start is called before the first frame update
    void Start()
    {
        flLevel = 0;
        flStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        batteryLevelUpdate();                               //Updates the level of the battery based on time
        batteryAnimator.SetInteger("level", flLevel);       //Changes the integer "level" in the animator controller which changes the animation

        if (flStatus == true)
        {
          timeStart += Time.deltaTime;                      //Adds time to timeStart if the flashlight (flStatus) is on
        }
    }

    void batteryLevelUpdate()                               //Increases the level of the battery every 30 seconds.
    {                                                       //After 90s the light reaches level 3 and turns off
      if (timeStart <= 30)
      {
        flLevel = 0;
      }
      else if (timeStart <= 60)
      {
        flLevel = 1;
      }
      else if (timeStart <= 90)
      {
        flLevel = 2;
      }
      else
      {
        flLevel = 3;
      }
    }

}
