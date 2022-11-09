using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static string playerName;
    private Button button;
    public InputField inpf;
    private bool created = false;

    void Awake()
    {
        if (created!) { DontDestroyOnLoad(this.gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GoToScene);
    }

    private void GoToScene()
    {
        if (inpf.text != "")
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
