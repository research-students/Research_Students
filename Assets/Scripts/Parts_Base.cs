using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Base : MonoBehaviour
{
    [SerializeField] string type;
    [SerializeField] float  impulse;
    [SerializeField] int    life_sub1;
    [SerializeField] int    life_sub2;

    private Parts_Image parts_image;


    //---------------------
    // アタッチ : Enemy用
    //---------------------
    public void Attach(Transform body)
    {
        transform.parent   = body;
        transform.position = body.position;
        transform.rotation = body.rotation;

        GetComponent<Rigidbody>().isKinematic = true;

        // グループを有効化
        gameObject.tag   = body.root.tag;
        gameObject.layer = body.gameObject.layer + 1;
    }


    //----------------------
    // アタッチ : Player用
    //----------------------
    public void Attach(Transform body, Parts_Image parts_image)
    {
        Attach(body);

        // parts_imageを取得
        this.parts_image = parts_image;
    }


    //-----------
    // ドロップ
    //-----------
    public void Drop()
    {
        transform.parent = null;

        GetComponent<Rigidbody>().isKinematic = false;

        // 飛ばす方向をセット
        Vector3 fly_vec = Vector3.up + (Vector3.forward * Random.Range(-1f, 1f));
        
        // 飛ばす
        GetComponent<Rigidbody>().AddForce(fly_vec * impulse, ForceMode.Impulse);

        // グループを無効化
        gameObject.tag   = type;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }


    //--------------
    // アクション1
    //--------------
    public virtual void Action1(bool life_sub, int adj)
    {
        if (life_sub)
        {
            parts_image.Life_Sub(life_sub1 + adj);
        }
    }


    //--------------
    // アクション2
    //--------------
    public virtual void Action2(bool life_sub, int adj)
    {
        if (life_sub)
        {
            parts_image.Life_Sub(life_sub2 + adj);
        }
    }
}