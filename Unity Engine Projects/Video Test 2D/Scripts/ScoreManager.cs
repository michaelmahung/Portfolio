using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text totalScoreText;
	public static int totalScore;

	void Start ()
	{
		//PlayerPrefs.DeleteAll();
		Debug.Log ("Total Score is: " + totalScore);
		if (PlayerPrefs.HasKey ("Score"))
		{
			totalScore = PlayerPrefs.GetInt ("Score");
		}
		totalScoreText.text = "Total Score is " + PlayerPrefs.GetInt ("Score", totalScore).ToString();
	}
	void Update ()
	{
		totalScoreText.text = "Total Score is: " + PlayerPrefs.GetInt("Score", totalScore).ToString();
		PlayerPrefs.SetInt ("Score", totalScore);

		if (TextControl.totalCorrect > 0) 
		{
			totalScore = totalScore += TextControl.points;
			Debug.Log ("Total Score is: " + totalScore);
			PlayerPrefs.SetInt ("Score", totalScore);
			TextControl.totalCorrect = 0;
		}


	}

}
