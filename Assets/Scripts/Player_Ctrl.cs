using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl : Character_Base
{
    [SerializeField] GameFlow_CoverScene cover_gameover;
    [SerializeField] GameFlow_CoverScene cover_gameclear;
    [SerializeField] GameFlow_CoverScene cover_bug_avoidance;
    [SerializeField] Data_Manager        data_manager;
    [SerializeField] Transform[]         bodys;
    [SerializeField] RectTransform[]     bodys_UI;
    [SerializeField] RectTransform[]     slots_UI;
    [SerializeField] float               jump_power;
    [SerializeField] float               jump_max_height;

    private bool stop;


    //-------
    // 走る
    //-------
    public override void Run(float amount)
    {
        if (stop) return;

        base.Run(amount);
    }


    //-----------
    // 通常攻撃
    //-----------
    public override void Attack()
    {
        if (stop) return;

        base.Attack();
    }


    //-----------
    // ジャンプ
    //-----------
    public void Jump(float amount)
    {
        if (stop) return;

        if (landing)
        {
            amount *= jump_power;

            if (amount > jump_max_height)
            {
                amount = jump_max_height;
            }

            Vector3 force = Vector3.up * amount;

            rigid.AddForce(force * (1242.0f / Screen.width), ForceMode.Impulse);
        }
    }


    //----------------------
    // アクション : タップ
    //----------------------
    public void Action_Tap()
    {
        if (stop) return;

        if (bodys[1].childCount == 0)
        {
            Attack();

            if (bodys[3].childCount != 0)
            {
                bodys[3].GetChild(0).GetComponent<Parts_Base>().Action2(true, 0);
            }
        }
        else
        {
            bodys[1].GetChild(0).GetComponent<Parts_Base>().Action1(true, 0);
        }
    }


    //----------------------------
    // アクション : ロングタップ
    //----------------------------
    public void Action_LongTap()
    {
        if (stop) return;

        if (bodys[1].childCount == 0)
        {
            Attack_Strong();

            if (bodys[3].childCount != 0)
            {
                bodys[3].GetChild(0).GetComponent<Parts_Base>().Action2(true, 0);
            }
        }
        else
        {
            bodys[1].GetChild(0).GetComponent<Parts_Base>().Action2(true, 0);
        }
    }


    //----------------------------
    // アクション : ロングステイ
    //----------------------------
    public void Action_LongStay(bool flag)
    {
        if (stop) return;

        if (bodys[1].childCount != 0)
        {
            Parts_Shield parts_shield = bodys[1].GetChild(0).GetComponent<Parts_Shield>();

            if (parts_shield)
            {
                if (parts_shield.Get_Parts_Type() == "Shield")
                {
                    parts_shield.Rush_Enabled(flag);
                }
            }
        }
    }


    //------------------------
    // アクション : フリック
    //------------------------
    public void Action_Flick(Vector3 dir)
    {
        if (stop) return;

        Change_Direction(dir.x);

        if (Mathf.Pow(dir.y, 2) > Mathf.Pow(dir.x, 2))
        {
            if (dir.y > 0.0f)
            {
                if (bodys[2].childCount == 0)
                {
                    Jump(dir.magnitude);
                }
                else
                {
                    bodys[2].GetChild(0).GetComponent<Parts_Base>().Action1(true, (int)dir.magnitude);
                }
            }
        }
        else
        {
            if (bodys[2].childCount == 1)
            {
                bodys[2].GetChild(0).GetComponent<Parts_Base>().Action2(true, (int)dir.magnitude);
            }
        }
    }


    //------------------
    // Death状態か返す
    //------------------
    public bool Get_Death()
    {
        return stop;
    }


    //--------------------
    // Clearした時の処理
    //--------------------
    public void Clear()
    {
        stop = true;

        // ゲームクリアシーンを重ねる
        cover_gameclear.Cover();
        
        // 所持中のパーツを保存
        data_manager.Save_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.NAME, bodys_UI);
        data_manager.Save_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.LIFE, bodys_UI);
        data_manager.Save_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.NAME, slots_UI);
        data_manager.Save_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.LIFE, slots_UI);
    }


    //--------------------
    // Deathした時の処理
    //--------------------
    protected override void Death()
    {
        stop = true;

        for (int i = 0; i < bodys.Length; i++)
        {
            if (bodys[i].childCount == 1)
            {
                bodys[i].GetChild(0).GetComponent<Parts_Base>().Drop();
            }
        }

        // ゲームオーバーシーンを重ねる
        cover_gameover.Cover();

        GameObject.Find("Player_Model").transform.Translate(Vector3.down * 0.5f);
        GameObject.Find("Player_Model").transform.Rotate(Vector3.left * 90f);
    }
}