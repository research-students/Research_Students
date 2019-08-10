using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork_Ctrl : MonoBehaviour
{
    [SerializeField] Player_Ctrl player_ctrl;
    [SerializeField] float       work_wait;
    [SerializeField] float       work_friction;

    
    void FixedUpdate()
    {
        // playerの移動量取得
        float speed = player_ctrl.Get_Run_Amount();

        // カメラの追従
        transform.Translate(Vector3.left * speed * work_wait);

        // 減速
        transform.localPosition *= work_friction;
    }
}