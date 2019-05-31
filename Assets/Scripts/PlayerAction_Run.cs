using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_Run : MonoBehaviour
{
    [SerializeField] float run_speed;
    [SerializeField] float run_friction;

    private float run_amount;
    private float arrange;


    void Start()
    {
        // 画面サイズ違いでの速度の差をなくす
        arrange = 1242.0f / Screen.width;
    }


    void FixedUpdate()
    {
        float speed = run_amount * run_speed * arrange;

        // アニメーション予定
        // anim

        // 移動
        transform.Translate(Vector3.forward * speed);

        // 摩擦で減速
        run_amount *= run_friction;
    }


    public float Get_Run_amount()
    {
        return run_amount;
    }


    //---------------------
    // ドラッグアクション
    //---------------------
    public void Drag(float _drag_amount)
    {
        run_amount = _drag_amount;
    }
}