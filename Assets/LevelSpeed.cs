using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour {

    public static float scrollSpeed { get; private set; } // speed the background scrolls at

    private static float nextUpdate = 1f; // when the speed increases
    private float time { get { return Time.realtimeSinceStartup; } } // total time
    private float increase = 5f; // Update increase time
    private float speedUp = 0.5f; // Speed increase time
    private float maxSpeed = 15f; // maximum speed

    private void Awake()
    {
        scrollSpeed = -3f;
    }
	
	// Update is called once per frame
	void Update () {
        if (time >= nextUpdate && scrollSpeed >= -maxSpeed) // if time has passed nextUpdate time AND scrollSpead is not too fast
        {
            nextUpdate = time + increase; // next time to update increases
            scrollSpeed -= speedUp; // increase speed
        }
    }
}
