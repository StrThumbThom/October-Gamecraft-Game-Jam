using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] items;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++)
        {
            GameObject possibleSpawner = transform.GetChild(i).gameObject;
            if (possibleSpawner.CompareTag("ItemSpawner"))
            {
                int randomItem = Random.Range(0, items.Length);
                Instantiate(items[randomItem], possibleSpawner.transform.position, Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
