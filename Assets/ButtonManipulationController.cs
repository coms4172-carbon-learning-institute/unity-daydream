using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManipulationController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool translate;
    public bool transform;
    public bool rotate;
    public Button translateBtn;
    public Button transformBtn;
    public Button rotateBtn;

    void Start()
    {
        translate = false;
        transform = false;
        rotate = false;
    }

    // Update is called once per frame

    public void onClick() {

      if (gameObject == translateBtn) {

        translate = true;
        transform = false;
        rotate = false;

      } else if (gameObject == transformBtn) {

        transform = true;
        translate = false;
        rotate = false;

      } else {

        rotate = true;
        transform = false;
        translate = false;
      }

    }

    void Update()
    {

    }
}
