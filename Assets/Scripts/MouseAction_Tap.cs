using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Tap : MonoBehaviour
{
    [SerializeField] PlayerAction_Tap player;
    [SerializeField] int              maxLimit;

    private bool tap;
    private int  limit;


    void Update()
    {
        if (tap)
        {
            limit++;
        }
    }


    public void Down()
    {
        tap = true;
    }


    public void Up()
    {
        if (tap)
        {
            if (limit < maxLimit)
            {
                player.Tap();
            }

            tap   = false;
            limit = 0;
        }
    }
}