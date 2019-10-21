using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float CurrentProgress { get; set; }
    public float MaxProgress { get; set; }

    public bool dealDamage;
    
    public bool winAchieved;
    
    public Slider progressBarObject;
    
    
    void Start()
    {
        //This can also be set on inspector
        MaxProgress = 100f;
        //Reset progress to 0 on mini game load
        CurrentProgress = 0;

        dealDamage = true;
        winAchieved = false;
  
        progressBarObject.value = CalculateProgress();
    }

    
    void Update()
    {
            //There are multiple ways we are going to make the health bar
            //Decrease overtime.
            if (dealDamage)
            {
                DealDamage(10);
            }
            

            if (Input.GetKeyDown(KeyCode.A))
            {
                addProgress(5);
            }

            if (CurrentProgress >= 100)
            {
                Debug.Log("Win");
                winAchieved = true;
                dealDamage = false;
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
            //Die
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
