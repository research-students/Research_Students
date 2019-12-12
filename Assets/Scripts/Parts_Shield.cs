using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Shield : Parts_Base
{
    [SerializeField] Vector3 force;
    [SerializeField] float   speed;
    [SerializeField] int     damage;

    private Character_Base character;
    private bool           rush;


    void FixedUpdate()
    {
        if (rush)
        {
            if (transform.root.tag == "Player")
            {
                Action2(true, 0);

                character.Run(transform.forward.z * speed);
            }
            else
            {
                Action2(false, 0);
            }
        }
    }


    //---------------------------
    // アタッチした時に設定する
    //---------------------------
    protected override void Attach_Settig()
    {
        character = transform.root.GetComponent<Character_Base>();
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


    //-----------------
    // 突進の有無効化
    //-----------------
    public void Rush_Enabled(bool flag)
    {
        rush = flag;
    }


    //-----------------
    // 突進状態か返す
    //-----------------
    public bool Get_Rush_Enable()
    {
        return rush;
    }


    //-----------------------
    // 攻撃パーツと触れたら
    //-----------------------
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player_Attack")
        {
            transform.root.GetComponent<Character_Base>().HP_Sub(col.transform.GetComponent<Attack_Base>().Get_Damage() / 2f);
        }
    }


    //-------------------
    // キャラと触れたら
    //-------------------
    private void OnTriggerStay(Collider col)
    {
        if (rush == false)
        {
            return;
        }
        if (col.tag == tag)
        {
            return;
        }

        if (col.tag == "Enemy" || col.tag == "Player")
        {
            Vector3 force = this.force;

            force.z *= transform.forward.z;
            
            // 吹っ飛ばす
            col.transform.root.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

            // ダメージを与える
            col.transform.root.GetComponent<Character_Base>().HP_Sub(damage);
        }

        if (col.gameObject.tag == "Destruction_Object")
        {
            Destruction_Object tmp = col.gameObject.GetComponent<Destruction_Object>();

            // Playerが触れた時のみダメージを与える
            tmp.Life_Sub(damage, transform.root.tag);
        }
    }
}