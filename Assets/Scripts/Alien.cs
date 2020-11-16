using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public Action<Alien> dies;

    [SerializeField] private float borderRight = 7.5f;
    [SerializeField] private float borderLeft = -5f;
    [SerializeField] private int score;
    [SerializeField] private AliensController aliensController;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject diedPrefab;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    // Right is 1 left is -1
    private int direction = 1;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        aliensController.move += Move;
        aliensController.changeDirection += ChangeDirection;
    }

    private void Update()
    {
        CheckIfAtBorder();
    }

    public void Shoot()
    {
        GameObject instantiated = Instantiate(bulletPrefab);
        instantiated.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void ChangeDirection(int newDirection)
    {
        direction = newDirection;
    }

    private void Move(Vector2 movePosition)
    {
        transform.Translate(movePosition);
        if(spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    private void CheckIfAtBorder()
    {
        if(
            (direction == 1 && transform.localPosition.x >= borderRight)
        ){
            aliensController.TriggerChangeDirection(-1);
        } else if(direction == -1 && transform.localPosition.x <= borderLeft)
        {
            aliensController.TriggerChangeDirection(1);
        }
    }

    private void Dies()
    {
        GameObject instantiated = Instantiate(diedPrefab);
        instantiated.transform.position = transform.position;
        scoreController.AddScore(score);
        dies.Invoke(this);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Dies();
        }
    }

    private void OnDestroy()
    {
        aliensController.move -= Move;
        aliensController.changeDirection -= ChangeDirection;
    }
}
