using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow_Spawn : MonoBehaviour
{
    [SerializeField] Transform Core_Prefab;


    void Start()
    {
        Transform tmp = Instantiate(Core_Prefab);

        tmp.GetChild(0).parent = null;
    }
}