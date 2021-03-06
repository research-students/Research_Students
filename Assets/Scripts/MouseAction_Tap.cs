﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Tap : MonoBehaviour
{
    [SerializeField] Player_Ctrl player_ctrl;
    [SerializeField] float       limit_time;
    [SerializeField] float       limit_mag;

    private Vector3 pos;
    private bool    down;


    private IEnumerator Limit()
    {
        yield return new WaitForSeconds(limit_time);

        down = false;
    }


    public void Down()
    {
        down = true;
        pos  = Input.mousePosition;

        StartCoroutine("Limit");
    }


    public void Up()
    {
        if (down)
        {
            // タップは指を動かさない
            float mag = (Input.mousePosition - pos).magnitude;

            if (mag < limit_mag)
            {
                player_ctrl.Action_Tap();
            }
        }
    }
}