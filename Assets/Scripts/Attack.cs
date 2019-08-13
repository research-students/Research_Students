using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int damage;


    void Start()
    {
        tag = transform.root.tag + "_Attack";
    }


    //-------------------
    // ダメージを与える
    //-------------------
    public int Get_Damage()
    {
        return damage;
    }
}