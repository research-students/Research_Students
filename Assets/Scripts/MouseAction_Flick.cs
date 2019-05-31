using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAction_Flick : MonoBehaviour
{
    [SerializeField] PlayerAction_Flick action;
    [SerializeField] float              limit_mag;

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
            action.Flick(dir);
        }
    }
}