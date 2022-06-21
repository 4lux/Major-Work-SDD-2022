using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Page_Counter : MonoBehaviour
{
    public static Page_Counter instance;

    public TextMeshProUGUI pageText;
    int pages = 0;

    private void Awake()
    {
      instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pageText.text = "Pages : " + pages.ToString();
    }

    // Update is called once per frame
    public void AddPage()
    {
        pages += 1;
        pageText.text = "Pages : " + pages.ToString();
    }
}
