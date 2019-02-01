using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Preloader : MonoBehaviour
{
    public Image splashImage;
    public string loadLevel;
    
    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadLevel);
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1, 1.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0, 1.5f, false);
    }
}
