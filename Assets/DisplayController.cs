using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{

    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void clickExit() {
      canvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {



    }
}
