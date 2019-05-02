using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void clickExit() {
      panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {



    }
}
