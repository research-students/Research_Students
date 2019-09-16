using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_LongStay : MonoBehaviour
{
    [SerializeField] Player_Ctrl player_ctrl;
    [SerializeField] float       limit_time;
    [SerializeField] float       limit_mag;

    private Vector3 pos;
    private bool    down;
    private bool    down_long;


    private IEnumerator Limit()
    {
        yield return new WaitForSeconds(limit_time);

        if (down)
        {
            float mag = (Input.mousePosition - pos).magnitude;

            if (mag < limit_mag)
            {
                down_long = true;

                player_ctrl.Action_LongStay(true);
            }
        }
    }


    public void Down()
    {
        down = true;
        pos  = Input.mousePosition;

        StartCoroutine("Limit");
    }


    public void Up()
    {
        down      = false;
        down_long = false;

        player_ctrl.Action_LongStay(false);
    }


    public bool Active()
    {
        return down_long;
    }
}