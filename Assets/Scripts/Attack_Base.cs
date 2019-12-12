using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Base : MonoBehaviour
{
    [SerializeField] int damage;


    //-----------------
    // ダメージを返す
    //-----------------
    public int Get_Damage()
    {
        return damage;
    }
}