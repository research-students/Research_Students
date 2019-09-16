﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Base : MonoBehaviour
{
    [SerializeField] Slider    hp_ui;
    [SerializeField] Transform model;
    [SerializeField] float     run_speed;
    [SerializeField] float     run_friction;
    [SerializeField] float     attack_power;
    [SerializeField] float     attack_power_strong;

    protected Rigidbody rigid;
    protected Vector3   movement;
    protected bool      landing;
    private   bool      invincible;
    private   float     speed;
    private   float     attack;


    void Awake()
    {
        rigid  = GetComponent<Rigidbody>();
        speed  = 1f;
        attack = 1f;
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
        movement.z = amount * speed;

        if (Mathf.Pow(amount, 2) > 0.01f)
        {
            Change_Direction(movement.z);
        }
    }


    //-----------
    // 通常攻撃
    //-----------
    public virtual void Attack()
    {
        Debug.Log("キック---攻撃力: " + (attack_power * attack));
    }


    //------------------
    // 通常攻撃 : 強化
    //------------------
    public virtual void Attack_Strong()
    {
        Debug.Log("強いキック---攻撃力: " + (attack_power_strong * attack));
    }


    //-------------------
    // スピードチェンジ
    //-------------------
    public void Speed_Change(float amount)
    {
        speed = amount;
    }


    //-----------------
    // 攻撃力チェンジ
    //-----------------
    public void Attack_Change(float amount)
    {
        attack = amount;
    }


    //-------------
    // HPを減らす
    //-------------
    public void HP_Sub(int damage)
    {
        if (invincible)
        {
            return;
        }

        hp_ui.value -= damage;

        if (hp_ui.value <= 0)
        {
            Death();
        }
    }


    //---------------------
    // 無敵状態の切り替え
    //---------------------
    public void Set_Invincible(bool flag)
    {
        invincible = flag;
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