using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    private string _pd;
    [SerializeField] private GameObject _resultWText;
    [SerializeField] private GameObject _resultLText;
    [SerializeField] private GameObject _fireballsText;
    [SerializeField]private Button _paButton;
    [SerializeField] private Button _menuButton;

    // Start is called before the first frame update
    void Start()
    {
        _pd = PlayerPrefs.GetString("PlayerName");
        _paButton.onClick.AddListener(GoToGame);
        _menuButton.onClick.AddListener(GoToMenu);
        Result();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Result()
    {
        if (PlayerPrefs.GetInt("Result") == 1)
        {
            _nameText.text = "Congrats, " + _pd;
            _resultWText.SetActive(true);
            _resultLText.SetActive(false);
            if (PlayerPrefs.GetInt("Mode") == 1)
            {
                _fireballsText.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Mode") == 2)
            {
                _fireballsText.SetActive(true);
            }
        }
        else if (PlayerPrefs.GetInt("Result") == 2)
        {
            _nameText.text = "What a bad luck... " + _pd;
            _resultWText.SetActive(false);
            _resultLText.SetActive(true);
            if (PlayerPrefs.GetInt("Mode") == 1)
            {
                _fireballsText.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Mode") == 2)
            {
                _fireballsText.SetActive(true);
            }
        }
    }

    private void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
