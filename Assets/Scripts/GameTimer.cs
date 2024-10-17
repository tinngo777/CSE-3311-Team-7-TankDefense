using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float timeElapsed = 0f;
    private bool isRunning = true;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        // Format the time into minutes and seconds
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed % 60F);

        // Display the formatted time in the TextMeshProUGUI element
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Optionally stop the timer (e.g., when game is over)
    public void StopTimer()
    {
        isRunning = false;
    }
}
