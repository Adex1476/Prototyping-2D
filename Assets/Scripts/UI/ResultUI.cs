using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _fcountText;
    private float _fbs;
    private string _pd;
    private int _mode;
    [SerializeField] private GameObject _resultWText;
    [SerializeField] private GameObject _resultLText;
    [SerializeField] private GameObject _fireballsText;
    [SerializeField] private Button _paButton;
    [SerializeField] private Button _menuButton;

    // Start is called before the first frame update
    void Start()
    {
        _fbs = 0;
        _pd = PlayerPrefs.GetString("PlayerName");
        _mode = PlayerPrefs.GetInt("Mode");
        _paButton.onClick.AddListener(GoToGame);
        _menuButton.onClick.AddListener(GoToMenu);
        Result();
    }

    // Update is called once per frame
    void Update() {}

    private void Result()
    {
        _fbs = PlayerPrefs.GetFloat("FireballCont");
        if (PlayerPrefs.GetInt("Result") == 1)
        {
            _nameText.text = "Congrats, " + _pd;
            _resultWText.SetActive(true);
            _resultLText.SetActive(false);
            if (_mode == 1)
            {
                _fireballsText.SetActive(false);
            }
            else if (_mode == 2)
            {
                _fireballsText.SetActive(true);
                _fcountText.text = "Casted fireballs: " + _fbs;
            }
        }
        else if (PlayerPrefs.GetInt("Result") == 2)
        {
            _nameText.text = "What a bad luck... " + _pd;
            _resultWText.SetActive(false);
            _resultLText.SetActive(true);
            if (_mode == 1)
            {
                _fireballsText.SetActive(false);
            }
            else if (_mode == 2)
            {
                _fireballsText.SetActive(true);
                _fcountText.text = "Casted fireballs: " + _fbs;
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
