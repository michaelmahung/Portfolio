using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be used to allow the camera to follow the player strictly on the X-Axis

public class CameraController : MonoBehaviour {
	
	//Because we created the PlayerController script and assigned it to the player model,
	//We can access that through the script and attach the camera to it.
	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition; //Even though its a 2D game, the player still has a Z value and therefore must be found with a Vector3
	private float distanceToMove;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();	//This allows the game to understand which object to attach to the camera.
	}
	
	// Update is called once per frame
	void Update () {


		//What this next line of code will do is look at the current x value of the player and subtract it by the players position on the last frame
		//We can now use distanceToMove in the next line of code
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;


		//Because we know this script is attached to the camera, there is no need to specify what transform we are referring to
		//Again we use Vector3 because the x,y and z values are all tracked regardless of it being 2D
		//Now the camera will know how far it needs to move while moving along the x axis without it following the player when jumping or falling.
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		 
		lastPlayerPosition = thePlayer.transform.position;
		//We need to write a line of code that will make the camera follow the position of the player.
	}
}
