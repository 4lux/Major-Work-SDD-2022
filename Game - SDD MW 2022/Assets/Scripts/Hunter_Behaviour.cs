using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class Hunter_Behaviour : MonoBehaviour
{
    public AIPath aiPath;

    Vector3 destination;
    public static int ntps = 0;
    float timer = 0f;

    public PolygonCollider2D flashlightCol;
    public CircleCollider2D playerCol;
    public BoxCollider2D self;

    [SerializeField] private AudioSource woosh;

    private void OnTriggerEnter2D(Collider2D other)
    {
        timer =0;
        aiPath.maxSpeed = 0f;
        if (self.IsTouching(playerCol))
        {
          SceneManager.LoadScene("Death Screen");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
      if(self.IsTouching(flashlightCol))
      {
        timer += Time.deltaTime;
      }
      if ((timer >= 2f) && (self.IsTouching(flashlightCol)))
      {
        //stageteleport();
        teleport(20,40);
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      aiPath.maxSpeed = 3f;
    }


    void teleport(int lthreshold, int uthreshold)
    {
      int i = Random.Range(1,4);
      if (i == 1)
      {
        destination.x = transform.position.x + Random.Range(lthreshold,uthreshold);
        destination.y = transform.position.y + Random.Range(-uthreshold,uthreshold);
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

      Debug.Log(i);
      Debug.Log(destination.x);
      destination.z = -transform.position.z;
      woosh.Play();
      self.transform.position = destination;
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
