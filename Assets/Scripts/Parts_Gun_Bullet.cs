using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Gun_Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;


    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }


    //---------
    // 初期化
    //---------
    public void Init(Transform gun)
    {
        transform.position = gun.position;
        transform.rotation = gun.rotation;
    }


    //-------------------
    // ダメージを与える
    //-------------------
    public float Get_Damage()
    {
        return damage;
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