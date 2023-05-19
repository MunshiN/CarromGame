using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float totalTime = 120f; // Total time in seconds
    public TMP_Text timerText;
    private float currentTime;
    public GameObject go;
    private void Start()
    {
       
        currentTime = totalTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            go.SetActive(true);
            currentTime = 0f;
            
        }

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = "Time: "+timeText;
    }
}

