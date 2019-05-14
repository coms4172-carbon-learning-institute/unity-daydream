using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classroomStep3 : MonoBehaviour
{

    public GameObject playerIcon;
    public bool step3Num;
    public int count;
    // Start is called before the first frame update
    void Start()
    {

      //step2Num = playerIcon.GetComponent<CanvasController>().step2Count;
      count = 0;
    }

    void Update() {

      //step2Num = playerIcon.GetComponent<CanvasController>().step2Count;

    }

    private void OnTriggerEnter(Collider other)
    {

      if (other.gameObject.CompareTag("Brick")) {
        //playerIcon.GetComponent<CanvasController>().step2Count += 1;
        count += 1;

      }

    }

    private void OnTriggerExit(Collider other)
    {
      if (other.gameObject.CompareTag("Brick")) {
        //playerIcon.GetComponent<CanvasController>().step2Count += 1;
        count -= 1;

      }
    }

}
