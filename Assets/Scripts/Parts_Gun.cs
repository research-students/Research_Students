using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Gun : Parts_Base
{
    [SerializeField] Parts_Gun_Bullet bullet1;
    [SerializeField] float            interval;

    private bool can_shot;


    void Start()
    {
        can_shot = true;
    }


    //--------------
    // アクション1
    //--------------
    public override void Action1()
    {
        if (can_shot)
        {
            base.Action1();

            Instantiate(bullet1).Init(transform);

            StartCoroutine("CoolTime");

            Debug.Log("Action1");
        }
    }


    //--------------
    // アクション2
    //--------------
    public override void Action2()
    {
        if (can_shot)
        {
            base.Action2();

            Debug.Log("Action2");

            // 拡張予定
        }
    }


    //---------------
    // クールタイム
    //---------------
    private IEnumerator CoolTime()
    {
        can_shot = false;

        yield return new WaitForSeconds(interval);

        can_shot = true;
    }
}