using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private int score;

    public void AddScore(int increase)
    {
        score += increase;
        scoreText.text = score.ToString();
    }
}
