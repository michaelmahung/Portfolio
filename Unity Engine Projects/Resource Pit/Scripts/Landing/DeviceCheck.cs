using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceCheck : MonoBehaviour {

	public Text deviceText;

	void Start () 
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			deviceText.text = "Android";
            deviceText.text += " Build " + Application.version;
		} else if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			deviceText.text = "iPhone";
            deviceText.text += " Build " + Application.version;
        } else if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
		{
			deviceText.text = "OSX";
            deviceText.text += " Build " + Application.version;
        } else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			deviceText.text = "Windows";
            deviceText.text += " Build " + Application.version;
        }
		
	}

}
