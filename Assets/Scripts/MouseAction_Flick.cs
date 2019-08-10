using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Flick : MonoBehaviour
{
    [SerializeField] Player_Ctrl player_ctrl;
    [SerializeField] float       limit_mag;

    private Vector3 pos;

    
    public void Touch()
    {
        pos = Input.mousePosition;
    }


    public void Up()
    {
        Vector2 dir = Input.mousePosition - pos;

        if (dir.magnitude > limit_mag)
        {
            if (Mathf.Pow(dir.y, 2) > Mathf.Pow(dir.x, 2))
            {
                if (dir.y > 0.0f)
                {
                    player_ctrl.Jump(dir.magnitude);
                }
                else
                {
                    // Down();
                }
            }
            else
            {
                player_ctrl.Action_Flick(dir.x);
            }
        }
    }
}