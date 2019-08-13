using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ctrl : Character_Base
{
    [SerializeField] Transform[] bodys;
    [SerializeField] float       jump_power;
    [SerializeField] float       jump_max_height;

    private bool death;


    //-------
    // 走る
    //-------
    public override void Run(float amount)
    {
        if (death) return;

        base.Run(amount);
    }


    //-----------
    // ジャンプ
    //-----------
    public void Jump(float amount)
    {
        if (death) return;

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
        if (death) return;

        if (bodys[1].childCount == 0)
        {
            Debug.Log("キック");
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
        if (death) return;

        if (bodys[1].childCount == 0)
        {
            Debug.Log("強いキック");
        }
        else
        {
            bodys[1].GetChild(0).GetComponent<Parts_Base>().Action2(true, 0);
        }
    }


    //------------------------
    // アクション : フリック
    //------------------------
    public void Action_Flick(Vector3 dir)
    {
        if (death) return;

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
        return death;
    }


    //--------------------
    // Deathした時の処理
    //--------------------
    protected override void Death()
    {
        death = true;

        for (int i = 0; i < bodys.Length; i++)
        {
            if (bodys[i].childCount == 1)
            {
                bodys[i].GetChild(0).GetComponent<Parts_Base>().Drop();
            }
        }

        GameObject.Find("Player_Model").transform.Translate(Vector3.down * 0.5f);
        GameObject.Find("Player_Model").transform.Rotate(Vector3.left * 90f);
    }


    //-----------------
    // 攻撃を受けたら
    //-----------------
    private void OnCollisionEnter(Collision col)
    {
        if (death) return;

        if (col.gameObject.tag == "Enemy_Attack")
        {
            HP_Sub(col.gameObject.GetComponent<Attack>().Get_Damage());
        }
    }
}