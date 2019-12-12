using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAction_Hand : MonoBehaviour
{
    [SerializeField] Enemy_Parts_Manager parts_manager;

    private Parts_Base parts;


    void Start()
    {
        if (transform.childCount > 0)
        {
            parts = transform.GetChild(0).GetComponent<Parts_Base>();
        }

        StartCoroutine(Action());
    }


    //-------------
    // アクション
    //-------------
    private IEnumerator Action()
    {
        while (true)
        {
            if (parts)
            {
                if (parts.Get_Parts_Type() == "Gun")
                {
                    yield return new WaitForSeconds(5f);

                    parts_manager.Action(1, Activation_Determination_Gun());
                }
                if (parts.Get_Parts_Type() == "Shield")
                {
                    yield return new WaitForSeconds(5f);

                    parts_manager.Action(1, Activation_Determination_Shield());
                }
            }
            else
            {
                yield return new WaitForSeconds(3f);

                Debug.Log(name + " : キック");
            }
        }
    }


    //---------------
    // 発動判定: 銃
    //---------------
    private int Activation_Determination_Gun()
    {
        return 1;
    }


    //---------------
    // 発動判定: 盾
    //---------------
    private int Activation_Determination_Shield()
    {
        return 0;
    }
}