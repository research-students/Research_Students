using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Image : MonoBehaviour
{
    [SerializeField] Parts_Base prefab;

    private Parts_Base parts_base;
    private Transform  body;


    //-----------
    // 初期設定
    //-----------
    public void Init(Transform _parts_changer, Transform _body)
    {
        transform.SetParent(_parts_changer);

        transform.position = _parts_changer.position;

        _parts_changer.tag = tag;

        body = _body;
    }


    //-------------------------------
    // プレイヤーにパーツをアタッチ
    //-------------------------------
    public void Attach_Player()
    {
        // パーツを生成
        parts_base = Instantiate(prefab);

        // プレイヤーにアタッチ
        parts_base.Attach(body);
    }


    //---------------------------------
    // プレイヤーからパーツをデタッチ
    //---------------------------------
    public void Detach_Player()
    {
        if (parts_base)
        {
            // パーツを削除
            Destroy(parts_base.gameObject);
        }
    }


    //--------------------
    // Parts_Imageの破棄
    //--------------------
    public void Delete()
    {
        // デタッチもする
        Detach_Player();

        // 破棄
        Destroy(gameObject);
    }
}