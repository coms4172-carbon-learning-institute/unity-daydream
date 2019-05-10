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

    public void Hold() {
    // get the Transform component of the pointer
        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;
        Debug.Log(pointerTransform);
        // set the GameObject's parent to the pointer
        transform.SetParent(pointerTransform, false);
        // position it in the view
        //transform.localPosition = new Vector3(0, 0, 2);

        // disable physics
        //GetComponent<Rigidbody>().isKinematic = true;
    }

    /*
    public void Translate() {

      Debug.Log("in translate");
      Debug.Log(pointer.gameObject.transform.position);
    }

    */

    public void Move() {
      Debug.Log("in drag function");
      this.gameObject.transform.position = pointer.gameObject.transform.position;

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

    /*
    public void Release() {
  // set the parent to the world
      transform.SetParent(null, true);
      // get the rigidbody physics component
      Rigidbody rigidbody = GetComponent<Rigidbody>();
      // reset velocity
      rigidbody.velocity = Vector3.zero;
      // enable physics
      rigidbody.isKinematic = false;
    }
    */

    public void testFct() {

        Debug.Log("hello");
        Debug.Log("dragging");

    }



    /*
    public void Translate(PointerEventData data) {

      Debug.Log(data);
    }
    /*

    public void OnDrag(PointerEventData data) {

        Debug.Log("hello");

    }
    */

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
