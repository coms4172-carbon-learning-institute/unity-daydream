using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public GameObject[] selectedObjs;
    public Material currentObjMaterial;
    public GameObject infoPanel;

    private Material hoverMaterial;
    public GameObject currSelectedObj;

    void Start()
    {
        infoPanel.SetActive(false);
        hoverMaterial = Resources.Load("Materials/Hover") as Material;
        selectedObjs = GameObject.FindGameObjectsWithTag("selectable");

        foreach (GameObject obj in selectedObjs)
        {
            currentObjMaterial = obj.GetComponent<Renderer>().material;
            obj.AddComponent<MeshCollider>();
            //obj.AddComponent<GoogleVR.HelloVR.ObjectController>();
            //obj.GetComponent<GoogleVR.HelloVR.ObjectController>().inactiveMaterial = currentObjMaterial;
            //obj.GetComponent<GoogleVR.HelloVR.ObjectController>().gazedAtMaterial = hoverMaterial;
            obj.AddComponent<CustomObjectController>();
            obj.GetComponent<CustomObjectController>().inactiveMaterial = currentObjMaterial;
            obj.GetComponent<CustomObjectController>().gazedAtMaterial = hoverMaterial;
            obj.GetComponent<CustomObjectController>().panel = infoPanel;

            //pointerEnter

            EventTrigger eventTrigger = obj.AddComponent<EventTrigger>();
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerEnter;
            //entry1.callback.AddListener((eventData) => obj.GetComponent<GoogleVR.HelloVR.ObjectController>().SetGazedAt(true));
            entry1.callback.AddListener((eventData) => obj.GetComponent<CustomObjectController>().SetGazedAt(true));
            eventTrigger.triggers.Add(entry1);

            //pointerExit
            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerExit;
            //entry2.callback.AddListener((eventData) => obj.GetComponent<GoogleVR.HelloVR.ObjectController>().SetGazedAt(false));
            entry2.callback.AddListener((eventData) => obj.GetComponent<CustomObjectController>().SetGazedAt(false));
            eventTrigger.triggers.Add(entry2);

            EventTrigger.Entry entry3 = new EventTrigger.Entry();
            entry3.eventID = EventTriggerType.PointerClick;
            entry3.callback.AddListener((eventData) => obj.GetComponent<CustomObjectController>().showPanel(true));
            eventTrigger.triggers.Add(entry3);


            // add parent information for info panel

        }
    }

    private void Update()
    {
        //currSelectedObj = EventSystem.current.currentSelectedGameObject;

    }
}
