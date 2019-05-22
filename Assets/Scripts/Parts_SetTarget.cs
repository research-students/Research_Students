using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_SetTarget : MonoBehaviour
{
    private bool empty;


    void Start()
    {
        empty = true;
    }


    public bool Empty()
    {
        return empty;
    }


    public void Attach()
    {
        empty = false;
    }
}