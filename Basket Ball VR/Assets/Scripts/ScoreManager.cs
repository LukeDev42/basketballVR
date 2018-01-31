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
    }

    void Update()
    {
        OnTriggerEnter(scoreKeeper);
        Debug.Log(score);
        UpdateScore();
	}

    private void OnTriggerEnter(Collider scoreKeeper)
    {
        if(scoreKeeper)
        {
            score += 1;
        }
        return;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
