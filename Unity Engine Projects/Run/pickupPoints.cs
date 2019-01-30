using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is going to give value to the coins collected and add the score to the game

public class pickupPoints : MonoBehaviour {


	public int scoreToGive;

	private ScoreManager theScoreManager;

	private AudioSource coinSound;


	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();

		coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) //This will check when something else collides with the object assigned and execute an action.
	{ //Here we are telling it that if the player collides with the coin, add the value of the coin to the score.
		if (other.gameObject.name == "Player") 
		{ 
			theScoreManager.AddScore (scoreToGive);
			gameObject.SetActive (false);

			if (coinSound.isPlaying) {
				coinSound.Stop ();
				coinSound.Play ();
			} else {
				coinSound.Play ();
			}


		}
	}
}
