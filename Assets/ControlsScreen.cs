using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsScreen : MonoBehaviour
{
    public GameObject panel;
    public GameObject welcome;
    public Button HowToUse;
    public Button close;

    void Start()
    {
        panel.SetActive(false);
        HowToUse.onClick.AddListener(TurnOn);
        close.onClick.AddListener(TurnOff);
    }

    void TurnOn()
    {
        panel.SetActive(true);
        welcome.SetActive(false);
    }

    void TurnOff()
    {
        panel.SetActive(false);
    }
}
