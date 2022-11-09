using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoMovement : MonoBehaviour
{
    private PlayerData _playerData;
    public SpriteRenderer spriteRenderer;
    public MovementManager _mm;
    private Vector3 _posR, _posL, _posI;
    private direction _dir;

    // Start is called before the first frame update
    void Start()
    {
        _playerData = GetComponent<PlayerData>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _mm = GetComponent<MovementManager>();

        _dir = direction.left;
        _posI = transform.position;
        _posR = _posI + new Vector3(_playerData.Dist, 0);
        _posL = _posI - new Vector3(_playerData.Dist, 0);
    }

    // Update is called once per frame
    void Update()
    {
        _posR = _posI + new Vector3(_playerData.Dist, 0);
        _posL = _posI - new Vector3(_playerData.Dist, 0);

        if (_mm.m == MovementManager.Mov.Movement)
        {
            if (_dir == direction.right)
            {
                Walk(_posR);
            }
            else if (_dir == direction.left)
            {
                Walk(_posL);
            }
        }
    }

    void Walk(Vector3 pos)
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, _playerData.pas);
        if (transform.position == pos)
        {
            StartCoroutine(Flip());
            _dir = direction.stop;
            if (transform.position == _posR)
            {
                _dir = direction.left;
            }
            else
            {
                _dir = direction.right;
            }
        }
    }

    IEnumerator Flip()
    {
        _mm.m = MovementManager.Mov.Stop;
        yield return new WaitForSeconds(2);
        _mm.m = MovementManager.Mov.Movement;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
enum direction { stop, right, left }