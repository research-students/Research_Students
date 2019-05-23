using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Attacher : MonoBehaviour
{
    private Parts_Get_Empty get_empty;
    private Transform       target;


    void Start()
    {
        get_empty = GameObject.Find("Parts_SetTarget").GetComponent<Parts_Get_Empty>();
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            // 空のbodyを取得
            target = get_empty.Body(tag);

            if (target)
            {
                // パーツをModeBodyへ、そしてアタッチ
                gameObject.AddComponent<Parts_ModeBody>().Attach(target);

                return;
            }

            // 空のslotを取得
            target = get_empty.Slot();

            if (target)
            {
                // パーツをModeSlotへ、そしてアタッチ
                gameObject.AddComponent<Parts_ModeSlot>().Attach(target);
            }
        }
    }
}