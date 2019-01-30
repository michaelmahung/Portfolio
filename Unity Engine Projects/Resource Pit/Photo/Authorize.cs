using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/* This is a simple class that will ask the user if they want to allow the camera to turn on.
 * This, in conjuncture with the privacy policy and Camera Usage Description in player settings
 * is how I was able to get this app available on both the app store and the google play store.*/


public class Authorize : MonoBehaviour
{

    public GameObject blockPanel;

    private void Awake()
    {
		Application.targetFrameRate = 60;
        //Turn on the panel that prevents app interaction then request authorization.
        VarCheck.Instance.LandscapeOnly();
        blockPanel.SetActive(true);
        Application.RequestUserAuthorization(UserAuthorization.WebCam);
    }

    public void Allow()
    {
        //If the user authorizes webcam usage, turn off the panel.
        VarCheck.Instance.AutoRotate();
        blockPanel.SetActive(false);
        Application.HasUserAuthorization(UserAuthorization.WebCam);
    }

    public void Deny()
    {
        //If the user does not accept webcam usage, close the application.

        Application.Quit();
    }



}
