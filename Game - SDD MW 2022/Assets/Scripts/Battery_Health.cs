using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Health : MonoBehaviour
{
    public Animator batteryAnimator;

    public bool flStatus;
    public int flLevel;
    private float timeStart;


    // Start is called before the first frame update
    void Start()
    {
        flLevel = 0;
        flStatus = true;
    }

    // Update is called once per frame
    void Update()
    {
        batteryLevelUpdate();
        batteryAnimator.SetInteger("level", flLevel);

        if (flStatus == true)
        {
          timeStart += Time.deltaTime;
        }
    }

    void batteryLevelUpdate()
    {
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
