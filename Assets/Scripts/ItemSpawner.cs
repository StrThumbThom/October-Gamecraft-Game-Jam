using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] items = GameObject.Find("ItemMasterList").GetComponent<ItemList>().items;

		for (int i = 0; i < transform.childCount; i++)
        {
            GameObject possibleSpawner = transform.GetChild(i).gameObject;
            if (possibleSpawner.CompareTag("ItemSpawner"))
            {
                int randomItem = Random.Range(0, items.Length);
                Instantiate(items[randomItem], possibleSpawner.transform.position, items[randomItem].gameObject.transform.rotation);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
