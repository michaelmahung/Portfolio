using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //We need to add this line of script so unity knows we want edit the UI
//This script will keep track of and display the players score

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond; 

	public bool scoreIncreasing; 

	// The following code will check the game to see if there is a previous highscore set in playerprefs. If so it will recall it and set it as the current highscore, it not it will open playerprefs.
	void Start () {
		//PlayerPrefs.DeleteAll (); //Comment in to reset highscores
		if(PlayerPrefs.HasKey("HighScore"))
		{
			hiScoreCount = PlayerPrefs.GetFloat ("HighScore");
		}
	}
	
	// Update is called once per frame



	void Update () {
		
		if(scoreIncreasing)
		{
			scoreCount += pointsPerSecond * Time.deltaTime; //Time.deltaTime is the time it takes per frame, so here we are multiplying our points per second by how long it takes to update each frame.
		}
		if (scoreCount > hiScoreCount) 
		{
			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
		}

		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);
		
	}

	public void AddScore(int pointsToAdd) //This will work as a universal score keeper, i can use this to reference the amount of points i need per item.
	{
		scoreCount += pointsToAdd;
	}
}
