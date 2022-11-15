using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static string playerName;
    private Button _button;
    [SerializeField] private InputField _inpf;
    private bool _created = false;

    void Awake()
    {
        if (_created!) { DontDestroyOnLoad(this.gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(GoToScene);
    }

    private void GoToScene()
    {
        if (_inpf.text != "")
        {
            SceneManager.LoadScene("SampleScene");
        }     
    }

    public void ReadStringInput(string s)
    {
        playerName = s;
        PlayerPrefs.SetString("PlayerName", playerName);
    } 
}
