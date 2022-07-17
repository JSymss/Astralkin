using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAction : BaseAction
{
    private int maxInteractDistance = 1;

    public override string GetActionName()
    {
        return "Interact";
    }

    private void Update() 
    {
        if(!isActive)
        {
            return;
        }

    }
    
    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 0
        };
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for (var x = -maxInteractDistance; x <= maxInteractDistance; x++)
        {
            for (var z = -maxInteractDistance; z <= maxInteractDistance; z++)
            {
                GridPosition offsetGridPosition = new(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    //Is in range of the generated grid
                    continue;
                }

                if(unit.GetGridPosition() == testGridPosition)
                {
                    continue;
                }

                Door door = LevelGrid.Instance.GetDoorAtGridPosition(testGridPosition);

                if(door==null)
                {
                    // No door on this grid position
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        Door door = LevelGrid.Instance.GetDoorAtGridPosition(gridPosition);

        door.Interact(onActionComplete);

        ActionStart(onActionComplete);
    }

    private void onInteractionComplete()
    {
        ActionComplete();
    }
}
