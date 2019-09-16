using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Crown : Parts_Base
{
    [SerializeField] Vector3 force;

    private Player_Ctrl    player_ctrl;
    private SphereCollider sphere_col;


    void Awake()
    {
        sphere_col = GetComponent<SphereCollider>();
    }


    void FixedUpdate()
    {
        if (sphere_col.enabled)
        {
            Action1(true, 0);
        }
    }


    //---------------------------
    // アタッチした時に設定する
    //---------------------------
    protected override void Attach_Settig()
    {
        sphere_col.enabled = true;

        // 無敵状態にする
        transform.root.GetComponent<Player_Ctrl>().Set_Invincible(true);
    }


    //--------------
    // アクション1
    //--------------
    public override void Action1(bool life_sub, int adj)
    {
        base.Action1(life_sub, adj);
    }


    //---------
    // 消滅時
    //---------
    void OnDestroy()
    {
        if (sphere_col.enabled)
        {
            // 無敵状態を解除する
            transform.root.GetComponent<Player_Ctrl>().Set_Invincible(false);
        }
    }


    //------------------
    // Enemyと触れたら
    //------------------
    private void OnTriggerStay(Collider col)
    {
        if (!sphere_col.enabled)
        {
            return;
        }
        if (!col.GetComponent<Rigidbody>())
        {
            return;
        }
        if (col.tag == "Enemy")
        {
            force.z *= transform.forward.z;

            // 吹っ飛ばす
            col.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}