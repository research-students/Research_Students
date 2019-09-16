using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] bool not_init;
    [SerializeField] int  damage;


    void Start()
    {
        if (not_init == false)
        {
            tag = transform.root.tag + "_Attack";
        }
    }


    //-------------------
    // ダメージを与える
    //-------------------
    public int Get_Damage()
    {
        return damage;
    }
}