//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google Inc.">
// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    public Material inactiveMaterial;
    public Material gazedAtMaterial;
    public GameObject canvas;
    public GameObject panel;
    public RawImage rawimage;

    private Vector3 startingPosition;
    private Renderer myRenderer;

    private void Start()
    {
        startingPosition = transform.localPosition;
        myRenderer = GetComponent<Renderer>();
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }

    public void showCanvas(bool show)
    {
        canvas.SetActive(show);
        string tag = gameObject.transform.parent.tag;

        Texture mat = Resources.Load("Model_Materials/" + tag + "_material") as Texture;
        rawimage.texture = mat;

        /*if (gameObject.transform.parent.CompareTag("Farming"))
        {
            print("yes farming");
            Texture mat = Resources.Load("Model_Materials/"+tag+"_material") as Texture;
            rawimage.texture = mat;

        }*/
    }
}
