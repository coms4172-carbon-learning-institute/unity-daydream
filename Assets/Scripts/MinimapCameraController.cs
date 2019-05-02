using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    private float minimapCameraOffset = 1000.0f;
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y +  minimapCameraOffset, player.transform.position.z);
        transform.Rotate(90f, 0, 0);
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y +  minimapCameraOffset, player.transform.position.z);
        transform.eulerAngles = player.transform.eulerAngles + new Vector3(90f, 0, 0);
    }

   
}
