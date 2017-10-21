using UnityEngine;
using UnityEngine.UI;
using System;

public class Distance : MonoBehaviour {
    //variables
    private double distance; //the distance
    Text distance_ui; //this will be used to display distance
    double velocity = 0.5; //this is just a variable used for testing since not everything was setup in the player class. DON'T USE THIS IN THE FINAL GAME!!! Reference the player class' velocity instead
    private double time; //the time since the mimic has started running
    private double timeSinceStart; //the amount of seconds since the program started

    // Use this for initialization
    void Awake () {
        distance_ui = GetComponent<Text>(); //gets the Text component the script is attached to
        distance = 0; //sets distance to 0 at the start of running
        timeSinceStart = Time.time; //gets the time since the program started
	}

    // Update is called once per frame
    void Update() {
        time = Time.time - timeSinceStart; //get how many seconds have passed since the mimic has started running
        distance = velocity * time; //gets the distance that the mimic has traveled *NOTE: replace "velocity" with the velocity in the player class in the final build of the game
        double d_formated = Math.Truncate(distance * 100) / 100; //formats distance
        distance_ui.text = string.Format("{0:0.00}", d_formated) + "m"; //returns the formatted distance to text component
	}
}
