using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Gun_Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int   damage;


    void Start()
    {
        tag = transform.root.tag + "_Attack";
    }


    void FixedUpdate()
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

        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
        {
            Character_Base tmp = col.gameObject.GetComponent<Character_Base>();

            if (tmp)
            {
                // ダメージを与える
                tmp.HP_Sub(damage);
            }
        }

        // 消滅
        Destroy(gameObject);
    }
}