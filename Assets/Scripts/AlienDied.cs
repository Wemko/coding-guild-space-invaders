using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDied : MonoBehaviour
{
    [SerializeField] private float duration = 1.0f;

    private float timeStamp;

    private void Awake()
    {
        timeStamp = Time.time + duration;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time > timeStamp)
        {
            Destroy(gameObject);
        }

    }
}
