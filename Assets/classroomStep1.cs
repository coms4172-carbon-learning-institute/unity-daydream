using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classroomStep1 : MonoBehaviour
{
    //public GameObject Brick_1;
    //public GameObject Brick_2;
    //public GameObject Brick_3;

    private int collisionCount;

    public bool step1Succeeded;

    // Start is called before the first frame update
    void Start()
    {
        collisionCount = 0;
        step1Succeeded = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (collisionCount == 3) {
            step1Succeeded = true;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(collisionCount);
        if (other.gameObject.CompareTag("Brick")) {
          collisionCount += 1;
        }

    }

    private void OnTriggerExit(Collider other)

    {
        collisionCount -= 1;

    }


}
