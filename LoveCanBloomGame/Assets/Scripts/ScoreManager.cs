using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI travisScoreText;
    public TextMeshProUGUI dessyScoreText;

    public int travisActualScore;
    public int dessyActualScore;
    

    public GameObject SCORE;
    
    void Start()
    {
        if (SCORE == null)
        {
            SCORE = this.gameObject;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            return;
        }
    }

    
    void Update()
    {
        travisScoreText.text = travisActualScore.ToString();
        dessyScoreText.text = dessyActualScore.ToString();
    }
}
