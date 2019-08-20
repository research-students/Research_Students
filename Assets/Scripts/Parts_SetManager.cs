using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_SetManager : MonoBehaviour
{
    [SerializeField] Parts_Attacher[] parts_attacher;
    [SerializeField] RectTransform[]  body_UI;
    [SerializeField] RectTransform[]  slot_UI;
    [SerializeField] string[]         type;


    //--------------------------------
    // 対象のbody_UIが空ならアタッチ
    //--------------------------------
    private bool Attach_UI_Body(int i, Parts_Base parts)
    {
        if (body_UI[i].GetChild(0).childCount == 0)
        {
            // イメージのみアタッチ
            parts_attacher[i].Attach(parts.name, body_UI[i].GetChild(0));

            // パーツは一旦削除
            Destroy(parts.gameObject);

            return true;
        }

        return false;
    }



    //------------------------------------
    // 空のslot_UIを探してあればアタッチ
    //------------------------------------
    private void Attach_UI_Slot(int i, Parts_Base parts)
    {
        for (int j = 0; j < slot_UI.Length; j++)
        {
            if (slot_UI[j].GetChild(0).childCount == 0)
            {
                // イメージのみアタッチ
                parts_attacher[i].Attach(parts.name, slot_UI[j].GetChild(0));
                
                // パーツは一旦削除
                Destroy(parts.gameObject);

                return;
            }
        }
    }


    //-------------------
    // パーツに触れたら
    //-------------------
    private void OnTriggerStay(Collider col)
    {
        for (int i = 0; i < type.Length; i++)
        {
            if (col.tag != type[i])
            {
                continue;
            }
            if (col.transform.parent.parent)
            {
                return;
            }
            if (Attach_UI_Body(i, col.transform.parent.GetComponent<Parts_Base>()))
            {
                return;
            }
            else
            {
                Attach_UI_Slot(i, col.transform.parent.GetComponent<Parts_Base>());
            }
        }
    }
}