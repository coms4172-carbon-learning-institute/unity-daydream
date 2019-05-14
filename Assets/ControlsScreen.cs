using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsScreen : MonoBehaviour
{
    public GameObject panel;
    public GameObject welcome;
    public Button HowToUse;

    void Start()
    {
        panel.SetActive(false);
        HowToUse.onClick.AddListener(TurnOn);
    }

    void TurnOn()
    {
        panel.SetActive(true);
        welcome.SetActive(false);
    }
}
