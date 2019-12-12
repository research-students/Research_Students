using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Wing : Parts_Base
{
    [SerializeField] Vector3 force1;
    [SerializeField] Vector3 force2;


    //--------------
    // アクション1
    //--------------
    public override void Action1(bool life_sub, int adj)
    {
        base.Action1(life_sub, adj);

        Flight(force1, transform.root.GetComponent<Rigidbody>());
    }


    //--------------
    // アクション2
    //--------------
    public override void Action2(bool life_sub, int adj)
    {
        base.Action2(life_sub, adj);

        Vector3 force = force2;

        force.z *= transform.forward.z;

        Flight(force, transform.root.GetComponent<Rigidbody>());
    }


    //-------
    // 飛行
    //-------
    public void Flight(Vector3 force, Rigidbody rigid)
    {
        rigid.velocity = Vector3.zero;

        rigid.AddForce(force * (1242.0f / Screen.width), ForceMode.Impulse);
    }
}