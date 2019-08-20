using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Ctrl : MonoBehaviour
{
    [SerializeField] Player_Ctrl player_ctrl;
    [SerializeField] GameObject  clear_ui;
    [SerializeField] Kill_Count  kill_count;
    [SerializeField] int         kill_count_limit;

    private Collider col;


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

        if (kill_count.Kill_Num() >= kill_count_limit)
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
        if (clear_ui.activeSelf)
        {
            return;
        }

        if (kill_count.Kill_Num() >= kill_count_limit)
        {
            // クリア : 仮演出
            player_ctrl.Clear();

            // クリア : 仮演出
            clear_ui.SetActive(true);
        }
    }
}