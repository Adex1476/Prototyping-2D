using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMovement : MonoBehaviour
{
    public Sprite[] animationSprites;
    private SpriteRenderer _spriteRenderer;
    public PlayerAutoMovement pam;
    public MovementManager mm;

    private int _spriteNum;
    private float _count;
    private float _frameR;


    // Start is called before the first frame update
    void Start()
    {
        mm = GetComponent<MovementManager>();
        pam = GetComponent<PlayerAutoMovement>(); 
        animationSprites = gameObject.GetComponent<PlayerData>().animationSprites;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteNum = 0;
        _frameR = 1/12f;
    }

    void Update() {
        if (mm.m == MovementManager.Mov.Movement)
        {
            Walking();
        } 
        else
        {
            Idle();
        } 
    }

    void Walking()
    {
        _count += Time.deltaTime;
        if (_count >= _frameR)
        {
            _count -= _frameR;
            _spriteNum = (_spriteNum + 1) % animationSprites.Length;
            _spriteRenderer.sprite = animationSprites[_spriteNum];
        }
    }

    void Idle ()
    {
        _spriteRenderer.sprite = animationSprites[0];
    }
}