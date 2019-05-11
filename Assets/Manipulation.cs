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
    private Vector2? initTouch = null;
    public float minInputThreshold;
    public float maxInputThreshold;

    public float transformX, transformY, transformZ;


    void Start()
    {
      myRenderer = GetComponent<Renderer>();
      SetGazedAt(false);
      //pointer = GameObject.Find("ControllerPointerParent");
      //initialPosition = GvrPointerInputModule.Pointer.PointerTransform;
      //get initial object of Brick
      initialPosition = gameObject.transform.position;
      currentScale = gameObject.transform.localScale;
      minInputThreshold = 0.3f;
      maxInputThreshold = 0.65f;

    }


    private bool IsTouchTranslating(Vector2 touchPos) {

        initTouch = GvrControllerInput.TouchPos;
        return Mathf.Abs(touchPos.y) > minInputThreshold;

    }

    private bool IsTouchRotating(Vector2 touchPos) {

        initTouch = GvrControllerInput.TouchPos;
        return Mathf.Abs(touchPos.x) > minInputThreshold;
    }

    public void SetGazedAt(bool gazedAt)
    {
        Debug.Log("in set gazed at");
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }

    public void Rotate() {

        Transform diff = GvrPointerInputModule.Pointer.PointerTransform;
        //Transform diff = currentPosition.position - initialPosition.position;

        xAngle = diff.eulerAngles.x;
        yAngle = diff.eulerAngles.y;
        zAngle = diff.eulerAngles.z;

        Debug.Log(new Vector3(xAngle, yAngle, zAngle));
        this.gameObject.transform.Rotate(xAngle, yAngle, zAngle, Space.World);
    }

    public void Transform() {

        currentScale = gameObject.transform.localScale;
        float currentScaleX = currentScale.x + 10f;
        float currentScaleY = currentScale.y + 10f;
        float currentScaleZ = currentScale.z + 10f;
        transform.localScale = new Vector3(currentScaleX, currentScaleY, currentScaleZ);

    }


    public void Hold() {

        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;
        //transform.position = pointerTransform;
        transform.SetParent(pointerTransform, true);

    }


    public void Release() {
        transform.SetParent(null, true);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
