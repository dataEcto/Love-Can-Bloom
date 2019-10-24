using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime = 0f;
    public float startingTime;

    public bool countdownOver;

    [SerializeField] TextMeshProUGUI countDownText;
    void Start()
    {
        currentTime = startingTime;
        countdownOver = false;
    }

    
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownOver = true;
        }
    }
}
