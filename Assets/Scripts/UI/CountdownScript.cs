using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownScript : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning;
    public bool finishGame;
    [SerializeField] private Text _timeText;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        timeRemaining = 30;
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

        if (finishGame && PlayerPrefs.GetInt("Mode") == 1)
        {
            PlayerPrefs.SetInt("Result", 1);
            SceneManager.LoadScene("GameOverScene");
        }
        else if (finishGame && PlayerPrefs.GetInt("Mode") == 2)
        {
            PlayerPrefs.SetInt("Result", 2);
            SceneManager.LoadScene("GameOverScene");
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
