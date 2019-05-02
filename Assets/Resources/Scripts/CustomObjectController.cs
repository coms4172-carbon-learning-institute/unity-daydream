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
    public Text info;
    public Text infoTitle;

    private Vector3 startingPosition;
    private Renderer myRenderer;

    Dictionary<string, string> info_dict = new Dictionary<string, string>();
    Dictionary<string, string> infoTitle_dict = new Dictionary<string, string>();

    private void Start()
    {
        startingPosition = transform.localPosition;
        myRenderer = GetComponent<Renderer>();
        SetGazedAt(false);

        infoTitle_dict.Add("Farming", "CLT(Cross Laminated Timber)");
        info_dict.Add("Farming", "Embodied carbon: - 460 Kg/Ton");

        infoTitle_dict.Add("Frame", "BIOCHAR Brick");
        info_dict.Add("Frame", "Embodied carbon: - 900 Kg/Ton");
      
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
        //canvas.SetActive(show);
        print("switch panel");
        panel.SetActive(show);
        string tag = gameObject.transform.parent.tag;

        Texture mat = Resources.Load("Model_Materials/" + tag + "_material") as Texture;
        rawimage.texture = mat;
        //print(info_dict[tag]);
        info.text = info_dict[tag];
        infoTitle.text = infoTitle_dict[tag];
    }
}
