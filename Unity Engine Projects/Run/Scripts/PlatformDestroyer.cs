using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be used to delete platforms once they can no longer be interacted with

public class PlatformDestroyer : MonoBehaviour {


	public GameObject platformDestructionPoint;
	// Use this for initialization
	void Start () {
		platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");	
		//Here we are assigning our variable to the game object of PlatformDestructionPoint
		//In other words we are filling the empty game object with this variable.
	}
	
	// Update is called once per frame
	void Update () {
		//The next line of code will identify when a platform is outside of the designated x value for the point of destruction
		//Once a platform has been found to be outside of range, it will be destroyed.
		if (transform.position.x < platformDestructionPoint.transform.position.x)
		{
			//Destroy (gameObject); if we constantly create and destroy platforms, i can cause performance issues on a larger scale
			//To avoid this we will instead utilize object pooling - which will make platforms active or inactive and recycle them instead.

			gameObject.SetActive (false); //this code will deactivate the platforms


		}
		
	}
}
//As a whole, when using this line of code in addition to a Prefab, the game will continually spawn and destroy extra platforms and increase performance.