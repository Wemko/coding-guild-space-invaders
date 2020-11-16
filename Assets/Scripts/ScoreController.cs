using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private GameDataController gameDataController;

    private int score;

    // Start is called before the first frame update
    private void Start()
    {
        int highScore = gameDataController.GetHighScore();
        highScoreText.text = highScore.ToString();
    }

    public void AddScore(int increase)
    {
        score += increase;
        scoreText.text = score.ToString();
    }
}
