using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Score aScore;
    public TextMeshProUGUI scoreTextDisplay;


    void Start()
    {
        
    }

    void DisplayScore()
    {
        scoreTextDisplay.text = aScore.ScorePoints.ToString();
    }

    void FixedUpdate()
    {
        DisplayScore();
    }
}
