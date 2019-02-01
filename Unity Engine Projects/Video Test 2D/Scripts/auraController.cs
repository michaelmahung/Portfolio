using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (nextButton.resetAura == "y") 
		{
			GetComponent<ParticleSystem> ().Stop ();
		}


		if (nextButton.resetAura == "n") 
		{
			GetComponent<ParticleSystem> ().Play ();
		}
	}
}
