using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolArray2D {
    public bool[] array;
}

/*
 * Represents an inventory item that is a collection of squares.
 * Author: Adam Waggoner
 */
public class TetrisPiece : MonoBehaviour {

    /// <summary>
    /// Shape of the piece. A true represents that there is a block.
    /// accessed by shape[y][x]
    /// </summary>
    [SerializeField]
    private BoolArray2D[] shape;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
