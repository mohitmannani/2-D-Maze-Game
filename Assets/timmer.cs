using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timmer : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text element

    private bool isTimerRunning = true;
    private float timer = 0f;

    private void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime; // Increase the timer based on the time passed since the last frame
            UpdateTimerUI(); // Update the UI text element
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine"))
        {
            isTimerRunning = false; // Stop the timer when the ball passes the finish line
            Debug.Log("Time taken: " + timer.ToString("F2") + " seconds"); // Display the time taken
        }
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = timer.ToString("F2") + " s"; // Update the UI text with the current timer value
        }
    }
}
