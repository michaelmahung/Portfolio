using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	public string NextScreen; 
	public GameObject VGHolder;
	public GameObject CatHolder;


	public void CategoryMenu ()
	{
		CatHolder.SetActive (true);
		VGHolder.SetActive (false);
	}

	public void VGMenu()
	{
		VGHolder.SetActive (true);
		CatHolder.SetActive (false);
	}

	public void QAKof()
	{
		TextControl.totalQuestions = 0;
		TextControl.totalCorrect = 0;
		SceneManager.LoadScene ("Q&A Kof");
	}

	public void ReplayKoF()
	{
		SceneManager.LoadScene ("Kof Video");
	}

	public void Kof()
	{
		SceneManager.LoadScene ("Kof Video");
	}

	public void QuitApp()
	{
		Application.Quit();
	}
		
	public void MainMenu()
	{
		SceneManager.LoadScene ("Menu Screen");
	}

	public void MirrorsEdge()
	{
		SceneManager.LoadScene ("Mirrors Edge Video");
	}

	public void ReplayMirrorsEdge()
	{
		
		SceneManager.LoadScene ("Mirrors Edge Video");
	}

	public void QAMirrorsEdge ()
	{
		TextControl.totalQuestions = 0;
		TextControl.totalCorrect = 0;
		SceneManager.LoadScene ("Q&A Mirrors Edge");
	}

}
