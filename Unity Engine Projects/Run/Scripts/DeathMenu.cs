using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This script will be used to allow the player to restart the game or go to the main menu after death

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame()
	{
		FindObjectOfType<GameManager> ().Reset ();
	}

	public void QuitToMain()
	{
		SceneManager.LoadScene ("Main Menu");
	}


}
