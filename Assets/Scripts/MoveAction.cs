using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    [SerializeField] private int maxMoveDistance = 4;
    private Vector3 targetPosition;
    private Unit unit;


    private void Awake()
    {
        targetPosition = transform.position;
        unit = GetComponent<Unit>();
    }

    private void Update() 
    {
        float stoppingDistance = .1f;
        if(Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        float moveSpeed = 4f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);

        unitAnimator.SetBool("IsWalking", true);
        }else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
    }
    
        public void Move(GridPosition gridPosition)
    {
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }

    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for (var x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (var z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    //Is in range of the generated grid
                    continue;
                }
                if(unitGridPosition == testGridPosition)
                {
                    //This is the same position the unit is already at
                    continue;
                }
                if(LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                {
                    //Grid position already occupied by another unit
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }
}
