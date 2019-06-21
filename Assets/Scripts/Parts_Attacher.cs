using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts_Attacher : MonoBehaviour
{
    [SerializeField] Parts_Image[] prefab;


    //----------------
    // アタッチ : UI
    //----------------
    public void Attach(string _parts_name, Transform _parts_changer)
    {
        for (int i = 0; i < prefab.Length; i++)
        {
            if (_parts_name == prefab[i].name)
            {
                // イメージを生成、アタッチ
                Instantiate(prefab[i]).Init(_parts_changer, transform);
            }
        }
    }
}