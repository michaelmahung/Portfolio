using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script will be used to decide where the player and platform generator starts, it will also be responsible for handling game death and respawns.
public class GameManager : MonoBehaviour {

	public Transform platformGenerator; //We will use this to decide where the platform generators default start is
	private Vector3 platformStartPoint;

	public PlayerController thePlayer; //Again we are picking where the player will start
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;
	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	public ScrollingBackground theBackground;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position; //When writing this we dont need to specify to grab the transform because it already is one
		playerStartPoint = thePlayer.transform.position; //On the other hand, the player is a player controller so we are getting the transform attached to it

		theScoreManager = FindObjectOfType<ScoreManager>();
		theBackground = FindObjectOfType<ScrollingBackground> ();
		theBackground.Speed = 0.05f;
	}

	// Update is called once per frame
	void Update () {

	}

	public void RestartGame() //We want the game to restart whenever the player touches the net at the bottom of the screen, in order to call this scrips elsewhere, we need to create a new void command
	{

		theScoreManager.scoreIncreasing = false; //Becuase we now have the menu we wont use our old restart code, instead well use this same code but intergrate our new features.
		thePlayer.gameObject.SetActive (false);

		theBackground.Speed = 0f;
		theDeathScreen.gameObject.SetActive (true);
		//StartCoroutine ("RestartGameCo");
	}

	public void Reset()
	{
		
		theDeathScreen.gameObject.SetActive (false);
		platformList = FindObjectsOfType<PlatformDestroyer> (); //This line will find all the active platforms with the PlatformDestroyer script attached to them
		for (int i = 0; i < platformList.Length; i++)
		{
			platformList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
		theBackground.Speed = 0.05f;

	}

	/*public IEnumerator RestartGameCo () //This will execute the sequence below before going back to the "regular" game code. The player will become inactive and after  half a second, will be transported
									//back to the start of the game. They will then become active again.
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		platformList = FindObjectsOfType<PlatformDestroyer> (); //This line will find all the active platforms with the PlatformDestroyer script attached to them
		for (int i = 0; i < platformList.Length; i++) 
		{
			platformList [i].gameObject.SetActive (false);
		}
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
