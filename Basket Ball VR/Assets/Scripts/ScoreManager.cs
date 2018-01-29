using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public BoxCollider ScoreKeeper;

    int newScoreValue = 0;
    int score;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
        score = 0;
        UpdateScore();
    }

    void Update()
    {
        if (ScoreKeeper)
        {
            UpdateScore();
        }
        AddScore(newScoreValue);
        Debug.Log(newScoreValue);
        scoreText.text = " " + score;
	}

    //Add to the actual score
    void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    //Find the new score value
    int UpdateScore()
    {
        if(ScoreKeeper)
        {
            newScoreValue = 1 + newScoreValue;
        }
        return newScoreValue;
    }
}
