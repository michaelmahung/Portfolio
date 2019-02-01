using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameObject))]
public class ButtonAccept : MonoBehaviour {

    GameObject accept;
    Text acceptText;
    string testText = "Ready to Save";
    string defaultText = "Accept and Take Picture";
    string answerText = "Please Answer all Fields";
    string connectedText = "No Internet Connection";

	void Start ()
    {
        accept = this.gameObject;
        acceptText = accept.GetComponentInChildren<Text>();
	}

    //When pressing the button, first check if all of the fields have been filled. If any of them havent been, stop there.
    //If all of the fields have been filled, check for internet connectivity.

    public void Accept()
    {
        for (int i = 0; i < VarCheck.Instance.filled.Length; i ++)
        {
            if (!VarCheck.Instance.filled[i])
            {
                acceptText.text = answerText;
                Invoke("Default", 3);
				//Debug.Log("Missing Field " + i);
                return;
            }
        }

        VarCheck.Instance.applicationFilled = true;
        acceptText.text = testText;
    }

    void CheckConnection()
    {
        //Check if there is a connection to the internet, if there isnt one, stop there.
        //If a connection is found, flag the application as filled so the applicatoin saver can run it own function.

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            acceptText.text = connectedText;
            Invoke("Default", 3);
            return;
        }

        VarCheck.Instance.applicationFilled = true;
        acceptText.text = testText;
    }

    void Default()
    {
        acceptText.text = defaultText;
    }

}
