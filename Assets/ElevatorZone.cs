using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorZone : MonoBehaviour
{
    public GameObject elevatormode;


    public GameObject PodWindow1;
    public GameObject PodWindow2;
    public GameObject PodWindow3;
    public GameObject PodWindow4;
    public GameObject PodWindow5;
    public GameObject PodWindow6;
    public GameObject PodWindow7;

    public bool InClassroom;

    void Start()
    {

        elevatormode.SetActive(false);
        InClassroom = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
        if (other.CompareTag("Minimap Stairs"))
        {
            elevatormode.SetActive(true);
        }

        // if entering classroom
        if (other.CompareTag("Target Pod")) {

            //disable the windows
            InClassroom = true;
            PodWindow1.SetActive(false);
            PodWindow2.SetActive(false);
            PodWindow3.SetActive(false);
            PodWindow4.SetActive(false);
            PodWindow5.SetActive(false);
            PodWindow6.SetActive(false);
            PodWindow7.SetActive(false);
            //adjust the length of the raycast

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

        if (other.CompareTag("Target Pod")) {

            //disable the windows
            InClassroom = false;
            PodWindow1.SetActive(true);
            PodWindow2.SetActive(true);
            PodWindow3.SetActive(true);
            PodWindow4.SetActive(true);
            PodWindow5.SetActive(true);
            PodWindow6.SetActive(true);
            PodWindow7.SetActive(true);
            //adjust the length of the raycast
        }

    }
}
