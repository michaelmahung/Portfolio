using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityInfoManager : MonoBehaviour {

    public struct RectInfo
    {
        public Vector2 Min;
        public Vector2 Max;
    }

    public GameObject EntityInfoPanel;
    public GameObject EntityCanvasPanel;
    public Text NameText;
    public Text DescriptionText;
    public RectTransform rect;
    private RectInfo startingRect;

	void Start ()
    {
        startingRect.Min = rect.offsetMin;
        startingRect.Max = rect.offsetMax;
        DisableEntityInfoPanel();
	}

    public void SetEntityInfoPanel(string EntityName, string EntityDescription)
    {
        rect.offsetMin = startingRect.Min;
        rect.offsetMax = startingRect.Max;
        NameText.text = EntityName;
        DescriptionText.text = EntityDescription;
    }

    public void DisableEntityInfoPanel()
    {
        EntityCanvasPanel.SetActive(true);
        EntityInfoPanel.SetActive(false);
    }

    public void EnableEntityInfoPanel()
    {
        EntityCanvasPanel.SetActive(false);
        EntityInfoPanel.SetActive(true);
    }
	
}
