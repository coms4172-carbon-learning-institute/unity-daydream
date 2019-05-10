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

      /*
        brickObjs = GameObject.FindGameObjectsWithTag("brick");

        foreach (GameObject obj in brickObjs) {
          EventTrigger eventTrigger = obj.AddComponent<EventTrigger>();
          EventTrigger.Entry entry1 = new EventTrigger.Entry();
          entry1.eventID = EventTriggerType.BeginDrag;
          entry1.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Translate());
          eventTrigger.triggers.Add(entry1);


        }

        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
