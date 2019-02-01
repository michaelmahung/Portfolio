using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
    public Entity[] Entities;
    public GameObject ButtonPrefab;
    private EntityHolder holder;

	void Awake ()
    {
        Entities = Resources.LoadAll<Entity>("Entities");

        for (int i = 0; i < Entities.Length; i ++)
        {
            Instantiate(ButtonPrefab, gameObject.transform);
            holder = ButtonPrefab.GetComponent<EntityHolder>();
            holder.entity = Entities[i];
        } 
	}
}
