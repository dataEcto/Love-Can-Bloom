using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class TravisBar : MonoBehaviour
{
    
    public float CurrentProgress { get; set; }
    public float MaxProgress { get; set; }

    public bool dealDamage;
    
    public bool travisWins;
    
    public Slider progressBarObject;

    public GameObject scoreManager;
    public ScoreManager scoreScript;
    public bool shouldSendScore;

    public GameObject timerObject;
    public CountDownTimer timerScript;

    public Flowchart storyChart;
    
    void Start()
    {
        //This can also be set on inspector
        MaxProgress = 100f;
        //Reset progress to 0 on mini game load
        CurrentProgress = 0;

        dealDamage = true;
        travisWins = false;
  
        progressBarObject.value = CalculateProgress();

        scoreManager = GameObject.Find("SCORE");
        scoreScript = scoreManager.GetComponent<ScoreManager>();
        shouldSendScore = false;

        timerObject = GameObject.Find("TIMER");
        timerScript = timerObject.GetComponent<CountDownTimer>();

       
    }

    
    void Update()
    {
            //There are multiple ways we are going to make the health bar
            //Decrease overtime.0
            if (dealDamage)
            {
                DealDamage(10);
            }
            

            if (Input.GetKeyDown(KeyCode.A) && timerScript.countdownOver)
            {
                addProgress(5);

                if (storyChart.GetBooleanVariable("TravisAdvantage"))
                {
                    addProgress(10);
                    Debug.Log("Travis has the advantage");
                }
            }

            if (CurrentProgress >= 100 && travisWins == false) 
            {
                CurrentProgress = 99;
                Debug.Log("Travis wins");
                travisWins = true;
                shouldSendScore = true;
                dealDamage = false;         
            }
            

            if (travisWins && shouldSendScore)
            {
                scoreScript.travisActualScore = scoreScript.travisActualScore + 1;
                scoreScript.travisWinBranch = true;
                shouldSendScore = false;
            }

      
          
    }
    
    void DealDamage(float damageValue)
    {
        //Deduct the damage dealt from the current health
        CurrentProgress -= damageValue * Time.deltaTime;
        progressBarObject.value = CalculateProgress();
        //if the character is out of health, u die!
        if (CurrentProgress <= 0)
        {
            CurrentProgress = 1;
        }
    }
    
    float CalculateProgress()
    {
        //Accurately calculate health so
        //that it can be represented visually better.
        return CurrentProgress / MaxProgress;
    }
    
    void addProgress(float progressGained)
    {
        Debug.Log("Adding: " + progressGained );
      
        CurrentProgress += progressGained;
        progressBarObject.value = CalculateProgress();

        //Prevent the player from restoring past full health
        if (CurrentProgress >= MaxProgress)
        {
            CurrentProgress -= 1;
            //Debug.Log("Progress is full. Will no longer add more");
        }

    }

  
}
