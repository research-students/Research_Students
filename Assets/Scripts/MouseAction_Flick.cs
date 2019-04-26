using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Flick : MonoBehaviour
{
    [SerializeField] PlayerAction_Flick player;
    [SerializeField] float              drag;
    [SerializeField] float              flick;

    private float   amount;
    private Vector3 dragging;


    public void Drag()
    {
        float mag = (dragging - Input.mousePosition).magnitude;

        if (mag > drag)
        {
            amount += mag;
        }
        else
        {
            amount = 0.0f;
        }

        dragging = Input.mousePosition;
    }


    public void EndDrag()
    {
        if (amount > flick)
        {
            amount = 0.0f;

            Vector2 dir = Input.mousePosition - dragging;

            if (Mathf.Pow(dir.y, 2) > Mathf.Pow(dir.x, 2))
            {
                if (dir.y > 0.0f)
                {
                    player.Flick(PlayerAction_Flick.DIRECTION.UP);
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (dir.x < 0.0f)
                {
                    player.Flick(PlayerAction_Flick.DIRECTION.LEFT);
                }
                else
                {
                    player.Flick(PlayerAction_Flick.DIRECTION.RIGHT);
                }
            }
        }
    }
}