using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text1 : MonoBehaviour {

	static public BoxCollider2D answer1;

	List<string> firstchoice = new List<string>() {"12","450","Light Kick (LK)","Morrigan","Grand Piano","","Billboard","2","White","Far left of screen","A park"};

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = firstchoice [5];
		answer1 = GetComponent<BoxCollider2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (TextControl.randQuestion > -1 && TextControl.randQuestion < 5) 
		{
			GetComponent<TextMesh> ().text = firstchoice [TextControl.randQuestion];
		}

		if (TextControl.randQuestion == 5)
		{
			GetComponent<TextMesh> ().text = "";
		}

		if (TextControl.randQuestion > 5 && TextControl.randQuestion < 11) 
		{
			GetComponent<TextMesh> ().text = firstchoice [TextControl.randQuestion];
		}

		if (TextControl.randQuestion == 11)
		{
			GetComponent<TextMesh> ().text = "";
		}

	}

	void OnMouseDown()
	{
		Debug.Log ("correct answer is " + TextControl.correctAnswer);
		Debug.Log ("selected answer is " + TextControl.selectedAnswer);
		Debug.Log ("choice selected is " + TextControl.choiceSelected);
		Debug.Log ("total correct are " + TextControl.totalCorrect);
		Debug.Log ("total questions are " + TextControl.totalQuestions);
		Debug.Log ("rand question value is " + TextControl.randQuestion);
		Debug.Log ("object name is " + gameObject.name);
		TextControl.selectedAnswer = gameObject.name;
		TextControl.choiceSelected = "y";
	}
}
