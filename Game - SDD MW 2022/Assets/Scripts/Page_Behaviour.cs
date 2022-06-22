using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Behaviour : MonoBehaviour
{
    bool col = false;
    public GameObject Paper;
    [SerializeField] private AudioSource pturn;

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
        Paper.SetActive(false);
        pturn.Play();
        Page_Counter.instance.AddPage();
      }
    }




}
