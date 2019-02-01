using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextButton : MonoBehaviour {

	public GameObject NextButton;
	public static string resetAura = "n";
	public int questionCounter;



	// Use this for initialization
	void Start () {


		NextButton = GameObject.Find ("Next Button");
		//NextButton.SetActive (false);
	}


	
	// Update is called once per frame
	void Update ()
	{

		if(TextControl.choiceSelected == "y")

		{
			Text1.answer1.enabled = false;
			Text2.answer2.enabled = false;
			Text3.answer3.enabled = false;
			Text4.answer4.enabled = false;
			NextButton.SetActive (true);
		}

		if(TextControl.choiceSelected == "n")

		{
			Text1.answer1.enabled = false;
			Text2.answer2.enabled = false;
			Text3.answer3.enabled = false;
			Text4.answer4.enabled = false;
			NextButton.SetActive (true);
		}

	}

	public void Deactivate()
	{
		NextButton.SetActive (false);
		resetAura = "y";
		TextControl.randQuestion += 1;
		Text1.answer1.enabled = true;
		Text2.answer2.enabled = true;
		Text3.answer3.enabled = true;
		Text4.answer4.enabled = true;
		//TextControl.resultObj.TextMesh.text = "Answer";
	}
	
}
