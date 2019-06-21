using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Changer : MonoBehaviour
{
    private Transform parent;
    private Transform child;


    void Update()
    {
        // 指を離したらパーツを入れ替える
        if (Input.GetMouseButtonUp(0))
        {
            if (parent == null)
            {
                return;
            }

            // slotとbodyのパーツの入れ替えなら
            if (gameObject.layer != parent.gameObject.layer)
            {
                // 同じタイプのパーツのみ入れ替える
                if (tag == child.tag)
                {
                    Change();
                }
                else
                {
                    // 片方が空なので入れ替える
                    if (child.tag == "Untagged" || transform.tag == "Untagged")
                    {
                        Change();
                    }
                }
            }
            // slot同士なら自由に入れ替える
            else
            {
                Change();
            }
        }
    }


    //-------------
    // 入れ替える
    //-------------
    private void Change()
    {
        // パーツを入れ替える
        transform.SetParent(parent);

        // 位置をセット
        transform.position = parent.position;

        // layerをセット(body同士の当たり判定を無視)
        gameObject.layer = parent.gameObject.layer;
    }


    //---------------------------------
    // 入れ替えるパーツの親と子を取得
    //---------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        parent = other.transform.parent;
        child  = other.transform;
    }


    //-------------------------
    // 入れ替えるパーツを破棄
    //-------------------------
    private void OnTriggerExit2D(Collider2D other)
    {
        parent = null;
        child  = null;
    }
}