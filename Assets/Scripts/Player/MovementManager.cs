using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public PlayerAutoMovement pam;
    public PlayerMovement pm;
    public Mov m;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if ( pm == null && pam == null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.AddComponent<AnimationMovement>();
                pam = gameObject.AddComponent<PlayerAutoMovement>();
            } 
            else if (Input.GetKey(KeyCode.M))
            {
                gameObject.AddComponent<AnimationMovement>();
                pm = gameObject.AddComponent<PlayerMovement>();
            }
        } 
    }

    public enum Mov { Movement, Stop }
}
