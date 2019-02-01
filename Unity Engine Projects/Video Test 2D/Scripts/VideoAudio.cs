using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoAudio : MonoBehaviour {



	//Raw Image to Show Video Images [Assign from the Editor]
	public RawImage image;
	//Video To Play [Assign from the Editor]
	public VideoClip videoToPlay;

	private VideoPlayer videoPlayer;
	private VideoSource videoSource;

	//Audio
	private AudioSource audioSource;

	private GameObject VideoCube;

	private GameObject[] tagged;

	private GameObject BlackScreen;

	// Use this for initialization
	void Start()
	{
		VideoCube = GameObject.Find ("Video Player");
		Application.runInBackground = true;
		BlackScreen = GameObject.Find ("Black Screen");
		StartCoroutine(playVideo());
	}

	IEnumerator playVideo ()
	{
		//Add VideoPlayer to the GameObject
		videoPlayer = gameObject.AddComponent<VideoPlayer> ();

		//Add AudioSource
		audioSource = gameObject.AddComponent<AudioSource> ();

		//Disable Play on Awake for both Video and Audio
		videoPlayer.playOnAwake = true;
		audioSource.playOnAwake = true;

		//We want to play from video clip not from url
		videoPlayer.source = VideoSource.VideoClip;

		//Set Audio Output to AudioSource
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		//Assign the Audio from Video to AudioSource to be played
		videoPlayer.EnableAudioTrack (0, true);
		videoPlayer.SetTargetAudioSource (0, audioSource);

		//Set video To Play then prepare Audio to prevent Buffering
		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare ();

		//Wait until video is prepared
		while (!videoPlayer.isPrepared)
		{
			Debug.Log ("Preparing Video");
			yield return null;
		}

		Debug.Log ("Done Preparing Video");

		//Assign the Texture from Video to RawImage to be displayed
		image.texture = videoPlayer.texture;

		//Play Video
		videoPlayer.Play ();

		//Play Sound
		audioSource.Play ();

	

		Debug.Log ("Playing Video");
		while (videoPlayer.isPlaying) {
			Debug.LogWarning ("Video Time: " + Mathf.FloorToInt ((float)videoPlayer.time));
		}

		BlackScreen.SetActive (false);
		VideoCube.SetActive (true);
			
		yield return new WaitForSeconds (2.0f);

		videoPlayer.Stop ();
		audioSource.Stop ();
		BlackScreen.SetActive (true);
		VideoCube.SetActive (false);


	}
}
		



			



		
