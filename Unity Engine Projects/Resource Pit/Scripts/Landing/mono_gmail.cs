using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class mono_gmail : MonoBehaviour
{
    public Text sendText;
    public GameObject checker;
    IAPCheck check;
    bool sending;
    Image sendImage;
    Color hidden = new Color(1, 1, 1, 0);
    Color transparent = new Color(1, 1, 1, 0.45f);
    Color black = new Color(0, 0, 0, 0.45f);



    //Adding to send
    public void sendCheck()
    {
        check = checker.GetComponent<IAPCheck>();
        sendImage = this.gameObject.GetComponent<Image>();
        sendImage.color = transparent;
        CheckConnection();
        return;
    }


    //If all the questions have been answered, we next check if th user is connected to the internet. 
    //If not, we grey out the button and tell the user there is no internet connection.
    public void CheckConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //Debug.Log("No Internet Connection!");
            sendImage.color = black;
            sendText.text = "No Internet Connection Detected";
            return;
        }

        if (!sending)
        {
            sending = true;
            sendImage.color = transparent;
            sendAll();
            return;
        }
        else
        {
            //Debug.Log("Already Sending!");
            return;
        }

    }


    //If all the questions have been answered, and there is internet connectivity, we continue on.
    //We will check to make sure that credits are available for the information being sent.
    //We will use a bool to ensure the user does not send the data multiple times and change the text to sending.
    //Using the constructor, we will then call the sendMail function from the mono script.

    public void sendAll()
    {
        //Debug.Log("Attempting to send application type: " + VarCheck.Instance.appType);
        if (!String.IsNullOrEmpty(VarCheck.Instance.appType))
        {
            sendText.text = "Preparing to send data.";
            VarCheck.Instance.SetMail();
            /*Debug.Log(VarCheck.Instance.emailBody);
            Debug.Log(VarCheck.Instance.emailSubject);
            Debug.Log("Sending Answers.");*/
            DeletePrefs();
            return;
        }
        else
        {
            sendImage.color = Color.red;
            sendText.text = "Invalid Application Type Selected.";
            Invoke("TextReset", 3.5f);
            //Debug.Log("Not Enough Credits!");
            return;
        }

    }

    void DeletePrefs()
    {
        //Debug.Log("Deleting Old Prefs.");
        sendText.text = "Cleaning up files...";
        FileBasedPrefs.DeleteAll();
        //Debug.Log("Prefs Deleted");
        sendText.text = "Sending data may take over a minute, please do not close application.";
        SendMail();
        return;
    }

    //After the mail has been sent, we will come back here and close the application.
    //After the information is sent, we want to deduct the credit bought earlier.
    void Sent()
    {
        //Debug.Log("Mail Sent!");
        sendText.text = "Sent!";
        VarCheck.Instance.appType = null;
        VarCheck.Instance.appDone = false;
        VarCheck.Instance.pictureTaken = false;
        sendImage.color = hidden;
        check.AppCheck();
        sending = false;
        Invoke("TextReset", 3.5f);
        return;
    }



    void TextReset()
    {
        sendText.text = "Fill an electronic application to receive spiritual healing.";
        return;
    }

    void Close()
    {
        //Debug.Log("Closed");
        Application.Quit();
        return;
    }

    public void SendMail()
	{
        if (!Application.isEditor)
        {
            MailMessage mail = new MailMessage();

            Attachment picture = new Attachment(Path.Combine(VarCheck.Instance.filePath, VarCheck.Instance.pictureName));
            Attachment contract = new Attachment(Path.Combine(VarCheck.Instance.appPath, VarCheck.Instance.contractName));

            mail.From = new MailAddress(VarCheck.Instance.FromEmail);

            mail.To.Add(VarCheck.Instance.FromEmail);

            mail.Subject = VarCheck.Instance.emailSubject;

            mail.Body = VarCheck.Instance.emailBody;

            mail.IsBodyHtml = false;

            mail.Attachments.Add(contract);

            mail.Attachments.Add(picture);

            contract.Name = VarCheck.Instance.userName + " application.png";

            picture.Name = VarCheck.Instance.userName + " picture.png";

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            smtpServer.Port = 587;

            smtpServer.Credentials = new System.Net.NetworkCredential(VarCheck.Instance.FromEmail, VarCheck.Instance.Password) as ICredentialsByHost;

            smtpServer.EnableSsl = true;

            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

            smtpServer.Send(mail);
        }

        Sent();
        return;
    }
    
}