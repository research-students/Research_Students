using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_BodyMode : MonoBehaviour
{
    private Transform parts_t;
    private Rigidbody parts_r;


    void Awake()
    {
        parts_t = transform;
        parts_r = GetComponent<Rigidbody>();
    }


    public void Attach(Transform _target)
    {
        parts_t.parent        = _target;        // 子階層化
        parts_t.localPosition = Vector3.zero;   // 基準値へ        
        parts_r.isKinematic   = true;           // 物理挙動の無効化
    }
}