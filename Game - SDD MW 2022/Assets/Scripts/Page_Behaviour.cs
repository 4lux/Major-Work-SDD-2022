using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Behaviour : MonoBehaviour
{
    [SerializeField] private AudioSource pturn;
    bool col = false;
    public GameObject Paper;


    private void OnTriggerEnter2D(Collider2D Other)
    {
        col = true;
    }

    private void OnTriggerExit2D(Collider2D Other)
    {
        col = false;
    }

    private void Update()
    {
      if ((Input.GetMouseButtonDown(1)) && (col == true))
      {
        Page_Counter.instance.AddPage();
        Paper.SetActive(false);
      }
    }


}
