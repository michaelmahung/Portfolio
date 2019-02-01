using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text2 : MonoBehaviour {

	static public BoxCollider2D answer2;

	List<string> secondchoice = new List<string>() {"11", "420", "Light Punch (LP)", "Leona", "Cello","","Catwalk","3","Red","Middle left of screen","Water"};

		// Use this for initialization
		void Start () {
		GetComponent<TextMesh> ().text = secondchoice [5];
		answer2 = GetComponent<BoxCollider2D> ();
			

		}

		// Update is called once per frame
		void Update () {

		if (TextControl.randQuestion > -1 && TextControl.randQuestion < 5)  
		{
			GetComponent<TextMesh> ().text = secondchoice [TextControl.randQuestion];
		}

		if (TextControl.randQuestion > 4)
		{
			GetComponent<TextMesh> ().text = "";
		}

		if (TextControl.randQuestion > 5 && TextControl.randQuestion < 11) 
		{
			GetComponent<TextMesh> ().text = secondchoice [TextControl.randQuestion];
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
