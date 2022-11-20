using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void") || collision.CompareTag("Fireball"))
        {
            if (PlayerPrefs.GetInt("Mode") == 1)
            {
                PlayerPrefs.SetInt("Result", 2);
            } 
            else if(PlayerPrefs.GetInt("Mode") == 2)
            {
                PlayerPrefs.SetInt("Result", 1);
            } 
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
