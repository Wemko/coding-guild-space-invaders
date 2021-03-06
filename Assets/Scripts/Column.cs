﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Action<Column> columnEmpty;
    public Alien lowestAlien;
    public List<Alien> aliens;

    // Start is called before the first frame update
    void Start()
    {
        aliens = new List<Alien>(GetComponentsInChildren<Alien>());
        foreach (Alien alien in aliens)
        {
            alien.dies += AlienDies;
        }
        UpdateLowestAlien();
    }

    private void AlienDies(Alien alien)
    {
        aliens.Remove(alien);
        UpdateLowestAlien();

        if (aliens.Count == 0)
        {
            columnEmpty?.Invoke(this);
            Destroy(gameObject);
        }
    }

    private void UpdateLowestAlien()
    {
        Alien lowest = null;

        foreach (Alien alien in aliens)
        {
            if (lowest == null)
            {
                lowest = alien;
            }
            else if (alien.gameObject.transform.position.y < lowest.gameObject.transform.position.y)
            {
                lowest = alien;
            }
        }
        lowestAlien = lowest;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
