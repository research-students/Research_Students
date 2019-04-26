using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_Flick : MonoBehaviour
{
    public enum DIRECTION
    {
        UP,
        LEFT,
        RIGHT,
        DOWN
    }


    public void Flick(DIRECTION _direction)// 方向を取得
    {
        switch (_direction)
        {
            case DIRECTION.UP:
                Debug.Log("上フリック");
                break;
            case DIRECTION.LEFT:
                Debug.Log("左フリック");
                break;
            case DIRECTION.RIGHT:
                Debug.Log("右フリック");
                break;
        }
    }
}