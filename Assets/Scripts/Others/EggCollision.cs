using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollision : MonoBehaviour
{
    private SpriteRenderer _objRenderer;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        _objRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void") || collision.CompareTag("Ground"))
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(Blink());
        }
        if (collision.CompareTag("Player"))
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            animator.SetBool("Break", true);
            Invoke("Destroy", 1f);
        }
    }

    IEnumerator Blink()
    {
        _objRenderer.enabled = true;
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < 3; i++)
        {
            _objRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            _objRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
            _objRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            _objRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}