using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_Attack : MonoBehaviour
{
    //-------------------
    // タップアクション
    //-------------------
    public void Tap()
    {
        Debug.Log("タップ成功");
    }


    //-------------------------
    // ロングタップアクション
    //-------------------------
    public void LongTap()
    {
        Debug.Log("ロングタップ成功");
    }
}