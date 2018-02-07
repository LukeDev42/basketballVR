using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour {

    static TextMesh scoreText;
    static int currentScore = 0;

    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMesh>();
        UpdateScore(currentScore);
    }

    public void UpdateScore(int addedValue)
    {
        currentScore += addedValue;
        scoreText.text = "Score: " + currentScore;
    }
}
