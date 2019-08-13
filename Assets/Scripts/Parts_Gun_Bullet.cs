using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Gun_Bullet : Attack
{
    [SerializeField] float speed;


    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }


    //---------
    // 初期化
    //---------
    public void Init(Transform gun)
    {
        tag                = gun.tag;
        transform.position = gun.position;
        transform.rotation = gun.rotation;
        gameObject.layer   = gun.gameObject.layer;
    }


    //---------------------
    // 銃以外と衝突したら
    //---------------------
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Parts_Gun"))
        {
            return;
        }

        // 消滅
        Destroy(gameObject);
    }
}