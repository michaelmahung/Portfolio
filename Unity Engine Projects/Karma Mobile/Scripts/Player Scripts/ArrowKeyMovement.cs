using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowKeyMovement : MonoBehaviour {

	public GameObject left;
	public GameObject middle;
	public GameObject right;
	public AudioClip moveSound;
	public AudioClip blockSound;
	public AudioSource moveSoundPlayer;
	public static bool fullScreen;
	public static bool canMove;
	public static bool paused;
	public static float scalingFramesLeft;
	public static Vector3 smallScale;
	public static Vector3 startingScale;
	public static Vector3 blockedScale;
	public static Vector3 currentScale;
	public static Vector3 variableScale;
	public static string l;
	public static string m;
	public static string r;
	public static string l2;
	public static string m2;
	public static string r2;
	public static string lastPosition;
	public float lerpTime = 0;
	public static float currentLerpTime;
	public static bool canPause;
	private bool cheating;



	void Start ()
	{
		cheating = false;
		currentScale = startingScale;
		canPause = true;
		variableScale = startingScale;
		smallScale = new Vector3 (1, 0.5f, 1);
		startingScale = new Vector3 (1, 1, 1);
		blockedScale = new Vector3 (0.85f, 0.85f, 1);
		currentScale = startingScale;
		l = "1";
		m = "2";
		r = "3";
		l2 = "4";
		m2 = "5";
		r2 = "6";
		paused = false;
		moveSoundPlayer = GetComponent<AudioSource> ();
		moveSoundPlayer.volume = 0.08f;
		canMove = true;
		transform.position = middle.transform.position;
	}

	public void ToggleFullscreen ()
	{
		if (Screen.fullScreen) {
			Screen.fullScreen = false;
		}

		if (!Screen.fullScreen) {
			Screen.fullScreen = true;
		}
	}

	public void PauseGame()
	{
		if (paused && canPause) {
			Debug.Log ("Unpausing");
			BGMAudio.bgmAudio.UnPause ();
			canMove = true;
			FallingScript.fallSpeed = FallingScript.regSpeed;
			Time.timeScale = 1;
			paused = false;
		} else {

			if (!paused && canPause) {
				Debug.Log ("Pausing");
				ScreenShaker.shake = 0;
				BGMAudio.bgmAudio.Pause ();
				canMove = false;
				FallingScript.fallSpeed = 0f;
				Time.timeScale = 0;
				paused = true;
			}
		}
	}



	void Update ()
	{

		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}

		float perc = currentLerpTime / lerpTime;
		transform.localScale = currentScale;
		currentScale = Vector3.Lerp (variableScale, startingScale, perc);

		/*if (transform.localScale.x < 1 || transform.localScale.y < 1) 
		{
			currentScale.x = Time.deltaTime;
			currentScale.y = Time.deltaTime;
		}*/

		/*while (scalingFramesLeft > 0) 
		{

			Debug.Log ("Frames to scale " + scalingFramesLeft);
			scalingFramesLeft = scalingFramesLeft - 1;
		}*/


		if (canMove && Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {

			currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (lastPosition == l) {
				moveSoundPlayer.clip = blockSound;
				moveSoundPlayer.Play ();
				variableScale = blockedScale;
				//Debug.Log ("Transform is " + transform.localScale);
				//scalingFramesLeft = 60;
			} else { 
				moveSoundPlayer.clip = moveSound;
				moveSoundPlayer.Play ();
				variableScale = smallScale;
				//Debug.Log ("Transform is " + transform.localScale);
				//scalingFramesLeft = 60;
			}
			if (Spawner.healTime && PlayerHealth.currentHealth < PlayerHealth.startingHealth)
			{
				PlayerHealth.currentHealth += 3;
				if (PlayerHealth.currentHealth < 75 && PlayerHealth.currentHealth > 50) 
				{
					if (levelManager.whiteLevel) {

					} else {
						ScoreManager.currentScore = ScoreManager.currentScore * 0.995f;
					}
				}

				if (PlayerHealth.currentHealth > 75) 
				{
					if (levelManager.whiteLevel) {

					} else {
						ScoreManager.currentScore = ScoreManager.currentScore * 0.985f;
					}
				}
				//ScoreManager.pointLoss = ScoreManager.originalScore - ScoreManager.currentScore;
			}
				
			canMove = true;
			PlayerHealth.tailgating = false;
			PlayerHealth.murderTrail = false;
			transform.position = left.transform.position;
			lastPosition = l;



		}

		if (canMove && Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {

			currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (lastPosition == r) {
				moveSoundPlayer.clip = blockSound;
				moveSoundPlayer.Play ();
				variableScale = blockedScale;
				//scalingFramesLeft = 10;
			} else { 
				moveSoundPlayer.clip = moveSound;
				moveSoundPlayer.Play ();
				variableScale = smallScale;
				//scalingFramesLeft = 10;
			}

			if (Spawner.healTime && PlayerHealth.currentHealth < PlayerHealth.startingHealth)
			{
				PlayerHealth.currentHealth += 3;
				if (PlayerHealth.currentHealth < 75 && PlayerHealth.currentHealth > 50) 
				{
					if (levelManager.whiteLevel) {

					} else {
						ScoreManager.currentScore = ScoreManager.currentScore * 0.995f;
					}
				}

				if (PlayerHealth.currentHealth > 75) 
				{
					if (levelManager.whiteLevel) {

					} else {
						ScoreManager.currentScore = ScoreManager.currentScore * 0.985f;
					}
				}
				//ScoreManager.pointLoss = ScoreManager.originalScore - ScoreManager.currentScore;
			}

			canMove = true;
			PlayerHealth.tailgating = false;
			PlayerHealth.murderTrail = false;
			transform.position = right.transform.position;
			lastPosition = r;


		}

		if (canMove && Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {

			currentLerpTime = 0;
			ImpactManager.currentFrameTime = 0;

			if (lastPosition == m) {
				moveSoundPlayer.clip = blockSound;
				moveSoundPlayer.Play ();
				variableScale = blockedScale;
				//scalingFramesLeft = 10;
			} else { 
				moveSoundPlayer.clip = moveSound;
				moveSoundPlayer.Play ();
				variableScale = smallScale;
				//scalingFramesLeft = 10;
			}

			if (Spawner.healTime && PlayerHealth.currentHealth < PlayerHealth.startingHealth)
			{
				PlayerHealth.currentHealth += 3;
				if (PlayerHealth.currentHealth < 75 && PlayerHealth.currentHealth > 50) 
				{
					if (levelManager.whiteLevel) {

					} else {
						ScoreManager.currentScore = ScoreManager.currentScore * 0.995f;
					}
				}

				if (PlayerHealth.currentHealth > 75) 
				{
					if (levelManager.whiteLevel) {

					} else {
						ScoreManager.currentScore = ScoreManager.currentScore * 0.985f;
					}
				}
				//ScoreManager.pointLoss = ScoreManager.originalScore - ScoreManager.currentScore;
			}

			PlayerHealth.tailgating = false;
			PlayerHealth.murderTrail = false;
			transform.position = middle.transform.position;
			lastPosition = m;


		}
			
		if (Input.GetKeyDown (KeyCode.Delete)) {
			PlayerHealth.currentHealth = 0;
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			PauseGame ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (levelManager.greyLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 50f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

			if (levelManager.blueLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 75f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

			if (levelManager.greenLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 300f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

			if (levelManager.purpleLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 800f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

			if (levelManager.violetLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 1500f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

			if (levelManager.pinkLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 2000f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

			if (levelManager.goldLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 10000f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

			if (levelManager.whiteLevel) {
				ScoreManager.currentScore = ScoreManager.currentScore + 20000f;
				/*if (ScoreManager.currentScore >= levelManager.endScore) {
					ScoreManager.currentScore = levelManager.endScore;
				}*/
			}

		}


		if (Input.GetKeyDown (KeyCode.F)) {
			ToggleFullscreen ();
		}

		if (Input.GetKeyDown (KeyCode.G)) 
		{
			if (PlayerHealth.playerCol.enabled == false) {
				PlayerHealth.playerCol.enabled = true;
			} else 
			{
				if (PlayerHealth.playerCol.enabled == true) 
				{
					PlayerHealth.playerCol.enabled = false;
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) 
		{
			
			if (!PlayerHealth.isDead && levelManager.currentLevel == 1 && !cheating)
			{ 
				cheating = true;
				levelManager.currentLevel = 2;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}

			if (!PlayerHealth.isDead && levelManager.currentLevel == 2 && !cheating)
			{ 
				cheating = true;
				levelManager.currentLevel = 3;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}

			if (!PlayerHealth.isDead && levelManager.currentLevel == 3 && !cheating)
			{
				cheating = true;
				levelManager.currentLevel = 4;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}

			if (!PlayerHealth.isDead && levelManager.currentLevel == 4 && !cheating)
			{
				cheating = true;
				levelManager.currentLevel = 5;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}

			if (!PlayerHealth.isDead && levelManager.currentLevel == 5 && !cheating)
			{
				cheating = true;
				levelManager.currentLevel = 6;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}

			if (!PlayerHealth.isDead && levelManager.currentLevel == 6 && !cheating)
			{ 
				cheating = true;
				levelManager.currentLevel = 7;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}

			if (!PlayerHealth.isDead && levelManager.currentLevel == 7 && !cheating)
			{
				cheating = true;
				levelManager.currentLevel = 8;
				FileBasedPrefs.SetFloat ("Current Level", levelManager.currentLevel);
				SceneManager.LoadScene ("Game");
			}


		}
			
	}

	
}
