using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Ctrl : MonoBehaviour
{
    [SerializeField] int kill_count_limit;

    private Collider col;
    private bool     clear;


    void Start()
    {
        col = GetComponent<Collider>();
    }


    //------------------------------------
    // Playerがゴールに触れたら : 解放前
    //------------------------------------
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            return;
        }
        if (this.col.isTrigger)
        {
            return;
        }

        if (GameObject.Find("Kill_Count").GetComponent<Kill_Count>().Kill_Num() >= kill_count_limit)
        {
            // ゴールを開放
            this.col.isTrigger = true;
        }
    }


    //------------------------------------
    // Playerがゴールに触れたら : 解放後
    //------------------------------------
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag != "Player")
        {
            return;
        }
        if (clear)
        {
            return;
        }

        if (GameObject.Find("Kill_Count").GetComponent<Kill_Count>().Kill_Num() >= kill_count_limit)
        {
            clear = true;

            // クリア演出
            GameObject.Find("Player").GetComponent<Player_Ctrl>().Clear();
        }
    }
}