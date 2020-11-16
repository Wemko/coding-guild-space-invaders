using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 8.0f;
    [SerializeField] private GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(axisX * speed * Time.deltaTime, 0));

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject instantiated = Instantiate(bulletPrefab);
            instantiated.transform.position = transform.position;
        }
    }
}
