using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridCell : MonoBehaviour, IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == 0)
            GridManager.Instance.CellClicked(transform.GetSiblingIndex()%15, transform.GetSiblingIndex()/15);
    }
}
