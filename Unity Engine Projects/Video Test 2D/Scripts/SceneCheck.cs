using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheck : MonoBehaviour {

	public Scene scene;

	void Start (){

		scene = SceneManager.GetActiveScene();
		Debug.Log (scene.name);

		DontDestroyOnLoad(this.gameObject);

		if (scene.name == "Q&A Mirrors Edge")
		{
			TextControl.randQuestion = 6;
		}

		if (scene.name == "Q&A Kof")
		{
			TextControl.randQuestion = 0;
		}

	}

}