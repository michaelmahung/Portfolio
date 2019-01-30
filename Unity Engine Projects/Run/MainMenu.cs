using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Activating this will allow us to switch scenes
//This script will be used to assign functions to the buttons on the main menu screen
public class MainMenu : MonoBehaviour {

	public string playGameLevel;

	public void PlayGame()
	{
		SceneManager.LoadScene ("Endless");
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

}
