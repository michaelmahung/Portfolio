﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIController : MonoBehaviour, IWeaponSwap {

    public bool ShowText;
    public bool GamePaused;
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private Text UIText;
    [SerializeField] private Text ScoreText;
    [SerializeField] AudioMixerGroup MasterGroup;

    private string weaponName;
    private string songName;

	void Start ()
    {
        FindComponents();
        PauseScreen.SetActive(false);
        UpdateUIText();

        GameManager.Instance.PlayerRespawned += UpdateUIText;
        GameManager.Instance.ScoreAdded += UpdateScoreText;
	}

    public void WeaponSwapped()
    {
        weaponName = GameManager.Instance.PlayerObject.GetComponent<PlayerWeapon>().playerWeapon.name;
        UpdateUIText();
    }

    public void UpdateScoreText()
    {
        ScoreText.text = GameManager.Instance.CurrentScore.ToString();
    }

	public void UpdateUIText()
    {
        if (ShowText)
        {
            UIText.fontSize = 30;
            UIText.text = "Left Click to Fire\n";
            UIText.text += "Current weapon: " + weaponName + "\n";
            UIText.text += "Tap 'Shift' to dash.\n";
            UIText.text += "Press '1' to change colors \n";
            UIText.text += "Press '2' to swap weapons\n";
            UIText.text += "Press 'Z' to pause the game.";
        } else
        {
            UIText.text = "";
        }
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PauseGame();
            System.GC.Collect();
        }
    }

    //We have any kind of error when Pausing/Unpausing, we want to make sure we default to an unpaused state
    public void PauseGame()
    {
        try
        {
            if (!GamePaused)
            {
                GamePaused = true;
                PauseScreen.SetActive(true);
                Time.timeScale = 0;
                MasterGroup.audioMixer.SetFloat("CutoffFreq", 400);
            }
            else
            {
                PauseScreen.SetActive(false);
                GamePaused = false;
                Time.timeScale = 1;
                MasterGroup.audioMixer.SetFloat("CutoffFreq", 22000);
            }
        }
        catch
        {
            PauseScreen.SetActive(false);
            GamePaused = false;
            Time.timeScale = 1;
            MasterGroup.audioMixer.SetFloat("CutoffFreq", 22000);
        }

    }

    void FindComponents()
    {
        if (PauseScreen == null)
        {
            PauseScreen = GameObject.Find("PauseScreen");
        }

        if (ScoreText == null)
        {
            ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        if (UIText == null)
        {
            UIText = GameObject.Find("UIText").GetComponent<Text>();
        }
    }
}
