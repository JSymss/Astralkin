using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    private object gridObject;

    [SerializeField] TextMeshPro gridPositionText;

    protected virtual void Update() 
    {
        gridPositionText.text = gridObject.ToString();
    }
    
    public virtual void SetGridObject(object gridObject)
    {
        this.gridObject = gridObject;
    }
}
