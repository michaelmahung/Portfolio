using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextControl : MonoBehaviour {

	public static List<string> questions = new List<string>() {"How many hits were in the combo?","How much damage was dealt?", "What is the last button pressed?", "What character is being played?", "What instrument is in the background?","",
	"What object is jumped off of near the beginning of the video?","While in the air, how many cars pass below?","What color is the players left glove?","After getting off the crane, where is the orange tower?","What can be seen in the distance while jumping?"};

	public static List<string> correctAnswer = new List<string> () { "3", "4", "2", "3", "1", "", "1", "3", "4", "2", "2"};

	public Transform resultObj;

	public static string selectedAnswer;

	public static string choiceSelected ="n";

	public static int randQuestion; 

	public Transform auraObj;

	public static int points;
	public static int totalCorrect = 0;
	public static int totalQuestions = 0;
	public Transform scoreObj;
	public float scorePer;
	public GameObject quitButton;
	public GameObject videoButton;
	public GameObject menuButton;
	public GameObject NextButton;
	public GameObject Questions;

	void Start () {

		Questions = GameObject.Find ("questionText");
		NextButton = GameObject.Find ("Next Button");
		menuButton = GameObject.Find ("Menu Button");
		quitButton = GameObject.Find ("Quit Button");
		videoButton = GameObject.Find ("Video Button");
		quitButton.SetActive (false);
		videoButton.SetActive (false);
		menuButton.SetActive (false);
		NextButton.SetActive (false);
		Questions.SetActive (true);
	}
		
	
	// Update is called once per frame
	void Update () {

		if (randQuestion == -1) 
		{
			randQuestion = (0);
		}
		if (randQuestion > -1 && randQuestion <5) 
		{
			GetComponent<TextMesh> ().text = questions [randQuestion];
		}

		if (randQuestion > 5 && randQuestion <11) 
		{
			GetComponent<TextMesh> ().text = questions [randQuestion];
		}


		if (!NextButton.activeSelf)
		{
			resultObj.GetComponent<TextMesh> ().text = "";
		}



		if (totalQuestions > 0) 
		{
			scoreObj.GetComponent<TextMesh> ().text = "Points : " + totalCorrect*10;
		}



		if (randQuestion  == 5 || randQuestion == 11)
		{
			quitButton.SetActive (true);
			videoButton.SetActive (true);
			menuButton.SetActive (true);
			Questions.SetActive (false);

			if (totalCorrect == 0) 
			{
				resultObj.GetComponent<TextMesh> ().text = "Better luck next time?";
				points = 0;
			}

			if (totalCorrect == 1) 
			{
				resultObj.GetComponent<TextMesh> ().text = "You earned 10 points!";
				points = 10;
			}

			if (totalCorrect == 2) 
			{
				resultObj.GetComponent<TextMesh> ().text = "You earned 20 points!";
				points = 20;
			}

			if (totalCorrect == 3) 
			{
				resultObj.GetComponent<TextMesh> ().text = "You earned 30 points!";
				points = 30;
			}

			if (totalCorrect == 4) 
			{
				resultObj.GetComponent<TextMesh> ().text = "You earned 40 points!";
				points = 40;
			}

			if (totalCorrect == 5) 
			{
				resultObj.GetComponent<TextMesh> ().text = "You earned 50 points!";
				points = 50;
			}


		}
			

		
		if (choiceSelected == "y") 
		{
			NextButton.SetActive (true);
			choiceSelected = "n";
			totalQuestions += 1;

			if (correctAnswer [randQuestion] == selectedAnswer) 
			{
				resultObj.GetComponent<TextMesh> ().text = "Correct!";
				totalCorrect += 1;

			} else {
				NextButton.SetActive (true);
				nextButton.resetAura = "n";
				resultObj.GetComponent<TextMesh> ().text = "Incorrect!";
				if (correctAnswer [randQuestion] == "1") {
					auraObj.GetComponent<Transform> ().position = new Vector3 (-7.00f, 1.70f, 0);
				}

				resultObj.GetComponent<TextMesh> ().text = "Incorrect!";
				if (correctAnswer [randQuestion] == "2") {
					auraObj.GetComponent<Transform> ().position = new Vector3 (-7.00f, -0.30f, 0);
				}

				resultObj.GetComponent<TextMesh> ().text = "Incorrect!";
				if (correctAnswer [randQuestion] == "3") {
					auraObj.GetComponent<Transform> ().position = new Vector3 (-7.00f, -2.30f, 0);
				}

				resultObj.GetComponent<TextMesh> ().text = "Incorrect!";
				if (correctAnswer [randQuestion] == "4") {
					auraObj.GetComponent<Transform> ().position = new Vector3 (-7.00f, -4.30f, 0);
				}

			}
		}
	}

			


}
	