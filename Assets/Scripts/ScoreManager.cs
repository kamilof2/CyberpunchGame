using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void addPoints(int points)
    {
        score += points;
    }
}
