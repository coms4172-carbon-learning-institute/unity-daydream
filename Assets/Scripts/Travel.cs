using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Travel : MonoBehaviour
{
    public Text DebugText;
    public GameObject greenhouse;
    public GameObject Headset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
  // listen for click events

  GvrControllerInputDevice DaydreamControllerInput = gameObject.GetComponent<GvrTrackedController>().ControllerInputDevice;
  if (DaydreamControllerInput.GetButton(GvrControllerButton.TouchPadButton)) {
    Debug.Log("Click!");
    if (DebugText){
        DebugText.text = "Clicking";
    }
    if (DaydreamControllerInput.TouchPos.y > 0.5){
          greenhouse.transform.position = greenhouse.transform.position + new Vector3(0,0, -1);

    } else if (DaydreamControllerInput.TouchPos.y < -0.5){
          greenhouse.transform.position = greenhouse.transform.position + new Vector3(0,0, 1);

    }
    
  } else {
      if (DebugText){
        DebugText.text = "";
    }

    // DebugText.text = GvrPointerInputModule.CurrentRaycastResult.gameObject.name;
    DebugText.text = Headset.transform.position.ToString();
  }
}
}
