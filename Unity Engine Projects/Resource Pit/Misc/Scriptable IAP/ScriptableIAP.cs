using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableIAP", menuName = "ScriptableIAP")]
public class ScriptableIAP : ScriptableObject {

    public string IAPid;
    public string IAPName;
    public string IAPButtonName;
    public string IAPPrice;
    [TextArea]
    public string IAPDescription;

}
