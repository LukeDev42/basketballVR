using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public TextMesh scoreText;
    public BoxCollider scoreKeeper;
    public static int score;

    private void Awake()
    {
        scoreKeeper = GetComponent<BoxCollider>();
        score = 0;
        UpdateScore();
    }

    void Update()
    {
        Debug.Log(score);
        
	}

    private void OnTriggerEnter(Collider col)
    {
        switch(col.tag)
        {
            case "Trigger":
                AddScore(1);
                break;
        }
    }

    void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
