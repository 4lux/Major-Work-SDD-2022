using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class Hunter_Behaviour : MonoBehaviour
{
    public AIPath aiPath;                                   //Declares the aiPath variable

    Vector3 destination;
    //public static int ntps = 0; was gonna be used for the stage system but had fundamental problems
    float timer = 0f;

    public PolygonCollider2D flashlightCol;                  //Declares the flashlight box collider
    public CircleCollider2D playerCol;                       //Declares the player box collider
    public BoxCollider2D self;                               //Declares its own box collider

    [SerializeField] private AudioSource woosh;              //Declares the woosh sound component

    private void OnTriggerEnter2D(Collider2D other)           //Will active when hunter collider interacts with another coll
    {
        timer = 0;                                            //Begins the timer for the teleporter
        aiPath.maxSpeed = 0f;                                 //Sets the hunter's speed to 0
        if (self.IsTouching(playerCol))
        {
          SceneManager.LoadScene("Death Screen");             //If the hunter touches the player it changes to the death scene
        }
    }

    private void OnTriggerStay2D(Collider2D other)            //Will stay active for the frames when colliders are touching
    {
      if(self.IsTouching(flashlightCol))
      {
        timer += Time.deltaTime;                              //If the hunter is touching the flashlight collider, begin tp timer
      }
      if ((timer >= 2f) && (self.IsTouching(flashlightCol)))
      {
        //stageteleport();
        teleport(20,40);                                      //If the hunter has been in the flashligh for 2 seconds, it will run teleport function
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      aiPath.maxSpeed = 3f;                                   //Once the two colliders stop touching speed will return to 3
    }


    void teleport(int lthreshold, int uthreshold)             //Teleport within a square with a side 2x the upper threshold but not in a s
    {                                                         //quare with sides 2 x the lower threshold (from current position)
      int i = Random.Range(1,4);                              //Random selection of side (1=right, 2=top, 3=left, 4=bottom)
      if (i == 1)
      {
        destination.x = transform.position.x + Random.Range(lthreshold,uthreshold);      //Vector destination will be the total of random x
        destination.y = transform.position.y + Random.Range(-uthreshold,uthreshold);     //and random y with the current position
      }
      else if (i == 2)
      {
        destination.x = transform.position.x + Random.Range(-uthreshold,uthreshold);
        destination.y = transform.position.y + Random.Range(lthreshold,uthreshold);
      }
      else if (i == 3)
      {
        destination.x = transform.position.x + Random.Range(-lthreshold,-uthreshold);
        destination.y = transform.position.y + Random.Range(-uthreshold,uthreshold);
      }
      else if (i == 4)
      {
        destination.x = transform.position.x + Random.Range(-uthreshold,uthreshold);
        destination.y = transform.position.y + Random.Range(-lthreshold,-uthreshold);
      }

      destination.z = -transform.position.z;          //set the z to the opposite of current (To counteract AI z rotations)
      woosh.Play();                                   //play woosh noise
      self.transform.position = destination;          //teleport the hunter to new random position
    }

  /*/  void stageteleport()
    {
      if (Hunter_GFX.stage == 1)
      {
          teleport(30,50);
      }
      if (Hunter_GFX.stage == 2)
      {
          if (ntps == 0)
          {
            teleport(10,12);
            ntps +=1;
            Debug.Log(ntps);
          }
          else if (ntps == 1)
          {
            teleport(30,50);
            ntps = 0;
          }
      }
      if (Hunter_GFX.stage == 3)
      {
        if (ntps == 0)
        {
          teleport(10,12);
          ntps +=1;
        }
        else if (ntps == 1)
        {
          teleport(10,12);
          ntps += 1;
        }
        else if (ntps == 2)
        {
          teleport(30,50);
          ntps = 0;
        }
      }
    } /*/
}
