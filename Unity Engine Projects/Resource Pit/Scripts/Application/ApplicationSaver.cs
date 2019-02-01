using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

//Make sure this is attached to a camera.
[RequireComponent(typeof(Camera))]
public class ApplicationSaver : MonoBehaviour {

    Camera mainCam;
    public GameObject DeclineButton;
    public GameObject AcceptButton;
    public GameObject blockPanel;
    public MonoBehaviour camZoom;
    public RectTransform ApplicationRect;
    public ScrollRect ScrollRect;

    private void Awake()
	{
        VarCheck.Instance.SceneCheck(SceneManager.GetActiveScene().name);

        //We need a scenamanager because we're going to load the old camera scene once were done with the application.
        //We set the camera to a fixed location and change the field of view so all phone sizes can see the entire with of the application.
        blockPanel.SetActive(false);
        mainCam = GetComponent<Camera>();
        mainCam.transform.localPosition = new Vector3(0, 200, -20f);
        mainCam.transform.localEulerAngles = new Vector3(0, 0, 0);
        mainCam.fieldOfView = 168;
        //Debug.Log(ApplicationRect.offsetMax + " " + ApplicationRect.offsetMin);
	}

    public void ConfirmApplication()
    {
        if (VarCheck.Instance.applicationFilled)
        {
            //Heres how im going to hack my way through an issue.
            //When the application is completely filled and the user decided to submit it, the following will happen in order.
            /* 1 - The accept and decline buttons will deactivate.
             * 2 - The camera will turn itself sideways (portrait view) and position itself centered with the application.
             * 3 - The camera will change its distance and field of view to capture the entire documents on any device.
             * 4 - The application will take a screenshot of the application with the filled text imposed over it and multiply its scale by 4.
             * 5 - On mobile devices, the file path for screenshots is appended, so we keep the application path empty for now.
             * 6 - Once the application has been saved, we can assign the application path a variable.
             * 7 - Finally, we load the main camera scene and continue on.
            */
            ScrollRect.enabled = false;
            camZoom.enabled = false;
            blockPanel.SetActive(true);
            DeclineButton.SetActive(false);
            AcceptButton.SetActive(false);
            mainCam.transform.localPosition = new Vector3(0, 0, -11.50f);
            mainCam.transform.eulerAngles = new Vector3(0, 0, 90);
            mainCam.fieldOfView = 174.5f;
            ApplicationRect.offsetMin = new Vector2(0, 0);
            ApplicationRect.offsetMax = new Vector2(0, -500);
        } else
        {
            //Debug.Log("Application is not ready to be sent.");
        }
    }

    //After filling an application it is important to set playerprefs so that if the user quits part way through the process
    //They still have the ability to continue where they left off.
    //This will also set the camera position so that people will be able to review their 

    public void SaveApplication()
    {
        FileBasedPrefs.SetBool("App Done", true);
        VarCheck.Instance.appDone = true;
        blockPanel.SetActive(false);
        mainCam.transform.localPosition = new Vector3(0, 0, -11.50f);
        mainCam.transform.eulerAngles = new Vector3(0, 0, 90);
        mainCam.fieldOfView = 174.5f;
        ScreenCapture.CaptureScreenshot(Path.Combine(VarCheck.Instance.appPath, VarCheck.Instance.contractName), 4);
        VarCheck.Instance.appPath = Application.persistentDataPath;
        //Debug.Log(VarCheck.Instance.appPath + VarCheck.Instance.contractName);
        Screen.orientation = ScreenOrientation.Landscape;
        SceneManager.LoadScene("Camera");
    }

    public void EditApplication()
    {
        ScrollRect.enabled = true;
        camZoom.enabled = true;
        DeclineButton.SetActive(true);
        AcceptButton.SetActive(true);
        blockPanel.SetActive(false);
        Screen.orientation = ScreenOrientation.Landscape;
        mainCam.transform.localPosition = new Vector3(0, 200, -20f);
        mainCam.transform.localEulerAngles = new Vector3(0, 0, 0);
        mainCam.fieldOfView = 168;
    }

}
