using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public GameObject step1Collider;
    public GameObject step2Collider1;
    public GameObject step2Collider2;

    public GameObject step3Collider1;
    public GameObject step3Collider2;
    public GameObject step3Collider3;
    public GameObject step3Collider4;

    public bool step1Success;
    public bool step2Success;
    public bool step3Success;
    public int step2Count;
    public int step3Count;

    public GameObject welcome;
    public Button howtouse;
    public Button close_welcome;

    public GameObject instructions;
    //public Button next;

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

    public GameObject step1result;
    public GameObject step2result;
    public GameObject step3result;

    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public Button finish;
    public Button close_class;
    public Button nextStep1;
    public Button nextStep2;

    public GameObject discGlassParent;
    public GameObject manPanel;
    public GameObject classroomPanel;
    public GameObject classroomWelcome;
    public GameObject glassSilicon;
    public bool inClassroom;
    private bool afterstep1;
    private bool afterstep2;
    private bool afterstep3;

    void Start()
    {
        afterstep1 = false;
        afterstep2 = false;
        afterstep3 = false;
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
        //finish.SetActive(false);

        step2Count = 0;
        step3Count = 0;

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

        //next.onClick.AddListener(GoToCarbonGoggles);

        close_carbongoggles.onClick.AddListener(Close_CG);

        Go.onClick.AddListener(ToStep1);
        // close_welcome_class.onClick.AddListener(ExitWelcomeClass);
        nextStep1.onClick.AddListener(ToStep2);
        nextStep2.onClick.AddListener(ToStep3);
        finish.onClick.AddListener(ExitClass);

        //close_class.onClick.AddListener(ExitClass);
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

    void ToStep1()
    {
        welcome_class.SetActive(false);
        step1.SetActive(true);
        manPanel.SetActive(true);
    }

    void ToStep2()
    {
        step1Success = false;
        step1result.SetActive(false);
        step1.SetActive(false);
        step2.SetActive(true);
        step2Collider1.SetActive(true);
        step2Collider2.SetActive(true);
    }
    void ToStep3()
    {
        step2Collider1.SetActive(false);
        step2Collider2.SetActive(false);
        step2.SetActive(false);
        step2result.SetActive(false);
        step3.SetActive(true);
        step3Collider1.SetActive(true);
        step3Collider2.SetActive(true);
        step3Collider3.SetActive(true);
        step3Collider4.SetActive(true);
    }
    void ToFinish()
    {
        step3.SetActive(false);
    }
    void ExitClass()
    {
        step3result.SetActive(false);
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
            welcome.SetActive(false);
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

        if (step1Success && !afterstep1) {

            step1.SetActive(false);
            step1result.SetActive(true);
            step1Success = false;
            //enable Step 1
            afterstep1 = true;
        }

        step2Count += step2Collider1.GetComponent<classroomStep2>().count;
        step2Count += step2Collider2.GetComponent<classroomStep2>().count;

        if (step2Count >= 2 && !afterstep2) {

            step1result.SetActive(false);
            step1.SetActive(false);
            step2.SetActive(false);
            step2result.SetActive(true);
            afterstep2 = true;
            //ENABLE STEP 2 MODEL

        }
        step3Count += step3Collider1.GetComponent<classroomStep3>().count;
        step3Count += step3Collider2.GetComponent<classroomStep3>().count;
        step3Count += step3Collider3.GetComponent<classroomStep3>().count;
        step3Count += step3Collider4.GetComponent<classroomStep3>().count;

        if (step3Count >= 4 && !afterstep3) {

            step3.SetActive(false);
            step3result.SetActive(true);
            //ENABLE STEP 2 MODEL
            afterstep3 = true;

        }


    }
}
