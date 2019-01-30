using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityHolder : MonoBehaviour
{
    public string Name;
    public string Description;
    private Text buttonText;
    private EntityInfoManager infoManager;

    public Entity entity;

	void Start ()
    {
        buttonText = GetComponentInChildren<Text>();
        Name = entity.EntityName;
        Description = entity.EntityDescription;
        buttonText.text = Name;
        infoManager = GetComponentInParent<EntityInfoManager>();
	}

    public void SetMenu()
    {
        infoManager.EnableEntityInfoPanel();
        infoManager.SetEntityInfoPanel(Name, Description);
    }
}
