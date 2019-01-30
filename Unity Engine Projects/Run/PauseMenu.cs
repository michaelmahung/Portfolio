using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This script will be used to add functionality to the pause menu

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;
	private AudioSource pauseSound;
	private AudioSource unpauseSound;
	private AudioSource backgroundMusic;

	void Start()
	{

		pauseSound = GameObject.Find ("PauseSound").GetComponent<AudioSource> ();
		unpauseSound = GameObject.Find ("UnpauseSound").GetComponent<AudioSource> ();
		backgroundMusic = GameObject.Find ("Background Music").GetComponent<AudioSource> ();


	}

	public void PauseGame()
	{
		pauseSound.Play ();
		backgroundMusic.volume = 0.025f;
		Time.timeScale = 0f; //The normal time scale of the game is 1, so setting it to 0 will stop everything
		pauseMenu.SetActive(true);


	}
		
	public void ResumeGame()
	{
		unpauseSound.Play ();
		backgroundMusic.volume = 0.15f;
		Time.timeScale = 1f;
		pauseMenu.SetActive (false);

	}

	public void RestartGame()
		{
		Time.timeScale = 1f;
		backgroundMusic.volume = 0.15f;
		pauseMenu.SetActive (false);
		FindObjectOfType<GameManager> ().Reset ();
		}

	public void QuitToMain()
		{
		Time.timeScale = 1f;
		backgroundMusic.volume = 0.15f;
		SceneManager.LoadScene ("Main Menu");
		}


	}
