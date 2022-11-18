using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    private float x;
    private float y;
    [SerializeField] private GameObject _fireball;
    [SerializeField] private GameObject _egg;

    // Start is called before the first frame update
    void Start()
    {
        y = 5f;
        x = 10f;
        InvokeRepeating("Spawn", 0.3f, 0.5f);
    }

    // Update is called once per frame
    void Update() {}

    void Spawn()
    {
        var rnd = Random.Range(1, 11);
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
    Vector2 rdmFbSpawn() { return new Vector2(Random.Range(-x, x), y); }
}
