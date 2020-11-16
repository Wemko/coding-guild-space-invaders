using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensController : MonoBehaviour
{
    [SerializeField] private float shootDelayRandomOffset = 1.0f;
    [SerializeField] private float shootDelay = 1.0f;
    [SerializeField] private float moveDelay = 0.5f;
    [SerializeField] private float moveSpeed = 0.25f;
    [SerializeField] private float moveDownStep = 0.25f;

    public Action<int> changeDirection;
    public Action<Vector2> move;

    private float nextMoveTimeStamp;
    private int direction = 1;
    private List<Column> columns;

    // Start is called before the first frame update
    void Start()
    {
        columns = new List<Column>(GetComponentsInChildren<Column>());
        foreach(Column column in columns)
        {
            column.columnEmpty += RemoveColumn;
        }

        StartCoroutine(IntervalMoveCommand());
        StartCoroutine(IntervalShootCommand());
    }

    IEnumerator IntervalShootCommand()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay + UnityEngine.Random.Range(0, shootDelayRandomOffset));
            int index = UnityEngine.Random.Range(0, columns.Count);
            if (columns[index].lowestAlien)
            {
                columns[index].lowestAlien.Shoot();
            }
        }
    }


    IEnumerator IntervalMoveCommand()
    {
        while(true)
        {
            //int currentDirection = direction;
            yield return new WaitForSeconds(moveDelay);
            move?.Invoke(new Vector2(moveSpeed * direction, 0));
        }

    }

    public void RemoveColumn(Column column)
    {
        columns.Remove(column);
    }

    public void TriggerChangeDirection(int newDirection)
    {
        if(direction != newDirection)
        {
            direction = newDirection;
            changeDirection.Invoke(newDirection);
            move.Invoke(new Vector2(0, -moveDownStep));
        }
    }
}
