using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Flick : MonoBehaviour
{
    [SerializeField] PlayerAction_Flick player;
    [SerializeField] float              limit_drag;
    [SerializeField] float              limit_flick;

    private float   amount;
    private Vector3 dif;
    private Vector3 pos;


    public void Drag()
    {
        dif = Input.mousePosition - pos;

        if (dif.magnitude > limit_drag)
        {
            amount += dif.magnitude;
        }
        else
        {
            amount = 0.0f;
        }

        pos = Input.mousePosition;
    }


    public void EndDrag()
    {
        if (amount > limit_flick)
        {
            if (Mathf.Pow(dif.y, 2) > Mathf.Pow(dif.x, 2))
            {
                if (dif.y > 0.0f)
                {
                    player.Flick_Up();
                }
            }
            else
            {
                if (dif.x < 0.0f)
                {
                    player.Flick_Left();
                }
                else
                {
                    player.Flick_Right();
                }
            }
        }

        amount = 0.0f;
    }
}