﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] selectedObjs;
    public Material currentObjMaterial;
    private Material hoverMaterial;

    void Start()
    {
        hoverMaterial = Resources.Load("Materials/Hover") as Material;
        selectedObjs = GameObject.FindGameObjectsWithTag("selectable");

        foreach (GameObject obj in selectedObjs) {
            currentObjMaterial = obj.GetComponent<Renderer>().material;
            obj.AddComponent<MeshCollider>();
            obj.AddComponent<GoogleVR.HelloVR.ObjectController>();

            obj.GetComponent<GoogleVR.HelloVR.ObjectController>().inactiveMaterial = currentObjMaterial;
            obj.GetComponent<GoogleVR.HelloVR.ObjectController>().gazedAtMaterial = hoverMaterial;

            //pointerEnter

            EventTrigger eventTrigger = obj.AddComponent<EventTrigger>();
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerEnter;
            
            entry1.callback.AddListener((eventData) => obj.GetComponent<GoogleVR.HelloVR.ObjectController>().SetGazedAt(true));
            eventTrigger.triggers.Add(entry1);

            //pointerExit

            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerExit;
            entry2.callback.AddListener((eventData) => obj.GetComponent<GoogleVR.HelloVR.ObjectController>().SetGazedAt(false));
            eventTrigger.triggers.Add(entry2);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
