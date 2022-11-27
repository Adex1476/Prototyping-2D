using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public PlayerAutoMovement pam;
    public PlayerMovement pm;
    public Mov m;
    public int mode;

    // Start is called before the first frame update
    void Start() 
    {
        mode = PlayerPrefs.GetInt("Mode");
    }

    // Update is called once per frame
    void Update()
    {
        if ( pm == null && pam == null)
        {
            if (mode == 1)
            {
                gameObject.AddComponent<AnimationMovement>();
                pm = gameObject.AddComponent<PlayerMovement>();
            } 
            else if (mode == 2)
            {
                gameObject.AddComponent<AnimationMovement>();
                pam = gameObject.AddComponent<PlayerAutoMovement>();
            }
        } 
    }
    public enum Mov { Movement, Stop }

    public void DisableMovement()
    {
        if (mode == 1)
        {
            GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            GetComponent<PlayerAutoMovement>().enabled = false;
        }
    }

}
