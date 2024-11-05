using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeElapsed = 0f; // Start time at 0

    private bool timerRunning = true;

    void Start()
    {
        timeElapsed = 0f; // Initialize the timer at zero
    }

    void Update()
    {
        if (timerRunning)
        {
            timeElapsed += Time.deltaTime; // Increase time as the game progresses
            UpdateTimerDisplay(timeElapsed);
        }
    }

    void UpdateTimerDisplay(float time)
    {
        // Format time as minutes:seconds
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
