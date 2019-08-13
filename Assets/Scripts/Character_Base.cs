using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Base : MonoBehaviour
{
    [SerializeField] Slider    hp_ui;
    [SerializeField] Transform model;
    [SerializeField] float     run_speed;
    [SerializeField] float     run_friction;

    protected Rigidbody rigid;
    protected Vector3   movement;
    protected bool      landing;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        movement.y = rigid.velocity.y;

        if (landing) 
        {
            rigid.AddForce(Vector3.forward * movement.z * run_speed);

            rigid.velocity *= run_friction;
        }

        movement.z *= run_friction;
    }


    //-------
    // 走る
    //-------
    public virtual void Run(float amount)
    {
        movement.z = amount;

        if (Mathf.Pow(amount, 2) > 0.01f)
        {
            Change_Direction(movement.z);
        }
    }


    //-------------
    // HPを減らす
    //-------------
    protected void HP_Sub(int damage)
    {
        hp_ui.value -= damage;

        if (hp_ui.value <= 0)
        {
            Death();
        }
    }


    //--------------------
    // Deathした時の処理
    //--------------------
    protected virtual void Death()
    {

    }


    //---------------
    // 移動量を返す
    //---------------
    public float Get_Run_Amount()
    {
        return movement.z;
    }


    //-----------------
    // 接地状態を返す
    //-----------------
    public bool Get_Landing()
    {
        return landing;
    }


    //-----------
    // 方向転換
    //-----------
    protected void Change_Direction(float dir)
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