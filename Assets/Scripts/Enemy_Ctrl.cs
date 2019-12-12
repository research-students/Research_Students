using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ctrl : Character_Base
{
    [SerializeField] Enemy_Parts_Manager parts_manager;
    [SerializeField] Parts_Base[] parts;
    [SerializeField] Parts_Base drop_parts;
    [SerializeField] float jump_power;

    private Transform player;


    void Start()
    {
        player = GameObject.Find("Player").transform;

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i])
            {
                parts[i].Attach(parts[i].transform.parent);
            }
        }
    }


    void Update()
    {
        float x = player.position.z - transform.position.z;
        float y = player.position.y - transform.position.y;
        float r = Mathf.Atan2(y, x);

        Run(Mathf.Cos(r));
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


    //---------------
    // Playerを返す
    //---------------
    public Transform Get_Player()
    {
        return player;
    }
}