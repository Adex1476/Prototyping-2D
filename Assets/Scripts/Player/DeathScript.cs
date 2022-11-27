using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    [SerializeField] private MovementManager _mm;
    [SerializeField] private Animation anim;
    private int _mode;
    public bool isDead;

    // Start is called before the first frame update
    void Start() 
    {
        isDead = false;
        _mode = PlayerPrefs.GetInt("Mode");
    }

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
            isDead = true;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        anim.Play();
        _mm.DisableMovement();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        SceneManager.LoadScene("GameOverScene");
    }
}
