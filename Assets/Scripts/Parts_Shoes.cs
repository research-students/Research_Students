using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Shoes : Parts_Base
{
    [SerializeField] float up_run_speed;
    [SerializeField] float up_attack_power;

    private bool attaching;
    private bool parent_player;


    void FixedUpdate()
    {
        if (attaching)
        {
            Action1(parent_player, 0);
        }
    }


    //---------------------------
    // アタッチした時に設定する
    //---------------------------
    protected override void Attach_Settig()
    {
        if (transform.root.tag == "Player")
        {
            attaching     = true;
            parent_player = true;
        }

        // 移動速度、通常攻撃力強化
        transform.root.GetComponent<Character_Base>().Speed_Change(up_run_speed);
        transform.root.GetComponent<Character_Base>().Attack_Change(up_attack_power);
    }


    //--------------
    // アクション1
    //--------------
    public override void Action1(bool life_sub, int adj)
    {
        base.Action1(life_sub, adj);
    }


    //--------------
    // アクション2
    //--------------
    public override void Action2(bool life_sub, int adj)
    {
        base.Action2(life_sub, adj);
    }


    //---------
    // 消滅時
    //---------
    void OnDestroy()
    {
        if (attaching)
        {
            // 移動速度、通常攻撃力を元に戻す
            if (transform.root.GetComponent<Character_Base>())
            {
                transform.root.GetComponent<Character_Base>().Speed_Change(1f);
                transform.root.GetComponent<Character_Base>().Attack_Change(1f);
            }
        }
    }
}