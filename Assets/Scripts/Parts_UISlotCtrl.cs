using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_UISlotCtrl : MonoBehaviour
{
    //------------------------------
    // UISlot内のParts_Changerのみ
    //------------------------------
    void Update()
    {
        // 1フレームSlot内が空になるのでスルー
        if (transform.childCount == 0)
        {
            return;
        }

        // Parts_Changerの中身が空だったら
        if (transform.GetChild(0).childCount == 0)
        {
            // Parts_ChangerのtagをUntaggedに戻す
            transform.GetChild(0).tag = "Untagged";
        }
    }
}