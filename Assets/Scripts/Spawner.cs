using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] levelChunks;
    private GameObject currentChunk;

    //private float timeToSpawn = 1.0f;
    private float centerX;

    // Use this for initialization
    void Start () {
        centerX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).x;

        Spawn();
    }
	
	// Update is called once per frame
	void Update () {
        // when the current object is in the middle of the frame

        if (currentChunk.transform.position.x < centerX + 0.1f && currentChunk.transform.position.x > centerX - 0.1f)
        {
            Spawn();
        }
	}

    void Spawn()
    {
        int pickPlatform = Random.Range(0, levelChunks.Length);

        // Use floor as pivot point
        currentChunk = Instantiate(levelChunks[pickPlatform], new Vector3(transform.position.x, levelChunks[pickPlatform].transform.position.y), Quaternion.identity);
    }
}
