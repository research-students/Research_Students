using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Get_Empty : MonoBehaviour
{
    [SerializeField] Transform[] body;
    [SerializeField] Transform[] slot;

    private const int empty = 0;


    //-------------------------------
    // 空のbodyを探して、あれば返す
    //-------------------------------
    public Transform Body(string _type)
    {
        for (int i = 0; i < body.Length; i++)
        {
            if (body[i].tag == _type)
            {
                if (body[i].childCount == empty)
                {
                    return body[i];
                }
            }
        }

        return null;
    }


    //-------------------------------
    // 空のslotを探して、あれば返す
    //-------------------------------
    public Transform Slot()
    {
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].childCount == empty)
            {
                return slot[i];
            }
        }

        return null;
    }
}