using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class IAPCheck : MonoBehaviour {

    public GameObject purchaseApp;
    public GameObject fillApp;
    public GameObject sendButton;
    public GameObject creditPanel;
    public GameObject resetPanel;
    public Text appText;
    public Text typeText;
    string sendText = "Sending an application may take over a minute, please do not close application.";
    string defaultText = "Fill an electronic application to receive spiritual healing.";
    string purchaseText = "Purchase an application response type to send your application.";
    string purchaseFailed = "Purchase Failed";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VarCheck.Instance.appDone = true;
            VarCheck.Instance.pictureTaken = true;
            FileBasedPrefs.SetBool("App Done", true);
            FileBasedPrefs.SetBool("Picture Taken", true);
            AppCheck();
        }
    }

    void Start ()
    {
        resetPanel.SetActive(false);
        creditPanel.SetActive(false);
        AppCheck();
	}

    public void CreditPanelOpen()
    {
        creditPanel.SetActive(true);
    }

    public void CreditPanelClose()
    {
        creditPanel.SetActive(false);
    }

    public void ResetButton()
    {
        resetPanel.SetActive(true);
    }

    public void NoReset()
    {
        resetPanel.SetActive(false);
    }

    public void ResetCredits()
    {
        VarCheck.Instance.appType = null;
        FileBasedPrefs.DeleteAll();
        VarCheck.Instance.appDone = false;
        VarCheck.Instance.pictureTaken = false;
        AppCheck();
        resetPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    public void AppCheck()
    {
        TypeCheck();

        if (VarCheck.Instance.appDone == true && VarCheck.Instance.pictureTaken == true)
        {
            ButtonCheck();
        }
        else
        {
            FillApp();
            appText.text = defaultText;
        }
    }

    public void ButtonCheck()
    {
        if (String.IsNullOrEmpty(VarCheck.Instance.appType))
        {
            PurchaseApp();
            appText.text = purchaseText;
        }
        else
        {
            SendApp();
            appText.text = sendText;
        }
    }

    public void TypeCheck()
    {
        if (String.IsNullOrEmpty(VarCheck.Instance.appType))
        {
            typeText.text = "Application Type:\nNone";
        }
        else
        {
            typeText.text = "Application Type:\n" + VarCheck.Instance.appType;
        }
    }

    void SendApp()
    {
        sendButton.SetActive(true);
        fillApp.SetActive(false);
        purchaseApp.SetActive(false);
    }

    void FillApp()
    {
        sendButton.SetActive(false);
        fillApp.SetActive(true);
        purchaseApp.SetActive(false);
    }

    void PurchaseApp()
    {
        sendButton.SetActive(false);
        fillApp.SetActive(false);
        purchaseApp.SetActive(true);
    }

    public void BuyApplicationType(string type)
    {
        if (String.IsNullOrEmpty(VarCheck.Instance.appType))
        {
            FileBasedPrefs.SetString("App Type", type);
            VarCheck.Instance.appType = type;
            Invoke("AppCheck", 0.1f);
            Invoke("CreditPanelClose", 0.1f);
        } else
        {
            PurchaseExceeded();
        }
    }

    public void PurchaseExceeded()
    {
        CreditPanelClose();
        Invoke("DefaultText", 2);
    }

    public void PurchaseFail()
    {
        appText.text = purchaseFailed;
        Invoke("CreditPanelClose", 0.1f);
    }

    public void DefaultText()
    {
        appText.text = defaultText;
    }
	
}
