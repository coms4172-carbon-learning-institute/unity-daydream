using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public GameObject[] selectedObjs;
    public Material currentObjMaterial;
    public GameObject canvas;
    public GameObject panel;
    public RawImage rawimage;

    private Material hoverMaterial;
    public GameObject currSelectedObj;

    void Start()
    {
        canvas.SetActive(false);
        hoverMaterial = Resources.Load("Materials/Hover") as Material;
        selectedObjs = GameObject.FindGameObjectsWithTag("selectable");

        foreach (GameObject obj in selectedObjs)
        {
            currentObjMaterial = obj.GetComponent<Renderer>().material;
            obj.AddComponent<MeshCollider>();
            obj.AddComponent<CustomObjectController>();
            obj.GetComponent<CustomObjectController>().inactiveMaterial = currentObjMaterial;
            obj.GetComponent<CustomObjectController>().gazedAtMaterial = hoverMaterial;
            obj.GetComponent<CustomObjectController>().canvas = canvas;
            obj.GetComponent<CustomObjectController>().panel = panel;
            obj.GetComponent<CustomObjectController>().rawimage = rawimage;

            //pointerEnter

            EventTrigger eventTrigger = obj.AddComponent<EventTrigger>();
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerEnter;
            entry1.callback.AddListener((eventData) => obj.GetComponent<CustomObjectController>().SetGazedAt(true));
            eventTrigger.triggers.Add(entry1);

            //pointerExit
            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerExit;
            entry2.callback.AddListener((eventData) => obj.GetComponent<CustomObjectController>().SetGazedAt(false));
            eventTrigger.triggers.Add(entry2);

            EventTrigger.Entry entry3 = new EventTrigger.Entry();
            entry3.eventID = EventTriggerType.PointerClick;
            entry3.callback.AddListener((eventData) => obj.GetComponent<CustomObjectController>().showCanvas(true));
            eventTrigger.triggers.Add(entry3);


            // add parent information for info panel

        }
    }

    private void Update()
    {
        //currSelectedObj = EventSystem.current.currentSelectedGameObject;

    }
}
