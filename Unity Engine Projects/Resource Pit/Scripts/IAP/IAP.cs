using UnityEngine;

public class IAP : MonoBehaviour
{
    public string MyID;

    public void PurchaseIAP()
    {
        Purchaser.Instance.PurchaseIAP(MyID);
    }
}
