using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Player : MonoBehaviour
{
    [SerializeField] private AudioSource click;

    public void clickPlay()
    {
      click.Play();
    }
}
