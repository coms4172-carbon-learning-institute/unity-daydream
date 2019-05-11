using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    // Start is called before the first frame update

    private float minimapCameraOffset = 900.0f;
    private float cameraStartPosY;

    public GameObject player;

    // Minimaps
    public GameObject Floor1;
    public GameObject Floor2;
    public GameObject Floor3;

    // Floor levels
    private float elevation_floor1;
    private float elevation_floor2;
    private float elevation_floor3;

    void Start()
    {
        transform.position = new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y +  minimapCameraOffset, Camera.main.transform.position.z);
        transform.Rotate(90f, 0, 0);
        cameraStartPosY = Camera.main.transform.position.y;
        // save elevation info
        elevation_floor1 = Floor1.transform.GetChild(0).position.y;
        elevation_floor2 = Floor2.transform.GetChild(0).position.y;
        elevation_floor3 = Floor3.transform.GetChild(0).position.y;

        // start on the first floor. deactivate the other floor minimaps
        Floor2.SetActive(false);
        Floor3.SetActive(false);

    }

    void Update()
    {
        // Minimap camera always looks down 
        float cameraXRotation = Camera.main.transform.eulerAngles.x;
        transform.eulerAngles = Camera.main.transform.eulerAngles + new Vector3(-1 * cameraXRotation + 90f, 0, 0);

        if (GetPlayerCurrentFloor() == 1){
            Floor1.SetActive(true);
            Floor2.SetActive(false);
            Floor3.SetActive(false);

            cameraStartPosY = elevation_floor1;
        } else if (GetPlayerCurrentFloor() == 2) {
            Floor1.SetActive(false);
            Floor2.SetActive(true);
            Floor3.SetActive(false);

            cameraStartPosY = elevation_floor2;
        } else if (GetPlayerCurrentFloor() == 3) {
            Floor1.SetActive(false);
            Floor2.SetActive(false);
            Floor3.SetActive(true);

            cameraStartPosY = elevation_floor3;
        }

        transform.position = new Vector3(Camera.main.transform.position.x, cameraStartPosY +  minimapCameraOffset, Camera.main.transform.position.z);

    }

    int GetPlayerCurrentFloor()
    {
        if (player.transform.position.y > elevation_floor3){
            return 3;
        } else if (player.transform.position.y > elevation_floor2) {
            return 2;
        } else {
            return 1;
        }
    }

   
}
