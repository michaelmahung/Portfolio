using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEnableDisable : MonoBehaviour 
{
    public void DisableObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void EnableObject(GameObject obj)
    {
        obj.SetActive(true);
    }
}
