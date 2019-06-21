using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_AttacherCtrl : MonoBehaviour
{
    private Parts_Image parts_image;
    private Transform   child;


    void Update()
    {
        // 子階層に変更があったら
        if (Detect_Differences())
        {
            if (child)
            {
                // すでにアタッチされていれば一旦デタッチ
                if (parts_image)
                {
                    parts_image.Detach_Player();
                }

                // Parts_Imageを取得 : 更新
                parts_image = child.GetComponent<Parts_Image>();

                // プレイヤーにパーツをアタッチ
                parts_image.Attach_Player();
            }
            else
            {
                // 空状態なら普通にデタッチ
                parts_image.Detach_Player();

                parts_image = null;
            }
        }
    }


    //---------------------------------
    // 子階層に変更があったか検出する
    //---------------------------------
    private bool Detect_Differences()
    {
        // 子を取得
        Transform in_get = transform.Find("Parts_Changer");

        if (in_get)
        {
            // まだ子があるか調べる
            if (in_get.childCount == 0)
            {
                in_get = null;
            }
            else
            {
                in_get = in_get.GetChild(0);
            }
        }
        else
        {
            in_get = null;
        }

        // 変更なし : スルー
        if (child == in_get)
        {
            return false;
        }
        // 変更あり : 子階層の変更を更新
        else
        {
            child = in_get;
        }

        return true;
    }
}