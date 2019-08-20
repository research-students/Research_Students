using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kill_Count : MonoBehaviour
{
    [SerializeField] Image image_num1;
    [SerializeField] Image image_num2;

    private float num1;
    private float num2;
    private int   count;


    void Start()
    {
        Scroll();
    }


    //-----------------------
    // KILL数をカウントする
    //-----------------------
    public void Kill_Counter()
    {
        if (count >= 99)
        {
            return;
        }

        num1 += 0.1f;

        if (num1 >= 1.0f)
        {
            num1  = 0.0f;
            num2 += 0.1f;
        }

        count++;

        Scroll();
    }


    //-----------------
    // スクロールする
    //-----------------
    private void Scroll()
    {
        image_num1.material.SetTextureOffset("_MainTex", Vector2.right * num1);
        image_num2.material.SetTextureOffset("_MainTex", Vector2.right * num2);
    }


    //---------------
    // KILL数を返す
    //---------------
    public int Kill_Num()
    {
        return count;
    }
}