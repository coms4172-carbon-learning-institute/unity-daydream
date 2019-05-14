using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public GameObject[] selectedObjs;
    public GameObject[] brickObjs;
    public Material currentObjMaterial;
    public GameObject canvas;
    public GameObject panel;
    public GameObject controlPanel;
    public GameObject manPanel;
    public RawImage rawimage;
    public Text info;
    public Text infoTitle;
    public Toggle carbonToggle;

    private GameObject[] selectedBricks;
    public Toggle noneToggle;
    public Toggle scaleToggle;
    public Toggle translateToggle;
    public Toggle rotateToggle;

    private Material hoverMaterial;
    public GameObject currSelectedObj;


    public Dictionary<string, string> info_dict = new Dictionary<string, string>();
    public Dictionary<string, string> infoTitle_dict = new Dictionary<string, string>();
    public Dictionary<string, string> infoMat_dict = new Dictionary<string, string>();


    private Dictionary<string, float> carbon_dict = new Dictionary<string, float>();

    private Dictionary<GameObject, Material> og_mat_dict = new Dictionary<GameObject, Material>();
    private Dictionary<GameObject, Material> carbon_mat_dict = new Dictionary<GameObject, Material>();

    // Daydream Controller Input
    public GameObject HandheldController;
    private GvrControllerInputDevice DaydreamControllerInput;

    void Start()
    {
        panel.SetActive(false);
        hoverMaterial = Resources.Load("Materials/Hover") as Material;
        selectedObjs = GameObject.FindGameObjectsWithTag("selectable");

        infoTitle_dict.Add("Farming", "CLT(Cross Laminated Timber)");
        info_dict.Add("Farming", "Embodied carbon: - 900 Kg/Ton");
        infoMat_dict.Add("Farming", "Farming_material");
        carbon_dict.Add("Farming", -900f);

        infoTitle_dict.Add("Frame", "BIOCHAR Brick");
        info_dict.Add("Frame", "Embodied carbon: - 460 Kg/Ton");
        infoMat_dict.Add("Frame", "Frame_material");
        carbon_dict.Add("Frame", -460);

        infoTitle_dict.Add("Glue", "GLT(Glue Laminated Timber)");
        info_dict.Add("Glue", "Embodied carbon: - 870 Kg/Ton");
        infoMat_dict.Add("Glue", "Glue_material");
        carbon_dict.Add("Glue", -870);

        infoTitle_dict.Add("Floor", "Gravel");
        info_dict.Add("Floor", "Embodied carbon: - 4.32 Kg/Ton");
        infoMat_dict.Add("Floor", "Floor_material");
        carbon_dict.Add("Floor", -4.32f);

        infoTitle_dict.Add("Floor Circular", "Wooden Floor Planks");
        info_dict.Add("Floor Circular", "Embodied carbon: - 650 Kg/Ton");
        infoMat_dict.Add("Floor Circular", "Floor_circular_material");
        carbon_dict.Add("Floor Circular", -650);

        infoTitle_dict.Add("Discs", "Hemp Bioplastic");
        info_dict.Add("Discs", "Embodied carbon: - 428 Kg/Ton");
        infoMat_dict.Add("Discs", "Discs_material");
        carbon_dict.Add("Discs", -428);

        infoTitle_dict.Add("Floor Inside", "Soil");
        info_dict.Add("Floor Inside", "Embodied carbon: - 23 Kg/Ton");
        infoMat_dict.Add("Floor Inside", "Floor_inside_material");
        carbon_dict.Add("Floor Inside", -23);

        selectedBricks = GameObject.FindGameObjectsWithTag("Brick");

        // get min and max of carbon_dict values
        float min = float.MaxValue;
        float max = float.MinValue;

        foreach(KeyValuePair<string,float> entry in carbon_dict)
        {
            if (entry.Value > max)
            {
                max = entry.Value;
            }
            if (entry.Value < min)
            {
                min = entry.Value;
            }
        }
        print("min: " + min);
        print("max: " + max);

        //print(scale(min, max, -500.0f));
        //print(scale(min, max, -460.0f));
        // visual indication of running, workingo n displaying tunnel speed
        foreach (GameObject obj in selectedObjs)
        {
            currentObjMaterial = obj.GetComponent<Renderer>().material;
            og_mat_dict.Add(obj, currentObjMaterial);
            int carbonvalue = scale(min, max, carbon_dict[obj.transform.parent.tag]);
            Material tempMat = new Material(Shader.Find("Specular"));
            tempMat.color = new Color32((byte)carbonvalue, (byte)carbonvalue, (byte)carbonvalue, (byte)1);
            carbon_mat_dict.Add(obj, tempMat);

            obj.AddComponent<MeshCollider>();
            obj.AddComponent<CustomObjectController>();
            obj.GetComponent<CustomObjectController>().inactiveMaterial = currentObjMaterial;
            obj.GetComponent<CustomObjectController>().gazedAtMaterial = hoverMaterial;
            obj.GetComponent<CustomObjectController>().canvas = canvas;
            obj.GetComponent<CustomObjectController>().panel = panel;
            obj.GetComponent<CustomObjectController>().rawimage = rawimage;
            obj.GetComponent<CustomObjectController>().info = info;
            obj.GetComponent<CustomObjectController>().infoTitle = infoTitle;


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

        DaydreamControllerInput = HandheldController.GetComponent<GvrTrackedController>().ControllerInputDevice;

        //start of brick initialization (should be in update?)
        //upon click of UI panel and depending on step, initialize # of bricks
        brickObjs = GameObject.FindGameObjectsWithTag("Brick");

        foreach (GameObject obj in brickObjs) {

            EventTrigger eventTrigger = obj.AddComponent<EventTrigger>();
            EventTrigger.Entry entry1 = new EventTrigger.Entry();
            entry1.eventID = EventTriggerType.PointerDown;

            //depending on the toggle
            if (scaleToggle.isOn) {

                entry1.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Transform());

            } else if (translateToggle.isOn) {

                entry1.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Hold());

            } else if (rotateToggle.isOn) {

                entry1.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Rotate());

            }

            eventTrigger.triggers.Add(entry1);

            EventTrigger.Entry entry2 = new EventTrigger.Entry();
            entry2.eventID = EventTriggerType.PointerClick;
            entry2.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().SetGazedAt(true));
            eventTrigger.triggers.Add(entry2);


            EventTrigger.Entry entry3 = new EventTrigger.Entry();
            entry3.eventID = EventTriggerType.PointerUp;
            entry3.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().Release());
            eventTrigger.triggers.Add(entry3);


            EventTrigger.Entry entry4 = new EventTrigger.Entry();
            entry4.eventID = EventTriggerType.PointerEnter;
            entry4.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().SetGazedAt(true));
            eventTrigger.triggers.Add(entry4);


            EventTrigger.Entry entry5 = new EventTrigger.Entry();
            entry5.eventID = EventTriggerType.PointerExit;
            entry5.callback.AddListener((eventData) => obj.GetComponent<Manipulation>().SetGazedAt(false));
            eventTrigger.triggers.Add(entry5);


        }

        //end of brick initialization

    }
    private int scale(float minval, float maxval, float x)
    {
        // scale between 0 and 255
        int b = 205;
        int a = 50;
        return (int) ((b-a) * ((x - minval) / (maxval - minval))+a);
    }

    private void Update()
    {

        carbonToggle.onValueChanged.AddListener(CarbonToggleListener);

        if (DaydreamControllerInput.GetButtonUp(GvrControllerButton.App)) {
            bool controlPanelIsActive = controlPanel.activeInHierarchy;
            controlPanel.SetActive(!controlPanelIsActive);
            Debug.Log("Toggle Control Panel");
        }
        noneToggle.onValueChanged.AddListener(NoneToggleListener);
        scaleToggle.onValueChanged.AddListener(ScaleToggleListener);
        rotateToggle.onValueChanged.AddListener(RotateToggleListener);
        translateToggle.onValueChanged.AddListener(TranslateToggleListener);


    }
    private void NoneToggleListener(bool value)
    {

        if (noneToggle.isOn)
        {


        }


    }

    private void ScaleToggleListener(bool value)
    {
        if (scaleToggle.isOn)
        {
            foreach (GameObject brick in selectedBricks)
            {
                EventTrigger trigger = brick.GetComponent<EventTrigger>();
                foreach (EventTrigger.Entry entry in trigger.triggers)
                {
                    if (entry.eventID == EventTriggerType.PointerDown)
                    {
                        trigger.triggers.Remove(entry);
                        //entry.callback.AddListener((eventData) => brick.GetComponent<Manipulation>().Transform());
                        EventTrigger.Entry newEntry = new EventTrigger.Entry();
                        newEntry.eventID = EventTriggerType.PointerDown;
                        newEntry.callback.AddListener((eventData) => brick.GetComponent<Manipulation>().Transform());
                        trigger.triggers.Add(newEntry);
                    }
                }
            }

        }
    }

    private void RotateToggleListener(bool value)
    {
        if (rotateToggle.isOn)
        {
          foreach (GameObject brick in selectedBricks)
          {
              EventTrigger trigger = brick.GetComponent<EventTrigger>();

              foreach (EventTrigger.Entry entry in trigger.triggers)
              {

                  if (entry.eventID == EventTriggerType.PointerDown)
                  {

                      entry.callback.RemoveAllListeners();
                      entry.callback.AddListener((eventData) => brick.GetComponent<Manipulation>().Rotate());
                  }
              }
          }

        }
    }

    private void TranslateToggleListener(bool value)
    {
        if (translateToggle.isOn)
        {
          foreach (GameObject brick in selectedBricks)
          {
              EventTrigger trigger = brick.GetComponent<EventTrigger>();

              foreach (EventTrigger.Entry entry in trigger.triggers)
              {
                  if (entry.eventID == EventTriggerType.PointerDown)
                  {

                      entry.callback.RemoveAllListeners();
                      entry.callback.AddListener((eventData) => brick.GetComponent<Manipulation>().Hold());
                  }

              }
          }

        }
    }

    private void CarbonToggleListener(bool value)
    {
        if (carbonToggle.isOn)
        {
            foreach (GameObject obj in selectedObjs)
            {
                obj.GetComponent<Renderer>().material = carbon_mat_dict[obj];
                obj.GetComponent<CustomObjectController>().inactiveMaterial = carbon_mat_dict[obj];
            }
        }
        else
        {
            foreach (GameObject obj in selectedObjs)
            {
                obj.GetComponent<Renderer>().material = og_mat_dict[obj];
                obj.GetComponent<CustomObjectController>().inactiveMaterial = og_mat_dict[obj];
            }
        }
    }
}
