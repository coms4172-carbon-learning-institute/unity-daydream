using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    // Start is called before the first frame update

    private float minimapCameraOffset = 900.0f;
    private float cameraStartPosY;
    void Start()
    {
        transform.position = new Vector3(Camera.main.transform.position.x,Camera.main.transform.position.y +  minimapCameraOffset, Camera.main.transform.position.z);
        transform.Rotate(90f, 0, 0);
        cameraStartPosY = Camera.main.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x, cameraStartPosY +  minimapCameraOffset, Camera.main.transform.position.z);

        float cameraXRotation = Camera.main.transform.eulerAngles.x;
        transform.eulerAngles = Camera.main.transform.eulerAngles + new Vector3(-1 * cameraXRotation + 90f, 0, 0);
    }

   
}
