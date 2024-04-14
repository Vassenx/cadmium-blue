using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookTimer : MonoBehaviour
{
    [SerializeField] private Slider timerSlider;
    [SerializeField] private Image goodThresholdLine;
    [SerializeField] private Image greatThresholdLine;
    
    private bool isRunning = false;
    
    public float curTime { get; private set; }
    private float cookedTime;
    private float overcookedTime;
    private float totalTime; // burnt time

    void Start()
    {
        timerSlider.value = 0;

        ToggleTimer(false);
    }

    public void StartTimer(float goodThreshold, float greatThreshold, float totalCookTime)
    {
        ToggleTimer(true);
        
        cookedTime = goodThreshold;
        overcookedTime = greatThreshold;
        totalTime = totalCookTime;
        
        timerSlider.maxValue = totalTime;

        timerSlider.value = goodThreshold;
        goodThresholdLine.rectTransform.position = timerSlider.fillRect.position;
        
        timerSlider.value = greatThreshold;
        greatThresholdLine.rectTransform.position = timerSlider.fillRect.position;

        isRunning = true;
        curTime = 0;
        timerSlider.value = 0;
    }
    
    public void EndTimer()
    {
        ToggleTimer(false);
        
        curTime = 0;
        timerSlider.value = 0;
    }

    void Update()
    {
        if (!isRunning)
        {
            return;
        }

        curTime += Time.deltaTime;
        if (curTime >= totalTime)
        {
            curTime = totalTime;
            isRunning = false;
        }
        
        timerSlider.value = curTime;
    }

    private void ToggleTimer(bool enable)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(enable);
        }
    }
}
