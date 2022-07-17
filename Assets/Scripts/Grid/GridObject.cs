using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{

    private GridPosition gridPosition;
    private GridSystem<GridObject> gridSystem;
    private List<Unit> unitList;
    private Door door;

    public GridObject(GridSystem<GridObject> gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public bool HasAnyUnit()
    {
        return unitList.Count > 0;
    }

    public override string ToString()
    {
        string unitString = "";
        foreach(Unit unit in unitList)
        {
            unitString += unit + "\n";
        }
        
        return gridPosition.ToString() + "\n" + unitString;
    }

    public Unit GetUnit()
    {
        if(HasAnyUnit())
        {
            return unitList[0];
        }else{
            return null;
        }
    }

    public Door GetDoor()
    {
        return door;
    }

    public void SetDoor(Door door)
    {
        this.door = door;
    }
}
