using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_SetManager : MonoBehaviour
{
    [SerializeField] Parts_Attacher[] parts_attacher;
    [SerializeField] RectTransform[]  body_UI;
    [SerializeField] RectTransform[]  slot_UI;
    [SerializeField] Data_Manager     data_manager;
    [SerializeField] string[]         type;


    void Start()
    {
        // パーツのセーブデータを読み込む
        string[] bp_names = data_manager.Load_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.NAME);
        string[] bp_lifes = data_manager.Load_Parts(Data_Manager.CATEGORY.BP, Data_Manager.STATE.LIFE);
        string[] sp_names = data_manager.Load_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.NAME);
        string[] sp_lifes = data_manager.Load_Parts(Data_Manager.CATEGORY.SP, Data_Manager.STATE.LIFE);

        // パーツをアタッチ
        Attach_Parts(body_UI, bp_names, bp_lifes);
        Attach_Parts(slot_UI, sp_names, sp_lifes);
    }


    //-------------------
    // パーツをアタッチ
    //-------------------
    public void Attach_Parts(RectTransform[] rect, string[] names, string[] lifes)
    {
        for (int i = 0; i < rect.Length; i++)
        {
            if (names[i] == "___")
            {
                continue;
            }

            // アタッチ
            parts_attacher[i].Attach(names[i], rect[i].GetChild(0), int.Parse(lifes[i]));
        }
    }


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