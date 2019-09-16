using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Parts_Manager : MonoBehaviour
{
    [SerializeField] Transform[] bodys;
    [SerializeField] string[]    type;

    private Parts_Base[] parts = new Parts_Base[4];


    void Start()
    {
        for (int i = 0; i < bodys.Length; i++)
        {
            if (bodys[i].childCount == 1)
            {
                parts[i] = bodys[i].GetChild(0).GetComponent<Parts_Base>();

                parts[i].Attach(bodys[i]);
            }
        }
    }


    //-----------------------
    // パーツを装備中か返す
    //-----------------------
    public bool Get_Equipping(int i)
    {
        if (parts[i])
        {
            return true;
        }

        return false;
    }


    //-------------------------------
    // パーツのアクションを実行する
    //-------------------------------
    public void Action(int i, int action_num)
    {
        if (action_num == 1)
        {
            parts[i].Action1(false, 0);
        }
        if (action_num == 2)
        {
            parts[i].Action2(false, 0);
        }
    }


    //-----------------------
    // パーツに触れていたら
    //-----------------------
    private void OnTriggerStay(Collider col)
    {
        for (int i = 0; i < type.Length; i++)
        {
            if (col.tag != type[i])
            {
                continue;
            }
            if (bodys[i].childCount != 0)
            {
                return;
            }
            if (col.transform.parent.parent)
            {
                return;
            }

            // パーツを取得
            parts[i] = col.transform.parent.GetComponent<Parts_Base>();

            // Enemyが取得出来るパーツか
            if (parts[i].Get_Enemy_Can_Take())
            {
                // アタッチ
                parts[i].Attach(bodys[i]);
            }
        }
    }
}