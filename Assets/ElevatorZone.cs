using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorZone : MonoBehaviour
{
    public GameObject elevatormode;
    public GameObject discGlassParent;

    void Start()
    {
        elevatormode.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Minimap Stairs"))
        {
            elevatormode.SetActive(true);
        }
        if (other.CompareTag("Classroom"))
        {
            Debug.Log("Entered Classroom");
            discGlassParent.SetActive(false);
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
            Debug.Log("Exited Classroom");
            discGlassParent.SetActive(false);
        }
    }
}
