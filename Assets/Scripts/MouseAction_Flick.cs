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
            player_ctrl.Action_Flick(dir);
        }
    }
}