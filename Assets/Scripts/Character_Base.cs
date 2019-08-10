using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Base : MonoBehaviour
{
    [SerializeField] Transform model;
    [SerializeField] Transform hand;
    [SerializeField] float     jump_power;
    [SerializeField] float     jump_max_height;
    [SerializeField] float     run_speed;
    [SerializeField] float     run_friction;

    private Rigidbody rigid;
    private Vector3   movement;
    private bool      landing;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        movement.y = rigid.velocity.y;

        rigid.velocity = movement * (1242.0f / Screen.width);

        if (landing)
        {
            movement.z *= run_friction;
        }
    }


    //-------
    // 走る
    //-------
    public void Run(float amount)
    {
        movement.z = amount * run_speed;

        Change_Direction(movement.z);
    }


    //-----------
    // ジャンプ
    //-----------
    public void Jump(float amount)
    {
        if (landing)
        {
            if (amount > jump_max_height)
            {
                amount = jump_max_height;
            }

            Vector3 force = Vector3.up * jump_power * amount;

            rigid.AddForce(force * (1242.0f / Screen.width), ForceMode.Impulse);
        }
    }


    //----------------------
    // アクション : タップ
    //----------------------
    public void Action_Tap()
    {
        if (hand.childCount == 0)
        {
            Debug.Log("キック");
        }
        else
        {
            hand.GetChild(0).GetComponent<Parts_Base>().Action1();
        }
    }


    //----------------------------
    // アクション : ロングタップ
    //----------------------------
    public void Action_LongTap()
    {
        if (hand.childCount == 0)
        {
            Debug.Log("強いキック");
        }
        else
        {
            hand.GetChild(0).GetComponent<Parts_Base>().Action2();
        }
    }


    //------------------------
    // アクション : フリック
    //------------------------
    public void Action_Flick(float dir)
    {
        Change_Direction(dir);
    }


    //---------------
    // 移動量を返す
    //---------------
    public float Get_Run_Amount()
    {
        return movement.z;
    }


    //-----------
    // 方向転換
    //-----------
    private void Change_Direction(float dir)
    {
        if (dir > 0f)
        {
            model.eulerAngles = Vector3.up * 0f;
        }
        else
        {
            model.eulerAngles = Vector3.up * 180f;
        }
    }


    //-------------------------
    // 足が地面に触れていたら
    //-------------------------
    private void OnTriggerStay(Collider other)
    {
        landing = true;
    }


    //-----------------------
    // 足が地面から離れたら
    //-----------------------
    private void OnTriggerExit(Collider other)
    {
        landing = false;
    }
}