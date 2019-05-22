using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Attacher : MonoBehaviour
{
    private Parts_SearchEmpty empty;
    private Transform         target;


    void Start()
    {
        empty = GameObject.Find("Parts_Target").GetComponent<Parts_SearchEmpty>();
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            // 空のbodyを取得
            target = empty.GetEmpty_Body(tag);

            if (target)
            {
                // パーツをBodyModeへ、そしてアタッチ
                gameObject.AddComponent<Parts_BodyMode>().Attach(target);

                return;
            }

            // 空のslotを取得
            target = empty.GetEmpty_Slot();

            if (target)
            {
                // パーツをSlotModeへ、そしてアタッチ
                gameObject.AddComponent<Parts_SlotMode>().Attach(target);
            }
        }
    }
}