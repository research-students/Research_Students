using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_LongTap : MonoBehaviour
{
    [SerializeField] PlayerAction_Attack action;    
    [SerializeField] float               limit_time;
    [SerializeField] float               limit_mag;

    private Vector3 pos;
    private bool    down;
    private bool    down_long;


    private IEnumerator Limit()
    {
        yield return new WaitForSeconds(limit_time);

        if (down)
        {
            down_long = true;
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
        StopCoroutine("Limit");

        if (down_long)
        {
            // ロングタップは指を動かさない
            float mag = (Input.mousePosition - pos).magnitude;

            if (mag < limit_mag)
            {
                action.LongTap();
            }

            down_long = false;
        }

        down = false;
    }
}