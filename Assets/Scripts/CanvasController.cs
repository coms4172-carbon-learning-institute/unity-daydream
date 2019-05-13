using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameObject welcome;
    public Button howtouse;
    public Button close_welcome;

    public GameObject instructions;
    public Button next;

    public GameObject carbongoggles;
    public Button close_carbongoggles;

    public Toggle walk;
    public Toggle elevator;

    public GameObject elevatormode;
    public GameObject elevatorpanel;

    public GameObject minimap;
    public GameObject mainmenu;

    public GameObject welcome_class;
    public Button Go;
    public GameObject step1;
    public Button next1;
    public GameObject step2;
    public Button next2;
    public GameObject step3;
    public Button next3;
    public GameObject finish;
    public Button close_class;

    void Start()
    {
        welcome.SetActive(true);
        instructions.SetActive(false);
        carbongoggles.SetActive(false);
        elevatormode.SetActive(false);
        elevatorpanel.SetActive(false);
        minimap.SetActive(false);
        mainmenu.SetActive(false);
        welcome_class.SetActive(false);
        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
        finish.SetActive(false);

        walk.onValueChanged.AddListener(delegate
        {
            walk_toggle_change(walk);
        });
        elevator.onValueChanged.AddListener(delegate
        {
            elevator_toggle_change(elevator);
        });

        howtouse.onClick.AddListener(Instructions);
        close_welcome.onClick.AddListener(ExitWelcome);

        next.onClick.AddListener(GoToCarbonGoggles);

        close_carbongoggles.onClick.AddListener(Close_CG);

        Go.onClick.AddListener(ToStep1);
        next1.onClick.AddListener(ToStep2);
        next2.onClick.AddListener(ToStep3);
        next3.onClick.AddListener(ToFinish);
        close_class.onClick.AddListener(ExitClass);
    }

    void walk_toggle_change(Toggle change)
    {
        if (change.isOn)
        {
            minimap.SetActive(true);
        }
        else
        {
            minimap.SetActive(false);
        }
    }
    void elevator_toggle_change(Toggle change)
    {
        if (change.isOn)
        {
            minimap.SetActive(true);
            elevatorpanel.SetActive(true);
        }
        else
        {
            minimap.SetActive(false);
            elevatorpanel.SetActive(false);
        }
    }

    public void Instructions()
    {
        welcome.SetActive(false);
        instructions.SetActive(true);
    }
    void ExitWelcome() 
    {
        welcome.SetActive(false);
        mainmenu.SetActive(true);
    }
    void GoToCarbonGoggles()
    {
        instructions.SetActive(false);
        carbongoggles.SetActive(true);
    }
    void Close_CG()
    {
        carbongoggles.SetActive(false);
        mainmenu.SetActive(true);
    }
    void ToStep1()
    {
        welcome_class.SetActive(false);
        step1.SetActive(true);
    }
    void ToStep2()
    {
        step1.SetActive(false);
        step2.SetActive(true);
    }
    void ToStep3()
    {
        step2.SetActive(false);
        step3.SetActive(true);
    }
    void ToFinish()
    {
        step3.SetActive(false);
        finish.SetActive(true);
    }
    void ExitClass()
    {
        finish.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Minimap Stairs"))
        {
            elevatormode.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Minimap Stairs"))
        {
            elevatormode.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Minimap Stairs"))
        {
            elevatormode.SetActive(false);
        }
    }
}
