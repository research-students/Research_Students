using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Tail : Parts_Base
{
    //--------------
    // アクション1
    //--------------
    public override void Action1(bool life_sub, int adj)
    {
        base.Action1(life_sub, adj);

        Debug.Log("しっぽ: アクション1");
    }


    //--------------
    // アクション2
    //--------------
    public override void Action2(bool life_sub, int adj)
    {
        base.Action2(life_sub, adj);

        Debug.Log("しっぽ: アクション2");
    }
}