using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMovement : MonoBehaviour
{
    private PlayerData _playerData;
    public SpriteRenderer spriteRenderer;
    public MovementManager _mm;
    private direction _dir;
    private Vector2 _vectorDir = new Vector2(-2f, -1f);

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GetComponent<PlayerData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _mm = GetComponent<MovementManager>();
        _dir = direction.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (_mm.m == MovementManager.Mov.Movement)
        {
            if (_dir == direction.right)
            {
                _vectorDir = new Vector2(2, 0) + Vector2.down;
                WalkR();
            }
            else if (_dir == direction.left)
            {
                _vectorDir = new Vector2(-2, 0) + Vector2.down;
                WalkL();
            }
        }
        RaycastHit2D hitFront = Physics2D.Raycast(transform.position, _vectorDir, 3.5f, LayerMask.GetMask("Ground"));
        if (hitFront.collider == null)
        {
            _mm.m = MovementManager.Mov.Stop;
            if (_dir == direction.right)
            {
                _dir = direction.left;
                _mm.m = MovementManager.Mov.Movement;
                //WalkL();
            }
            else if (_dir == direction.left)
            {
                _dir = direction.right;
                _mm.m = MovementManager.Mov.Movement;
                //WalkR();
            }
        }  
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, _vectorDir);
    }

    void WalkR()
    {
        _dir = direction.right;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1F, 0));
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }

    void WalkL()
    {
        _dir = direction.left;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1F, 0));
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
}
enum direction { stop, right, left }