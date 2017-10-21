using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public List<Vector2> GridCells;

    [SerializeField]
    private GameObject BlockSprite;

    //bool matrix of whether block is present in shape
    private bool[,] _ShapeGrid;

    // Use this for initialization
    void Start()
    {
        ChangeShape(_Shape);
    }

    public void ChangeShape(int newShape)
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        _Shape = newShape;

        GridCells = new List<Vector2>();

        float _GridSize = BlockSprite.GetComponent<RectTransform>().sizeDelta.x;

        _ShapeGrid = new bool[4, 4];

        int mask = 1;
        for (int i = 0; i < 16; i++)
        {
            _ShapeGrid[i / 4, i % 4] = (mask & _Shape) != 0;
            mask <<= 1;

            if (_ShapeGrid[i / 4, i % 4])
            {
                var tmp = GameObject.Instantiate(BlockSprite, transform);
                tmp.transform.localPosition = new Vector2(i / 4, i % 4) * _GridSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Rotate()
    {
        transform.Rotate(0, 0, 90);
    }

    public IEnumerable<Vector2> Cells()
    {
        for (int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 4; x++)
            {
                if (_ShapeGrid[x, y])
                {
                    switch ((int)transform.rotation.eulerAngles.z)
                    {
                        case 0:
                            yield return new Vector2(x, -y);
                            break;
                        case 90:
                            yield return new Vector2(-y, -x);
                            break;
                        case 180:
                            yield return new Vector2(-x, y);
                            break;
                        case 270:
                            yield return new Vector2(y, x);
                            break;
                    }
                }
            }
        }
    }
}
