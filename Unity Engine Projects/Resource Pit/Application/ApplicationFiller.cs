using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFiller : MonoBehaviour
{

    //Heres a script im going to use to keep track of what questions have been answered.
    //For this case, we really only need to keep track of the users name.
    //Ideally, what I want this to look like, is that each input field will have a value slapped on it progromatically.
    //The function will check if the number is null, if it is, the question will be flagged as answerered when the input field is edited.
    //If the number isnt null, the function will know not to change the values within filled.

    public void Awake()
    {
        VarCheck.Instance.applicationFilled = false;
    }

    public void BirthFilled()
    {
        VarCheck.Instance.filled[0] = true;
        //Debug.Log(VarCheck.Instance.filled[0]);
    }

    public void CurrentFilled()
    {
        VarCheck.Instance.filled[1] = true;
        VarCheck.Instance.userName = VarCheck.Instance.nameText.text;

        FileBasedPrefs.SetString("User Name", VarCheck.Instance.userName);

        //Debug.Log(VarCheck.Instance.userName);
        //Debug.Log(VarCheck.Instance.filled[1]);
    }

    public void BDateFilled()
    {
        VarCheck.Instance.filled[2] = true;
        //Debug.Log(VarCheck.Instance.filled[2]);
    }

    public void PlaceFilled()
    {
        VarCheck.Instance.filled[3] = true;
        //Debug.Log(VarCheck.Instance.filled[3]);
    }

    public void ContactFilled()
    {
        VarCheck.Instance.filled[4] = true;
        //Debug.Log(VarCheck.Instance.filled[4]);
    }

    public void EmailFilled()
    {
        VarCheck.Instance.filled[5] = true;
        //Debug.Log(VarCheck.Instance.filled[5]);
    }

    public void SignFilled()
    {
        VarCheck.Instance.filled[6] = true;
        //Debug.Log(VarCheck.Instance.filled[6]);
    }

    public void DateFilled()
    {
        VarCheck.Instance.filled[7] = true;
        //Debug.Log(VarCheck.Instance.filled[7]);
    }

#if UNITY_EDITOR
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && (Input.GetKeyDown(KeyCode.P)))
        {
            for (int i = 0; i < VarCheck.Instance.filled.Length; i++)
            {
                VarCheck.Instance.filled[i] = true;
                //Debug.Log(i);
            }
        }
    }
#endif
}
