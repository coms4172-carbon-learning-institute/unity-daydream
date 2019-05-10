using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manipulation : MonoBehaviour
{
    // Start is called before the first frame update

    public Material inactiveMaterial;
    public Material gazedAtMaterial;
    private Renderer myRenderer;
    public GameObject pointer;


    void Start()
    {
      myRenderer = GetComponent<Renderer>();
      SetGazedAt(false);
      //pointer = GameObject.Find("ControllerPointerParent");
      Debug.Log(pointer.gameObject.transform.position);

      //gameObject.AddListener(EventTriggerType.PointerDown, Hold);
      //gameObject.AddListener(EventTriggerType.PointerUp, Release);
    }



    public void SetGazedAt(bool gazedAt)
    {
        Debug.Log("in set gazed at");
        Debug.Log(pointer.gameObject.transform.position);
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }


    public void Rotate() {

      Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;



    }

    public void Release() {




    }
    public void Hold() {

        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;
        transform.SetParent(pointerTransform, false);
    }

    public void Release() {

      transform.SetParent(null, true);

    }



    /*
    public void Translate() {

      Debug.Log("in translate");
      Debug.Log("position is");
      Debug.Log(this.gameObject.transform.position);

    } */


    /*
    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag called.");
    } */

    /*
    public void OnBeginDrag(PointerEventData data) {

      Debug.Log("beginning to drag");
      Debug.Log("data");
      this.gameObject.transform.position = data.position;
    } */

    // Update is called once per frame
    void Update()
    {

    }
}
