using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Represents an inventory item that is a collection of squares.
 * Author: Adam Waggoner
 */
public class TetrisPiece : MonoBehaviour
{

    /// <summary>
    /// Shape of the piece. A true represents that there is a block.
    /// accessed by shape[y][x]
    /// </summary>
    [SerializeField]
    private int _Shape;

    [SerializeField]
    private GameObject BlockSprite;

    [SerializeField]
    private float _GridSize = 100;

    //bool matrix of whether block is present in shape
    private bool[,] _ShapeGrid;

    // Use this for initialization
    void Start()
    {
        _ShapeGrid = new bool[4, 4];

        int mask = 1;
        for (int i = 0; i < 16; i++)
        {
            _ShapeGrid[i / 4, i % 4] = (mask & _Shape) != 0;
            mask <<= 1;

            if (_ShapeGrid[i / 4, i % 4])
            {
                var tmp = GameObject.Instantiate(BlockSprite, transform);
                tmp.transform.localPosition = new Vector3(i / 4, i % 4, 0) * _GridSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
