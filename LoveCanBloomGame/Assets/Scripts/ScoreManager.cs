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


    public GameObject SCORE;

    public Flowchart storyChart;

    public GameObject rainMaker;
    
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

        
    }

    
    void Update()
    {
        travisScoreText.text = travisActualScore.ToString();
        dessyScoreText.text = dessyActualScore.ToString();


        if (storyChart.GetBooleanVariable("TWin") == true)
        {
            if (storyChart.GetBooleanVariable("TravisPoint") == true)
            {
                Debug.Log("Travis get point");
                travisActualScore++;
                storyChart.SetBooleanVariable("TravisPoint",false);
            }
        }

        if (storyChart.GetBooleanVariable("DWin") == true)
        {
            if (storyChart.GetBooleanVariable("DessyPoint") == true)
            {
                Debug.Log("dessy get point");
                dessyActualScore++;
                storyChart.SetBooleanVariable("DessyPoint",false);
            }
            
        }

        if (storyChart.GetBooleanVariable("DecreasePoint") == true)
        {
            travisActualScore--;
            dessyActualScore--;
            storyChart.SetBooleanVariable("DecreasePoint", false);
        }

        if (storyChart.GetBooleanVariable("DisableRain") == true)
        {
            rainMaker.SetActive(false);
        }
        else
        {
            rainMaker.SetActive(true);
        }
        

        

      
    }
}
