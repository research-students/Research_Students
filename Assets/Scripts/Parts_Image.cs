using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parts_Image : MonoBehaviour
{
    [SerializeField] Parts_Base prefab;
    [SerializeField] Slider     life_ui;

    private Parts_Base parts_base;
    private Transform  body;


    //-----------
    // 初期設定
    //-----------
    public void Init(Transform parts_changer, Transform body)
    {
        transform.SetParent(parts_changer);

        transform.position = parts_changer.position;

        parts_changer.tag = tag;

        this.body = body;
    }


    //-----------------
    // ライフを減らす
    //-----------------
    public void Life_Sub(int damage)
    {
        life_ui.value -= damage;

        if (life_ui.value <= 0)
        {
            Delete();
        }
    }


    //-------------------------
    // Bodyにパーツをアタッチ
    //-------------------------
    public void Attach_Body()
    {
        // パーツを生成
        parts_base = Instantiate(prefab);

        // Bodyにアタッチ
        parts_base.Attach(body, this);
    }


    //---------------------------
    // Bodyからパーツをデタッチ
    //---------------------------
    public void Detach_Body()
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
        Detach_Body();

        // 破棄
        Destroy(gameObject);
    }
}