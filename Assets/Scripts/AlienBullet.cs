using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -speed * Time.deltaTime));

        if(transform.position.y > 100)
        {
            Destroy(gameObject);
        }
    }
}
