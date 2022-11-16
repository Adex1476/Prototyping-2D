using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    private float x;
    private float y;
    [SerializeField] private GameObject _fireball;

    // Start is called before the first frame update
    void Start()
    {
        y = 5f;
        x = 10f;
        InvokeRepeating("Spawn", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        Instantiate(_fireball, rdmFbSpawn(), Quaternion.identity);
    }
    Vector3 rdmFbSpawn() { return new Vector3(Random.Range(-x, x), y, transform.position.z); }
}
