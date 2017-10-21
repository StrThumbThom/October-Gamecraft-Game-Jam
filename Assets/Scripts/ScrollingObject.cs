using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private static float scrollSpeed = -3f; // speed the background scrolls at
    private static float nextUpdate = 1f; // when the speed increases
    private float time { get { return Time.realtimeSinceStartup; }} // total time
    private float increase = 5f; // Update increase time
    private float speedUp = 0.5f; // Speed increase time
    private float maxSpeed = 10; // maximum speed

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.velocity = new Vector2(scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (time >= nextUpdate && scrollSpeed >= -maxSpeed) // if time has passed nextUpdate time AND scrollSpead is not too fast
        {
            nextUpdate = time + increase; // next time to update increases
            scrollSpeed -= speedUp; // increase speed
        }
        rb2d.velocity = new Vector2(scrollSpeed, 0); // update wall scrolling
    }
}
