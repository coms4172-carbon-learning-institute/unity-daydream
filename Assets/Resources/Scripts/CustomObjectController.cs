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

public class CustomObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    public Material inactiveMaterial;

   
    public Material gazedAtMaterial;

    private Vector3 startingPosition;
    private Renderer myRenderer;

    /// <summary>Sets this instance's GazedAt state.</summary>
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    public void SetGazedAt(bool gazedAt)
    {
        if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }

    /// <summary>Resets this instance and its siblings to their starting positions.</summary>
    public void Reset()
    {
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        for (int i = 0; i < numSibs; i++)
        {
            GameObject sib = transform.parent.GetChild(i).gameObject;
            sib.transform.localPosition = startingPosition;
            sib.SetActive(i == sibIdx);
        }
    }


    private void Start()
    {
        startingPosition = transform.localPosition;
        myRenderer = GetComponent<Renderer>();
        SetGazedAt(false);
    }
}
