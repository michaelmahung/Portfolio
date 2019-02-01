using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will pool the platforms so they can be properly recycled

public class NewBehaviourScript : MonoBehaviour {


	public GameObject pooledObject; //We will use this to tell the game what platforms we want pooled

	public int pooledAmount; //This will tell how many of the platforms will be pooled

	List<GameObject> pooledObjects; //This will create a list of objects equal to the interger in the pooled amount


	// Use this for initialization
	void Start () {
		pooledObjects = new List<GameObject> (); //This will create an empty list

		for (int i = 0; i < pooledAmount; i++) //This code will start the value of i at 0 and check to see if that is less than the pooled amount.
		{		//If the value comes back as less than the pooled amount then it will add 1 i.
			GameObject obj = (GameObject)Instantiate (pooledObject); //This will place the platforms
			obj.SetActive (false); //This line of code makes it so that the object will be placed but not active
			pooledObjects.Add (obj); //This will tell the game to add the pooled object to the list, and will change the value of i
		}
	}
}
