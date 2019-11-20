using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ctrl : Character_Base
{
    [SerializeField] Enemy_Parts_Manager parts_manager;
    [SerializeField] Parts_Base[]        parts;
    [SerializeField] Parts_Base          drop_parts;
    [SerializeField] float               jump_power;


    void Start()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i])
            {
                parts[i].Attach(parts[i].transform.parent);
            }
        }
    }


    void FixedUpdate()
    {
        // 走る
        // Run(Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.forward * 0.001f);

        // アクション1 : Hand
        if (Input.GetKeyDown("z"))
        {
            if (parts_manager.Get_Equipping(1))
            {
                parts_manager.Action(1, 1);
            }
        }
        // アクション1 : Hand2
        if (Input.GetKeyDown("a"))
        {
            if (parts_manager.Get_Equipping(1))
            {
                parts_manager.Action(1, 2);
            }
        }

        // アクション2 : Shld
        if (Input.GetKeyDown("x"))
        {
            if (parts_manager.Get_Equipping(2))
            {
                parts_manager.Action(2, 1);
            }
            else
            {
                Jump();
            }
        }
        // アクション2: Shld
        if (Input.GetKeyDown("c"))
        {
            if (parts_manager.Get_Equipping(2))
            {
                Change_Direction(-1f);

                parts_manager.Action(2, 2);
            }
            else
            {
                Jump();
            }
        }
        // アクション2: Shld
        if (Input.GetKeyDown("v"))
        {
            if (parts_manager.Get_Equipping(2))
            {
                Change_Direction(1f);

                parts_manager.Action(2, 2);
            }
            else
            {
                Jump();
            }
        }
        // アクション3: Foot
        if (Input.GetKeyDown("b"))
        {
            Attack();
        }
    }


    //-------
    // 走る
    //-------
    public override void Run(float amount)
    {
        base.Run(amount);
    }


    //-----------
    // ジャンプ
    //-----------
    private void Jump()
    {
        if (Get_Landing())
        {
            Vector3 force = Vector3.up * jump_power;

            rigid.AddForce(force * (1242.0f / Screen.width), ForceMode.Impulse);
        }
    }


    //--------------------
    // Deathした時の処理
    //--------------------
    protected override void Death()
    {
        // パーツをドロップ
        drop_parts.Drop();

        // Kill数を加算
        GameObject.Find("Kill_Count").GetComponent<Kill_Count>().Kill_Counter();

        // 消滅
        Destroy(gameObject);
    }
}