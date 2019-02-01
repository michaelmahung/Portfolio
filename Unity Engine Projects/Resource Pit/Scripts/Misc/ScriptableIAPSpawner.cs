using UnityEngine.UI;
using UnityEngine;

public class ScriptableIAPSpawner : MonoBehaviour
{
    public GameObject IAPPrefab;

    private ScriptableIAP[] IAPs;
    private IAPHolder holder;
    [SerializeField]
    private RectTransform thisRect;
    private EntityInfoManager.RectInfo rectInfo;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();
        IAPs = Resources.LoadAll<ScriptableIAP>("IAPs");

        foreach (ScriptableIAP iap in IAPs)
        {
            Instantiate(IAPPrefab, gameObject.transform);
            holder = IAPPrefab.GetComponent<IAPHolder>();
            holder.transform.SetAsLastSibling();
            holder.MyIAP = iap;
            thisRect.offsetMax += new Vector2(450, 0);
        }
    }


}
