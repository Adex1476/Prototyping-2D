using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PUstatus currentStatus;
    public float cdTime = 6f;
    public float PUtime = 6f;
    public PlayerData dataPlayer;
    private Vector3 maxSize;
    private Vector3 Size;
    bool increase = false, decrease = false;
    private float Scale;
    private Vector3 Vector = new Vector3(1, 1, 1);
    private bool cantGrow;
    private DeathScript _ds;

    // Start is called before the first frame update
    void Start()
    {
        dataPlayer = GetComponentInParent<PlayerData>();
        _ds = GetComponent<DeathScript>();
        Size = transform.localScale;
        Scale = dataPlayer.Height / 10;
        maxSize = Size + Vector * Scale;
        currentStatus = PUstatus.baseF;
        cantGrow = false;
    }

    // Update is called once per frame
    void Update()
    {
        PUfases();
    }

    void PUfases()
    {
        switch (currentStatus)
        {
            case PUstatus.baseF:
                baseF();
                break;
            case PUstatus.grow:
                grow();
                break;
            case PUstatus.giant:
                giant();
                break;
            case PUstatus.ungrow:
                ungrow();
                break;
            case PUstatus.cd:
                cd();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg") && !_ds.isDead)
        {
            if (cantGrow == false)
            {
                currentStatus = PUstatus.grow;
            }
        }
    }

    void cd()
    {
        if (cdTime > 0) { cdTime -= Time.deltaTime; }
        else
        {
            cdTime = 0f;
            cantGrow = false;
            currentStatus = PUstatus.baseF;
        }
    }

    void baseF() {}

    void grow()
    {
        increase = true;
        cantGrow = true;
        if (increase)
        {
            transform.localScale += Vector;
            if (transform.localScale.x >= maxSize.x)
            {
                increase = false;
                currentStatus = PUstatus.giant;
            }
        }
    }

    void giant()
    {
        if (PUtime > 0) { PUtime -= Time.deltaTime; }
        else
        {
            PUtime = 3f;
            currentStatus = PUstatus.ungrow;
        }
    }

    void ungrow()
    {
        decrease = true;
        if (decrease)
        {
            transform.localScale -= Vector;
            if (transform.localScale.x <= Size.x)
            {
                decrease = false;
                currentStatus = PUstatus.cd;
            }
        }
    }
}

public enum PUstatus { baseF, grow, giant, ungrow, cd }

