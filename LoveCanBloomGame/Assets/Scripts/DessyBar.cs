using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DessyBar : MonoBehaviour
{
    public float CurrentProgress { get; set; }
    public float MaxProgress { get; set; }

    public bool dealDamage;
    
    public bool dessyWins;
    
    public Slider dessyProgressBar;
    
    public GameObject scoreManager;
    public ScoreManager scoreScript;

    public bool shouldSendScore;
    
    void Start()
    {
        //This can also be set on inspector
        MaxProgress = 100f;
        //Reset progress to 0 on mini game load
        CurrentProgress = 0;
        
        dealDamage = true;
        dessyWins = false;
          
        dessyProgressBar.value = CalculateProgress();
        
        scoreManager = GameObject.Find("SCORE");
        scoreScript = scoreManager.GetComponent<ScoreManager>();

        shouldSendScore = false;
    }

    
    void Update()
    {
        //There are multiple ways we are going to make the health bar
        //Decrease overtime.
        if (dealDamage)
        {
            DealDamage(10);
        }
                    
        if (Input.GetKeyDown(KeyCode.L))
        {
            addProgress(5);
        }
        
        if (CurrentProgress >= 100 && dessyWins == false) 
        {
            CurrentProgress = 99;
            Debug.Log("DESSY wins");
            dessyWins = true;
            shouldSendScore = true;
            dealDamage = false;         
        }
            

        if (dessyWins && shouldSendScore)
        {
            scoreScript.dessyActualScore = scoreScript.dessyActualScore + 1;
            shouldSendScore = false;
        }
    }
    
    void DealDamage(float damageValue)
    {
        //Deduct the damage dealt from the current health
        CurrentProgress -= damageValue * Time.deltaTime;
        dessyProgressBar.value = CalculateProgress();
        //if the character is out of health, u die!
        if (CurrentProgress <= 0)
        {
            //Die
        }
    }
    
    void addProgress(float progressGained)
    {
        Debug.Log("Adding: " + progressGained );
      
        CurrentProgress += progressGained;
        dessyProgressBar.value = CalculateProgress();

        //Prevent the player from restoring past full health
        if (CurrentProgress >= MaxProgress)
        {
            CurrentProgress -= 1;
            //Debug.Log("Progress is full. Will no longer add more");
        }

    }
    
    float CalculateProgress()
    {
        //Accurately calculate health so
        //that it can be represented visually better.
        return CurrentProgress / MaxProgress;
    }
}
