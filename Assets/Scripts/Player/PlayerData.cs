using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string PlayerName;
    public PlayerKind PlayerKind;
    public float Height, Weight = 5f, Speed = 1f, Dist = 9f;
    public Sprite[] animationSprites;
    public float pas { get; set; }

    // Start is called before the first frame update
    void Awake() 
    {
        PlayerName = PlayerPrefs.GetString("PlayerName");
    }

    void Start() { }

    // Update is called once per frame
    void Update() 
    { 
        pas = Time.deltaTime * (Speed / (Weight / 20));
    }
}
public enum PlayerKind { Fighter, Builder, Racist, Mistborn }


