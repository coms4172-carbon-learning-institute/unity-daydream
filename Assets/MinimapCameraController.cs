using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public float minimapCameraOffset = 10.0f;
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y +  minimapCameraOffset, player.transform.position.z);
        transform.Rotate(90f, 0, 0);
    }

   
}
