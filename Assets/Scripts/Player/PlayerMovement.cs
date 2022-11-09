using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private MovementManager _mm;
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
        Walk();
    }

    void Walk()
    {
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = true;
            _mm.m = MovementManager.Mov.Movement;
            transform.position = new Vector3(transform.position.x + _playerData.pas, transform.position.y, transform.position.z);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = false;
            _mm.m = MovementManager.Mov.Movement;
            transform.position = new Vector3(transform.position.x + _playerData.pas * -1, transform.position.y, transform.position.z);
        }
        else
        {
            _mm.m = _mm.m = MovementManager.Mov.Stop;
        }
    }
}
