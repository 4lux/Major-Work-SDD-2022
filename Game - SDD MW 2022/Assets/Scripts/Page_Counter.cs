using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Page_Counter : MonoBehaviour
{
    public static Page_Counter instance;

    public TextMeshProUGUI pageText;
    public int pages;

    private void Awake()
    {
      instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pages = 0;
        pageText.text = "Pages : " + pages.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      if (pages == 7)
      {
        SceneManager.LoadScene("Win Screen");
      }
    }
    public void AddPage()
    {
        pages += 1;
        pageText.text = "Pages : " + pages.ToString();
    }
}
