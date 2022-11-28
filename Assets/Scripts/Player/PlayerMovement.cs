using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private MovementManager _mm;
    private bool canJump;
    private PlayerData _playerData;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _mm = GetComponent<MovementManager>();
        _playerData = GetComponent<PlayerData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") { canJump = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground") { canJump = false; }
    }

    void Movement()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = true;
            _mm.m = MovementManager.Mov.Movement;
            transform.position = new Vector3(transform.position.x + _playerData.pas, transform.position.y, transform.position.z);
        }
        else if (Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = false;
            _mm.m = MovementManager.Mov.Movement;
            transform.position = new Vector3(transform.position.x + _playerData.pas * -1, transform.position.y, transform.position.z);
        }
        else
        {
            _mm.m = _mm.m = MovementManager.Mov.Stop;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 800F));
        }
    }
}
