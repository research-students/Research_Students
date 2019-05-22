using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_Flick : MonoBehaviour
{
    // PlayerAction_Flickは仮名、PlayerAction_Runみたいにする


    public void Up()
    {
        Debug.Log("上フリック");
    }


    public void Down()
    {
        Debug.Log("下フリック");
    }


    public void Left()
    {
        Debug.Log("左フリック");
    }


    public void Right()
    {
        Debug.Log("右フリック");
    }


    //---------------------
    // フリックアクション
    //---------------------
    public void Flick(Vector2 _dir)
    {
        if (Mathf.Pow(_dir.y, 2) > Mathf.Pow(_dir.x, 2))
        {
            if (_dir.y > 0.0f)
            {
                Up();
            }
            else
            {
                Down();
            }
        }
        else
        {
            if (_dir.x < 0.0f)
            {
                Left();
            }
            else
            {
                Right();
            }
        }
    }
}