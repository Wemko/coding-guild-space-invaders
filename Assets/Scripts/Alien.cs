using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float moveDelay = 1.0f;
    public float moveSpeed = 1.0f;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    private void Move()
    {
        Debug.Log("Moving");
        transform.Translate(new Vector2(moveSpeed, 0));
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            Move();
        }
    }
}
