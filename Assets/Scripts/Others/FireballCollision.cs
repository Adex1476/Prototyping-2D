using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField]private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void") || collision.CompareTag("Ground"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Destroy(this.GetComponent<CapsuleCollider2D>());
            animator.SetBool("Impact", true);
            Invoke("Explosion", 1f);
        }
    }

    private void Explosion()
    {
        Destroy(gameObject);
    }
}
