using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System.Linq;
public class GridManager : Singleton<GridManager>{

    public Vector2 Size;

    [SerializeField]
    private TetrisPiece _CurrentPiece;
    private Dictionary<Vector2, TetrisPiece> _Pieces;

    public GameObject templatePiece;

    private void Awake()
    {
        _Pieces = new Dictionary<Vector2, TetrisPiece>();
    }
	
	// Update is called once per frame
	void Update () {

        if (_CurrentPiece != null)
        {
            _CurrentPiece.transform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(1))
            {
                _CurrentPiece.Rotate();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _CurrentPiece = Instantiate(templatePiece, transform.parent).GetComponent<TetrisPiece>();
            _CurrentPiece.ChangeShape(Random.Range(1, 16));
        }
	}

    public bool CellIsEmpty(int x, int y)
    {
        return !_Pieces.ContainsKey(new Vector2(x,y));
    }

    public void CellClicked(int x, int y)
    {
        if (_CurrentPiece == null)
        {
            _CurrentPiece = GetPiece(x, y);

            if(_CurrentPiece != null)
                RemovePiece(_CurrentPiece);
        }
        else
        {
            if (CanPlace(x, y))
                AddPiece(x, y);
        }
    }

    public void AddPiece(int x, int y)
    {
        if (_CurrentPiece == null)
            return;

        Vector2 cp = new Vector2(x, y);

        foreach (Vector2 v in _CurrentPiece.Cells())
        {
            _Pieces[cp + v] = _CurrentPiece;
            _CurrentPiece.GridCells.Add(cp + v);
        }

        int cID = y * (int)Size.x + x;        
        _CurrentPiece.transform.position = transform.GetChild(cID).transform.position;
        _CurrentPiece = null;
    }

    public bool CanPlace(int x, int y)
    {
        Vector2 cp = new Vector2(x, y);
        return _CurrentPiece.Cells().All(v => {
            Debug.Log(v + cp);
            if (v.x + cp.x >= Size.x || v.y + cp.y >= Size.y) return false;
            if (v.x + cp.x < 0 || v.y + cp.y < 0) return false;
            return CellIsEmpty((int)(v.x + cp.x), (int)(v.y + cp.y));    
        });
    }

    public TetrisPiece GetPiece(int x, int y)
    {
        if (CellIsEmpty(x, y))
            return null;

        
        return _Pieces[new Vector2(x, y)];
    }

    public void RemovePiece(TetrisPiece piece)
    {
        foreach (Vector2 v in piece.GridCells)
        {
            _Pieces.Remove(v);
        }
        piece.GridCells.Clear();
    }
    
}
