﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour 
{
	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 3.5f; //Minimum time of the scene

	private void Start()
	{
		fadeGroup = FindObjectOfType<CanvasGroup> ();

		fadeGroup.alpha = 1;

		//Preload game here

		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time;
	}

	private void Update()
	{
		if (Time.time < minimumLogoTime) 
		{
			fadeGroup.alpha = 1 - Time.time;
		}
		if (Time.time > minimumLogoTime && loadTime != 0) 
		{
			fadeGroup.alpha = Time.time - minimumLogoTime;
			if (fadeGroup.alpha >= 1)
			{
				SceneManager.LoadScene ("Menu Screen");
			}
		}
	}
}
