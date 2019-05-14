using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public GameObject step1Collider;
    //public GameObject step2Collider;
    //public GameObject step3Collider;

    public bool step1Success;
    public bool step2Success;
    public bool step3Success;

    public GameObject welcome;
    public Button howtouse;
    public Button close_welcome;

    public GameObject instructions;
    public Button next;

    public GameObject carbongoggles;
    public Button close_carbongoggles;

    public Toggle walk;
    public GameObject tunnelspeed;
    private float speed;
    public Toggle elevator;

    public GameObject elevatormode;
    public GameObject elevatorpanel;

    public GameObject minimap;
    public GameObject mainmenu;

    public GameObject welcome_class;
    public Button close_welcome_class;
    public Button Go;
    public GameObject step1;
    public Button next1;
    public GameObject step2;
    public Button next2;
    public GameObject step3;
    public Button next3;
    public GameObject finish;
    public Button close_class;

    public GameObject discGlassParent;
    public GameObject manPanel;
    public GameObject classroomPanel;
    public GameObject classroomWelcome;
    public GameObject glassSilicon;
    public bool inClassroom;

    void Start()
    {
        welcome.SetActive(true);
        instructions.SetActive(false);
        carbongoggles.SetActive(false);
        tunnelspeed.SetActive(false);
        elevatormode.SetActive(false);
        elevatorpanel.SetActive(false);
        minimap.SetActive(false);
        mainmenu.SetActive(false);
        welcome_class.SetActive(false);
        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
        finish.SetActive(false);


        step1Success = step1Collider.GetComponent<classroomStep1>().step1Succeeded;

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

        //Go.onClick.AddListener(ToStep1);
        close_welcome_class.onClick.AddListener(ExitWelcomeClass);
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
            tunnelspeed.SetActive(true);
            elevatorpanel.SetActive(false);
        }
        else
        {
            minimap.SetActive(false);
            tunnelspeed.SetActive(false);
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
    void ExitWelcomeClass()
    {
        welcome_class.SetActive(false);
    }
    /*
    void ToStep1()
    {
        welcome_class.SetActive(false);
        step1.SetActive(true);
    }
    */
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
        if (other.CompareTag("Classroom"))
        {
            inClassroom = true;
            Debug.Log("Entered Classroom");
            discGlassParent.SetActive(false);
            //manPanel.SetActive(true);
            classroomPanel.SetActive(true);
            classroomWelcome.SetActive(true);
            glassSilicon.SetActive(false);
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
        if (other.CompareTag("Classroom"))
        {
            inClassroom = false;
            Debug.Log("Exited Classroom");
            discGlassParent.SetActive(false);
            glassSilicon.SetActive(true);
        }
    }


    void Update() {

        step1Success = step1Collider.GetComponent<classroomStep1>().step1Succeeded;

        if (step1Success) {

            welcome_class.SetActive(false);
            step1.SetActive(true);

        }

    }
}
