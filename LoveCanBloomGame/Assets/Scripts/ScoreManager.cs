using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI travisScoreText;
    public TextMeshProUGUI dessyScoreText;

    public int travisActualScore;
    public int dessyActualScore;

    public bool travisWinBranch;
    public bool dessyWinBranch;
    

    public GameObject SCORE;

    public Flowchart storyChart;
    
    void Start()
    {
        if (SCORE == null)
        {
            SCORE = this.gameObject;
        }
        else
        {
            
            return;
        }

        travisWinBranch = false;
        dessyWinBranch = false;
    }

    
    void Update()
    {
        travisScoreText.text = travisActualScore.ToString();
        dessyScoreText.text = dessyActualScore.ToString();

        if (travisWinBranch)
        {
            storyChart.ExecuteBlock("Travis Wins 1");
            travisWinBranch = false;
            dessyWinBranch = false;
        }
        
        if (dessyWinBranch)
        {
            storyChart.ExecuteBlock("Dessy Wins 1");
            travisWinBranch = false;
            dessyWinBranch = false;
        }
    }
}
