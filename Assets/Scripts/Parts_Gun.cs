using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Gun : Parts_Base
{
    [SerializeField] Parts_Gun_Bullet bullet1;
    [SerializeField] Parts_Gun_Bullet bullet2;
    [SerializeField] float            interval;

    private bool can_shot;


    void Start()
    {
        can_shot = true;
    }


    //--------------
    // アクション1
    //--------------
    public override void Action1(bool life_sub, int adj)
    {
        if (can_shot)
        {
            base.Action1(life_sub, adj);

            Instantiate(bullet1).Init(transform);

            StartCoroutine("CoolTime");
        }
    }


    //--------------
    // アクション2
    //--------------
    public override void Action2(bool life_sub, int adj)
    {
        if (can_shot)
        {
            base.Action2(life_sub, adj);

            Instantiate(bullet2).Init(transform);

            StartCoroutine("CoolTime");
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