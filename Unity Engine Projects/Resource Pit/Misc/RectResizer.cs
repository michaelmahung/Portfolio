using UnityEngine.UI;
using UnityEngine;

public class RectResizer : MonoBehaviour {

    private RectTransform thisRect;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();

        foreach (Transform child in transform)
        {
            thisRect.offsetMax += new Vector2(400, 0);
        }
    }
}
