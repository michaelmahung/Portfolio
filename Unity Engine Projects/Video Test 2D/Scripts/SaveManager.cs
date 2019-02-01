using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour 
{
	public static SaveManager Instance { set; get; }
	//public SaveState state;

	private void Awake ()
	{
		Instance = this;
	}

	public void Save()
	{
		//PlayerPrefs.SetString("save",);
	}

}
