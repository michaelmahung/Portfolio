using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "Entity", order = 1)]
public class Entity : ScriptableObject
{
    public string EntityName = "Default";

    [TextArea(40, 100)]
    public string EntityDescription = "Default";
}
