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
    public GameObject controlPanel;
    public RawImage rawimage;
    public Text info;
    public Text infoTitle;
    public Toggle carbonToggle;

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
        info_dict.Add("Farming", "Embodied carbon: - 460 Kg/Ton");
        infoMat_dict.Add("Farming", "Farming_material");
        carbon_dict.Add("Farming", -460f);

        infoTitle_dict.Add("Frame", "BIOCHAR Brick");
        info_dict.Add("Frame", "Embodied carbon: - 900 Kg/Ton");
        infoMat_dict.Add("Frame", "Frame_material");
        carbon_dict.Add("Frame", -900f);

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
