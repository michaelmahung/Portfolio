using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController: MonoBehaviour {

    //Keep these public so they can be set from the editor.
    //If all goes as plans with the PhoneCamera script, image preview will n longer be necessary.
    public GameObject savePanel;
    public GameObject menuPanel;
    public GameObject surveyPanel;
    //public GameObject imagePreview;
	public GameObject camImage;


    void Start ()
    {
        //Set the base menus as deactive and hardcode all answers as unanswered.
        //imagePreview.SetActive(false);
        menuPanel.SetActive(false);
        surveyPanel.SetActive(false);
        savePanel.SetActive(false);
		camImage.SetActive(false);
    }


    //The following methods simply change the active menus.
    public void Allowed ()
    {
        //imagePreview.SetActive(true);
        menuPanel.SetActive(true);
        surveyPanel.SetActive(false);
        savePanel.SetActive(false);
		camImage.SetActive(true);
    }

    public void Save ()
    {
        savePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void Menu ()
    {
       menuPanel.SetActive(true);
       savePanel.SetActive(false);
    }

    public void OpenSurvey ()
    {
        surveyPanel.SetActive(true);
        menuPanel.SetActive(false);
        savePanel.SetActive(false);
        //imagePreview.SetActive(false);
		camImage.SetActive(false);
        VarCheck.Instance.LandscapeOnly();
    }
}
