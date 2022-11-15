using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownScript : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning;
    public bool finishGame;
    [SerializeField] private TextMeshPro _timeText;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        timeRemaining = 10;
        finishGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                finishGame = true;
            }
        }

        if (finishGame)
        {
            SceneManager.LoadScene("StartScene");
        }

        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
