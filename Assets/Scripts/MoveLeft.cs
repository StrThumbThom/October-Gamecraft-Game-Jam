using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    private float horizontalSpeed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        horizontalSpeed = LevelSpeed.scrollSpeed;
        this.transform.position = new Vector3(this.transform.position.x + (horizontalSpeed * Time.deltaTime), transform.position.y, transform.position.z);
	}
}
