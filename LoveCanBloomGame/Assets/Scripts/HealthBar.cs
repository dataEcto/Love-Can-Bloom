using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider healthBarObject;
    
    void Start()
    {
        //This can also be set on inspector
        MaxHealth = 50f;
        //Reset health to full on game load
        CurrentHealth = MaxHealth;

        healthBarObject.value = CalculateHealth();
    }

   
    void Update()
    {
        //We will change this to deal damage based on wrong 
        //choices being made.
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(10);
        }
    }

    void DealDamage(float damageValue)
    {
        //Deduct the damage dealt from the current health
        CurrentHealth -= damageValue;
        healthBarObject.value = CalculateHealth();
        //if the character is out of health, u die!
        if (CurrentHealth <= 0)
        {
           //Die
        }
    }

    float CalculateHealth()
    {
        //Accurately calculate health so
        //that it can be represented visually better.
        return CurrentHealth / MaxHealth;
    }
    
    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("You died!");
    }
}
