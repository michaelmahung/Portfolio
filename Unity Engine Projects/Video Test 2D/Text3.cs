using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3 : MonoBehaviour {

	static public BoxCollider2D answer3;

	List<string> thirdchoice = new List<string>() {"13","440", "Heavy Kick (HK)", "Athena", "Harp","","Railing","4","Yellow","Middle right of screen","A festival"};

		// Use this for initialization
		void Start () {
			GetComponent<TextMesh> ().text = thirdchoice [5];
			answer3 = GetComponent<BoxCollider2D> ();

		}

		// Update is called once per frame
		void Update () {

		if (TextControl.randQuestion > -1 && TextControl.randQuestion < 5)  
		{
			GetComponent<TextMesh> ().text = thirdchoice [TextControl.randQuestion];
		}

		if (TextControl.randQuestion > 4)
		{
			GetComponent<TextMesh> ().text = "";
		}

		if (TextControl.randQuestion > 5 && TextControl.randQuestion < 11) 
		{
			GetComponent<TextMesh> ().text = thirdchoice [TextControl.randQuestion];
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
