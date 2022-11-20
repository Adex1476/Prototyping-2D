using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    private float x;
    private float y;
    private float xm;
    private float cd;
    private float nextFireball;
    private int mode;
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _egg;

    // Start is called before the first frame update
    void Start()
    {
        mode = PlayerPrefs.GetInt("Mode");
        y = 5f;
        x = 10f;
        cd = 1.5f;
        nextFireball = 0f;
        _sr.enabled = false;
        if (mode == 1)
        {
            InvokeRepeating("RndSpawn", 0.3f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetMouseButtonDown(0) && mode == 2 && Time.time > nextFireball)
        {
            _sr.enabled = true;
            nextFireball = Time.time + cd;
            Invoke("MouseSpawn", 0);
            _anim.SetTrigger("Active");
        }
    }

    void RndSpawn()
    {
        var rnd = Random.Range(1, 21);
        if (rnd <= 2)
        {
            Instantiate(_egg, rdmFbSpawn(), Quaternion.identity);
        }
        else
        {
            Instantiate(_fireball, rdmFbSpawn(), Quaternion.identity);
        }
        transform.position = rdmFbSpawn();
    }

    void MouseSpawn()
    {
        var rnd = Random.Range(1, 21);
        xm = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

        if (rnd <= 2)
        {
            Instantiate(_egg, mouseFbSpawn(), Quaternion.identity);
        }
        else
        {
            Instantiate(_fireball, mouseFbSpawn(), Quaternion.identity);
        }
        transform.position = mouseFbSpawn();
        StartCoroutine(DisableSprite());
    }

    Vector2 rdmFbSpawn() { return new Vector2(Random.Range(-x, x), y); }

    Vector2 mouseFbSpawn() { return new Vector2(xm, y); }

    IEnumerator DisableSprite()
    {
        yield return new WaitForSeconds(0.6f);
        _sr.enabled = false;
    }
}
