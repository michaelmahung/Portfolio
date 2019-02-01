using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadVideo()
    {
        SceneManager.LoadScene("VideoInfo");
    }

    public void LoadCamera()
    {
        SceneManager.LoadScene("Camera");
    }

    public void LoadPDF()
    {
        SceneManager.LoadScene("PDF");
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadEntityInfo()
    {
        SceneManager.LoadScene("EntityInfo");
    }
}
