using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text4 : MonoBehaviour {

	static public BoxCollider2D answer4;

	List<string> fourthchoice = new List<string>() {"14","430","Heavy Punch (HP)", "Ivy", "Guitar","","Stairs","5","No Glove","Far right of screen","The sun"};

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh> ().text = fourthchoice [5];
		answer4 = GetComponent<BoxCollider2D> ();

	}

	// Update is called once per frame
	void Update () {

		if (TextControl.randQuestion > -1 && TextControl.randQuestion < 5)  
		{
			GetComponent<TextMesh> ().text = fourthchoice [TextControl.randQuestion];
		}

		if (TextControl.randQuestion > 4)
		{
			GetComponent<TextMesh> ().text = "";
		}

		if (TextControl.randQuestion > 5 && TextControl.randQuestion < 11) 
		{
			GetComponent<TextMesh> ().text = fourthchoice [TextControl.randQuestion];
		}

		if (TextControl.randQuestion == 11)
		{
			GetComponent<TextMesh> ().text = "";
		}

	

	}
	void OnMouseDown()
	{
		Debug.Log (TextControl.choiceSelected);
		Debug.Log (TextControl.totalCorrect);
		Debug.Log (TextControl.totalQuestions);
		Debug.Log (TextControl.randQuestion);
		Debug.Log (gameObject.name);
		TextControl.selectedAnswer = gameObject.name;
		TextControl.choiceSelected = "y";

	}
}
