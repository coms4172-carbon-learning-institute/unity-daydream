using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InitializeBricks : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] brickObjs;



    void Start()
    {
        brickObjs = GameObject.FindGameObjectsWithTag("brick");

        foreach (GameObject obj in brickObjs) {

            EventTrigger eventTrigger = obj.AddComponent<EventTrigger>();
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerDown;


            //depending on the boolean
            if (gameObject.GetComponent<ButtonManipulationController>().translate == true) {

                entry1.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Hold());

            } else if (gameObject.GetComponent<ButtonManipulationController>().transform == false) {

                entry1.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Transform());

            } else {

                entry1.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Rotate());

            }

            eventTrigger.triggers.Add(entry1);

            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerUp;
            entry2.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Release());
            eventTrigger.triggers.Add(entry2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
