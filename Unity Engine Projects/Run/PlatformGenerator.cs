using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be used to create infinitely generating game platforms ahead of the view of the camera.

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform; //This will be used to decide what platforms are going to be created
	public Transform generationPoint; //This defines how far out we will generate the platforms
	public float distanceBetween; //This will be used to define the amount of space between each generated platform

	private float platformWidth; //This will be used to decide the length/width of newly generated playforms


	//In order to add more variety to the game we will change the spawn distance between each platform
	//We will use these new variables to insert random values for each spawn within a certain range
	public float distanceBetweemMin;
	public float distanceBetweenMax;

	//public GameObject[] thePlatforms;
	private int platformSelector;
	private float[] platformWidths;

	public ObjectPooler[] theObjectPools; //This is necessary to call the pooled platforms from the objectpooler script.

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold; //We want to make the coins generate randomly on platforms, we will use this to do that. 

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths [i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//We need to add a line of code that will prevent the platforms from spawning on top of each other, to do this we can use an if/ then statement. 
		//Here we are checking if the position of our current transform position is less than our generation point.
		//After we check this we tell our game to instantiate/copy a new platform at the assigned position and rotation.

		if (transform.position.x < generationPoint.position.x)
		{
			distanceBetween = Random.Range (distanceBetweemMin, distanceBetweenMax);
			//This tells the game to pick a random number between the two set values to be set in the platformgenerator 

			platformSelector = Random.Range (0, theObjectPools.Length);

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) 
			{
				heightChange = minHeight;
			}

			//Instantiate (/*thePlatform,*/ theObjectPools[platformSelector], transform.position, transform.rotation);

			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject(); //This says to get an object from the pooled object list.

			newPlatform.transform.position = transform.position; //This will set the transform properly
			newPlatform.transform.rotation = transform.rotation; //This will set the rotation properly
			newPlatform.SetActive (true); //This will have an activated platform be placed instead of the deactived ones from before */

			if (Random.Range (0f, 100f) < randomCoinThreshold) //This will roll and if the number is greater than a set value, it will generate coins on the platform.
			{
				theCoinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

		}
		
	}
}

//However, because we are endlessly generating platforms, they will eventually clog the game with unused platforms.
//To remedy this we can create a code to destroy platforms once we have gone far enough away to no longer use them
