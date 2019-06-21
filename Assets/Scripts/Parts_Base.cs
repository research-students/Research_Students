using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Base : MonoBehaviour
{
    [SerializeField] int life;


    //-----------
    // アタッチ
    //-----------
    public void Attach(Transform _body)
    {
        transform.parent   = _body;
        transform.position = _body.position;
        transform.rotation = _body.rotation;

        GetComponent<Rigidbody>().isKinematic = true;

        // プレイヤーとの衝突判定を無効化
        gameObject.layer = LayerMask.NameToLayer("Player");
    }


    //-------------
    // アクション
    //-------------
    public void Action()
    {
        life--;
    }
}