using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class IAPHolder : MonoBehaviour {

    [SerializeField] private List<GameObject> allTextComponents;

    private Text iapButtonName;
    private Text iapName;
    private Text iapDescription;
    private Text iapPrice;
    
    public ScriptableIAP MyIAP;

    private void Awake()
    {
        Invoke("FindText", 0.1f);
    }

    public void FindText()
    {
        foreach (Transform child in transform)
        {
            allTextComponents.Add(child.gameObject);
        }

        foreach (GameObject obj in allTextComponents)
        {
            if (obj.name.Contains("Button"))
            {
                iapButtonName = obj.GetComponentInChildren<Text>();
            }
            else if (obj.name.Contains("Name"))
            {
                iapName = obj.GetComponent<Text>();
            }
            else if (obj.name.Contains("Description"))
            {
                iapDescription = obj.GetComponent<Text>();
            }
            else if (obj.name.Contains("Price"))
            {
                iapPrice = obj.GetComponent<Text>();
            }
            else
            {
                Debug.Log("Could not attach button " + obj.name);
            }
        }

        SetValues();
    }

    public void SetValues()
    {
        print(iapButtonName);
        iapButtonName.text = MyIAP.IAPButtonName;
        iapName.text = MyIAP.IAPName;
        iapDescription.text = MyIAP.IAPDescription;
        iapPrice.text = MyIAP.IAPPrice;

        iapButtonName.gameObject.GetComponentInParent<IAP>().MyID = MyIAP.IAPid; 
    }

}
