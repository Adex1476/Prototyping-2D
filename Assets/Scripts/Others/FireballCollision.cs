using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private Rigidbody2D _rb;
    private GameObject _player; 
    private float strength = 16;
    // Start is called before the first frame update
    void Start() 
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void") || collision.CompareTag("Ground"))
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Destroy(this.GetComponent<CapsuleCollider2D>());
            Vector2 dir = (transform.position - _player.transform.position).normalized;
            _rb.AddForce(dir * strength, ForceMode2D.Impulse);
            animator.SetBool("Impact", true);
            Invoke("Explosion", 1f);
        }
    }

    private void Explosion()
    {
        _rb.velocity = Vector2.zero;
        Destroy(gameObject);
    }
}