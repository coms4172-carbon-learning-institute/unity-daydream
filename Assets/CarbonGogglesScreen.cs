using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarbonGogglesScreen : MonoBehaviour
{
    public GameObject panel;
    public Button close;
    public Button TurnOn;
    public GameObject controls;

    void Start()
    {
        panel.SetActive(false);
        TurnOn.onClick.AddListener(On);
        close.onClick.AddListener(Off);
    }

    void On()
    {
        panel.SetActive(true);
        controls.SetActive(false);
    }

    void Off()
    {
        panel.SetActive(false);
    }
}
