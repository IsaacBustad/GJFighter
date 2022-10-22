// Isaac Bustad
// 10/22/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Score")]
public class Score : ScriptableObject
{
    // vars
    private int scorePoints = 0;

    public int ScorePoints
    {
        get { return scorePoints; }
        set { if(scorePoints + value < 0) { scorePoints = 0; } else { scorePoints += value; } }
    }

    // functions


    // accessors
}
