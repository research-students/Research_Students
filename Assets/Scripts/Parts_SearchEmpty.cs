using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_SearchEmpty : MonoBehaviour
{
    [SerializeField] Parts_SetTarget[] body;
    [SerializeField] Parts_SetTarget[] slot;


    //-------------------------------
    // 空のbodyを探して、あれば返す
    //-------------------------------
    public Transform GetEmpty_Body(string _type)
    {
        for (int i = 0; i < body.Length; i++)
        {
            if (body[i].tag == _type)
            {
                if (body[i].Empty())
                {
                    body[i].Attach();

                    return body[i].transform;
                }
            }
        }

        return null;
    }


    //-------------------------------
    // 空のslotを探して、あれば返す
    //-------------------------------
    public Transform GetEmpty_Slot()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].Empty())
            {
                slot[i].Attach();

                return slot[i].transform;
            }
        }

        return null;
    }
}