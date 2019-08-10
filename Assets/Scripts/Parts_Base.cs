using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parts_Base : MonoBehaviour
{
    [SerializeField] int life_sub1;
    [SerializeField] int life_sub2;

    private Parts_Image parts_image;


    //-----------
    // アタッチ
    //-----------
    public void Attach(Transform body, Parts_Image parts_image)
    {
        transform.parent   = body;
        transform.position = body.position;
        transform.rotation = body.rotation;

        GetComponent<Rigidbody>().isKinematic = true;

        // 保持グループとの衝突判定を無効化
        gameObject.layer = body.gameObject.layer;

        // parts_imageを取得
        this.parts_image = parts_image;
    }


    //--------------
    // アクション1
    //--------------
    public virtual void Action1()
    {
        parts_image.Life_Sub(life_sub1);
    }


    //--------------
    // アクション2
    //--------------
    public virtual void Action2()
    {
        parts_image.Life_Sub(life_sub2);
    }
}