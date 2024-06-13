using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; 
    public Text penaltyText;

    private float timeRemaining = 30f; 
    private bool timerIsRunning = false; 
    private bool timeRunningOut = false; 

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
                int seconds = Mathf.CeilToInt(timeRemaining);
                timerText.text = seconds.ToString();
                if (seconds <= 10)
                {
                    timerText.color = Color.red;
                    timeRunningOut = true; 
                }
            }
            else 
            {
                timeRemaining = 0f;
                timerText.text = "0";
                timerIsRunning = false;
                Debug.Log("REINICIO");
                ResetLevel();
            }

            if (timeRunningOut && timeRemaining > 0f)
            {
                timerText.color = Color.red;
            }
        }
    }

    public void StartTimer(float duration)
    {
        timeRemaining = duration;
        timerIsRunning = true;
        timeRunningOut = false;
        timerText.color = Color.white;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void SubtractTime(float penalty)
    {
        timeRemaining -= penalty;
        if (timeRemaining < 0f)
        {
            timeRemaining = 0f;
        }
        ShowPenalty("-2");
    }

    public void ShowPenalty(string message)
    {
        if (penaltyText != null)
        {
            penaltyText.text = message;
            penaltyText.gameObject.SetActive(true);
            StartCoroutine(HidePenaltyText());
        }
    }
    private IEnumerator HidePenaltyText()
    {
        yield return new WaitForSeconds(1f);
        if (penaltyText != null)
        {
            penaltyText.gameObject.SetActive(false);
        }
    }

    private void ResetLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
