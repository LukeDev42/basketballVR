using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private ScoreAdder scoreAdder;

    private void Start()
    {
        scoreAdder = GameObject.FindObjectOfType<ScoreAdder>();
    }

    private void OnTriggerEnter(Collider col)
    {
        switch(col.tag)
        {
            case "Trigger":
                scoreAdder.UpdateScore(1);
                break;
        }
    }
}
