﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionColor : MonoBehaviour {

    [SerializeField] private Material startMat;
    [SerializeField] private Material endMat;
    Material currentMaterial;
    Renderer myRenderer;

	// Use this for initialization
	void Start () {
        myRenderer = GetComponent<Renderer>();
        currentMaterial = myRenderer.material;
	}
	
    public void SetColor(float lerp)
    {
        currentMaterial.Lerp(startMat, endMat, lerp);
    }
}
