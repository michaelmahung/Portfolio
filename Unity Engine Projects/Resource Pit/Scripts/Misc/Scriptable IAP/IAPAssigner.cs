using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPAssigner : MonoBehaviour {

    public ScriptableIAP[] IAPS;
    private IAPHolder holder;

    private void Awake()
    {
        holder = GetComponent<IAPHolder>();

        if (Purchaser.Instance.OnPhase1)
        {
            holder.MyIAP = IAPS[0];
        }else if (Purchaser.Instance.OnPhase2)
        {
            holder.MyIAP = IAPS[1];
        } else
        {
            holder.MyIAP = IAPS[2];
        }

        holder.FindText();
    }
}
