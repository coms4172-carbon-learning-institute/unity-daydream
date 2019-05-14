﻿using System.Collections;
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
    public float xAngle, yAngle, zAngle;
    public Vector3 initialPosition;
    public Vector3 currentScale;
    public Vector3 offset;
    private Vector2 initTouch;
    public float minInputThreshold;
    public float maxInputThreshold;
    private GameObject brickToSet;
    private bool inRotate;

    public GameObject brickParent;

    public float transformX, transformY, transformZ;

    private Vector3 initPos;
    private Vector3 initPointerPos;


    void Start()
    {

      myRenderer = GetComponent<Renderer>();
      SetGazedAt(false);
      inRotate = false;

      //pointer = GameObject.Find("ControllerPointerParent");
      //initialPosition = GvrPointerInputModule.Pointer.PointerTransform;
      //get initial object of Brick

      initialPosition = gameObject.transform.position;
      currentScale = gameObject.transform.localScale;
      minInputThreshold = 0.3f;
      maxInputThreshold = 0.65f;



    }

    private bool IsTouchTransformation(Vector2 touchPos) {

        return Mathf.Abs(touchPos.y) > minInputThreshold;

    }

    private bool IsTouchRotating(Vector2 touchPos) {

        return Mathf.Abs(touchPos.x) > minInputThreshold;

    }

    public void SetGazedAt(bool gazedAt)
    {

        //gameObject.transform.SetParent(brickParent.transform);
        //gameObject.transform.SetParent(brickParent.transform);

        Debug.Log("in set gazed at");
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
        //initPos = gameObject.transform.position;
        //initPointerPos = GvrPointerInputModule.Pointer.PointerTransform.position;

        //offset = initPointerPos - initPos;
        //currentScale = gameObject.transform.localScale;
    }

    public void Rotate() {

        inRotate = true;
        //initTouch = GvrControllerInput.TouchPos;
        //Transform diff = GvrPointerInputModule.Pointer.PointerTransform;
        //Transform diff = currentPosition.position - initialPosition.position;
        /*
        xAngle = diff.eulerAngles.x;
        yAngle = diff.eulerAngles.y;
        zAngle = diff.eulerAngles.z;
        */

        yAngle = 45f;

        //Debug.Log(new Vector3(xAngle, yAngle, zAngle));

        //if the position is on the right side
        if (IsTouchRotating(initTouch)) {

            this.gameObject.transform.Rotate(xAngle, yAngle, zAngle, Space.World);

        } else {
            this.gameObject.transform.Rotate(-1f * xAngle, -1f * yAngle, -1f * zAngle, Space.World);
        }
    }

    public void Transform() {

        inRotate = false;
        float diff = 10f;

        float currentScaleX = currentScale.x + 10f;
        float currentScaleY = currentScale.y + 10f;
        float currentScaleZ = currentScale.z + 10f;

        currentScale = gameObject.transform.localScale;

        if (IsTouchTransformation(initTouch)) {

            Debug.Log("in top half");
            currentScaleX = currentScale.x + 10f;
            currentScaleY = currentScale.y + 10f;
            currentScaleZ = currentScale.z + 10f;

        } else {

            Debug.Log("in bottom half");
          //don't make the brick disappear if already the scale of (10f, 10f, 10f)
            if (currentScale.x != 10f && currentScale.y != 10f && currentScale.z != 10f) {

                currentScaleX = currentScale.x - 5f;
                currentScaleY = currentScale.y - 5f;
                currentScaleZ = currentScale.z - 5f;

            }

        }

        transform.localScale = new Vector3(currentScaleX, currentScaleY, currentScaleZ);
        //this.gameObject.transform.Rotate(xAngle, yAngle, zAngle, Space.World);


    }


    public void Hold() {

        inRotate = false;
        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

        //Vector3 offset = pointerTransform.position - initPointerPos;
        //print(offset);
        //initPointerPos = pointerTransform.position;


        //gameObject.transform.position = pointerTransform.transform.position - offset;
        gameObject.transform.SetParent(pointerTransform, true);
        //gameObject.transform.localRotation = initPos;


    }


    public void Release() {
        transform.SetParent(null, true);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
      if (!inRotate) {

        transform.Rotate(-1*transform.eulerAngles.x, -1*transform.eulerAngles.y,-1*transform.eulerAngles.z, Space.Self);

      }




    }
}
