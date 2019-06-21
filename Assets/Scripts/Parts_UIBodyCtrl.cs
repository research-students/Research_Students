using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_UIBodyCtrl : MonoBehaviour
{
    //------------------------------
    // UIBody内のParts_Changerのみ
    //------------------------------
    void Update()
    {
        // 1フレームbody内が空になるのでスルー
        if (transform.childCount == 0)
        {
            return;
        }

        // Parts_ChangerのtagがUntaggedのままだったら
        if (transform.GetChild(0).tag == "Untagged")
        {
            // Parts_Changerのtagを対応するbodyのtagに戻す
            transform.GetChild(0).tag = tag;
        }
    }
}