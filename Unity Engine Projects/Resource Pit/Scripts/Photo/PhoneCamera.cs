using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhoneCamera : MonoBehaviour
{
    bool camAvailable;
    bool frontAvailable;
    bool backAvailable;
    bool midAvailable;
    Texture2D photo;
    WebCamTexture midCam;
    WebCamTexture backCam;
    WebCamTexture frontCam;
    WebCamTexture currentCam;
    public GameObject cameraImage;

    public RawImage background;
    public AspectRatioFitter fit;

    /**WHY I USE AWAKE**
    Because I feel like it...
        No actually though, I'm using awake because I don't want to start looking for a background texture until it has actually been activated.
        If I don't wait, I will get errors because the attached RawImage wont be active in the scene.
        This is going to take the place of the current CameraController script, so it will be very messy for the time being.
    */

    private void Awake()
    {
        //Set the default background to the current background texture then create an array of webcam devices (cameras).
        
        WebCamDevice[] devices = WebCamTexture.devices;

        //If no cameras are found, do nothing.
        if (devices.Length == 0)
        {
            //Debug.Log("No Camera Found.");
            camAvailable = false;
            return;
        } else
        {
            //If there is a camera available, say how many are found.
            camAvailable = true;
            //Debug.Log(devices.Length + " Device(s) Found.");
        }

        //If there are two or more cameras, activate the front facing camera button.
        if (devices.Length > 1)
        {
            cameraImage.SetActive(true);
        } else
        {
            cameraImage.SetActive(false);
        }

        //For every camera, check if its backfacing or frontfacing and create a new texture to support it.
        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backAvailable = true;
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                backCam.name = "back";
                backCam.requestedFPS = 60;
                //Debug.Log("Back Facing Camera Found " + devices[i].name);
            } else if (devices[i].isFrontFacing)
            {
                frontAvailable = true;
                frontCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                frontCam.name = "front";
                frontCam.requestedFPS = 60;
                //Debug.Log("Front Facing Camera Found " + devices[i].name);
            } else
            {
                midAvailable = true;
                midCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                midCam.name = "mid";
                midCam.requestedFPS = 60;
               // Debug.Log("Other Device Found " + devices[i].name);
            }

        }

        //if for some reason the camera is neither front or back facing, run it anyways.

        if (midAvailable)
        {
            StartMid();
        } else
        {
            StartBack();
        }
        return;
    }

    private void Update()
    {
        //If there aren't any cameras available, don't worry about updating.
        if (!camAvailable)
        {
            return;
        }

        //Otherwise, make sure that the image is properly croppped within the camera view.
        //Also make sure that the aspect ratio properly fits.
        //Finally, check the rotation and reorient the image as needed.  

        float ratio = (float)currentCam.width / (float)currentCam.height;
        fit.aspectRatio = ratio;

        float scaleY = currentCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        VarCheck.Instance.orient = -currentCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, VarCheck.Instance.orient);

    }

    void StartMid()
    {
        //Debug.Log("Starting Other Camera");
        currentCam = midCam;
        currentCam.Play();
        background.texture = currentCam;
    }

    void StartBack()
    {
        //If there is no back camera, check for front cameras. Otherwise, start the back camera..
        if (backCam == null)
        {
            //Debug.Log("No back camera available.");
            StartFront();
            return;
        } else
        {
            currentCam = backCam;
            currentCam.Play();
            background.texture = currentCam;

            backAvailable = true;
            //Debug.Log("Starting Back Camera.");
        }
    }

    public void StartFront()
    {
        //If there is no front camera, check for mid cameras. Otherwise, start the front camera.
        if (frontCam == null)
        {
            //Debug.Log("No front camera available.");
            StartMid();
            return;
        } else
        {
            currentCam = frontCam;
            currentCam.Play();
            background.texture = currentCam;

            frontAvailable = true;
            //Debug.Log("Starting Front Camera.");
        }
    }

    public void SwapCam()
    {
        //If there are both front and back cameras available, this will swap between them.
        if (frontAvailable && backAvailable)
        {
            if (currentCam == frontCam)
            {
                //Debug.Log("Enabling Back Cam.");
				//VarCheck.Instance.LandscapeOnly();
                currentCam.Stop();
                currentCam = backCam;
                currentCam.Play();
                background.texture = currentCam;
            } else if (currentCam == backCam)
            {
                //Debug.Log("Enabling Front Cam.");
				//VarCheck.Instance.LandscapeOnly();
                currentCam.Stop();
                currentCam = frontCam;
                currentCam.Play();
                background.texture = currentCam;
            } else { /*Debug.Log("Error Switching Cameras");*/ }
        }

        //Debug.Log("Multiple Cameras Not Available.");
    }

    void Pause()
    {
        currentCam.Pause();
    }

    void Stop()
    {
        currentCam.Stop();
    }

    void Play()
    {
        currentCam.Play();
    }

    public void TakePic()
    {
        StartCoroutine(Picture());
    }

    //https://stackoverflow.com/questions/24496438/can-i-take-a-photo-in-unity-using-the-devices-camera#24497723
    IEnumerator Picture()
    {
        if (currentCam.isPlaying)
        {
            //Here, we are taking a snapshot of the webcamtexture and setting it as a new Texture2D.
            //The Texture2D will not be finally set until we Apply the texture, so I plan to rotate the texture here as well.

            // NOTE - you almost certainly have to do this here:

            yield return new WaitForEndOfFrame();

            // it's a rare case where the Unity doco is pretty clear,
            // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
            // be sure to scroll down to the SECOND long example on that doco page 

            photo = new Texture2D(currentCam.width, currentCam.height);
            photo.SetPixels(currentCam.GetPixels());
            photo.Apply();
            Pause();

            yield break;
        } else
        {
            Play();
        }
    }

    void saveImage()
    {
        FileBasedPrefs.SetBool("Picture Taken", true);
        VarCheck.Instance.pictureTaken = true;
        //Here we are taking the Texture2D we applied earlier and saving it as a PNG file. Afterwards, we create an array of bytes to hold the data and
        //save that data in the applications temp folder.
        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes(Path.Combine(VarCheck.Instance.filePath, VarCheck.Instance.pictureName), bytes);
        //Debug.Log(VarCheck.Instance.filePath + VarCheck.Instance.pictureName);
        currentCam.Stop();
        bytes = null;
        photo = null;
    }


    public void Quit()
    {
        Application.Quit();
    }

}
