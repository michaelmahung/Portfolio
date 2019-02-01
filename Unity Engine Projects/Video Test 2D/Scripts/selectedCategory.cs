using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedCategory : MonoBehaviour {

	public static string catSel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		catSel = gameObject.name;
	}
}
