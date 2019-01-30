using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {

	public Transform colorPanel;
	public Transform itemPanel;

	private Vector3 desiredMenuPosition;

	private void Start()
	{
		InitShop ();
	}

	private void InitShop()
	{
		if (colorPanel == null || itemPanel == null)
			Debug.Log ("You did not assign the color/item panel in the inspector");

		int i = 0;
		foreach(Transform t in colorPanel)
		{
			int currentIndex = i;
			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => OnColorSelect (currentIndex));

			i++;
		}

		i = 0;

		foreach(Transform t in itemPanel)
		{
			int currentIndex = i;
			Button b = t.GetComponent<Button> ();
			b.onClick.AddListener (() => OnItemSelect (currentIndex));

			i++;
		}
	}

	//public void OnPlayClick ();
	//public void OnShopClick ();
	public void OnColorBuy()
	{
		Debug.Log("Buy/Set Color");
	}

	public void OnItemBuy ()
	{
		Debug.Log("Buy Item");
	}

	private void OnColorSelect(int currentIndex)
	{
		Debug.Log("Selecting color button : " + currentIndex);
	}

	private void OnItemSelect(int currentIndex)
	{
		Debug.Log("Selecting item button : " + currentIndex);
	}
		

}
