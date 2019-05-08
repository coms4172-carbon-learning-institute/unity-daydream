using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScreen : MonoBehaviour
{
    public Button start;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
        start.onClick.AddListener(Begin);
    }

    void Begin()
    {
        panel.SetActive(false);
    }
}
