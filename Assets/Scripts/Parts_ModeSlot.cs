using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_ModeSlot : MonoBehaviour
{
    private Transform parts_t;
    private Rigidbody parts_r;
    private Vector3   set_rot;
    private Vector3   set_scale;


    void Awake()
    {
        parts_t   = transform;
        parts_r   = GetComponent<Rigidbody>();
        set_rot.z = 90.0f;
        set_scale = new Vector3(0.05f, 0.35f, 0.35f);
    }


    public void Attach(Transform _target)
    {
        parts_t.parent        = _target;                    // 子階層化
        parts_t.localPosition = Vector3.zero;               // 基準値へ
        parts_t.localRotation = Quaternion.Euler(set_rot);  // 回転の調整
        parts_t.localScale    = set_scale;                  // 大きさの調整
        parts_r.isKinematic   = true;                       // 物理挙動の無効化
    }
}